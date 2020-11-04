using AngleSharp;
using AngleSharp.Dom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParserApp
{
    public class Sharp
    {
        private IConfiguration config;
        private IBrowsingContext context;

        public Sharp()
        {
            config = Configuration.Default.WithDefaultLoader();
            context = BrowsingContext.New(config);
        }

        public async Task<List<IElement>> GetElementsOfOptionsAsync(string link, string selector)
        {
            IDocument document = await context.OpenAsync(link);
            return document.QuerySelectorAll(selector).ToList();
        }

        public async Task<List<IElement>> GetElementsOfOptionsAsync(string link, string selector, string outerhtmlContains)
        {
            IDocument document = await context.OpenAsync(link);
            return document.QuerySelectorAll(selector).Where(a => a.OuterHtml.Contains(outerhtmlContains)).ToList();
        }

        public async Task<IDocument> GetIDocumentAsync(string link)
        {
            return await context.OpenAsync(link);
        }
    }
}
