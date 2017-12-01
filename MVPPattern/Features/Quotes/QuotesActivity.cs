using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace MVPPattern.Features.Quotes
{
    [Activity(Label = "MVPPattern", MainLauncher = true)]
    public class QuotesActivity : Activity, IQuotesView
    {
        private TextView _textView;
        private ProgressBar _progressBar;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Quotes);

            var presenter = new QuotesPresenter(this, new QuotesService());

            _textView = FindViewById<TextView>(Resource.Id.textView);
            _progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);

            await presenter.OnGetNextQuoteButtonClick();

            FindViewById<Button>(Resource.Id.GetNextQuoteButton).Click += async (sender, args) =>
            {
                await presenter.OnGetNextQuoteButtonClick();
            };
        }

        public void Busy(bool busy = false)
        {
            _progressBar.Visibility = busy ? ViewStates.Visible : ViewStates.Gone;
        }

        public void SetQuote(string quote)
        {
            _textView.Text = quote;
        }
    }
}

