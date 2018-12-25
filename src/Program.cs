using System;
using Format;
using DataLoader;
using System.Collections.Generic;

namespace UnMatchTableUpdateQueryGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            FileFormat fmt = new FileFormat();

            fmt.FileName = "TEST_OLD.CSV";
            fmt.Separator = ',';
            fmt.fileType = "OLD";
            fmt.DataPatchQuery = "UPDATE TEMP SET VALUE = '{0}' WHERE KEY = '{0}';";

            Dictionary<string, string> old = new Dictionary<string, string>();
            Dictionary<string, string> old2 = new Dictionary<string, string>();
            using(var dl = new DataLoad(fmt))
            {
                old = dl.GetKeyValuesData();
            }

            fmt.FileName = "TEST_NEW.CSV";
            fmt.fileType = "NEW";

            using(var dl = new DataLoad(fmt))
            {
                old2 = dl.GetKeyValuesData();
            }

            foreach(KeyValuePair<string, string> kvp in old)
            {
                if(old2[kvp.Key] != kvp.Value)
                {
                    Console.WriteLine("UnMatchLine = OLD1:{0},OLD2:{1}", old[kvp.Key], old2[kvp.Key]);
                    Console.WriteLine(fmt.DataPatchQuery, kvp.Value, kvp.Key);
                }
            }
        }
    }
}
