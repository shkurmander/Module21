using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task2
{
    /// Ваша задача — написать программу, которая позволит понять, какие 10 слов чаще всего встречаются в тексте.
    class Program
    {
        static void Main(string[] args)
        {
            // читаем весь файл в строку 
            string text = File.ReadAllText(@"c:\test\Text.txt");
            // разбиваем в массив, используя пробел в качестве разделителя
            var words = text.Split(" ");

            //инициализируем словарь ключом будет слово, значением количество упоминаний
            Dictionary<string, int> wordDictionary = new Dictionary<string, int>();
            //Заполняем словарь исключая пунктуацию
            foreach (var item in words)
            {
                if (wordDictionary.ContainsKey(item))
                    wordDictionary[item]++;
                else
                {
                    char symbol;
                    if (item.Length > 1)                   
                        wordDictionary.Add(item, 1);                    
                    else
                        if (Char.TryParse(item, out symbol) && !Char.IsPunctuation(symbol))                        
                            wordDictionary.Add(item, 1);                    
                       
                }
            }
            //упорядоченный по количеству упоминаний слов в тексте словарь. 
            var orderedDictionary = from record in wordDictionary
                        where record.Value > 1
                        orderby record.Value descending
                        select record;
            // количество слов для выборки
            int max = 10;
            //счетчик
            int cnt = 1;

            Console.WriteLine($"{max} слов наиболее часто встречающиеся в тексте: ");
            foreach (var item in orderedDictionary)
            {
                Console.WriteLine($"{item.Key} - {item.Value} раз");
                ++cnt;
                if (cnt > max)
                    break;
            }
            Console.WriteLine($"Всего уникальных слов в тексте:  { orderedDictionary.Count()}");


            Console.ReadKey();
        }
    }
}
