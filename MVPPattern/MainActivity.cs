using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace MVPPattern
{
    [Activity(Label = "MVPPattern", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            var textView = FindViewById<TextView>(Resource.Id.textView);
            var button = FindViewById<Button>(Resource.Id.button);
            var progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);


            button.Click += async (sender, args) =>
            {
                progressBar.Visibility = ViewStates.Visible;
                await Task.Delay(1500);
                textView.Text = new QuotesService().GetRandomQuoute();
                progressBar.Visibility = ViewStates.Gone;
            };
        }
    }
}

