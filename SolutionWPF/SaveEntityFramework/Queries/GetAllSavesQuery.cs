using Microsoft.EntityFrameworkCore;
using SaveDomain.Models;
using SaveDomain.Queries;
using SaveEntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveEntityFramework.Queries
{
    public class GetAllSavesQuery : IGetAllSavesQuery
    {
        private readonly SavesDbContextFactory _contextFactory;

        public GetAllSavesQuery(SavesDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Save>> Execute()
        {
            using(SavesDbContext context = _contextFactory.Create())
            {
                IEnumerable<SaveDto> saveDtos = await context.Saves.ToListAsync();
                return saveDtos.Select(y => new Save(y.Id, y.SaveName, y.SourceDisplay, y.DestinationDisplay, y.TypeDisplay));
            }
        }
    }
}
