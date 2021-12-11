using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TextApi
{
    public static class CheckFile
    {
        private static bool isExists
        {
            get
            {
                if (File.Exists("C:\\filesXJ\\text.txt"))
                {
                    return true;
                }
                else return false;
            }
        }

        public static void CreateFile()
        {
            if (!isExists)
            {
                File.Create("C:\\filesXJ\\text.txt");
            }
        }
    }
}
