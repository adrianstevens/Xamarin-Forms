using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GetDeviceType
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

           // lblFamily.Text = App.DeviceFamily.GetFamily(); //is that string?? ... is that enum??

            
            switch(Device.RuntimePlatform)
            {
                case Device.WinPhone:
                case Device.Windows:
                    lblFamily.Text = App.DeviceFamily.UWPDeviceFamily.ToString();
                    break;
                case Device.Android:
                    lblFamily.Text = App.DeviceFamily.AndroidDeviceFamily.ToString();
                    break;
             //   case Device.iOS:
             //       lblFamily.Text = App.DeviceFamily.AppleDeviceFamily.ToString();
             //       break;
                default:
                    lblFamily.Text = "no idea what you're running on";
                    break;
            }
        }
    }
}
