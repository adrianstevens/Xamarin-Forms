using Radio.Windows;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(PlatformFileHelper))]

namespace Radio.Windows
{
    class PlatformFileHelper : IFileHelper
    {
        public string GetNameWithPath(string filename)
        {
            return filename;
        }

        public async Task<string> LoadLocalFileAsync(string filename)
        {
            try
            {
                var file = await ApplicationData.Current.LocalFolder.GetFileAsync(filename).AsTask();
                return await FileIO.ReadTextAsync(file);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> SaveLocalFileAsync(string filename, string data)
        {
            try
            {
                var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting).AsTask();
                await FileIO.WriteTextAsync(file, data);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
