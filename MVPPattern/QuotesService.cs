using System;
using System.Collections.Generic;
using System.Linq;

namespace MVPPattern
{
    public interface IQuotesService
    {
        string GetRandomQuoute();
    }

    public class QuotesService : IQuotesService
    {
        public string GetRandomQuoute()
        {
            var items = GetQuoutes();
            var random = new Random();
            var index = random.Next(items.Count());

            return items.ElementAt(index);
        }

        private static IEnumerable<string> GetQuoutes()
        {
            return new List<string>
            {
                "Be yourself. everyone else is already taken.",
                "A room without books is like a body without a soul.",
                "You only live once, but if you do it right, once is enough.",
                "Be the change that you wish to see in the world.",
                "If you tell the truth, you don't have to remember anything."
            };
        }
    }
}