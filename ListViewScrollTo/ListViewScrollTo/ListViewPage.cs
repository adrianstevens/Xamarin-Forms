using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace ListViewScrollTo
{
	public class ListViewPage : ContentPage
	{
		ListView myList;
		ObservableCollection<Person> people = PersonFactory.GetPeople();

		public ListViewPage ()
		{
			var myGrid = new Grid ();

			//list 
			myGrid.RowDefinitions.Add (new RowDefinition () { Height = new GridLength (1, GridUnitType.Auto) });

			//button
			myGrid.RowDefinitions.Add (new RowDefinition () { Height = new GridLength (1, GridUnitType.Star) });

			//add list
			myList = CreateList ();
			myList.ItemsSource = people;
			myList.ItemTapped += MyList_ItemTapped;
			Grid.SetRow (myList, 1);

			myGrid.Children.Add (myList);

			//add button
			var myButton = new Button () {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.Center,
				HeightRequest = 40,
				Text = "Scroll to Random Item",
			};
			myButton.Clicked += MyButton_Clicked;


			Grid.SetRow (myButton, 0);
			myGrid.Children.Add (myButton);


			Content = myGrid;

		}

		//use item slected if you want an event to fire when items are programatically selected
		void MyList_ItemTapped (object sender, ItemTappedEventArgs e)
		{
			DisplayAlert ((e.Item as Person).Name, "ListView Item Tapped", "ok");
		}

		void MyButton_Clicked (object sender, EventArgs e)
		{
			int index = new Random ().Next (people.Count);

			myList.ScrollTo (people [index], ScrollToPosition.Center, true);
			myList.SelectedItem = people [index];
		}

		ListView CreateList ()
		{
			var listView = new ListView
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				ItemTemplate = new DataTemplate(() =>
					{
						var nameLabel = new Label();
						var birthdayLabel = new Label();
						var boxView = new BoxView();

						var stack = new StackLayout
						{
							
							Padding = new Thickness(5),
							Orientation = StackOrientation.Horizontal,
							BackgroundColor = Color.Black,
							Children =
							{
								boxView,
								new StackLayout
								{
									VerticalOptions = LayoutOptions.Center,
									Spacing = 0,
									Children =
									{
										nameLabel,
										birthdayLabel
									}
								}
							}
						};

						nameLabel.SetBinding(Label.TextProperty, "Name");
						birthdayLabel.SetBinding(Label.TextProperty, new Binding("Birthday", BindingMode.OneWay, null, null, "Born {0:d}"));
						boxView.SetBinding(BoxView.ColorProperty, "FavoriteColor");
						stack.SetBinding(BackgroundColorProperty, "BackgroundColor");

						return new ViewCell
						{
							View = stack
						};
					})
			};

			return listView;
		}
	}
}


