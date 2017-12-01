using System.Threading.Tasks;

namespace MVPPattern.Features.Quotes
{
    public interface IQuotesPresenter
    {
        Task OnGetNextQuoteButtonClick();
    }
}