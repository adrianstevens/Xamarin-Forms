using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SimpleAudioRecorder
{
	public partial class App : Application
	{
        public static IAudioRecorder AudioRecorder;

		public App ()
		{
			InitializeComponent();

			MainPage = new SimpleAudioRecorder.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
