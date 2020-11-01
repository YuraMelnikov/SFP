﻿using AngleSharp.Dom;
using System;
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
            //list = await sharp.GetElementsOfOptionsAsync("https://wildsoft.motorsport.com/", "option", "cnt.php?id=");
            //new CountriesParser(list);
            //list = await sharp.GetElementsOfOptionsAsync("https://wildsoft.motorsport.com/", "option", "gp.php?y=");
            //new SeasonsParser(list);
            for (int i = 65; i <= 90; i++) 
            {
                string charForLink = Convert.ToChar(i).ToString();
                string link = "https://wildsoft.motorsport.com/cha.php?l=" + charForLink;
                list = await sharp.GetElementsOfOptionsAsync(link, "a", "cha.php?id=");
                if (list.Count > 0)
                    new ManufacturingParcer(list);
            }


        }
    }
}
