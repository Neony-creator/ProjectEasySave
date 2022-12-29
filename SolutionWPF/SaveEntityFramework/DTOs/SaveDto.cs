using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveEntityFramework.DTOs
{
    public class SaveDto
    {

        public Guid Id { get; set; }
        public string SaveName { get; set; }
        public string SourceDisplay { get; set; }
        public string DestinationDisplay { get; set; }
        public string TypeDisplay { get; set; }
    }
}
