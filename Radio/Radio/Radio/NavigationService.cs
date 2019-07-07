using System.Threading.Tasks;
using System;

namespace Radio
{
	public enum AppPage
	{
		HomePage,
        LessonPage,
		QuestionPage,
		ReviewPage,
	}

	public class NavigationService
	{
		public async Task GotoPageAsync (AppPage page, int index = 0)
		{
			var nav = App.Current.MainPage.Navigation;

			switch (page) 
			{
				case AppPage.HomePage:
					await nav.PushAsync (new HomePage (), true);
					return;

                case AppPage.LessonPage:
					Game game = App.GameMan.LoadGame((GameMode)index);

					if (game.Lessons.Count == 1)
					{
						index = 0; //hacky
						goto case AppPage.QuestionPage;
					}

					await nav.PushAsync(new LessonsPage(new ViewModels.LessonsPageViewModel(game.Lessons)));
				
					return;

				case AppPage.QuestionPage:
					if (App.Current == null) 
						return; // Prevent starting before the game is ready

					App.GameMan.GetCurrentGame().LessonIndex = index;

					var qp = new QuestionPage(new QuestionPageViewModel(App.GameMan.GetCurrentGame()));

                    await nav.PushAsync (qp, true);
					return;

				case AppPage.ReviewPage:
					await nav.PushAsync (new ReviewPage (new ReviewPageViewModel (App.GameMan.GetCurrentGame())), true);
					nav.RemovePage (nav.NavigationStack [1]); // Forces app to HomePage when navigating back from the review page
					return;

				default:
					throw new ArgumentOutOfRangeException("Attempted to navigate to invalid page");
			}
		}
	}
}