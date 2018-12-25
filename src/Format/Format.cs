using System;

namespace Format
{
    public class FileFormat
    {
        public string FileName { get; set; }
        public char Separator { get; set; }
        public string Delimiter { get; set; }
        public string Encoding { get; set; }
        public string fileType { get; set;}
        public string DataPatchQuery { get; set; }
    }

}
