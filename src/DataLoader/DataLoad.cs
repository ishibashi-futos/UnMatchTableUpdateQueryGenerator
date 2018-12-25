using System;
using Format;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace DataLoader
{
    public class DataLoad : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(Boolean disposing)
        {
        }
        private FileFormat fmt;
        public DataLoad(FileFormat fmt)
        {
            this.fmt = fmt;
        }

        public Dictionary<string, string> GetKeyValuesData()
        {
            
            string path = "";
            if (fmt.fileType == "OLD")
            {
                path = Path.Combine("../DATA.OLD/" + DateTime.Now.ToString("yyyyMMdd"), fmt.FileName);
            }
            else if (fmt.fileType == "NEW")
            {
                path = Path.Combine("../DATA.NEW/" + DateTime.Now.ToString("yyyyMMdd"), fmt.FileName);
            }
            return File.ReadLines(path)
                .Select(line => line.Split(fmt.Separator))
                .ToDictionary(cells => cells[0].Trim(), cells => cells[1].Trim());
        }
    }
}
