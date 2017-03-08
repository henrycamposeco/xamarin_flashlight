using Android.App;
using Android.Widget;
using Android.OS;
using Lamp.Plugin;
using Android.Views;

namespace Flashlight
{
    [Activity(Label = "Flashlight", MainLauncher = true, Icon = "@drawable/icon", Theme ="@android:style/Theme.Holo.NoActionBar.Fullscreen")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            base.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            CrossLamp.Current.TurnOn();
            ToggleButton toggle = FindViewById<ToggleButton>(Resource.Id.Toggle);
            toggle.Text = "";
            toggle.Checked = true;
            toggle.SetBackgroundResource(Resource.Drawable.On);
            

            toggle.Click += delegate
            {
                if (toggle.Checked)
                {
                    toggle.SetBackgroundResource(Resource.Drawable.On);
                    CrossLamp.Current.TurnOn();
                }
                else
                {
                    toggle.SetBackgroundResource(Resource.Drawable.Off);
                    CrossLamp.Current.TurnOff();
                }

            };


        }
    }
}

