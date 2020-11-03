using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParserApp
{
    public class EngineParcer
    {
        RepositoryParcer repository;

        public EngineParcer(IEnumerable<string> chassies, Guid manufacturingId)
        {
            repository = new RepositoryParcer();
            foreach (var data in chassies)
            {
                if(repository.Engines.Count(a => a.Name == data && a.IdManufacturer == manufacturingId) == 0)
                {
                    Engine engine = new Engine
                    {
                        IdManufacturer = manufacturingId,
                        Name = data,
                        IdImage = Guid.Parse("7785471e-79af-4892-bd56-07ea29f5e8a2")
                    };
                    repository.Engines.Add(engine);
                    repository.SaveChanges();
                }
            }
        }
    }
}
