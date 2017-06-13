using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using Worklight.Xamarin.Android;
using Worklight;

namespace AFPCapital.Movil.Droid
{
    [Activity(Label = "AFP Capital", Icon = "@drawable/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

		protected override void OnCreate(Bundle bundle)
        {

           	TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            global::Xamarin.FormsMaps.Init(this, bundle);
            ImageCircleRenderer.Init();

			WLHelper wlHelper = new WLHelper(WorklightClient.CreateInstance(this));

            LoadApplication(new AFPCapital.Movil.App());
        }

}
}


