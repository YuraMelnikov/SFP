using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

            //for (int i = 1950; i < 2020; i++)
            //{
            //    if (repository.Seasons.Count(a => a.Year == i) == 0)
            //    {
            //        repository.Seasons.Add(new Season
            //        {
            //            Year = i,
            //            IdImage = getDefGuid
            //        });
            //        repository.SaveChanges();
            //        Console.WriteLine("Add season: {0}", i.ToString());
            //    }
            //}

            //for (int i = 65; i <= 90; i++)
            //{
            //    string charForLink = Convert.ToChar(i).ToString();
            //    document = await context.OpenAsync("https://wildsoft.motorsport.com/cha.php?l=" + charForLink);
            //    var manufLinks = document.QuerySelectorAll("#links > div > a").ToList().Cast<IHtmlAnchorElement>().Select(m => m.Href).ToList();
            //    if (manufLinks.Count > 0)
            //    {
            //        foreach (var man in manufLinks)
            //        {
            //            document = await context.OpenAsync(man);
            //            string name = document.QuerySelectorAll("#cha_column_2 > table:nth-child(1) > tbody > tr > td > h1").First().InnerHtml;
            //            string img = startPage + document.QuerySelectorAll("#cha_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(1) > img").First().Attributes[0].Value;
            //            var chassiesImg = document.QuerySelectorAll("#cha_column_2 > table:nth-child(5) > tbody > tr > td:nth-child(2) > img").ToList();
            //            var chassiesA = document.QuerySelectorAll("#cha_column_2 > table:nth-child(5) > tbody > tr > td:nth-child(2) > a").ToList();
            //            if (repository.Manufacturers.Count(a => a.Name == name) == 0)
            //            {
            //                repository.Manufacturers.Add(new Manufacturer
            //                {
            //                    Name = name,
            //                    IdImage = new ImageParser(img, folderImg).SaveObject(),
            //                    IdCountry = repository.Countries.First().Id
            //                });
            //                repository.SaveChanges();
            //                Console.WriteLine("Add Manufacturer: {0}", name);
            //            }
            //            Guid guidMan = repository.Manufacturers.First(a => a.Name == name).Id;
            //            foreach (var ch in chassiesImg)
            //            {
            //                string nameCh = ch.Attributes[5].Value;
            //                string linkCh = startPage + ch.Attributes[0].Value;
            //                if (repository.Chassis.Count(a => a.Name == nameCh && a.IdManufacturer == guidMan) == 0)
            //                {
            //                    Guid imgLiv = new ImageParser(linkCh, folderLivery).SaveObject();
            //                    Chassis chassis = new Chassis
            //                    {
            //                        IdManufacturer = guidMan,
            //                        Name = nameCh,
            //                        IdImage = imgLiv,
            //                        IdLivery = imgLiv
            //                    };
            //                    repository.Chassis.Add(chassis);
            //                    repository.SaveChanges();
            //                    Console.WriteLine("Add chassi: {0}", nameCh);
            //                }
            //            }
            //            foreach (var ch in chassiesA)
            //            {
            //                string nameCh = ch.Attributes[0].Value;
            //                if (repository.Chassis.Count(a => a.Name == nameCh && a.IdManufacturer == guidMan) == 0)
            //                {
            //                    Chassis chassis = new Chassis
            //                    {
            //                        IdManufacturer = guidMan,
            //                        Name = nameCh,
            //                        IdImage = getDefGuid,
            //                        IdLivery = getDefGuid
            //                    };
            //                    repository.Chassis.Add(chassis);
            //                    repository.SaveChanges();
            //                    Console.WriteLine("Add chassi: {0}", nameCh);
            //                }
            //            }
            //        }

            //        document = await context.OpenAsync("https://wildsoft.motorsport.com/eng.php?l=" + charForLink);
            //        var engLinks = document.QuerySelectorAll("#links > div > a").ToList().Cast<IHtmlAnchorElement>().Select(m => m.Href).ToList();
            //        if (engLinks.Count > 0)
            //        {
            //            foreach (var eng in engLinks)
            //            {
            //                document = await context.OpenAsync(eng);
            //                string nameManEng = document.QuerySelectorAll("#eng_column_2 > table:nth-child(1) > tbody > tr > td > h1").First().InnerHtml;
            //                if (repository.Manufacturers.Count(a => a.Name == nameManEng) == 0)
            //                {
            //                    repository.Manufacturers.Add(new Manufacturer
            //                    {
            //                        Name = nameManEng,
            //                        IdImage = getDefGuid,
            //                        IdCountry = repository.Countries.First().Id
            //                    });
            //                    repository.SaveChanges();
            //                    Console.WriteLine("Add manufacturer: {0}", nameManEng);
            //                }
            //                Guid guidMan = repository.Manufacturers.First(a => a.Name == nameManEng).Id;
            //                var engList = document.QuerySelectorAll("#eng_column_2 > table:nth-child(5) > tbody > tr > td.cell_cla_br-rt:nth-child(2)");
            //                IEnumerable<string> titles = engList.Select(m => m.TextContent);
            //                foreach (var e in titles)
            //                {
            //                    if (repository.Engines.Count(a => a.Name == e && a.IdManufacturer == guidMan) == 0)
            //                    {
            //                        Engine engine = new Engine
            //                        {
            //                            IdManufacturer = guidMan,
            //                            Name = e,
            //                            IdImage = getDefGuid
            //                        };
            //                        repository.Engines.Add(engine);
            //                        repository.SaveChanges();
            //                        Console.WriteLine("Add engine: {0}", e);
            //                    }
            //                }
            //            }
            //        }

            //        document = await context.OpenAsync("https://wildsoft.motorsport.com/drv.php?l=" + charForLink);
            //        var racerLinks = document.QuerySelectorAll("#links > div > a").ToList().Cast<IHtmlAnchorElement>().Select(m => m.Href).ToList();
            //        if (racerLinks.Count > 0)
            //        {
            //            foreach (var r in racerLinks)
            //            {
            //                document = await context.OpenAsync(r);
            //                string fn = document.QuerySelectorAll("#drv_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(2) > h1").First().InnerHtml;
            //                DateTime brn;
            //                try
            //                {
            //                    brn = DateTime.Parse(document.QuerySelectorAll("#drv_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(3) > table:nth-child(1) > tbody > tr:nth-child(1) > td:nth-child(2) > p").First().InnerHtml);
            //                }
            //                catch
            //                {
            //                    brn = new DateTime(1900, 1, 1);
            //                }
            //                if (repository.Racers.Count(a => a.FirstName == fn && a.Born == brn) == 0)
            //                {
            //                    Racer racer = new Racer();
            //                    string countryName = document.QuerySelectorAll("#drv_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(1) > p > img").First().Attributes[3].Value;
            //                    racer.Born = brn;
            //                    try
            //                    {
            //                        racer.BornIn = document.QuerySelectorAll("#drv_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(3) > table:nth-child(1) > tbody > tr:nth-child(1) > td:nth-child(3) > p").First().InnerHtml;
            //                    }
            //                    catch
            //                    {
            //                        racer.BornIn = "";
            //                    }
            //                    try
            //                    {
            //                        racer.Dead = DateTime.Parse(document.QuerySelectorAll("#drv_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(3) > table:nth-child(1) > tbody > tr:nth-child(2) > td:nth-child(2) > p").First().InnerHtml);
            //                        racer.DeadIn = document.QuerySelectorAll("#drv_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(3) > table:nth-child(1) > tbody > tr:nth-child(2) > td:nth-child(3) > p").First().InnerHtml;
            //                    }
            //                    catch
            //                    {
            //                        racer.DeadIn = "";
            //                    }
            //                    try
            //                    {
            //                        racer.IdCountry = repository.Countries.First(a => a.Name == countryName).Id;
            //                    }
            //                    catch
            //                    {
            //                        Country country = new Country { IdImage = getDefGuid, Name = countryName, NameRu = countryName };
            //                        repository.Countries.Add(country);
            //                        repository.SaveChanges();
            //                        Console.WriteLine("Add counrty: {0}", country.Name);
            //                        racer.IdCountry = country.Id;
            //                    }
            //                    racer.FirstName = fn;
            //                    racer.FirstNameRus = document.QuerySelectorAll("#drv_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(2) > h1").First().InnerHtml;
            //                    racer.SecondName = document.QuerySelectorAll("#drv_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(2) > h2").First().InnerHtml;
            //                    racer.SecondNameRus = document.QuerySelectorAll("#drv_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(2) > h2").First().InnerHtml;
            //                    racer.IdImage = new ImageParser("https://wildsoft.motorsport.com/" + document.QuerySelectorAll("#drv_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(1) > img").First().Attributes[0].Value, @"wwwroot/img/").SaveObject();
            //                    var texData = document.QuerySelectorAll("p.text_mb-5_i-10");
            //                    foreach (var d in texData)
            //                    {
            //                        racer.TextData += d.InnerHtml;
            //                    }
            //                    if (racer.TextData == null)
            //                        racer.TextData = "";
            //                    repository.Racers.Add(racer);
            //                    repository.SaveChanges();
            //                    Console.WriteLine("Add racet: {0}", racer.FirstNameRus);
            //                }
            //            }
            //        }
            //    }
            //}

            //document = await context.OpenAsync("https://wildsoft.motorsport.com/cir.php?id=0");
            //var trackLinks = document.QuerySelectorAll("#links > div > a").ToList().Cast<IHtmlAnchorElement>().Select(m => m.Href).ToList();
            //foreach (var t in trackLinks)
            //{
            //    document = await context.OpenAsync(t);
            //    string nameTrack = document.QuerySelectorAll("#cir_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(2) > h1").First().InnerHtml;
            //    if (repository.Tracks.Count(a => a.NameRus == nameTrack) == 0)
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
            //            Console.WriteLine("Add counrty: {0}", country.Name);
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

            //        Track track = new Track
            //        {
            //            IdCountry = countryTrack,
            //            IdImage = imgTrack,
            //            Name = nameTrackEng,
            //            NameRus = nameTrack
            //        };
            //        repository.Tracks.Add(track);
            //        repository.SaveChanges();
            //        Console.WriteLine("Add track: {0}", track.Name);
            //        Guid guidTrack = repository.Tracks.First(a => a.Name == nameTrackEng).Id;
            //        var confListImg = document.QuerySelectorAll("#cir_column_2 > table:nth-child(6) > tbody > tr > td:nth-child(1) > a > img");
            //        var confListDistance = document.QuerySelectorAll("#cir_column_2 > table:nth-child(6) > tbody > tr > td.cell_cla_br-rt:nth-child(2)");
            //        var confListPeriod = document.QuerySelectorAll("#cir_column_2 > table:nth-child(6) > tbody > tr > td.cell_cla_br-t");
            //        List<string> titlesImg = confListImg.Select(m => startPage + m.Attributes[0].Value).ToList();
            //        List<string> titlesDistance = confListDistance.Select(m => m.InnerHtml).ToList();
            //        List<string> titlesPeriod = confListPeriod.Select(m => m.TextContent).ToList();
            //        for (int j = 0; j < titlesImg.Count(); j++)
            //        {
            //            TrackСonfiguration trackConf = new TrackСonfiguration
            //            {
            //                IdImage = new ImageParser(titlesImg[j], folderImg).SaveObject(),
            //                IdTrack = guidTrack,
            //                Length = (float)Convert.ToDouble(titlesDistance[j].Replace(" ", "")),
            //                Note = titlesPeriod[j]
            //            };
            //            repository.TrackСonfigurations.Add(trackConf);
            //            repository.SaveChanges();
            //            Console.WriteLine("Add track conf: {0}", trackConf.Note);
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
            //    Nullable<Guid> tyreImgId = null;
            //    if (repository.Manufacturers.Count(a => a.Name == tyreName) == 0)
            //    {
            //        tyreImgId = new ImageParser(startPage + imgTyreLink, folderImg).SaveObject();
            //        Manufacturer manTyre = new Manufacturer { IdCountry = repository.Countries.First().Id, Name = tyreName, IdImage = tyreImgId.Value };
            //        repository.Manufacturers.Add(manTyre);
            //        repository.SaveChanges();
            //        Console.WriteLine("Add manufacturer: {0}", manTyre.Name);
            //    }
            //    if (repository.Tyres.Count(a => a.Name == tyreName) == 0)
            //    {
            //        if (tyreImgId.Value == null)
            //            tyreImgId = new ImageParser(startPage + imgTyreLink, folderImg).SaveObject();
            //        Tyre tyre = new Tyre { IdImage = tyreImgId.Value, IdManufacturer = repository.Manufacturers.First(a => a.Name == tyreName).Id, Name = tyreName };
            //        repository.Tyres.Add(tyre);
            //        repository.SaveChanges();
            //        Console.WriteLine("Add tyre: {0}", tyre.Name);
            //    }
            //}

            //for (int i = 2006; i < 2020; i++)
            //{
            //    Guid idSeason = repository.Seasons.First(a => a.Year == i).Id;
            //    document = await context.OpenAsync("https://wildsoft.motorsport.com/gp.php?y=" + i.ToString());
            //    var gpLinks = document.QuerySelectorAll("#links > div > a").ToList().Cast<IHtmlAnchorElement>().Select(m => m.Href).Where(m => m.Contains("https://wildsoft.motorsport.com/gp.php?gp=")).ToList();
            //    foreach (var g in gpLinks)
            //    {
            //        document = await context.OpenAsync(g);
            //        Guid idImage = new ImageParser(startPage + document.QuerySelectorAll("#gp_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(1) > img").First().Attributes[0].Value, folderImg).SaveObject();
            //        string hatDoc = document.QuerySelectorAll("#gp_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(2) > h1").First().TextContent;
            //        string ruGPName = hatDoc.Substring(hatDoc.IndexOf(". "));
            //        ruGPName = ruGPName.Substring(2, ruGPName.IndexOf(", ") - 2);
            //        var dategp = document.QuerySelectorAll("#gp_column_2 > table:nth-child(3) > tbody > tr > td:nth-child(3) > p").First().InnerHtml.ToString();
            //        dategp = dategp.Substring(dategp.IndexOf("кругов: ")).Replace("кругов: ", "");
            //        string dt = hatDoc.Substring(0, 10);
            //        int year = Convert.ToInt32(dt.Substring(6, 4));
            //        int month = Convert.ToInt32(dt.Substring(3, 2));
            //        int day = Convert.ToInt32(dt.Substring(0, 2));
            //        DateTime dateGp = new DateTime(year, month, day);
            //        string fullName = document.QuerySelectorAll("#gp_column_2 > table:nth-child(1) > tbody > tr > td:nth-child(2) > h3").First().InnerHtml;
            //        string trackRusName = hatDoc.Substring(hatDoc.IndexOf(",") + 2);
            //        Guid idTrackСonfiguration = repository.TrackСonfigurations.Where(a => a.Track.NameRus == trackRusName && a.Note.Contains(i.ToString())).First().Id;
            //        if (repository.GrandPrixes.Count(q => q.IdSeason == idSeason && q.Name == ruGPName && q.Date == dateGp) == 0)
            //        {
            //            GrandPrix grandPrix = new GrandPrix
            //            {
            //                FullName = fullName,
            //                IdSeason = idSeason,
            //                Number = repository.GrandPrixes.Count() + 1,
            //                NumberInSeason = repository.GrandPrixes.Count(a => a.IdSeason == idSeason) + 1,
            //                IdImage = idImage,
            //                Date = dateGp,
            //                IdTrackСonfiguration = idTrackСonfiguration,
            //                Name = ruGPName,
            //                NumberOfLap = Convert.ToInt32(dategp.Substring(0, dategp.IndexOf("<br>"))),
            //                PercentDistance = 0,
            //                Weather = dategp.Substring(dategp.IndexOf("м<br>") + 1).Replace("<br>", "")
            //            };
            //            repository.GrandPrixes.Add(grandPrix);
            //            repository.SaveChanges();
            //            Console.WriteLine(grandPrix.Number.ToString() + " - " + grandPrix.NumberInSeason.ToString() + " - " + i.ToString());
            //            var notesList = document.QuerySelectorAll("#gp_column_2 > p").ToList();
            //            foreach (var nt in notesList)
            //            {
            //                if (nt.TextContent == "" || nt.TextContent == " " || nt.TextContent == "Примечание: ")
            //                {
            //                }
            //                else
            //                {
            //                    GrandprixNote note = new GrandprixNote
            //                    {
            //                        IdGrandPrix = grandPrix.Id,
            //                        Note = nt.TextContent
            //                    };
            //                    repository.GrandprixNotes.Add(note);
            //                    repository.SaveChanges();
            //                    Console.WriteLine("Add nate: {0}", note.Note);
            //                }
            //            }
            //        }
            //    }
            //}


            //https://wildsoft.motorsport.com/gptable_be.php?y_be=1950&gp_be=1&t_be=c&drv_be=&cha_be=&eng_be=
            //l parcip
            //g st fiels
            //с classification
            //f bastL


            var gpList = repository.GrandPrixes.Include(a => a.Season).AsNoTracking().ToList();
            //foreach (var gp in gpList)
            //{
            //    string linkForParc = "https://wildsoft.motorsport.com/gptable_be.php?y_be=1900&gp_be=" + gp.Number.ToString() + "&t_be=l&drv_be=&cha_be=&eng_be=";
            //    document = await context.OpenAsync(linkForParc);
            //    var numList = document.QuerySelectorAll("#gp_column_2 > table > tbody > tr > td:nth-child(1)").ToList().Cast<IHtmlTableDataCellElement>().Where(m => m.InnerHtml != "<p><b>№</b></p>").Select(m => m.InnerHtml).ToList();
            //    var racerList = document.QuerySelectorAll("#gp_column_2 > table > tbody > tr > td:nth-child(4) > a").ToList().Cast<IHtmlAnchorElement>().Select(m => m.InnerHtml).ToList();
            //    var teamList = document.QuerySelectorAll("#gp_column_2 > table > tbody > tr > td:nth-child(5)").ToList().Cast<IHtmlTableDataCellElement>().Where(m => m.InnerHtml != "<p><b>Команда</b></p>").Select(m => m.InnerHtml).ToList();
            //    var chList = document.QuerySelectorAll("#gp_column_2 > table > tbody > tr > td:nth-child(6) > a").ToList().Cast<IHtmlAnchorElement>().Select(m => m.InnerHtml).ToList();
            //    var enList = document.QuerySelectorAll("#gp_column_2 > table > tbody > tr > td:nth-child(7) > a").ToList().Cast<IHtmlAnchorElement>().Select(m => m.InnerHtml).ToList();
            //    var tyreList = document.QuerySelectorAll("#gp_column_2 > table > tbody > tr > td:nth-child(8) > a").ToList().Cast<IHtmlAnchorElement>().Select(m => m.InnerHtml).ToList();
            //    int columns = racerList.Count();
            //    for (int l = 0; l < columns; l++)
            //    {
            //        if (racerList[l] != "")
            //        {
            //            Guid IdTeam = repository.Teams.First(a => a.Name == teamList[l]).Id;
            //            Guid IdChassis = repository.Chassis.First(a => a.Name == chList[l]).Id;
            //            Guid IdEngine = repository.Engines.First(a => a.Name == enList[l].TrimEnd(' ')).Id;
            //            Guid IdRacer = repository.Racers.First(a => a.FirstName == racerList[l]).Id;
            //            Guid IdTyre;
            //            try
            //            {
            //                IdTyre = repository.Tyres.First(a => a.Name == tyreList[l]).Id;
            //            }
            //            catch
            //            {
            //                IdTyre = Guid.Parse("884bdf24-0829-46d8-b259-a14d8d30e556");
            //            }
            //            Participant participant = new Participant
            //            {
            //                IdGrandPrix = gp.Id,
            //                Number = numList[l],
            //                IdTeam = IdTeam,
            //                IdChassis = IdChassis,
            //                IdEngine = IdEngine,
            //                IdRacer = IdRacer,
            //                IdTyre = IdTyre,
            //            };
            //            repository.Participants.Add(participant);
            //            repository.SaveChanges();
            //            Console.WriteLine(gp.Season.Year + " - " + gp.Number + " - " + participant.Id);
            //        }
            //    }
            //}

            gpList = repository.GrandPrixes.Include(a => a.Season)
                .AsNoTracking()
                //.Where(a => a.Number > 551)
                .ToList();
            //char[] trimChars = { ' ', 'q', 'Q', 'w','W', 'E', 'e', 'R', 'r', 'T', 't', 'Y', 'y', 'U', 'u', 'I', 'i', 'O', 'o', 'P', 'p', 'a', 'A',
            //    'S', 's', 'D', 'd', 'F', 'f', 'G', 'g', 'H', 'h', 'J', 'j', 'K', 'k', 'L', 'Z', 'l', 'z', 'X', 'x', 'C', 'c', 'V', 'v', 'B', 'b', 'N', 'n', 'M', 'm' };
            //foreach (var gp in gpList)
            //{
            //    string linkForParc = "https://wildsoft.motorsport.com/gptable_be.php?y_be=1900&gp_be=" + gp.Number.ToString() + "&t_be=g&drv_be=&cha_be=&eng_be=";
            //    document = await context.OpenAsync(linkForParc);
            //    var numList = document.QuerySelectorAll("#gp_column_2 > center > table > tbody > tr > td > p").ToList().Cast<IHtmlParagraphElement>().Select(m => m.TextContent).ToList();
            //    foreach(var qua in numList)
            //    {
            //        if (qua != "")
            //        {
            //            if (qua != "*")
            //            {
            //                if (qua != " ")
            //                {
            //                    string time = "No time";
            //                    try
            //                    {
            //                        time = qua.Substring(qua.IndexOf("'") - 1);
            //                    }
            //                    catch
            //                    {

            //                    }
            //                    string dataQue = qua;
            //                    dataQue = dataQue.Substring(dataQue.IndexOf("  ") + 2);
            //                    string fl = dataQue.Substring(0, 1);
            //                    string shortName = "";
            //                    try
            //                    {
            //                        shortName = dataQue.Substring(dataQue.IndexOf(".") + 1, dataQue.IndexOf(" "));
            //                        shortName = shortName.Substring(0, shortName.IndexOf(" "));
            //                    }
            //                    catch
            //                    {
            //                        shortName = dataQue.Substring(dataQue.IndexOf(".") + 1);
            //                    }
            //                    shortName = shortName.Trim(trimChars);
            //                    while (repository.Participants.AsNoTracking().Count(a => a.IdGrandPrix == gp.Id && a.Racer.FirstName.Contains(shortName)) == 0)
            //                    {
            //                        if (shortName == "7" || shortName == "3")
            //                        {
            //                            shortName = "Джеки";
            //                        }
            //                        else
            //                        {
            //                            shortName = shortName.Substring(0, shortName.Length - 2);
            //                        }
            //                    }
            //                    var parc = repository.Participants.AsNoTracking().First(a => a.IdGrandPrix == gp.Id && a.Racer.FirstName.Contains(shortName));
            //                    Qualification qualification = new Qualification
            //                    {
            //                        IdParticipant = parc.Id,
            //                        Points = 0,
            //                        Position = 0,
            //                        Time = time
            //                    };
            //                    repository.Qualifications.Add(qualification);
            //                    repository.SaveChanges();
            //                    Console.WriteLine(time);
            //                }
            //            }
            //        }
            //    }
            //}

            gpList = repository.GrandPrixes
                .AsNoTracking()
                .Include(a => a.Season)
                .ToList();
            foreach (var gp in gpList)
            {
                string linkForParc = "https://wildsoft.motorsport.com/gptable_be.php?y_be=1900&gp_be=" + gp.Number.ToString() + "&t_be=c&drv_be=&cha_be=&eng_be=";
                document = await context.OpenAsync(linkForParc);

                //#gp_column_2 > table > tbody > tr:nth-child(2) > td:nth-child(1)
                //#gp_column_2 > table > tbody > tr:nth-child(11) > td:nth-child(1)

                //#gp_column_2 > table > tbody > tr:nth-child(2) > td:nth-child(9)
                //#gp_column_2 > table > tbody > tr:nth-child(11) > td:nth-child(8)
                var resList = document.QuerySelectorAll("#gp_column_2 > table > tbody > tr > td").ToList().Cast<IHtmlTableDataCellElement>().Select(m => m.TextContent).ToList();
                GrandPrixResult result = new GrandPrixResult { 
                    IdParticipant = Guid.NewGuid(), 
                    Lap = 0, 
                    Points = 0, 
                    Position = 0, 
                    Time = "" 
                };


            }

            Console.ReadKey();
        }
    }

    public class ImageParser
    {
        private string link;
        private string folder;
        RepositoryParcer repository;

        public ImageParser(string link, string folder)
        {
            this.link = link;
            this.folder = folder;
            repository = new RepositoryParcer();
        }
        public Guid SaveObject()
        {
            System.String controlPath = Path.GetFileName(link);
            if (repository.Images.Count(c => c.Link == folder + controlPath) > 0)
                controlPath = Guid.NewGuid().ToString() + Path.GetFileName(link);
            WebClient godLikeClient = new WebClient();
            godLikeClient.DownloadFile(link, Path.Combine(@"C:\Users\Zianon\source\repos\SFP\ParserApp\" + folder, controlPath));
            Image image = new Image();
            image.Link = folder + controlPath;
            repository.Images.Add(image);
            repository.SaveChanges();
            return image.Id;
        }
    }
}


//1       2       Нино Фарина	Alfa Romeo	70	2:13'23.6	146.4	9	
//2       3       Луиджи Фаджиоли	Alfa Romeo	70	2:13'26.2	146.3	6	
//3       4       Редж Парнелл	Alfa Romeo	70	2:14'15.6	145.4	4	
//4       14      Ив Жиро-Кабанту	Talbot-Lago	68	2:13'25.0	142.2	3	
//5       15      Луи Розье	Talbot-Lago	68	2:14'28.4	141.1	2	
//6       12      Боб Джерард	ERA	67	2:13'26.4	140.1		
//7       11      Кат Харрисон	ERA	67	2:13'26.8	140.1		
//8       16      Филип Этанселен	Talbot-Lago	65	2:14'30.6	134.8		
//9       6       Дэвид Хемпшир	Maserati	64	2:14'03.6	133.2		
//10      10 = Maserati    64  2:15'00.4	132.2		

//    Джо Фрай		45				Отдал автомобиль Шоуи-Тэйлору
//	Брайан Шоуи-Тэйлор		19				Взял автомобиль Фрая
//11		18		Джонни Клэз	Talbot-Lago	64	2:15'28.6	131.8		
//нф 1       Хуан - Мануэль Фанхио Alfa Romeo	62				Маслопровод
//нк	23		Джо Келли	Alta	57				
//нф	21		Принц Бира	Maserati	49				Впрыск топлива
//нф	5		Дэвид Марри	Maserati	44				Двигатель
//нф	24		Джеф Кроссли	Alta	43				Трансмиссия
//нф	20		Туло де Граффенрид	Maserati	36				Двигатель / шатун
//нф	19		Луи Широн	Maserati	24				Утечка масла / сцепление
//нф	17		Эжен Мартен	Talbot-Lago	8				Давление масла / двигатель
//нф	9	=		ERA	5				Коробка передач
//	Питер Уокер		2				Отдал автомобиль Ролту
//	Тони Ролт		3				Взял автомобиль Уокера / коробка передач
//нф	8		Лесли Джонсон	ERA	2				Нагнетатель турбонаддува