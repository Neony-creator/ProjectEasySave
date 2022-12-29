using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveEntityFramework
{
    public class SavesDesignTimeDbContextFactory : IDesignTimeDbContextFactory<SavesDbContext>
    {


        public SavesDbContext CreateDbContext(string[] args=null)
        {
            return new SavesDbContext(new DbContextOptionsBuilder().UseSqlite("Data Source=Saves.db").Options);
        }
    }
}
