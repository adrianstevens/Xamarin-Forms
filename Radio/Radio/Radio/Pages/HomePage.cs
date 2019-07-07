using Xamarin.Forms;

namespace Radio
{
    public class HomePage : ContentPage
    {
        Grid layout;

        public HomePage()
        {
            layout = new Grid();

            Content = layout;

            var bg = new Image();
            bg.Source = ImageSource.FromResource("Radio.Images.background.jpg");
            bg.Aspect = Aspect.AspectFill;

            if(Device.RuntimePlatform != Device.macOS)
                NavigationPage.SetHasNavigationBar(this, false);

            layout.Children.Add(bg);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (layout.Children.Count > 1)
                return;

			var stack = new StackLayout()
			{
				Margin = 10,
				Spacing = 10,
				VerticalOptions = LayoutOptions.Center,
			};

			stack.Children.Add(GetButton("Basic Questions", (int)GameMode.Basic));
            stack.Children.Add(GetButton("Basic Practice Radio", (int)GameMode.BasicPractice));
			stack.Children.Add(GetButton("Advanced Questions", (int)GameMode.Advanced));
			stack.Children.Add(GetButton("Advanced Practice Radio", (int)GameMode.AdvancedPractice));
            stack.Children.Add(new Label() { Text = "v0.3.0", TextColor=Color.White, HorizontalTextAlignment=TextAlignment.End });

            layout.Children.Add(stack);
        }

        Button GetButton (string text, int index)
        {
			var button = new Button()
			{
				Text = text,
				TextColor = Color.White,
				BackgroundColor = Color.FromRgba(8, 146, 208, 128),  //.FromHex("#0892d0"),
                Font = Font.SystemFontOfSize(NamedSize.Medium),
            };
            button.Clicked += (s, e) => OnStartClicked(index);

            return button;
        }

        async void OnStartClicked(int index)
        {
            App.ButtonPlayer?.Play();

            var nav = DependencyService.Get<NavigationService>();

            await nav?.GotoPageAsync(AppPage.LessonPage, index);
        } 
    }
}