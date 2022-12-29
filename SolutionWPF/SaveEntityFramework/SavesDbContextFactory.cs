using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveEntityFramework
{
    public class SavesDbContextFactory
    {
        
        private readonly DbContextOptions _options;

        public SavesDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public SavesDbContext Create()
        {
            return new SavesDbContext(_options);
        }
    }
}
