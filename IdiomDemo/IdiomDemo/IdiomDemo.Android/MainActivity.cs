using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Xamarin.Forms;

namespace IdiomDemo.Droid
{
    [Activity(Label = "IdiomDemo", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            // Initial solution using Device.Idiom, but this doesnt work for tablets with higher display zoom
            // https://github.com/xamarin/Xamarin.Forms/issues/12624 
            PortraitModeOnPhoneUsingIdiom();

            // Alternative solution. Work also for tablet with high zoom. Just adapt inches parameter to fine tune. 
            //PortraitModeOnSmallPhoneUsingDisplayMetrices();
        }

        private void PortraitModeOnPhoneUsingIdiom()
        {
            if (Device.Idiom == TargetIdiom.Phone)
            {
                RequestedOrientation = ScreenOrientation.Portrait;
            }
        }

        private void PortraitModeOnSmallPhoneUsingDisplayMetrices()
        {
            using var metrics = new DisplayMetrics();
            WindowManager!.DefaultDisplay!.GetMetrics(metrics);
            float yInches = metrics.HeightPixels / metrics.Ydpi;
            float xInches = metrics.WidthPixels / metrics.Xdpi;
            double diagonalInches = Math.Sqrt(xInches * xInches + yInches * yInches);
            if (diagonalInches < 6.5)  // 6.5 inches
            {
                RequestedOrientation = ScreenOrientation.Portrait;
            }
        }
        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}