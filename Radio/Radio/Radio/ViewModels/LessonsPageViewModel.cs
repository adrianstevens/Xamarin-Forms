using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Radio.ViewModels
{
    public class LessonsPageViewModel
    {
        public List<Lesson> Lessons { get; private set; }

        public Command LessonTappedCommand { get; private set; }

        public LessonsPageViewModel(List<Lesson> lessons)
        {
            Lessons = lessons;

            LessonTappedCommand = new Command(() =>
            {
            //    int r = 99;

            });
        }
    }
}
