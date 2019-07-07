using System;
using Xamarin.Forms;
using Radio.Droid;
using System.Threading.Tasks;
using System.IO;

[assembly: Dependency(typeof(PlatformFileHelper))]

namespace Radio.Droid
{
    public class PlatformFileHelper : IFileHelper
	{
        public string GetNameWithPath(string filename)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), filename);
        }

        public Task<string> LoadLocalFileAsync (string filename)
		{
			try
			{
				return Task.FromResult(File.ReadAllText(GetNameWithPath(filename)));
			}
			catch 
			{
				return Task.FromResult<string>(null);
			}
		}

		public Task<bool> SaveLocalFileAsync (string filename, string data)
		{
			File.WriteAllText (GetNameWithPath(filename), data);

			return Task.FromResult (true);
		}
	}
}