using AngleSharp.Dom;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParserApp
{
    public class EngineParcer
    {
        RepositoryParcer repository;

        public EngineParcer(List<IElement> chassies, Guid manufacturingId)
        {
            repository = new RepositoryParcer();
            int count = chassies.Count;
            for (int i = 1; i < count; i += 3)
            {
                string name = chassies[i].InnerHtml;

                //trouble concat td AlfRom
                if (repository.Engines.Count(a => a.Name == name && a.IdManufacturer == manufacturingId) == 0)
                {
                    Engine engine = new Engine
                    {
                        IdManufacturer = manufacturingId,
                        Name = name,
                        IdImage = Guid.Parse("7785471e-79af-4892-bd56-07ea29f5e8a2")
                    };
                    //repository.Engines.Add(engine);
                    //repository.SaveChanges();
                }
            }



            foreach (var data in chassies)
            {

            }
        }
    }
}
