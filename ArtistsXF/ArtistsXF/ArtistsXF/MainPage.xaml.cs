using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArtistsXF
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            listArtists.ItemsSource = Artists.Shared.ArtistData.Artists;
        }
    }
}