// Напишіть жартівливу програму «Дешифратор», яка в текстовому файлі могла б замінити всі прийменники слово «ГАВ!».
using System;
using System.IO.Pipelines;
using System.Text.RegularExpressions;

class Program
{
    public static string Path = @"C:\Users\adm.fenovka\Documents\Lessons\HW4\task3\text.txt";
    static void Main()
    {
        string text;
        string pattern = @"\b(в|у|на|під|за|до|від|з|із|зі|для|по|через|при|над|об|про|без)\b";
        string target = "ГАВ!";
        string result;

            using (StreamReader sReader = new StreamReader(Path))
            {
                text = sReader.ReadToEnd();
            }
            
            result = Regex.Replace(text, pattern,target, RegexOptions.IgnoreCase);
        using (StreamWriter sWriter = new StreamWriter(Path))
            {
                sWriter.Write(result);
            }
    }
}