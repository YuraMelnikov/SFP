using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;

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



            list = await sharp.GetElementsOfOptionsAsync("https://wildsoft.motorsport.com/cir.php?id=61", "#links > div > a");
            var tracksLink = list.Cast<IHtmlAnchorElement>().Select(m => m.Href).ToList();
            foreach (var l in tracksLink)
            {
                using (var repository = new RepositoryParcer())
                {
                    var document = await sharp.GetIDocumentAsync(l);
                    Track track = new Track();
                    string countryTrack = document.QuerySelectorAll("#cir_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(1) > p > img").First().Attributes[3].Value;
                    //track.IdCountry = repository.Countries.First(a => a.Name == countryTrack).Id;
                    //track.IdImage = new ImageParser("https://wildsoft.motorsport.com/" + document.QuerySelectorAll("#cir_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(1) > p > img").First().Attributes[0].Value, @"wwwroot/img/").SaveObject();
                    track.Name = document.QuerySelectorAll("#cir_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(2) > h1").First().InnerHtml;

                    var trackConf = document.QuerySelectorAll("#cir_column_2 > table:nth-child(6)");


                    //# cir_column_2 > table:nth-child(6) > tbody > tr:nth-child(2) > td:nth-child(1) > a > img
                    //# cir_column_2 > table:nth-child(6) > tbody > tr:nth-child(3) > td:nth-child(1) > a > img

                    //# cir_column_2 > table:nth-child(6) > tbody > tr:nth-child(2) > td:nth-child(2)
                    //# cir_column_2 > table:nth-child(6) > tbody > tr:nth-child(3) > td:nth-child(2)

                    //# cir_column_2 > table:nth-child(6) > tbody > tr:nth-child(2) > td.cell_cla_br-t
                    //# cir_column_2 > table:nth-child(6) > tbody > tr:nth-child(3) > td.cell_cla_br-t

                }
            }


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
                //    }
                //}





                //link = "https://wildsoft.motorsport.com/drv.php?l=" + charForLink;
                //list = await sharp.GetElementsOfOptionsAsync(link, "#links > div > a");
                //if (list.Count > 0)
                //{
                //    var links = list.Cast<IHtmlAnchorElement>().Select(m => m.Href).ToList();
                //    foreach (var l in links)
                //    {
                //        using (var repository = new RepositoryParcer())
                //        {
                //            var document = await sharp.GetIDocumentAsync(l);
                //            Racer racer = new Racer();
                //            string countryName = document.QuerySelectorAll("#drv_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(1) > p > img").First().Attributes[3].Value;
                //            racer.Born = DateTime.Parse(document.QuerySelectorAll("#drv_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(3) > table:nth-child(1) > tbody > tr:nth-child(1) > td:nth-child(2) > p").First().InnerHtml);
                //            racer.BornIn = document.QuerySelectorAll("#drv_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(3) > table:nth-child(1) > tbody > tr:nth-child(1) > td:nth-child(3) > p").First().InnerHtml;
                //            try
                //            {
                //                racer.Dead = DateTime.Parse(document.QuerySelectorAll("#drv_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(3) > table:nth-child(1) > tbody > tr:nth-child(2) > td:nth-child(2) > p").First().InnerHtml);
                //                racer.DeadIn = document.QuerySelectorAll("#drv_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(3) > table:nth-child(1) > tbody > tr:nth-child(2) > td:nth-child(3) > p").First().InnerHtml;
                //            }
                //            catch
                //            {
                //                racer.DeadIn = "";
                //            }
                //            racer.IdCountry = repository.Countries.First(a => a.Name == countryName).Id;
                //            racer.FirstName = document.QuerySelectorAll("#drv_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(2) > h1").First().InnerHtml;
                //            racer.SecondName = document.QuerySelectorAll("#drv_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(2) > h2").First().InnerHtml;
                //            racer.IdImage = new ImageParser("https://wildsoft.motorsport.com/" + document.QuerySelectorAll("#drv_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(1) > img").First().Attributes[0].Value, @"wwwroot/img/").SaveObject();
                //            var texData = document.QuerySelectorAll("p.text_mb-5_i-10");
                //            foreach (var d in texData)
                //            {
                //                racer.TextData += d.InnerHtml;
                //            }
                //        }
                //    }
                //}

                link = "https://wildsoft.motorsport.com/gpr.php?l=" + charForLink;
                list = await sharp.GetElementsOfOptionsAsync(link, "#links > div > a");
                if (list.Count > 0)
                {
                    var links = list.Cast<IHtmlAnchorElement>().Select(m => m.Href).ToList();
                    foreach (var l in links)
                    {
                        using (var repository = new RepositoryParcer())
                        {
                            var document = await sharp.GetIDocumentAsync(l);
                            Racer racer = new Racer();
                            string countryName = document.QuerySelectorAll("#drv_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(1) > p > img").First().Attributes[3].Value;
                            racer.Born = DateTime.Parse(document.QuerySelectorAll("#drv_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(3) > table:nth-child(1) > tbody > tr:nth-child(1) > td:nth-child(2) > p").First().InnerHtml);
                            racer.BornIn = document.QuerySelectorAll("#drv_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(3) > table:nth-child(1) > tbody > tr:nth-child(1) > td:nth-child(3) > p").First().InnerHtml;
                            try
                            {
                                racer.Dead = DateTime.Parse(document.QuerySelectorAll("#drv_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(3) > table:nth-child(1) > tbody > tr:nth-child(2) > td:nth-child(2) > p").First().InnerHtml);
                                racer.DeadIn = document.QuerySelectorAll("#drv_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(3) > table:nth-child(1) > tbody > tr:nth-child(2) > td:nth-child(3) > p").First().InnerHtml;
                            }
                            catch
                            {
                                racer.DeadIn = "";
                            }
                            racer.IdCountry = repository.Countries.First(a => a.Name == countryName).Id;
                            racer.FirstName = document.QuerySelectorAll("#drv_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(2) > h1").First().InnerHtml;
                            racer.SecondName = document.QuerySelectorAll("#drv_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(2) > h2").First().InnerHtml;
                            racer.IdImage = new ImageParser("https://wildsoft.motorsport.com/" + document.QuerySelectorAll("#drv_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(1) > img").First().Attributes[0].Value, @"wwwroot/img/").SaveObject();
                            var texData = document.QuerySelectorAll("p.text_mb-5_i-10");
                            foreach (var d in texData)
                            {
                                racer.TextData += d.InnerHtml;
                            }
                        }
                    }
                }
            }
        }
    }
}
