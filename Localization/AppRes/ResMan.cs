using System;

namespace AppRes
{
	public static class ResMan
	{
		public static string GetString(string id)
		{
			return Strings.ResourceManager.GetString (id);
		}
	}
}

