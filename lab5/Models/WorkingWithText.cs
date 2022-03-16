using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace lab5.Models
{
    public class WorkingWithText
    {
        static void CheckFormat(string filename)
        {
            string format = filename.Substring(filename.Length - 4, 4);
            if (string.Compare(format, ".txt") != 0)
                throw new WorkingWithTextException("Неверный формат файла");
        }
        public static string LoadFromFile(string? filename)
        {
            string fileContent = "";
            CheckFormat(filename);

            if (File.Exists(filename))
            {
                using (StreamReader sr = File.OpenText(filename))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        fileContent += s;
                    }
                }
            }
            else throw new WorkingWithTextException("Файл не найден");
            return fileContent;
        }

        public static void SaveFromFile(string? filename, string? content)
        {
            string fileContent = "";
            CheckFormat(filename);

            if (File.Exists(filename))
            {
                using (StreamWriter sw = File.CreateText(filename))
                {
                    sw.WriteLine(content);
                }
            }
            else throw new WorkingWithTextException("Файл не найден");
        }

        public static string FindByTemplate(string str, string? pattern)
        {
            if (pattern == null)
                pattern = "";
            if (str == null)
                str = "";
            string answer = "";
            Regex regex = new Regex(pattern);
            foreach(Match match in regex.Matches(str))
            {
                answer += match.Value + '\n';
            }
            return answer;
        }
    }
}
