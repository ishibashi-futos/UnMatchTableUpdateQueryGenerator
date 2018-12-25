using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

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

    public static class fmtLoader
    {
        public static FileFormat load(string path)
        {
            using (var sr = new StreamReader(path))
            {
                string json = sr.ReadToEnd();
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {
                    var js = new DataContractJsonSerializer(typeof(FileFormat));
                    return js.ReadObject(stream) as FileFormat;
                }
            }
        }
    }
}
