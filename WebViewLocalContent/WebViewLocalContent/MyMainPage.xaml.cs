using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.IO;
using System.Reflection;

namespace WebViewLocalContent
{
	public partial class MyMainPage : ContentPage
	{
		public string htmlText { get; set; }
		public HtmlWebViewSource htmlSource { get; set; }

		public MyMainPage ()
		{
			BindingContext = this;
			//

			LoadHTML ();

			htmlSource = new HtmlWebViewSource ();

			InitializeComponent ();

			//wire it up without binding
			htmlSource.Html = htmlText;
			AboutWebView.Source = htmlSource;
		}

		void LoadHTML ()
		{
			var assembly = typeof(MyMainPage).GetTypeInfo().Assembly;

			Stream stream = assembly.GetManifestResourceStream("WebViewLocalContent.About.html");

			using (var reader = new System.IO.StreamReader (stream)) 
			{
				htmlText = reader.ReadToEnd ();
			}
		}
	}
}

