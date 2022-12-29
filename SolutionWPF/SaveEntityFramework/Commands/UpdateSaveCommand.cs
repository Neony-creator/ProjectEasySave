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
    public class UpdateSaveCommand : IUpdateSaveCommand
    {
        private readonly SavesDbContextFactory _contextFactory;

        public UpdateSaveCommand(SavesDbContextFactory contextFactory)
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
                context.Saves.Update(saveDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
