using System;
using Format;

namespace UnMatchTableUpdateQueryGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            FileFormat fmt = new FileFormat();

            fmt.FileName = @"/opt/UnMatchTableUpdateQueryGenerator/TEST_OLD.CSV";
            fmt.Delimiter = @"\r\n";
            fmt.Separator = ",";

            Console.WriteLine("Hello World!");
        }
    }
}
