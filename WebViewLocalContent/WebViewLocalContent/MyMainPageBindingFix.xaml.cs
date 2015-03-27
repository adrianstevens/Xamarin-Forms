using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Reflection;
using System.IO;

namespace WebViewLocalContent
{
	public partial class MyMainPageBindingFix : ContentPage
	{
		public string htmlText { get; set; }

		public MyMainPageBindingFix ()
		{
			LoadHTML ();

			InitializeComponent ();

			BindingContext = this;
		}

		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();

			AboutWebView.Source.BindingContext = BindingContext;
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

