using System;
using System.Threading.Tasks;

namespace MVPPattern.Features.Quotes
{
    public interface IQuotesService
    {
        event EventHandler<string> QuotedGenerated;
        Task GetRandomQuoute();
    }
}