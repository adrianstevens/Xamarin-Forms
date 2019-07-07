using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace Radio
{
    public class QuestionPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Command NextSelected { get; set; }
        public Command BackSelected { get; set; }

        public List<Command> AnswerSelected { get; set; }

        public string PageTitle { get { return $"xHam: Question {game.QuestionIndex + 1} of {game.NumberOfQuestions}"; } }

        public string Question { get { return game.CurrentQuestion.Question; } }

        public string Explanation { get { return game.CurrentQuestion.Explanation; } }

		public string Timer { get; private set; }

		DateTime timerStart;

		public bool ShowTimer
		{
			get
			{
				if (game.GameMode == GameMode.AdvancedPractice || game.GameMode == GameMode.BasicPractice)
				{
					if (isTimerRunning == false)
					{
						isTimerRunning = true;
						timerStart = DateTime.Now;
						Device.StartTimer(new TimeSpan(0, 0, 1), OnTimer);
					}
					return true;
				}
				isTimerRunning = false;
				return false;
			}
		}

        public bool AreAnswersEnabled { get { return game.CurrentResponse != game.CurrentQuestion.CorrectAnswer; } }

        public bool ShowExplanation { get { return game.CurrentResponse == game.CurrentQuestion.CorrectAnswer; } }

        public int CorrectAnswerIndex { get { return game.CurrentQuestion.CorrectAnswer; } }

        public List<string> Answers { get { return game.CurrentQuestion.Answers; } }

        public string Response
        {
            get
            {
                if (game.CurrentResponse == null)
                    return string.Empty;

                if (game.CurrentResponse == game.CurrentQuestion.CorrectAnswer)
                    return $"Correct: {game.CurrentQuestion.Answers[game.CurrentQuestion.CorrectAnswer]}";
                return "Incorrect";
            }
        }
      
        Game game;

		bool isTimerRunning = false;

        public QuestionPageViewModel (Game game)
        {
            this.game = game;

            //hard code for now
            AnswerSelected = new List<Command>();

            for (int i = 0; i < 4; i++)
            {
                int j = i;
                var cmd = new Command(() => OnAnswer(j));
                AnswerSelected.Add(cmd);
            }

            NextSelected = new Command(OnNext, OnCanExecuteNext);

            BackSelected = new Command(OnPrevious, () => { return game.QuestionIndex == 0 ? false : true; });

            game.Restart();

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ShowTimer"));
		}

		bool OnTimer()
		{
			var ts = DateTime.Now.Subtract(timerStart);

			Timer = ts.ToString("hh':'mm':'ss");

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Timer"));
			return isTimerRunning;
		}

        void RaiseAllPropertiesChanged ()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }

        void OnAnswer (int index)
        {
            App.ButtonPlayer?.Play();

            game.OnAnswer(index);

			if (game.GameMode == GameMode.AdvancedPractice || game.GameMode == GameMode.BasicPractice)
			{
				OnNext();
				return;
			}

            RaiseAllPropertiesChanged();

            NextSelected.ChangeCanExecute();
        }

        void OnPrevious()
        {
            App.ButtonPlayer?.Play();

            if (game.PreviousQuestion())
            {
                NextSelected.ChangeCanExecute();
                BackSelected.ChangeCanExecute();
                RaiseAllPropertiesChanged();
            }
        }

        async void OnNext()
        {
            App.ButtonPlayer?.Play();

            if (game.NextQuestion() == true)
            {
                NextSelected.ChangeCanExecute();
                BackSelected.ChangeCanExecute();
                RaiseAllPropertiesChanged();
            }
            else
            {
				isTimerRunning = false;
                var nav = DependencyService.Get<NavigationService>();
                if (nav != null)
                    await nav.GotoPageAsync(AppPage.ReviewPage);
            }
        }

        bool OnCanExecuteNext()
        {
            if (game.CurrentResponse == null)
                return false;
            return true;
        }
    }
}