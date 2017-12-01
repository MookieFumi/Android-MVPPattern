using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVPPattern.Features.Quotes
{
    public class QuotesService : IQuotesService
    {
        public event EventHandler<string> QuotedGenerated;

        protected virtual void OnQuotedGenerated(string quote)
        {
            QuotedGenerated?.Invoke(this, quote);
        }

        public async Task GetRandomQuoute()
        {
            await Task.Delay(1100);

            var items = GetQuoutes();
            var random = new Random();
            var index = random.Next(items.Count());
            
            OnQuotedGenerated(items.ElementAt(index));
        }

        private static IEnumerable<string> GetQuoutes()
        {
            return new List<string>
            {
                "Si exagerásemos nuestras alegrías, como hacemos con nuestras penas, nuestros problemas perderían importancia.",
                "Los mejores médicos del mundo son: el doctor dieta, el doctor reposo y el doctor alegría.",
                "La alegría es la piedra filosofal que todo lo convierte en oro.",
                "El corazón alegre hace tanto bien como el mejor medicamento.",
                "Todo les sale bien a las personas de cáracter dulce y alegre.",
                "Hay que simpatizar siempre con la alegría de la vida. Cuanto menos se hable de las llagas de la vida, mejor.",
                "Bueno es tener la alegría en casa y no haber menester de buscarla fuera.",
                "¡Cuán bueno hace al hombre la dicha! Parece que uno quisiera dar su corazón, su alegría. ¡Y la alegría es contagiosa!",
                "La juventud es el paraíso de la vida, la alegría es la juventud eterna del espíritu.",
                "La alegría de ver y entender es el más perfecto don de la naturaleza.",
                "Ten buena conciencia y tendrás siempre alegría. Si alguna alegría hay en el mundo la tiene seguramente el hombre de corazón puro."
            };
        }
    }
}