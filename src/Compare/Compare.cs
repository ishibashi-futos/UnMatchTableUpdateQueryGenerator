﻿using System;
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
                if(@new[kvp.Key] != kvp.Value)
                {
                    Console.WriteLine("OutputQuery => {0}", string.Format(fmtOld.DataPatchQuery, kvp.Value, kvp.Key));
                }
            }
        }

        public static void CompareKeyValueListData(Dictionary<string, string> old, Dictionary<string, string> @new,  FileFormat fmtOld)
        {
            foreach(KeyValuePair<string, string> kvp in old)
            {
                if(@new[kvp.Key] != kvp.Value)
                {
                    var val = kvp.Value.Split(',');
                    Console.WriteLine("OutputQuery => {0}", string.Format(fmtOld.DataPatchQuery, val[0], val[1], kvp.Key));
                }
            }
        }
    }
}
