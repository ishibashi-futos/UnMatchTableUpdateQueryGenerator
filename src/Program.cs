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
            if (args.Length < 2)
            {
                Console.Error.WriteLine("引数が不足しています");
                Environment.Exit(-1);
            }

            // 設定の読み込み
            var fmtOld = Format.fmtLoader.load(args[0]);
            var fmtNew = Format.fmtLoader.load(args[1]);

            // ファイルを読み込み
            Dictionary<string, string> old = new Dictionary<string, string>();
            using(var dl = new DataLoad(fmtOld))
            {
                old = dl.GetKeyValuesData();
            }
            Dictionary<string, string> @new = new Dictionary<string, string>();
            using(var dl = new DataLoad(fmtNew))
            {
                @new = dl.GetKeyValuesData();
            }

            foreach(KeyValuePair<string, string> kvp in old)
            {
                if(@new[kvp.Key] != kvp.Value)
                {
                    Console.WriteLine("OutputQuery => {0}", string.Format(fmtOld.DataPatchQuery, kvp.Value, kvp.Key));
                }
            }
        }
    }
}
