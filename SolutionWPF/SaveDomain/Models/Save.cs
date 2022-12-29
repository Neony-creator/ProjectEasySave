using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDomain.Models
{
    public class Save
    {
        public Guid Id { get; }
        public string SaveName { get; }
        public string SourceDisplay { get; }
        public string DestinationDisplay { get; }
        public string TypeDisplay { get; }

        public Save(Guid id, string savename, string sourceDisplay, string destinationDisplay, string typeDisplay)
        {
            Id = id;
            SaveName = savename;
            SourceDisplay = sourceDisplay;
            DestinationDisplay = destinationDisplay;
            TypeDisplay = typeDisplay;
        }
    }
}
