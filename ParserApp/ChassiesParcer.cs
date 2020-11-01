using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using Entities.Models;
using System.Linq;

namespace ParserApp
{
    public class ChassiesParcer
    {
        private readonly string folder = @"wwwroot/livery/";
        RepositoryParcer repository;

        public ChassiesParcer(List<IElement> chassies, Guid manufacturingId)
        {
            repository = new RepositoryParcer();
            foreach (var data in chassies)
            {
                Guid imgLink = Guid.Parse("7785471e-79af-4892-bd56-07ea29f5e8a2");
                string name = data.Attributes[0].Value;
                if(repository.Chassis.Count(a => a.Name == name && a.IdManufacturer == manufacturingId) == 0)
                {
                    try
                    {
                        string liveryLink = "https://wildsoft.motorsport.com/" + data.ParentElement.Children[1].Attributes[0].Value;
                        imgLink = new ImageParser(liveryLink, folder).SaveObject();
                    }
                    catch
                    {

                    }
                    Chassis chassis = new Chassis
                    {
                        IdManufacturer = manufacturingId,
                        Name = data.Attributes[0].Value,
                        IdImage = imgLink,
                        IdLivery = imgLink
                    };
                    repository.Chassis.Add(chassis);
                    repository.SaveChanges();
                }

            }
        }
    }
}
