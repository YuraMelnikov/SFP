using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Io;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParserApp
{
    public class Sharp
    {
        private IConfiguration config;
        private IBrowsingContext context;
        private IDocument document;
        private string _link;

        public Sharp(string link)
        {
            _link = link;
            config = Configuration.Default.WithDefaultLoader();
            context = BrowsingContext.New(config);
        }

        public async Task<List<IElement>> GetElementsOfOptionsAsync(string selector)
        {
            document = await context.OpenAsync(_link);
            return document.QuerySelectorAll(selector).ToList();
        }

        public async Task<List<IElement>> GetElementsOfOptionsAsync(string selector, string outerhtmlContains)
        {
            document = await context.OpenAsync(_link);
            return document.QuerySelectorAll(selector).Where(a => a.OuterHtml.Contains(outerhtmlContains)).ToList();
        }
    }
}
