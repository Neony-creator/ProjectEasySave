using SaveDomain.Commands;
using SaveEntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveEntityFramework.Commands
{
    public class DeleteSaveCommand : IDeleteSaveCommand 
    {
        private readonly SavesDbContextFactory _contextFactory;

        public DeleteSaveCommand(SavesDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Guid id)
        {
            using (SavesDbContext context = _contextFactory.Create())
            {
                SaveDto saveDto = new SaveDto()
                {
                    Id = id,
                };
                context.Saves.Remove(saveDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
