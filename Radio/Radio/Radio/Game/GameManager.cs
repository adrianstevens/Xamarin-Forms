using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;

namespace Radio
{
	public enum GameMode
	{
		Basic,
		BasicPractice,
		Advanced,
		AdvancedPractice, 
		count
	}

	public class GameManager
	{
		Game currentGame;

		public Game LoadGame(GameMode mode)
		{
			switch (mode)
			{
				case GameMode.Basic:
					return currentGame = LoadGame("BasicQuestions", GameMode.Basic);
				case GameMode.BasicPractice:
					return currentGame = LoadGame("BasicQuestions", GameMode.BasicPractice);
					case GameMode.Advanced:
					return currentGame = LoadGame("AdvancedQuestions", GameMode.Advanced);
				case GameMode.AdvancedPractice:
					return currentGame = LoadGame("AdvancedQuestions", GameMode.AdvancedPractice);
			}
			return null;
		}

		public Game GetCurrentGame()
		{
			return currentGame;
		}

		static Game LoadGame(string questionFile, GameMode mode)
		{
			var questionsText = String.Empty;

			//var fileHelper = DependencyService.Get<IFileHelper>();

			//  questionsText = await fileHelper.LoadLocalFileAsync("cachedquestions.json");

			if (string.IsNullOrWhiteSpace(questionsText))
			{
				var assembly = typeof(App).GetTypeInfo().Assembly;
				using (var stream = assembly.GetManifestResourceStream("Radio.Data." + questionFile + ".json"))
				{
					questionsText = new StreamReader(stream).ReadToEnd();
				}
			}

			//await fileHelper.SaveLocalFileAsync("cachedquestions.json", questionsText);

			var lessons = JsonConvert.DeserializeObject<List<Lesson>>(questionsText);

			//var questions = JsonConvert.DeserializeObject<List<QuizQuestion>>(questionsText);

			if (mode == GameMode.AdvancedPractice || mode == GameMode.BasicPractice)
				return new Game(GetPracticeRadio(lessons), 0, mode);
			return new Game(lessons);
		}

		static List<Lesson> GetPracticeRadio(List<Lesson> lessons)
		{
			int count = 80;

			var rand = new Random();

			var Radio = new Lesson();

			Radio.Title = "Practice Radio";

			while (Radio.NumberOfQuestions < count)
			{
				int lesson = rand.Next() % lessons.Count;

				int question = rand.Next() % lessons[lesson].NumberOfQuestions;

				if (Radio.Questions.Contains(lessons[lesson].Questions[question]))
					continue;

				Radio.Questions.Add(lessons[lesson].Questions[question]);
			}

			return new List<Lesson> { Radio }; //single item list (should be fine)
		}
	}
}
