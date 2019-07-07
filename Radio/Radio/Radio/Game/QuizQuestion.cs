using Newtonsoft.Json;
using System.Collections.Generic;

namespace Radio
{
	public class QuizQuestion
	{
		public string Question { get; set; }

        public List<string> Answers { get; set; }

        public int CorrectAnswer { get; set; }

        public string Explanation { get; set; }

        public string Keyword { get; set; }


        public int Lesson { get; set; } //don't really need to store this but it's in the question data
        public int Section { get; set; }
        public int Index { get; set; }
   
		
        public QuizQuestion ()
        {
            Answers = new List<string>();
        }
	}

    public class Lesson
    {
        public string Title { get; set; }
        public int ID { get; set; }

        [JsonIgnore]
        public int NumberOfQuestions { get { return Questions.Count; } }

       // [JsonProperty("Elements")]
        public List<QuizQuestion> Questions { get; set; }

        public Lesson ()
        {
            Questions = new List<QuizQuestion>();
        }
    }
}