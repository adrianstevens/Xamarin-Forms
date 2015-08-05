using System;

namespace AsyncWork
{
	public class Song
	{
		public string Artist {get;set;}
		public DateTime Timestamp {get;set;}
		public string TrackId {get;set;}
		public string Title {get;set;}

		public override string ToString ()
		{
			return String.Format ("{0} - {1}", Artist, Title);
		}
	}
}


