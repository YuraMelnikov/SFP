using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
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
            RepositoryParcer repository = new RepositoryParcer();
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            string folderImg = @"wwwroot/img/";
            string folderLivery = @"wwwroot/livery/";
            string startPage = "https://wildsoft.motorsport.com/";
            IDocument document = await context.OpenAsync("https://wildsoft.motorsport.com/cnt.php?id=2");
            //var countryLinks = document.QuerySelectorAll("#links > div > a").ToList().Cast<IHtmlAnchorElement>().Select(m => m.Href).ToList();
            //foreach (var country in countryLinks)
            //{
            //    document = await context.OpenAsync(country);
            //    string name = document.QuerySelectorAll("#cnt_column_2 > table:nth-child(1) > tbody > tr > td > h1").First().InnerHtml;
            //    string img = startPage + document.QuerySelectorAll("#cnt_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(1) > img").First().Attributes[0].Value;
            //    if (repository.Countries.Count(a => a.Name == name) == 0)
            //    {
            //        repository.Countries.Add(new Country
            //        {
            //            Name = name,
            //            NameRu = name,
            //            IdImage = new ImageParser(img, folderImg).SaveObject()
            //        });
            //        repository.SaveChanges();
            //        Console.WriteLine("Add counrty: {0}", name);
            //    }
            //}
            Guid getDefGuid = repository.Images.First(a => a.Link == "wwwroot/img/cnt_empty.gif").Id;
            //for (int i = 1950; i < 2021; i++)
            //{
            //    if (repository.Seasons.Count(a => a.Year == i) == 0)
            //    {
            //        repository.Seasons.Add(new Season
            //        {
            //            Year = i,
            //            IdImage = getDefGuid
            //        });
            //        repository.SaveChanges();
            //    }
            //}

            //for (int i = 65; i <= 90; i++)
            //{
            //    string charForLink = Convert.ToChar(i).ToString();
                //document = await context.OpenAsync("https://wildsoft.motorsport.com/cha.php?l=" + charForLink);
                //var manufLinks = document.QuerySelectorAll("#links > div > a").ToList().Cast<IHtmlAnchorElement>().Select(m => m.Href).ToList();
                //if (manufLinks.Count > 0)
                //{
                //    foreach (var man in manufLinks)
                //    {
                //        document = await context.OpenAsync(man);
                //        string name = document.QuerySelectorAll("#cha_column_2 > table:nth-child(1) > tbody > tr > td > h1").First().InnerHtml;
                //        string img = startPage + document.QuerySelectorAll("#cha_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(1) > img").First().Attributes[0].Value;
                //        var chassiesImg = document.QuerySelectorAll("#cha_column_2 > table:nth-child(5) > tbody > tr > td:nth-child(2) > img").ToList();
                //        var chassiesA = document.QuerySelectorAll("#cha_column_2 > table:nth-child(5) > tbody > tr > td:nth-child(2) > a").ToList();
                //        if (repository.Manufacturers.Count(a => a.Name == name) == 0)
                //        {
                //            repository.Manufacturers.Add(new Manufacturer
                //            {
                //                Name = name,
                //                IdImage = new ImageParser(img, folderImg).SaveObject(), 
                //                IdCountry = repository.Countries.First().Id
                //            });
                //            repository.SaveChanges();
                //        }
                //        Guid guidMan = repository.Manufacturers.First(a => a.Name == name).Id;
                //        foreach (var ch in chassiesImg)
                //        {
                //            string nameCh = ch.Attributes[5].Value;
                //            string linkCh = startPage + ch.Attributes[0].Value;
                //            if (repository.Chassis.Count(a => a.Name == nameCh && a.IdManufacturer == guidMan) == 0)
                //            {
                //                Guid imgLiv = new ImageParser(linkCh, folderLivery).SaveObject();
                //                Chassis chassis = new Chassis
                //                {
                //                    IdManufacturer = guidMan,
                //                    Name = nameCh,
                //                    IdImage = imgLiv,
                //                    IdLivery = imgLiv
                //                };
                //                repository.Chassis.Add(chassis);
                //                repository.SaveChanges();
                //            }
                //        }
                //        foreach (var ch in chassiesA)
                //        {
                //            string nameCh = ch.Attributes[0].Value;
                //            if (repository.Chassis.Count(a => a.Name == nameCh && a.IdManufacturer == guidMan) == 0)
                //            {
                //                Chassis chassis = new Chassis
                //                {
                //                    IdManufacturer = guidMan,
                //                    Name = nameCh,
                //                    IdImage = getDefGuid,
                //                    IdLivery = getDefGuid
                //                };
                //                repository.Chassis.Add(chassis);
                //                repository.SaveChanges();
                //            }
                //        }
                //    }

                //document = await context.OpenAsync("https://wildsoft.motorsport.com/eng.php?l=" + charForLink);
                //var engLinks = document.QuerySelectorAll("#links > div > a").ToList().Cast<IHtmlAnchorElement>().Select(m => m.Href).ToList();
                //if (engLinks.Count > 0)
                //{
                //    foreach (var eng in engLinks)
                //    {
                //        document = await context.OpenAsync(eng);
                //        string nameManEng = document.QuerySelectorAll("#eng_column_2 > table:nth-child(1) > tbody > tr > td > h1").First().InnerHtml;
                //        if (repository.Manufacturers.Count(a => a.Name == nameManEng) == 0)
                //        {
                //            repository.Manufacturers.Add(new Manufacturer
                //            {
                //                Name = nameManEng,
                //                IdImage = getDefGuid,
                //                IdCountry = repository.Countries.First().Id
                //            });
                //            repository.SaveChanges();
                //        }
                //        Guid guidMan = repository.Manufacturers.First(a => a.Name == nameManEng).Id;
                //        var engList = document.QuerySelectorAll("#eng_column_2 > table:nth-child(5) > tbody > tr > td.cell_cla_br-rt:nth-child(2)");
                //        IEnumerable<string> titles = engList.Select(m => m.TextContent);
                //        foreach (var e in titles)
                //        {
                //            if (repository.Engines.Count(a => a.Name == e && a.IdManufacturer == guidMan) == 0)
                //            {
                //                Engine engine = new Engine
                //                {
                //                    IdManufacturer = guidMan,
                //                    Name = e,
                //                    IdImage = getDefGuid
                //                };
                //                repository.Engines.Add(engine);
                //                repository.SaveChanges();
                //            }
                //        }
                //    }
                //}

                //document = await context.OpenAsync("https://wildsoft.motorsport.com/drv.php?l=" + charForLink);
                //var racerLinks = document.QuerySelectorAll("#links > div > a").ToList().Cast<IHtmlAnchorElement>().Select(m => m.Href).ToList();
                //if (racerLinks.Count > 0)
                //{
                //    foreach (var r in racerLinks)
                //    {
                //        document = await context.OpenAsync(r);
                //        string fn = document.QuerySelectorAll("#drv_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(2) > h1").First().InnerHtml;
                //        DateTime brn;
                //        try
                //        {
                //            brn = DateTime.Parse(document.QuerySelectorAll("#drv_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(3) > table:nth-child(1) > tbody > tr:nth-child(1) > td:nth-child(2) > p").First().InnerHtml);
                //        }
                //        catch
                //        {
                //            brn = new DateTime(1900, 1, 1);
                //        }
                //        if (repository.Racers.Count(a => a.FirstName == fn && a.Born == brn) == 0)
                //        {
                //            Racer racer = new Racer();
                //            string countryName = document.QuerySelectorAll("#drv_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(1) > p > img").First().Attributes[3].Value;
                //            racer.Born = brn;
                //            try
                //            {
                //                racer.BornIn = document.QuerySelectorAll("#drv_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(3) > table:nth-child(1) > tbody > tr:nth-child(1) > td:nth-child(3) > p").First().InnerHtml;
                //            }
                //            catch
                //            {
                //                racer.BornIn = "";
                //            }
                //            try
                //            {
                //                racer.Dead = DateTime.Parse(document.QuerySelectorAll("#drv_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(3) > table:nth-child(1) > tbody > tr:nth-child(2) > td:nth-child(2) > p").First().InnerHtml);
                //                racer.DeadIn = document.QuerySelectorAll("#drv_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(3) > table:nth-child(1) > tbody > tr:nth-child(2) > td:nth-child(3) > p").First().InnerHtml;
                //            }
                //            catch
                //            {
                //                racer.DeadIn = "";
                //            }
                //            try
                //            {
                //                racer.IdCountry = repository.Countries.First(a => a.Name == countryName).Id;
                //            }
                //            catch
                //            {
                //                Country country = new Country { IdImage = getDefGuid, Name = countryName, NameRu = countryName };
                //                repository.Countries.Add(country);
                //                repository.SaveChanges();
                //                racer.IdCountry = country.Id;
                //            }
                //            racer.FirstName = fn;
                //            racer.FirstNameRus = document.QuerySelectorAll("#drv_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(2) > h1").First().InnerHtml;
                //            racer.SecondName = document.QuerySelectorAll("#drv_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(2) > h2").First().InnerHtml;
                //            racer.SecondNameRus = document.QuerySelectorAll("#drv_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(2) > h2").First().InnerHtml;
                //            racer.IdImage = new ImageParser("https://wildsoft.motorsport.com/" + document.QuerySelectorAll("#drv_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(1) > img").First().Attributes[0].Value, @"wwwroot/img/").SaveObject();
                //            var texData = document.QuerySelectorAll("p.text_mb-5_i-10");
                //            foreach (var d in texData)
                //            {
                //                racer.TextData += d.InnerHtml;
                //            }
                //            if (racer.TextData == null)
                //                racer.TextData = "";
                //            repository.Racers.Add(racer);
                //            repository.SaveChanges();
                //        }
                //    }
                //}
            //}

            //document = await context.OpenAsync("https://wildsoft.motorsport.com/cir.php?id=0");
            //var trackLinks = document.QuerySelectorAll("#links > div > a").ToList().Cast<IHtmlAnchorElement>().Select(m => m.Href).ToList();
            //foreach (var t in trackLinks)
            //{
            //    document = await context.OpenAsync(t);
            //    string nameTrack = document.QuerySelectorAll("#cir_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(2) > h1").First().InnerHtml;
            //    if(repository.Tracks.Count(a => a.NameRus == nameTrack) == 0)
            //    {
            //        string nameTrackEng = document.QuerySelectorAll("#cir_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(2) > h2").First().InnerHtml;
            //        string countryName = document.QuerySelectorAll("#cir_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(1) > p > img").First().Attributes[3].Value;
            //        Guid countryTrack;
            //        try
            //        {
            //            countryTrack = repository.Countries.First(a => a.NameRu == countryName).Id;
            //        }
            //        catch
            //        {
            //            Country country = new Country { IdImage = getDefGuid, Name = countryName, NameRu = countryName };
            //            repository.Countries.Add(country);
            //            repository.SaveChanges();
            //            countryTrack = repository.Countries.First(a => a.NameRu == countryName).Id;
            //        }
            //        Guid imgTrack;
            //        try
            //        {
            //            imgTrack = new ImageParser(startPage + document.QuerySelectorAll("#cir_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(2) > a > img").First().Attributes[0].Value.Replace("/small", ""), folderImg).SaveObject();
            //        }
            //        catch
            //        {
            //            imgTrack = getDefGuid;
            //        }

            //        Track track = new Track { 
            //            IdCountry = countryTrack, 
            //            IdImage = imgTrack, 
            //            Name = nameTrackEng, 
            //            NameRus = nameTrack 
            //        };
            //        repository.Tracks.Add(track);
            //        repository.SaveChanges();
            //        Guid guidTrack = repository.Tracks.First(a => a.Name == nameTrackEng).Id;
            //        var confListImg = document.QuerySelectorAll("#cir_column_2 > table:nth-child(6) > tbody > tr > td:nth-child(1) > a > img");
            //        var confListDistance = document.QuerySelectorAll("#cir_column_2 > table:nth-child(6) > tbody > tr > td.cell_cla_br-rt:nth-child(2)");
            //        var confListPeriod = document.QuerySelectorAll("#cir_column_2 > table:nth-child(6) > tbody > tr > td.cell_cla_br-t");
            //        List<string> titlesImg = confListImg.Select(m => startPage + m.Attributes[0].Value).ToList();
            //        List<string> titlesDistance = confListDistance.Select(m => m.InnerHtml).ToList();
            //        List<string> titlesPeriod = confListPeriod.Select(m => m.TextContent).ToList();
            //        for(int i = 0; i < titlesImg.Count(); i++)
            //        {
            //            TrackСonfiguration trackConf = new TrackСonfiguration { 
            //                IdImage = new ImageParser(titlesImg[i], folderImg).SaveObject(), 
            //                IdTrack = guidTrack, 
            //                Length = (float)Convert.ToDouble(titlesDistance[i].Replace(" ", "")), 
            //                Note = titlesPeriod[i]
            //            };
            //            repository.TrackСonfigurations.Add(trackConf);
            //            repository.SaveChanges();
            //        }
            //    }
            //}

            //document = await context.OpenAsync("https://wildsoft.motorsport.com/tyr.php?id");
            //var tyrLinks = document.QuerySelectorAll("#links > div > a").ToList().Cast<IHtmlAnchorElement>().Select(m => m.Href).ToList();
            //foreach (var tyr in tyrLinks)
            //{
            //    document = await context.OpenAsync(tyr);
            //    string tyreName = document.QuerySelectorAll("#tyr_column_2 > table:nth-child(1) > tbody > tr > td > h1").First().InnerHtml;
            //    string imgTyreLink = document.QuerySelectorAll("#tyr_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(1) > img").First().Attributes[0].Value;
            //    Nullable <Guid> tyreImgId = null;
            //    if(repository.Manufacturers.Count(a => a.Name == tyreName) == 0)
            //    {
            //        tyreImgId = new ImageParser(startPage + imgTyreLink, folderImg).SaveObject();
            //        Manufacturer manTyre = new Manufacturer { IdCountry = repository.Countries.First().Id, Name = tyreName, IdImage = tyreImgId.Value };
            //        repository.Manufacturers.Add(manTyre);
            //        repository.SaveChanges();
            //    }
            //    if (repository.Tyres.Count(a => a.Name == tyreName) == 0)
            //    {
            //        if(tyreImgId.Value == null)
            //            tyreImgId = new ImageParser(startPage + imgTyreLink, folderImg).SaveObject();
            //        Tyre tyre = new Tyre { IdImage = tyreImgId.Value, IdManufacturer = repository.Manufacturers.First(a => a.Name == tyreName).Id, Name = tyreName };
            //        repository.Tyres.Add(tyre);
            //        repository.SaveChanges();
            //    }
            //}
            Console.ReadKey();
        }
    }
}