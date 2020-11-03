﻿using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParserApp
{
    class Program
    {
        static async Task Main()
        {
            List<IElement> list;
            Sharp sharp = new Sharp();
            //list = await sharp.GetElementsOfOptionsAsync("https://wildsoft.motorsport.com/", "option", "cnt.php?id=");
            //new CountriesParser(list);
            //list = await sharp.GetElementsOfOptionsAsync("https://wildsoft.motorsport.com/", "option", "gp.php?y=");
            //new SeasonsParser(list);
            for (int i = 65; i <= 90; i++) 
            {
                string charForLink = Convert.ToChar(i).ToString();
                string link = "https://wildsoft.motorsport.com/cha.php?l=" + charForLink;
                //list = await sharp.GetElementsOfOptionsAsync(link, "a", "cha.php?id=");
                //if (list.Count > 0)
                //{
                //    ManufacturingParcer manufacturing = new ManufacturingParcer(list);
                //    foreach (var man in manufacturing.manufacturersLinks)
                //    {
                //        list = await sharp.GetElementsOfOptionsAsync(man.Link, "a", "name");
                //        new ChassiesParcer(list, man.Id);
                //    }
                //}

                //link = "https://wildsoft.motorsport.com/eng.php?l=" + charForLink;
                //list = await sharp.GetElementsOfOptionsAsync(link, "a", "eng.php?id=");
                //if (list.Count > 0)
                //{
                //    ManufacturerEngineParcer manufacturing = new ManufacturerEngineParcer(list);
                //    foreach (var man in manufacturing.manufacturersLinks)
                //    {
                //        list = await sharp.GetElementsOfOptionsAsync(man.Link, "table > tbody > tr > td.cell_cla_br-rt:nth-child(2)");
                //        IEnumerable<string> titles = list.Select(m => m.TextContent);
                //        new EngineParcer(titles, man.Id);
                //        Console.WriteLine("Complited: {0}", man.Id);
                //    }
                //}

                link = "https://wildsoft.motorsport.com/eng.php?l=" + charForLink;
                list = await sharp.GetElementsOfOptionsAsync(link, "a", "eng.php?id=");
                if (list.Count > 0)
                {
                    ManufacturerEngineParcer manufacturing = new ManufacturerEngineParcer(list);
                    foreach (var man in manufacturing.manufacturersLinks)
                    {
                        list = await sharp.GetElementsOfOptionsAsync(man.Link, "table > tbody > tr > td.cell_cla_br-rt:nth-child(2)");
                        IEnumerable<string> titles = list.Select(m => m.TextContent);
                        new EngineParcer(titles, man.Id);
                        Console.WriteLine("Complited: {0}", man.Id);
                    }
                }
            }
        }
    }
}
