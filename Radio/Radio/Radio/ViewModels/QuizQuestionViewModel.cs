using System.Collections.Generic;

namespace Radio
{
	public class QuizQuestionViewModel
	{
		public string Question { get { return quizQuestion.Question; } }

        public List<string> Answers { get { return quizQuestion.Answers; } }

		public int Answer { get { return quizQuestion.CorrectAnswer; } }
		public string Explanation { get { return quizQuestion.Explanation; } }

        public string CorrectAnswer { get { return Answers[Answer]; } }

		public int? Response { get; private set; }

		public bool IsCorrect { get { return quizQuestion.CorrectAnswer == Response; } }

		QuizQuestion quizQuestion;

		public QuizQuestionViewModel (QuizQuestion quizQuestion, int? response)
		{
			this.Response = response;
			this.quizQuestion = quizQuestion;
		}
	}
}