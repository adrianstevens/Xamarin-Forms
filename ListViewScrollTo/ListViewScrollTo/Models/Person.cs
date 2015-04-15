using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace ListViewScrollTo
{
	public class Person
	{
		public string Name { private set; get; }
		public DateTime Birthday { private set; get; }
		public Color FavoriteColor { private set; get; }

		public Person(string name, DateTime birthday, Color favColor)
		{
			this.Name = name;
			this.Birthday = birthday;
			this.FavoriteColor = favColor;
		}
	}

	public static class PersonFactory
	{
		public static ObservableCollection<Person> GetPeople ()
		{
			return new ObservableCollection<Person> {
				new Person ("Abby", new DateTime (1975, 1, 15), Color.Aqua),
				new Person ("Bob", new DateTime (1976, 2, 20), Color.Black),
				new Person ("Kath", new DateTime (1977, 3, 10), Color.Blue),
				new Person ("David", new DateTime (1978, 4, 25), Color.Fuchsia),
				new Person ("Tori", new DateTime (1975, 1, 15), Color.Gray),
				new Person ("Nathan", new DateTime (1976, 1, 15), Color.Green),
				new Person ("Jorge", new DateTime (1977, 1, 15), Color.Lime),
				new Person ("Lisa", new DateTime (1975, 1, 15), Color.Maroon),
				new Person ("Scott", new DateTime (1976, 1, 15), Color.Navy),
				new Person ("Sara", new DateTime (1977, 1, 15), Color.Olive),
				new Person ("John", new DateTime (1975, 1, 15), Color.Pink),
				new Person ("Emily", new DateTime (1976, 1, 15), Color.Purple),
				new Person ("Cindy", new DateTime (1977, 1, 15), Color.Red),
				new Person ("Donny", new DateTime (1978, 1, 15), Color.Silver),
				new Person ("Marco", new DateTime (1977, 1, 15), Color.Teal),
				new Person ("Cesar", new DateTime (1976, 1, 15), Color.Transparent),
				new Person ("Adrian", new DateTime (1975, 1, 15), Color.White),
				new Person ("Matt", new DateTime (1974, 1, 15), Color.Yellow),

				new Person ("Chris", new DateTime (1975, 1, 15), Color.Aqua),
				new Person ("Rene", new DateTime (1976, 2, 20), Color.Black),
				new Person ("Mark", new DateTime (1977, 3, 10), Color.Blue),
				new Person ("Mark", new DateTime (1978, 4, 25), Color.Fuchsia),
				new Person ("Rob", new DateTime (1975, 1, 15), Color.Gray),
				new Person ("Bryan", new DateTime (1976, 1, 15), Color.Green),
				new Person ("Karina", new DateTime (1977, 1, 15), Color.Lime),
				new Person ("Judy", new DateTime (1975, 1, 15), Color.Maroon),
				new Person ("Helen", new DateTime (1976, 1, 15), Color.Navy),
				new Person ("Zulma", new DateTime (1977, 1, 15), Color.Olive),
				new Person ("Kym", new DateTime (1975, 1, 15), Color.Pink),
				new Person ("Glenn", new DateTime (1976, 1, 15), Color.Purple),
				new Person ("Adam", new DateTime (1977, 1, 15), Color.Red),
				new Person ("Amy", new DateTime (1978, 1, 15), Color.Silver),
				new Person ("Anuj", new DateTime (1977, 1, 15), Color.Teal),
				new Person ("Betai", new DateTime (1976, 1, 15), Color.Transparent),
				new Person ("Charles", new DateTime (1975, 1, 15), Color.White),
				new Person ("Craig", new DateTime (1974, 1, 15), Color.Yellow),
			};
		}
	}
}

