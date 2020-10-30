using AngleSharp;
using AngleSharp.Dom;
using Entities.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ParserApp
{
    public class StartPage
    {
        public async Task GetTyresGpsCountriesTracksYears()
        {
            string countryOuterHtml = "cnt.php?id=";
            string gpYearOuterHtml = "gp.php?y=";

            IConfiguration config = Configuration.Default.WithDefaultLoader();
            string indexLink = "https://wildsoft.motorsport.com/";
            IBrowsingContext context = BrowsingContext.New(config);
            IDocument document = await context.OpenAsync(indexLink);
            var optionSelector = "option";

            var countryDMO = document.QuerySelectorAll(optionSelector).Where(a => a.OuterHtml.Contains(countryOuterHtml)).ToList();
            var gpYearDMO = document.QuerySelectorAll(optionSelector).Where(a => a.OuterHtml.Contains(gpYearOuterHtml)).ToList();
            
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
