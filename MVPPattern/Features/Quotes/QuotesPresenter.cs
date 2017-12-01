using System.Threading.Tasks;

namespace MVPPattern.Features.Quotes
{
    public class QuotesPresenter : IQuotesPresenter
    {
        private readonly IQuotesView _view;
        private readonly IQuotesService _quotesService;

        public QuotesPresenter(IQuotesView view, IQuotesService quotesService)
        {
            _view = view;
            _quotesService = quotesService;
            _quotesService.QuotedGenerated += (sender, qoute) =>
            {
                _view.SetQuote(qoute);
                _view.Busy();
            };
        }

        public async Task OnGetNextQuoteButtonClick()
        {
            _view?.Busy(true);
            await _quotesService.GetRandomQuoute();
        }
    }
}