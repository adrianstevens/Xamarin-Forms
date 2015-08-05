using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AsyncWork
{
	public static class WebService
	{
		const string bigFile = "http://docs.xamarin.com/xamu-wcf/big_songs.json";

		public static List<Song> GetSongs()
		{
			var client = new WebClient ();
			var data = client.DownloadString(bigFile);

			return JsonConvert.DeserializeObject<List<Song>>(data);
		}

		// TODO: Step 1 - add async version of method
		public async static Task<List<Song>> GetSongsAsync()
		{
			var client = new WebClient ();
			var data = await client.DownloadStringTaskAsync(bigFile);

			return JsonConvert.DeserializeObject<List<Song>>(data);
		}

		// TODO: Step 3 - add improved async version of method
		public async static Task<List<Song>> BetterGetSongsAsync()
		{
			var client = new WebClient ();
			var data = await client.DownloadStringTaskAsync(bigFile);

			return await Task.Run(() => 
				JsonConvert.DeserializeObject<List<Song>>(data));
		}
	}
}

