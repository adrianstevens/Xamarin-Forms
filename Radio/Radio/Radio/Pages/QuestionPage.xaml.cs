using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Radio
{
    public partial class QuestionPage : ContentPage
    {
        public QuestionPage()
        {
            InitializeComponent();
        }

        private async void QuitClicked(object sender, EventArgs e)
        {
            await DependencyService.Get<NavigationService>()?.GotoPageAsync(AppPage.ReviewPage);
        }

        public QuestionPage (QuestionPageViewModel qpvm)
        {
            InitializeComponent();

            this.BindingContext = qpvm;
        }
    }
}
