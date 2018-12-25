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
            var result = new Dictionary<string, string>();
            string path = Path.Combine("../DATA." + fmt.fileType + "/" + DateTime.Now.ToString("yyyyMMdd"), fmt.FileName);
            foreach (string line in File.ReadLines(path))
            {
                var data = line.Split(fmt.Separator);
                var key = data[0].Trim();
                var val = data[1].Trim();
                // キーが存在し、
                if (result.ContainsKey(key))
                {
                    // 且つ値が99だった時、新しい行の値で書き換える
                    if(result[key] == "99")
                        result[key] = val;
                }
                else
                {
                    result.Add(key, val);
                }
            }
            return result;
        }

        public Dictionary<string, string> GetKeyValueListData()
        {
            string path = Path.Combine("../DATA." + fmt.fileType + "/" + DateTime.Now.ToString("yyyyMMdd"), fmt.FileName);
            return File.ReadLines(path)
                .Select(line => line.Split(fmt.Separator))
                .ToDictionary(cells => cells[0].Trim(), cells => {
                    return string.Format("{0},{1}", cells[1].Trim(), cells[2].Trim());
                });
        }
    }
}
