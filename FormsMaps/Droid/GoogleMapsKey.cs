using Android.App;

// Put your Google Maps V2 API Key here.
// See https://developers.google.com/maps/documentation/android/start#obtaining_an_api_key
#if RELEASE
[assembly: MetaDataAttribute("com.google.android.maps.v2.API_KEY", Value = "release_key_goes_here")]
#else
[assembly: MetaDataAttribute("com.google.android.maps.v2.API_KEY", Value = "AIzaSyDYGCJcdfXCoGcbjKl5KdmGXjXAOp4G5H0")]
#endif