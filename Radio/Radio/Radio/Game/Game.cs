using System;
using System.Collections.Generic;

namespace Radio
{
	public class Game
	{
        public List<Lesson> Lessons { get; private set; }
		public List<QuizQuestion> Questions
        {
            get { return Lessons[LessonIndex].Questions; }
        }
		public int?[] Responses { get; private set; }

		public QuizQuestion CurrentQuestion { get { return Questions[QuestionIndex]; } }
		public int? CurrentResponse { get { return Responses[QuestionIndex]; } }
		public int QuestionIndex { get; set; }

        public int LessonIndex
        {
            get { return lessonIndex; }
            set
            {
                lessonIndex = value;
                QuestionIndex = 0;
            }
        }
        int lessonIndex = 0;

		public int NumberOfQuestions 
		{
			get	{ return (Questions == null) ? 0 : Questions.Count; }
		}

        public int NumberOfLessons
        {
            get { return Lessons.Count; }
        }

		public GameMode GameMode { get; private set; }

        public Game (List<Lesson> lessons, int lessonIndex = 0, GameMode mode = GameMode.Basic)
        {
			GameMode = mode;
            Lessons = lessons;
            LessonIndex = lessonIndex;
  			Responses = new int?[Questions.Count];
		}

        public bool PreviousQuestion ()
        {
            if (QuestionIndex < 1)
                return false;

            QuestionIndex--;
            return true;
        }

		public bool NextQuestion ()
		{
			if (QuestionIndex < NumberOfQuestions - 1)
			{
				QuestionIndex++;

				return true;
			}

			return false;
		}

		public void Restart ()
		{
			QuestionIndex = 0;

			Responses = new int?[Questions.Count];
		}

        public void OnAnswer (int index)
        {
            Responses[QuestionIndex] = index;
        }

		public int GetNumberOfCorrectResponses ()
		{
			int count = 0;

			for (int i = 0; i < Responses.Length; i++)
			{
				if (IsQuestionCorrect (i) == true)
					count++;
			}

			return count;
		}

		bool IsQuestionCorrect (int index)
		{
			if (index < 0 || index >= NumberOfQuestions)
				return false;
			
			if (Responses[index] == null)
				return false;
			
			if (Responses[index].Value == Questions[index].CorrectAnswer)
				return true;
			
			return false;
		}
	}
}