using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Radio
{
	public static class QuizQuestionXmlSerializer
	{
		public static List<QuizQuestion> Deserialize(Stream stream)
		{
			var serializer = new XmlSerializer (typeof(List<QuizQuestion>));

			var questions = serializer.Deserialize(stream) as List<QuizQuestion>;

			return questions;
		}

		public static List<QuizQuestion> Deserialize (string data)
		{
			return Deserialize (GetStreamFromString(data));
		}

		public static string Serialize(List<QuizQuestion> questions)
		{
			var serializer = new XmlSerializer(typeof(List<QuizQuestion>));

			using (var tw = new StringWriter())
			{
				serializer.Serialize(tw, questions);

				return tw.ToString();
			}
		}

		private static Stream GetStreamFromString (string data)
		{
			var stream = new MemoryStream ();
			var writer = new StreamWriter (stream);
			writer.Write (data);
			writer.Flush ();
			stream.Position = 0;
			
			return stream;
		}
	}
}