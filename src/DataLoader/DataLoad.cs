using System;
using Format;
using System.IO;

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
            if(disposing)
            {
                
            }
        }
        private FileFormat fmt;
        private StreamReader sr;
        public DataLoad(FileFormat fmt)
        {
            this.fmt = fmt;
            this.sr = new StreamReader(fmt.FileName);
        }
    }
}
