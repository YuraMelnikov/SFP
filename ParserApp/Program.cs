using AngleSharp.Dom;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParserApp
{
    class Program
    {
        static async Task Main()
        {
            List<IElement> list;
            Sharp sharp = new Sharp("https://wildsoft.motorsport.com/");
            list = await sharp.GetElementsOfOptionsAsync("option", "cnt.php?id=");
            new CountriesParser(list);
            list = await sharp.GetElementsOfOptionsAsync("option", "gp.php?y=");
            new SeasonsParser(list);
        }
    }
}
