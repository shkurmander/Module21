using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Task1
{
   // Наша задача — сравнить производительность вставки в List<T> и LinkedList<T>.Для этого используйте уже знакомый вам StopWatch.

   //На примере этого текста, выясните, какие будут различия между этими коллекциями.

    class Program
    {
        static void Main(string[] args)
        {
            // читаем весь файл в строку 
            string text = File.ReadAllText(@"c:\test\Text.txt");
            // разбиваем в массив, используя пробел в качестве разделителя
            var words = text.Split(" ");
            List<string> simpleList = new List<string>();
            LinkedList<string> linkedList = new LinkedList<string>();

            Stopwatch timer = new Stopwatch();
            timer.Start();
            double mean = 0;
            for (int i = 0; i < 10; i++)
            {
                timer.Restart();
                foreach (var item in words)
                {
                    simpleList.Add(item);
                }
                timer.Stop();
                mean += timer.Elapsed.TotalMilliseconds;
                Console.WriteLine("Время затраченное на добавление элементов в List<T>:" + timer.Elapsed.TotalMilliseconds);
            }
            Console.WriteLine("\nСреднее время затраченное на добавление элементов в List<T>: " + mean / 10 + "\n");

            mean = 0; 
            for (int i = 0; i < 10; i++)
            {
                timer.Restart();
                foreach (var item in words)
                {
                    linkedList.AddLast(item);
                }
                timer.Stop();
                mean += timer.Elapsed.TotalMilliseconds;
                Console.WriteLine("Время затраченное на добавление элементов в LinkedList<T>:" + timer.Elapsed.TotalMilliseconds);

            }
            Console.WriteLine("\nСреднее время затраченное на добавление элементов в LinkedList<T>: " + mean / 10);

            Console.ReadKey();

        }
    }
}
