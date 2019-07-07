using Radio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Radio
{
    public partial class LessonsPage : ContentPage
    {
        public LessonsPage(LessonsPageViewModel lpvm)
        {
            InitializeComponent();

            BindingContext = lpvm;
        }

        private async void OnLessonTapped(object sender, ItemTappedEventArgs e)
        {
			LessonsPageViewModel lpvm = BindingContext as LessonsPageViewModel;

            var index = lpvm.Lessons.IndexOf((Lesson)e.Item);

            await DependencyService.Get<NavigationService>().GotoPageAsync(AppPage.QuestionPage, index);

        }
    }
}
