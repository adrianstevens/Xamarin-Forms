using System;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace NavigationCommon
{
	public class ColorModel
	{
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("hex")]
		public string Hex { get; set; }
		[JsonProperty("rgb")]
		public string RGB 
		{ 
			get { return rGB; }
			set { ParseColorString (rGB = value); }
		}
		private string rGB;

		public byte Red { get; set; }
		public byte Green { get; set; }
		public byte Blue { get; set; }

		public Color Color { get { return Color.FromRgb (Red, Green, Blue); } }

		void ParseColorString (string color)
		{
			var s = color.Substring(1, color.Length - 2).Split(',');

			Red 	= byte.Parse(s[0]);
			Green 	= byte.Parse(s[1]);
			Blue 	= byte.Parse(s[2]);
		}
	}
}