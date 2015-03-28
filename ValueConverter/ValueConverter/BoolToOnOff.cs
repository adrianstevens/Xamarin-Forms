using System;
using Xamarin.Forms;

namespace ValueConverter
{
	public class BoolToOnOff : IValueConverter
	{
		#region IValueConverter implementation

		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			
			bool useCapLetters = false;

			if(parameter != null)
				useCapLetters = (bool)parameter;

			var isOn = (bool)value;

			var returnString = isOn ? "On" : "Off";

			if (useCapLetters == true)
				returnString = returnString.ToUpper ();

			return returnString;
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

