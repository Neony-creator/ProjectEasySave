using SaveDomain.Commands;
using SaveDomain.Models;
using SaveEntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveEntityFramework.Commands
{
    public class CreateSaveCommand : ICreateSaveCommand
    {
        private readonly SavesDbContextFactory _contextFactory;

        public CreateSaveCommand(SavesDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Save save)
        {
            using (SavesDbContext context = _contextFactory.Create())
            {
                SaveDto saveDto = new SaveDto()
                {
                    Id = save.Id,
                    SaveName = save.SaveName,
                    SourceDisplay = save.SourceDisplay,
                    DestinationDisplay = save.DestinationDisplay,
                    TypeDisplay = save.TypeDisplay,
                };
                context.Saves.Add(saveDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
