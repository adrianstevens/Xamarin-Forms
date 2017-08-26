using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GetDeviceType
{
    public partial class App : Application
    {
        public static IDeviceFamily DeviceFamily { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new GetDeviceType.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
