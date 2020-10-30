using AngleSharp.Dom;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParserApp
{
    public class SeasonsParser
    {
        public SeasonsParser(List<IElement> gpYearDMO)
        {
            using (var repository = new RepositoryParcer())
            {
                foreach (var data in gpYearDMO)
                {
                    if (repository.Seasons.Count(a => a.Year == Convert.ToInt32(data.InnerHtml)) == 0)
                    {
                        Season season = new Season
                        {
                            IdImage = Guid.Parse("7785471e-79af-4892-bd56-07ea29f5e8a2"),
                            Year = Convert.ToInt32(data.InnerHtml),
                            IdTypeCalculate = Guid.Parse("0285471e-79af-4892-bd56-07ea29f5e8a2")
                        };
                        repository.Seasons.Add(season);
                        repository.SaveChanges();
                    }
                }
            }
        }
    }
}
