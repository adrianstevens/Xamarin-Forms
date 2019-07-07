using System.Collections.Generic;

namespace Radio
{
    public class ReviewPageViewModel
    {
        public List<QuizQuestionViewModel> QuestionViewModels { get; set; }

		Game game;

		public string Result
		{
			get { return $"{game.GetNumberOfCorrectResponses()} out of {game.NumberOfQuestions} ({(int)(game.GetNumberOfCorrectResponses() * 100 / game.NumberOfQuestions)}%)"; }
		}

        public ReviewPageViewModel (Game game)
        {
			this.game = game;
            QuestionViewModels = new List<QuizQuestionViewModel>();

            for (int i = 0; i < game.NumberOfQuestions; i++)
            {
                QuestionViewModels.Add(new QuizQuestionViewModel(game.Questions[i], game.Responses[i]));
            }
        }
    }
}