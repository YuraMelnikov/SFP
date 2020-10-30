using AngleSharp.Dom;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParserApp
{
    public class CountriesParser
    {
        public CountriesParser(List<IElement> countryDMO)
        {
            using (var repository = new RepositoryParcer())
            {
                foreach (var data in countryDMO)
                {
                    if (repository.Countries.Count(a => a.Name == data.InnerHtml) == 0)
                    {
                        Country country = new Country
                        {
                            Name = data.InnerHtml,
                            IdImage = Guid.Parse("7785471e-79af-4892-bd56-07ea29f5e8a2")
                        };
                        repository.Countries.Add(country);
                        repository.SaveChanges();
                    }
                }
            }
        }
    }
}
