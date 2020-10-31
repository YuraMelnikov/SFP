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
            Sharp sharp = new Sharp();
            list = await sharp.GetElementsOfOptionsAsync("https://wildsoft.motorsport.com/", "option", "cnt.php?id=");
            new CountriesParser(list);
            list = await sharp.GetElementsOfOptionsAsync("https://wildsoft.motorsport.com/", "option", "gp.php?y=");
            new SeasonsParser(list);
            ManufacturingAndChassie parserManufChassi = new ManufacturingAndChassie();
            parserManufChassi.SaveData();
        }
    }
}
