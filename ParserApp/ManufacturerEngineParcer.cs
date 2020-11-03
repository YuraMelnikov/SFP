using AngleSharp.Dom;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParserApp
{
    public class ManufacturerEngineParcer
    {
        public List<ManufacturersLink> manufacturersLinks;
        public ManufacturerEngineParcer(List<IElement> listElements)
        {
            manufacturersLinks = new List<ManufacturersLink>();
            using (var repository = new RepositoryParcer())
            {
                foreach (var data in listElements)
                {
                    string name = data.Text().Replace("   ", "");
                    string link = "https://wildsoft.motorsport.com/" + data.Attributes[0].Value;
                    if (repository.Manufacturers.Count(a => a.Name == name) == 0)
                    {
                        Manufacturer manufacturer = new Manufacturer
                        {
                            IdCountry = Guid.Parse("a818b6b6-cae5-455e-9989-bfacd20d0000"),
                            Name = name,
                            IdImage = Guid.Parse("7785471e-79af-4892-bd56-07ea29f5e8a2")
                        };
                        repository.Manufacturers.Add(manufacturer);
                        repository.SaveChanges();
                        manufacturersLinks.Add(new ManufacturersLink { Id = manufacturer.Id, Link = link });
                    }
                    else
                    {
                        var man = repository.Manufacturers.First(a => a.Name == name);
                        manufacturersLinks.Add(new ManufacturersLink { Id = man.Id, Link = link });
                    }
                }
            }
        }
    }
}
