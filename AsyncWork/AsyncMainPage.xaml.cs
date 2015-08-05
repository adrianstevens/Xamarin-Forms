using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AsyncWork
{
	public partial class AsyncMainPage : ContentPage
	{
		bool bShowTimer = false;

		public AsyncMainPage ()
		{
			InitializeComponent ();

			buttonRefresh.Clicked += (sender, e) => OnRefresh(true);
			listSongs.Refreshing += (sender, e) => OnRefresh(false);
		}

		void ShowProgressBar (bool bShow)
		{
			if (bShow == bShowTimer)
				return;

			bShowTimer = bShow;

			if (bShow == true) {
				progressBar.IsVisible = true;
				bShowTimer = true;
				Device.StartTimer (new TimeSpan (0, 0, 0, 0, 1500), OnTimer);
			} 
			else 
			{
				progressBar.IsVisible = false;
				bShowTimer = false;
			}
		}

		bool OnTimer ()
		{
			progressBar.Progress = 0;
			progressBar.ProgressTo (1, 1000, Easing.SinInOut);

			return bShowTimer;
		}

		public async void OnRefresh (bool bShowProgress)
		{
			try
			{
				if(bShowProgress)
					ShowProgressBar (true);
				
				// var songs = WebService.GetSongs();

				// TODO: Step 2 - call the async version of the service.
				var songs = await WebService.BetterGetSongsAsync();
				listSongs.ItemsSource = songs;
			}
			finally
			{
				listSongs.EndRefresh ();
				ShowProgressBar (false);
			}
		}
	}
}

