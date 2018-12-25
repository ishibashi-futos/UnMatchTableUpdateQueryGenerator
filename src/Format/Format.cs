using System;

namespace Format
{
    public class FileFormat
    {
        public string FileName { get; set; }
        public string Separator { get; set; }
        public string Delimiter { get; set; }
        public string Encoding { get; set; }
        public enum fileType {NEW, OLD}

    }
}
