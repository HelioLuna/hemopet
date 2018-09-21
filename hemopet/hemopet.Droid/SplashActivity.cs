using Android.App;
using Android.OS;

namespace hemopet.Droid
{
    [Activity(
        Label = "HemoPet",
        Icon = "@drawable/ic_launcher",
        Theme = "@style/Theme.Splash",
        MainLauncher = true,
        NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            StartActivity(typeof(MainActivity));
        }
    }
}