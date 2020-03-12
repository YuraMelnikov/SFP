﻿using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class TeamRepository : RepositoryBase<Team>, ITeamRepository
    {
        public TeamRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateTeam(Team team) =>
            Create(team);

        public void DeleteTeam(Team team) =>
            Delete(team);

        public async Task<IEnumerable<Team>> GetAllTeamAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.ShortName)
            .ToListAsync();

        public async Task<Team> GetTeamAsync(Guid teamId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(teamId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
