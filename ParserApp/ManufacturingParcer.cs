using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Entities.Models;
using System.Linq;
using AngleSharp.Dom;

namespace ParserApp
{
    public class ManufacturingParcer
    {
        public ManufacturingParcer(List<IElement> countryDMO)
        {
            using (var repository = new RepositoryParcer())
            {
                string folder = @"wwwroot/img/";
                foreach (var data in countryDMO)
                {
                    string name = data.Text().Replace("   ", "");
                    if (repository.Manufacturers.Count(a => a.Name == name) == 0)
                    {

                        string imgLink = "https://wildsoft.motorsport.com/" + data.Children[0].Attributes[0].Value.ToString().Replace(" / small", "");
                        Manufacturer manufacturer = new Manufacturer
                        {
                            IdCountry = Guid.Parse("693d467c-16c7-4b15-86e9-5780daa398f4"),
                            Name = name,
                            IdImage = new ImageParser(imgLink, folder).SaveObject()
                        };
                        ////repository.Countries.Add(country);
                        ////repository.SaveChanges();
                        ///
                    }
                }
            }
        }
    }
}
