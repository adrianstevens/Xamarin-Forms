using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace NavigationCommon
{
	public static class ColorLoader
	{
		static List<ColorModel> colors;

		public static List<ColorModel> GetColors ()
		{
			if (colors == null)
				colors = LoadColors ();

			return colors;
		}

		static List<ColorModel> LoadColors ()
		{
			string data = String.Empty;

			using (Stream stream = typeof(ColorLoader).GetTypeInfo().Assembly.GetManifestResourceStream("NavigationCommon.colors.json")) {
				using (StreamReader sr = new StreamReader (stream)) {
					data = sr.ReadToEnd ();
				}
			}

			return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ColorModel>>(data);
		}
	}
}

