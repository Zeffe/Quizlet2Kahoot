using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet2Kahoot
{
    class Quizlet
    {
        public class QuizletImage
        {
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }
        public class QuizletTerm
        {
            public string id { get; set; }
            public string term { get; set; }
            public string definition { get; set; }
            public QuizletImage image { get; set; }
            public int rank { get; set; }

            public void flip()
            {
                string temp = definition;
                definition = term;
                term = temp;
            }
        }

        public class QuizletCreator
        {
            public string username { get; set; }
            public string account_type { get; set; }
            public string profile_image { get; set; }
            public int id { get; set; }
        }
        public class QuizletQuiz
        {
            public string id { get; set; }
            public string url { get; set; }
            public string title { get; set; }
            public string created_by { get; set; }
            public int term_count { get; set; }
            public int created_date { get; set; }
            public int modified_date { get; set; }
            public int published_date { get; set; }
            public bool has_images { get; set; }
            public string[] subjects { get; set; }
            public string visibility { get; set; }
            public string editable { get; set; }
            public bool has_access { get; set; }
            public bool can_edit { get; set; }
            public string description { get; set; }
            public string lang_terms { get; set; }
            public string lang_definitions { get; set; }
            public int password_use { get; set; }
            public int password_edit { get; set; }
            public int access_type { get; set; }
            public int creator_id { get; set; }
            public QuizletCreator creator { get; set; }
            public int[] class_ids { get; set; }
            public QuizletTerm[] terms { get; set; }
        }
    }
}
