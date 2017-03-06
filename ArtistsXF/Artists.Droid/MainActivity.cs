using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Artists.Droid
{
    [Activity(Label = "Artists.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var listArtists = FindViewById<ListView>(Resource.Id.listArtists);

            var artists = Shared.ArtistData.Artists;
            var adapater = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, artists);

            listArtists.Adapter = adapater;

            listArtists.ItemClick += ListArtists_ItemClick;
        }

        private void ListArtists_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var artists = Shared.ArtistData.Artists;

            var message = String.Format("You clicked {0}", artists[e.Position]);
            Toast.MakeText(this, message, ToastLength.Short).Show();
        }
    
    }
}

