using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio
{
    class HamQuestionParser
    {
        public List<QuizQuestion> OpenQuestions (string questionsText)
        {
            if (string.IsNullOrWhiteSpace(questionsText))
                return null;

            var splitParams = new Char[] { '\r' };

            var lines = questionsText.Split(splitParams);

            int count = 0;

            Lesson lesson;

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];

                //time to parse
                if (string.IsNullOrWhiteSpace(line) || line[0] == '\'' || line[0] == '^' )
                    continue;

                if (line[0] == '{') //new lession
                {
                    lesson = CreateLesson(line);
                }
                else //process question, answers and explanation
                {
                    if (line[0] != 'B')
                        continue;

                    int lessonIndex = int.Parse(line.Substring(2, 1));
                    int sectionIndex = int.Parse(line.Substring(4, 1));
                    int questionIndex = int.Parse(line.Substring(6, 1));





                }
                

                //  Debug.WriteLine(lines[i]);

                //  count++;
            }

            Debug.WriteLine($"Count: {count}");

            return null;
        }

        Lesson CreateLesson (string lessonText)
        {
            var id = int.Parse(lessonText.Substring(2, 2));
            var title = lessonText.Substring(6);

            var lesson = new Lesson()
            {
                ID = id,
                Title = title
            };

            return lesson;
        }
    }
}


