using System;
using System.Collections.Generic;
using Entities.Models;
using System.Linq;
using AngleSharp.Dom;
using AngleSharp;

namespace ParserApp
{
    public class ManufacturingParcer
    {
        public List<ManufacturersLink> manufacturersLinks;
        public ManufacturingParcer(List<IElement> countryDMO)
        {
            manufacturersLinks = new List<ManufacturersLink>();
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
                            IdCountry = Guid.Parse("a818b6b6-cae5-455e-9989-bfacd20d0000"),
                            Name = name,
                            IdImage = new ImageParser(imgLink, folder).SaveObject()
                        };
                        repository.Manufacturers.Add(manufacturer);
                        repository.SaveChanges();
                        string linkChassies = "https://wildsoft.motorsport.com/" + data.Attributes[0].Value;
                        manufacturersLinks.Add(new ManufacturersLink { Id = manufacturer.Id, Link = linkChassies });
                    }
                }
            }
        }
    }
}
