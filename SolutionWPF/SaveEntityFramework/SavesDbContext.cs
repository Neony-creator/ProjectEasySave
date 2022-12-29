using Microsoft.EntityFrameworkCore;
using SaveEntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveEntityFramework
{
    public class SavesDbContext : DbContext 
    {
        public SavesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SaveDto> Saves { get; set; }
    }
}
