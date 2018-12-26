using System;
using System.Collections.Generic;

using Format;

namespace Compare
{
    public static class Compare
    {
        public static void CompareKeyValueData(Dictionary<string, string> old, Dictionary<string, string> @new, FileFormat fmtOld)
        {
            foreach(KeyValuePair<string, string> kvp in old)
            {
                // 該当キーが存在する場合
                if(@new.ContainsKey(kvp.Key))
                {
                    // Valueに誤りがある場合
                    if(@new[kvp.Key] != kvp.Value)
                    {
                        Console.WriteLine("OutputQuery => {0}", string.Format(fmtOld.DataPatchQuery, kvp.Value, kvp.Key));
                    }
                }
                else
                {
                    // キーが存在しない場合、INSERTクエリを出力する
                    Console.WriteLine("OutputQuery => {0}", string.Format(fmtOld.InsertQuery, kvp.Value, kvp.Key));
                }
            }
        }

        public static void CompareKeyValueListData(Dictionary<string, string> old, Dictionary<string, string> @new,  FileFormat fmtOld)
        {
            foreach(KeyValuePair<string, string> kvp in old)
            {
                var val = kvp.Value.Split(',');
                if(@new.ContainsKey(kvp.Key))
                {
                    if(@new[kvp.Key] != kvp.Value)
                    {
                        Console.WriteLine("OutputQuery => {0}", string.Format(fmtOld.DataPatchQuery, val[0], val[1], kvp.Key));
                    }
                }
                else
                {
                    Console.WriteLine("OutputQuery => {0}", string.Format(fmtOld.InsertQuery, val[0], val[1], kvp.Key));
                }
            }
        }
    }
}
