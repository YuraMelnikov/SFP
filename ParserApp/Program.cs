using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Entities.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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

            //gpList = repository.GrandPrixes.AsNoTracking().Include(a => a.Season)
            //    .ToList();
            //foreach (var gp in gpList)
            //{
            //    string linkForParc = "https://wildsoft.motorsport.com/gptable_be.php?y_be=1900&gp_be=" + gp.Number.ToString() + "&t_be=c&drv_be=&cha_be=&eng_be=";
            //    document = await context.OpenAsync(linkForParc);
            //    var tdPosition = document.QuerySelectorAll("#gp_column_2 > table > tbody > tr > td:nth-child(1)").ToList().Cast<IHtmlTableDataCellElement>().Select(m => m.TextContent).ToList();
            //    var tdClassification = document.QuerySelectorAll("#gp_column_2 > table > tbody > tr > td:nth-child(2)").ToList().Cast<IHtmlTableDataCellElement>().Select(m => m.TextContent).ToList();
            //    var tdNumber = document.QuerySelectorAll("#gp_column_2 > table > tbody > tr > td:nth-child(3)").ToList().Cast<IHtmlTableDataCellElement>().Select(m => m.TextContent).ToList();
            //    var tdFlag = document.QuerySelectorAll("#gp_column_2 > table > tbody > tr > td:nth-child(4)").ToList().Cast<IHtmlTableDataCellElement>().Select(m => m.TextContent).ToList();
            //    var tdRacer = document.QuerySelectorAll("#gp_column_2 > table > tbody > tr > td:nth-child(5)").ToList().Cast<IHtmlTableDataCellElement>().Select(m => m.TextContent).ToList();
            //    var tdLap = document.QuerySelectorAll("#gp_column_2 > table > tbody > tr > td:nth-child(7)").ToList().Cast<IHtmlTableDataCellElement>().Select(m => m.TextContent).ToList();
            //    var tdTime = document.QuerySelectorAll("#gp_column_2 > table > tbody > tr > td:nth-child(8)").ToList().Cast<IHtmlTableDataCellElement>().Select(m => m.TextContent).ToList();
            //    var tdAverageSpeed = document.QuerySelectorAll("#gp_column_2 > table > tbody > tr > td:nth-child(9)").ToList().Cast<IHtmlTableDataCellElement>().Select(m => m.TextContent).ToList();
            //    var tdPoints = document.QuerySelectorAll("#gp_column_2 > table > tbody > tr > td:nth-child(10)").ToList().Cast<IHtmlTableDataCellElement>().Select(m => m.TextContent).ToList();
            //    var tdNote = document.QuerySelectorAll("#gp_column_2 > table > tbody > tr > td:nth-child(11)").ToList().Cast<IHtmlTableDataCellElement>().Select(m => m.TextContent).ToList();
            //    int countTd = tdNote.Count;
            //    int posDouble = 0;
            //    string stateDouble = "";
            //    string timeDouble = "";
            //    string avsDouble = "";
            //    bool boolDouble = false;
            //    Guid IdParticipant;
            //    int? Position;
            //    string Classification;
            //    int? Lap;
            //    string Time;
            //    string AverageSpeed;
            //    float Points;
            //    string Note;
            //    for (int i = 1; i < countTd; i++)
            //    {
            //        if((tdPosition[i] + tdClassification[i] + tdRacer[i]).Replace(" ", "") != "")
            //        {
            //            tdRacer[i] = tdRacer[i].Replace("*", "").Trim(' ');
            //            if (tdFlag[i] == "=")
            //            {
            //                boolDouble = true;
            //                try
            //                {
            //                    posDouble = Convert.ToInt32(tdPosition[i]);
            //                }
            //                catch
            //                {
            //                    posDouble = 0;
            //                }
            //                avsDouble = tdAverageSpeed[i];
            //                timeDouble = tdTime[i];
            //                stateDouble = tdClassification[i];
            //            }
            //            else
            //            {
            //                if (tdPosition[i] != "")
            //                    boolDouble = false;
            //                if (tdClassification[i] != "")
            //                    boolDouble = false;
            //                if (boolDouble == true)
            //                {
            //                    if (posDouble != 0)
            //                    {
            //                        IdParticipant = repository.Participants.Include(a => a.Racer).First(a => a.Racer.FirstName == tdRacer[i].Replace("* ", "") && a.IdGrandPrix == gp.Id).Id;
            //                        Position = posDouble;
            //                        Classification = stateDouble;
            //                        if (tdLap[i] == "")
            //                            Lap = null;
            //                        else
            //                            Lap = Convert.ToInt32(tdLap[i]);
            //                        Time = timeDouble;
            //                        AverageSpeed = avsDouble;
            //                        Points = 0f;
            //                        if (tdPoints[i] != "")
            //                            Points = (float)Convert.ToDouble(tdPoints[i].Replace("(", "").Replace(")", ""));
            //                        Note = tdNote[i];
            //                    }
            //                    else
            //                    {
            //                        IdParticipant = repository.Participants.Include(a => a.Racer).First(a => a.Racer.FirstName == tdRacer[i] && a.IdGrandPrix == gp.Id).Id;
            //                        Position = 0;
            //                        Classification = stateDouble;
            //                        if (tdLap[i] == "")
            //                            Lap = null;
            //                        else
            //                            Lap = Convert.ToInt32(tdLap[i]);
            //                        Time = timeDouble;
            //                        AverageSpeed = avsDouble;
            //                        Points = 0f;
            //                        if (tdPoints[i] != "")
            //                            Points = (float)Convert.ToDouble(tdPoints[i].Replace("(", "").Replace(")", ""));
            //                        Note = tdNote[i];
            //                    }
            //                }
            //                else
            //                {
            //                    boolDouble = false;
            //                    posDouble = 0;
            //                    stateDouble = "";
            //                    timeDouble = "";
            //                    avsDouble = "";
            //                    IdParticipant = repository.Participants.Include(a => a.Racer).First(a => a.Racer.FirstName == tdRacer[i] && a.IdGrandPrix == gp.Id).Id;
            //                    if (tdPosition[i] == "")
            //                        Position = null;
            //                    else
            //                        Position = Convert.ToInt32(tdPosition[i]);
            //                    Classification = tdClassification[i];
            //                    if (tdLap[i] == "")
            //                        Lap = null;
            //                    else
            //                        Lap = Convert.ToInt32(tdLap[i]);
            //                    Time = tdTime[i];
            //                    AverageSpeed = tdAverageSpeed[i];
            //                    Points = 0f;
            //                    if (tdPoints[i] != "")
            //                        Points = (float)Convert.ToDouble(tdPoints[i].Replace("(", "").Replace(")", ""));
            //                    Note = tdNote[i];
            //                }
            //                GrandPrixResult result = new GrandPrixResult
            //                {
            //                    IdParticipant = IdParticipant,
            //                    Position = Position,
            //                    Classification = Classification,
            //                    Lap = Lap,
            //                    Time = Time,
            //                    AverageSpeed = AverageSpeed,
            //                    Points = Points,
            //                    Note = Note
            //                };
            //                repository.GrandPrixResults.Add(result);
            //                repository.SaveChanges();
            //                Console.WriteLine(String.Format("{0,3:" + "}", Position.ToString()) + " | " + String.Format("{0,3:" + "}", Classification) + " | " + String.Format("{0,25:" + "}", tdRacer[i]) + " | " + String.Format("{0,3:" + "}", Lap.ToString()) + " | " + String.Format("{0,10:" + "}", AverageSpeed) + " | " + String.Format("{0,3:" + "}", Points) + " | " + Note);
            //            }
            //        }
            //        else
            //        {
            //        }
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}

            //gpList = repository.GrandPrixes.AsNoTracking().Include(a => a.Season).ToList();
            //foreach (var gp in gpList)
            //{
            //    string linkForParc = "https://wildsoft.motorsport.com/gptable_be.php?y_be=1900&gp_be=" + gp.Number.ToString() + "&t_be=f&drv_be=&cha_be=&eng_be=";
            //    document = await context.OpenAsync(linkForParc);
            //    var tdflRacer = document.QuerySelectorAll("#gp_column_2 > table > tbody > tr > td:nth-child(4)").ToList().Cast<IHtmlTableDataCellElement>().Select(m => m.TextContent).ToList();
            //    var tdflTime = document.QuerySelectorAll("#gp_column_2 > table > tbody > tr > td:nth-child(7)").ToList().Cast<IHtmlTableDataCellElement>().Select(m => m.TextContent).ToList();
            //    var tdflSpeed = document.QuerySelectorAll("#gp_column_2 > table > tbody > tr > td:nth-child(10)").ToList().Cast<IHtmlTableDataCellElement>().Select(m => m.TextContent).ToList();
            //    bool contract = false;
            //    for (int i = 0; i < tdflRacer.Count; i++)
            //    {
            //        try
            //        {
            //            Guid pacipiandId = repository.Participants
            //                .AsNoTracking()
            //                .Include(a => a.Racer)
            //                .First(a => a.IdGrandPrix == gp.Id && a.Racer.FirstName == tdflRacer[i])
            //                .Id;
            //            FastLap fastLap = new FastLap();
            //            fastLap.IdParticipant = pacipiandId;
            //            fastLap.Time = tdflTime[i];
            //            fastLap.AverageSpeed = tdflSpeed[i];
            //            repository.FastLaps.Add(fastLap);
            //            repository.SaveChanges();
            //            contract = true;
            //            break;
            //        }
            //        catch 
            //        {
            //        }
            //    }
            //}

            //gpList = repository.GrandPrixes.AsNoTracking().Include(a => a.Season).ToList();
            //char[] trimLLChars = { '-', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            //foreach (var gp in gpList)
            //{
            //    string linkForParc = "https://wildsoft.motorsport.com/gptable_be.php?y_be=1900&gp_be=" + gp.Number.ToString() + "&t_be=c&drv_be=&cha_be=&eng_be=";
            //    document = await context.OpenAsync(linkForParc);
            //    var leaderLaps = document.QuerySelectorAll("#gp_column_2 > table > tbody > tr > td:nth-child(3) > table > tbody > tr").ToList().Cast<IHtmlTableRowElement>().Select(m => m.TextContent).ToList();
            //    bool control = false;
            //    for (int i = 0; i < leaderLaps.Count; i++)
            //    {
            //        try
            //        {
            //            Guid guidLapParcipiat = repository.Participants.AsNoTracking().Include(a => a.Racer).First(a => a.IdGrandPrix == gp.Id && a.Racer.FirstName == leaderLaps[i].Trim(trimLLChars)).Id;
            //            int first = 0;
            //            int last = 0;
            //            string racerTrim = leaderLaps[i].Trim(trimLLChars);
            //            try
            //            {
            //                string tmp1 = leaderLaps[i].Replace(racerTrim, "");
            //                first = Convert.ToInt32(leaderLaps[i].Substring(0, leaderLaps[i].IndexOf("-")));
            //                last = Convert.ToInt32(tmp1.Substring(leaderLaps[i].IndexOf("-") + 1));
            //            }
            //            catch
            //            {
            //                first = Convert.ToInt32(leaderLaps[i].Replace(racerTrim, ""));
            //                last = first;
            //            }
            //            LeaderLap lap = new LeaderLap();
            //            lap.IdParticipant = guidLapParcipiat;
            //            lap.First = first;
            //            lap.Last = last;
            //            repository.LeaderLaps.Add(lap);
            //            repository.SaveChanges();
            //            control = true;
            //        }
            //        catch
            //        {
            //        }
            //    }
            //    Console.WriteLine(gp.Number.ToString() + " - " + control);
            //}

            var listGP = repository.GrandPrixes.AsNoTracking().Where(a => a.Number > 338).ToList();
            foreach (var gp in listGP)
            {
                int i = 1;
                var quaList = repository.Qualifications
                    .Include(a => a.Participant)
                    .Where(a => a.Participant.IdGrandPrix == gp.Id)
                    .OrderBy(a => a.Time)
                    .ToList();
                foreach (var qua in quaList)
                {
                    qua.Position = i;
                    repository.Entry(qua).State = EntityState.Modified;
                    repository.SaveChanges();
                    i++;
                }
                Console.WriteLine(gp.Id.ToString() + " - " + gp.Number.ToString());
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