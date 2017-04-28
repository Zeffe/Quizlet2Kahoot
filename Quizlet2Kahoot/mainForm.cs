using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Citadel;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Specialized;
using CustomToolTip;
using Newtonsoft.Json.Linq;

namespace Quizlet2Kahoot
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }


        List<Quizlet.QuizletTerm> terms = new List<Quizlet.QuizletTerm>();
        Random rng = new Random();
        bool loggedIn = false; bool scraped = false;
        bool adding = false;
        string authToken;
        Kahoot.KahootQuiz quiz = new Kahoot.KahootQuiz();
        public static string imageData;
        Quizlet.QuizletQuiz quizData;
        string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        CustomizedToolTip quizletToolTip = new CustomizedToolTip();
        string uuid = "";


        #region Get Quizlet Data
        void getData(string ID)
        {
            string temp = "";
            string url2 = "https://api.quizlet.com/2.0/sets/" + ID + "?client_id=FtKq7eDyBA&whitespace=0";
            using (WebClient client = new WebClient())
            {

                temp = client.DownloadString(url2); // USE JSON.NET TO PARSE DATA http://www.w3schools.com/js/js_json_syntax.asp
                quizData = JsonConvert.DeserializeObject<Quizlet.QuizletQuiz>(temp); // http://www.newtonsoft.com/json/help/html/DeserializeDataSet.htm 
                terms = quizData.terms.ToList<Quizlet.QuizletTerm>();
                txtTitle2.Text = quizData.title;               
            }

            scraped = true;           
        }
        #endregion


        private void thirteenCheckBox1_CheckedChanged(object sender)
        {
            txtPass.UseSystemPasswordChar = !chkViewPass.Checked;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            msgbox msg = new msgbox("Are you sure you want to exit the program?", "Are You Sure?", 2);
            if (msg.ShowDialog() == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        Kahoot.KahootAnswer toAnswer(string term, bool correct)
        {
            Kahoot.KahootAnswer temp = new Kahoot.KahootAnswer();
            temp.answer = term;
            temp.correct = correct;
            return temp;
        }     

        public void postJson(string url, string json)
        {
            string response;
            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                if (adding)
                {
                    client.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate, br";
                    client.Headers[HttpRequestHeader.Accept] = "text/javascript, text/html, application/xml, text/xml, */*";
                    client.Headers[HttpRequestHeader.Cookie] = "_gat=1; __uvt=; uvts=5BnogGIPeb8ggJ3w; _ga=GA1.2.1267276510.1477079311; amplitude_idkahoot.it=eyJkZXZpY2VJZCI6IjY4NmQ5ZjBmLTk4Y2MtNGJjMS04ZGRhLWI4MzU4MzNhZGY1MVIiLCJ1c2VySWQiOiI0YmFlNmExZS00ZmVlLTQyNDctYTdmYS1jNWI0NDA3NjczOGEiLCJvcHRPdXQiOmZhbHNlLCJzZXNzaW9uSWQiOjE0NzcwNzkzMTgzNDYsImxhc3RFdmVudFRpbWUiOjE0NzcwNzkzNTg1NzcsImV2ZW50SWQiOjcsImlkZW50aWZ5SWQiOjQsInNlcXVlbmNlTnVtYmVyIjoxMX0=";
                    client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + authToken);
                    client.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 5.01; Windows NT 5.0)");
                    adding = false;
                }

                response = client.UploadString(url, json);

                if (response.Contains("\"uuid\""))
                {
                    JObject obj = JObject.Parse(response);
                    uuid = (string)obj["uuid"];
                }

                if (response.Contains("access_token"))
                {
                    authToken = response.Split(':')[1].Split('"')[1];
                }
            }
        }

        Kahoot.KahootAnswer[] genChoices (int index)
        {
            Kahoot.KahootAnswer[] choices = new Kahoot.KahootAnswer[4];

            choices[0] = toAnswer(terms[index].term, true);

            List<int> used = new List<int>();
            used.Add(index);
            for (int j = 1; j < 4; j++)
            {
                int randAns;
                do
                {
                    randAns = rng.Next(terms.Count);
                } while (used.Contains(randAns));
                choices[j] = toAnswer(terms[randAns].term, false);
            }
            used.Clear();

            return choices;
        }

        public string imagePath(string url)
        {
            string quizletPath = Path.Combine(appData, "quizlet2kahoot");
            if (!Directory.Exists(quizletPath))
            {
                Directory.CreateDirectory(quizletPath);
            }
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(url), Path.Combine(quizletPath, "image.jpg"));
            }
            return Path.Combine(quizletPath, "image.jpg");
        }
     
        private void btnCreate_Click(object sender, EventArgs e)
        { 
            try
            {
                List<Kahoot.KahootQuestion> tempQuestions = new List<Kahoot.KahootQuestion>();
                quiz.title = txtTitle2.Text;
                quiz.description = "Automatically generated by Quizlet2Kahoot.";
                for (int i = 0; i < terms.Count; i++)
                {
                    tempQuestions.Add(new Kahoot.KahootQuestion());
                    tempQuestions[i].time = Convert.ToInt32(Math.Round(Convert.ToDouble(cmbTime.Text) / 5.0) * 5) * 1000;
                    tempQuestions[i].choices = genChoices(i);
                    tempQuestions[i].randomizeChoices();
                    if (terms[i].image != null && chkImages.Checked)
                    {
                        string tempImagePath = imagePath(terms[i].image.url);
                        NameValueCollection nvc = new NameValueCollection();
                        nvc.Add("id", "TTR");
                        nvc.Add("btn-submit-photo", "Upload");
                        Kahoot.HttpUploadFile("https://create.kahoot.it/media-api/media/upload?_=1478185770520", tempImagePath, "f", "image/jpeg", nvc);
                        Kahoot.KahootMediaAPI imageData2 = JsonConvert.DeserializeObject<Kahoot.KahootMediaAPI>(imageData);
                        tempQuestions[i].image = "https://media.kahoot.it/" + imageData2.id + "_opt";
                    }
                    else
                    {
                        tempQuestions[i].image = "";
                    }
                    tempQuestions[i].question = terms[i].definition;
                }
                quiz.questions = tempQuestions.ToArray();
                string json = JsonConvert.SerializeObject(quiz);
                adding = true;
                postJson("https://create.kahoot.it/rest/kahoots", json);
                msgbox msg = new msgbox("Successfully created kahoot.", "Success", 1);
                msg.Show();
                txtLink.Text = "https://create.kahoot.it/#quiz/" + uuid;
                txtLink2.Text = "https://play.kahoot.it/#/?quizId=" + uuid;
                quiz = new Kahoot.KahootQuiz();
                quizData = new Quizlet.QuizletQuiz();
                listQuestions.Items.Clear();
                scraped = false;
                txtTitle2.Clear();
                btnCreate.Enabled = false;
            } catch
            {
                msgbox msg = new msgbox("Error creating kahoot, try changing the time or editing the questions on the previous tab.", "Error", 1);
                msg.Show();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text != "" && txtPass.Text != "")
            {
                Kahoot.KahootUser user = new Kahoot.KahootUser();
                user.username = txtUser.Text;
                user.password = txtPass.Text;
                try
                {
                    string json = JsonConvert.SerializeObject(user);
                    postJson("https://create.kahoot.it/rest/authenticate", json);
                    txtLoggedIn.Text = txtUser.Text;
                    btnLogin.Enabled = false;
                    txtAuth.Text = authToken;
                    loggedIn = true;
                    msgbox msg = new msgbox("Successfully logged in as " + txtUser.Text + ".", "Success", 1);
                    msg.Show();
                    btnCreate.Enabled = scraped;
                } catch
                {
                    msgbox msg = new msgbox("Error logging in, please ensure that username and password are correct.", "Error", 1);
                    msg.Show();
                }
            }
            else
            {
                msgbox msg = new msgbox("Please ensure both username and password are filled out.", "Error", 1);
                msg.Show();
            }
        }

        

        private void btnScrape_Click(object sender, EventArgs e)
        {
            getData(txtID.Text);
            updateList();
            btnCreate.Enabled = loggedIn;
        }

        void updateList()
        {
            listQuestions.Items.Clear();
            int count = 1;
            foreach (Quizlet.QuizletTerm term in terms)
            {
                listQuestions.Items.Add(count.ToString() + ". " + term.definition);
                count++;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            List<int> toRemove = new List<int>();

            foreach (int i in listQuestions.SelectedIndices)
            {
                toRemove.Add(i);               
            }

            toRemove.Reverse();

            foreach (int i in toRemove)
            {
                terms.RemoveAt(i);
                listQuestions.Items.RemoveAt(i);
            }
            updateList();
        }

        private void btnFlip_Click(object sender, EventArgs e)
        {
            foreach (int i in listQuestions.SelectedIndices)
            {
                terms[i].flip();
            }
            updateList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbTime.SelectedIndex = 1;
            ttQuizlet.SetToolTip(pbInfo2, "a");
            pbInfo2.Tag = Properties.Resources.quizlet;
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (listQuestions.SelectedIndex != -1)
            {
                msgbox msg = new msgbox("Question: " + terms[listQuestions.SelectedIndex].definition + "\n\nAnswer: " + terms[listQuestions.SelectedIndex].term, "Question " + (listQuestions.SelectedIndex + 1).ToString(), 1);
                msg.Show();
            }
        }

        private void btnCopy1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtLink.Text);
            msgbox msg = new msgbox("Copied to clipboard!", "Copied", 1);
            msg.Show();
        }

        private void btnCopy2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtLink2.Text);
            msgbox msg = new msgbox("Copied to clipboard!", "Copied", 1);
            msg.Show();
        }
    }
}
