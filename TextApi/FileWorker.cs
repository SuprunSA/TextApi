using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace TextApi
{
    public static class FileWorker
    {
        public static string FilePath { get; set; } = "C:\\filesXJ\\text.txt";

        public static int GetLen()
        {
            return File.ReadAllLines(FilePath).Length;
        }

        public static string GetAllText()
        {
            return File.ReadAllText(FilePath);
        }

        public static string GetRow(int row)
        {
            return File.ReadLines(FilePath).Skip(row - 1).First();
        }

        public static void DeleteRow(int row)
        {
            var data = File.ReadLines(FilePath).ToList();
            data.Remove(data[row - 1]);
            File.WriteAllText(FilePath, string.Join('\n', data));
        }

        public static void PostRow(string stringToPost)
        {
            File.AppendAllText(FilePath, new string(stringToPost + '\n'));
        }

        public static void PutRow(int row, string newRow)
        {
            var data = File.ReadLines(FilePath).ToList();
            data[row - 1] = newRow;
            File.WriteAllText(FilePath, string.Join('\n', data));
        }

        public static bool CheckContains(string stringToPost)
        {
            return File.ReadLines(FilePath).ToList().Contains(stringToPost);
        }

        public static string GetRange(int first, int last)
        {
            var data = "";
            for (int i = first; i <= last; i++)
            {
                data += GetRow(i);
                data += '\n';
            }
            return data;
        }
    }
}
