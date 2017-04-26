using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizlet2Kahoot
{
    class Kahoot
    {
        public class KahootVideo
        {
            public string fullUrl = "";
            public string service = "youtube";
            public int startTime = 0;
            public int endTime = 0;
            public string id = "";
        }

        public static void HttpUploadFile(string url, string file, string paramName, string contentType, NameValueCollection nvc)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

            Stream rs = wr.GetRequestStream();

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in nvc.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, file, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                mainForm.imageData = reader2.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }
        }

        public class KahootVariation
        {
            public string contentType { get; set; }
            public string uri { get; set; }
            public int contentLength { get; set; }
            public string label { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }
        public class KahootMediaAPI
        {
            public string contentType { get; set; }
            public string uri { get; set; }
            public int contentLength { get; set; }
            public string id { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public KahootVariation[] variations { get; set; }

        }
        public class KahootAnswer
        {
            public string answer { get; set; }
            public bool correct { get; set; }
        }
        public class KahootQuestion
        {
            Random rng = new Random(Guid.NewGuid().GetHashCode());

            public bool points = true;
            public string resources = "";
            public int time { get; set; }
            public KahootAnswer[] choices { get; set; }
            public string type = "quiz";
            public KahootVideo video = new KahootVideo();
            public string image { get; set; }
            public int questionFormat = 0;
            public string question { get; set; }
            public int numberOfAnswers = 4;           

            public void randomizeChoices()
            {
                choices = choices.OrderBy(x => rng.Next()).ToArray();
            }
        }

        public class KahootUser
        {
            public string username { get; set; }
            public string password { get; set; }
            public string grant_type = "password";
        }

        public class KahootQuiz
        {          
            public string audience = "School";
            public string resources = "";
            public string created = null;
            public string introVideo = "";
            public int visibility = 1;
            public string title { get; set; }
            public string language = "English";
            public string uuid = null;
            public string description { get; set; }
            public KahootQuestion[] questions { get; set; }
            public string quizType = "quiz";
            public string type = "quiz";
        }
    }
}
