using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FormStyles
{
    public partial class App : Application
    {
		public static ISetSystemColors SystemColors { get; set; }

        public App()
        {
            InitializeComponent();

            // The root page of your application
			MainPage = new FormStyles.MainPage();
        }

		public static void SetThemeColors (Color foreground, Color backgroud, Color accent)
		{
			App.Current.Resources["fgColor"] = foreground;
			App.Current.Resources["bgColor"] = backgroud;
			App.Current.Resources["acColor"] = accent;

			if (SystemColors != null)
				SystemColors.SetTintColor (accent.R, accent.G, accent.B);
		}
    }
}
