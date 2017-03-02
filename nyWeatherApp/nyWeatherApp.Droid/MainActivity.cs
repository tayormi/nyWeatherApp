using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace nyWeatherApp.Droid
{
    [Activity(Label = "nyWeatherApp.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.GetWeatherButton);
            button.Click += Button_Click;

            // Get our button from the layout resource,
            // and attach an event to it



        }
        private async void Button_Click(object sender, EventArgs e)
        {
            EditText zipCodeEntry = FindViewById<EditText>(Resource.Id.ZipCodeEdit);
            if (!String.IsNullOrEmpty(zipCodeEntry.Text))
            {
                weather weather = await Core.GetWeather(zipCodeEntry.ToString());
                FindViewById<TextView>(Resource.Id.HumidityText).Text = weather.Humidity;
                FindViewById<TextView>(Resource.Id.SunriseText).Text = weather.Sunrise;
                FindViewById<TextView>(Resource.Id.SunsetText).Text = weather.Sunset;
                FindViewById<TextView>(Resource.Id.TempText).Text = weather.Temperature;
                FindViewById<TextView>(Resource.Id.VisibilityText).Text = weather.Visibility;
                FindViewById<TextView>(Resource.Id.WindText).Text = weather.Wind;
            }
        }
    }
}


