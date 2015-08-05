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
			//set data source - prefer observable collection 
			myList.ItemsSource = people;


			//myList.ItemSelected - responds to ANY selection
			myList.ItemTapped += MyList_ItemTapped;//only respond to touch events, not programatic selections
			Grid.SetRow (myList, 1);

			myGrid.Children.Add (myList);

			//add button
			var myButton = new Button () 
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.Center,
				HeightRequest = 40,
				Text = "Scroll to Random Person",
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
			//create the data template
			var dataTemplate = new DataTemplate (() => {
				var nameLabel = new Label ();
				var birthdayLabel = new Label ();
				var boxView = new BoxView ();

				var stack = new StackLayout 
				{
					Padding = new Thickness (5),
					Orientation = StackOrientation.Horizontal,
				};

				stack.Children.Add (boxView);
				stack.Children.Add (new StackLayout 
					{
						VerticalOptions = LayoutOptions.Center,
						Spacing = 0,
						Children = 
						{
							nameLabel,
							birthdayLabel
						}
					});

				//set the bindings
				nameLabel.SetBinding (Label.TextProperty, "Name");
				birthdayLabel.SetBinding (Label.TextProperty, new Binding ("Birthday", BindingMode.OneWay, null, null, "Born {0:d}"));
				boxView.SetBinding (BoxView.ColorProperty, "FavoriteColor");

				//create the ViewCell
				return new ViewCell 
				{
					View = stack
				};
			});

			//create the list view
			var listView = new ListView {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				ItemTemplate = dataTemplate
			};

			return listView;
		}
	}
}


