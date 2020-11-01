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
            foreach (var data in chassies)
            {
                string name = data.Attributes[0].Value;
                if (repository.Engines.Count(a => a.Name == name && a.IdManufacturer == manufacturingId) == 0)
                {
                    Engine engine = new Engine
                    {
                        IdManufacturer = manufacturingId,
                        Name = data.Attributes[0].Value,
                        IdImage = Guid.Parse("7785471e-79af-4892-bd56-07ea29f5e8a2")
                    };
                    //repository.Engines.Add(engine);
                    //repository.SaveChanges();
                }
            }
        }
    }
}
