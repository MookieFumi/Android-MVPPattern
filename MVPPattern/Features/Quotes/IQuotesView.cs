namespace MVPPattern.Features.Quotes
{
    public interface IQuotesView
    {
        void Busy(bool busy = false);
        void SetQuote(string quote);
    }
}