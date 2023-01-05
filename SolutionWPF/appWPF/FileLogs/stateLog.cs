using System;
using System.Collections.Generic;
using System.Text;

namespace appWPF
{
    public class stateLog
    {
        public string backUpName { get; set; }
        public string timeStamp { get; set; }
        public string state { get; set; }
        public string totalNumberOfFile { get; set; }
        public long totalSize { get; set; }
        public int totalNumberOfFileRemaining { get; set; }
        public long sizeRemaining { get; set; }
        public string sourcePath { get; set; }
        public string destinationPath { get; set; }

    }
}
