using System;
using System.Collections.Generic;

using DataLoader;
using Format;
using Compare;

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
            Dictionary<string, string> @new = new Dictionary<string, string>();

            if(fmtOld.ValueType == "SingleItem")
            {
                using(var dl = new DataLoad(fmtOld))
                {
                    old = dl.GetKeyValuesData();
                }
                using(var dl = new DataLoad(fmtNew))
                {
                    @new = dl.GetKeyValuesData();
                }
                Compare.Compare.CompareKeyValueData(old, @new, fmtOld);
            }
            else if (fmtOld.ValueType == "ListItem")
            {
                using(var dl = new DataLoad(fmtOld))
                {
                    old = dl.GetKeyValueListData();
                }
                using(var dl = new DataLoad(fmtNew))
                {
                    @new = dl.GetKeyValueListData();
                }
                Compare.Compare.CompareKeyValueListData(old, @new, fmtOld);
            }
        }
    }
}
