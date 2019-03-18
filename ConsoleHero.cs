using System;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleHero
{
    internal static class ConsoleHero
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Console Hero!");
            while (true)
            {
                Book book = LoadFile();
                book.Read();
            }
        }

        private static Book LoadFile()
        {
            Book result = null;
            bool valid;
            do
            {
                string fileName = ReadFileName();
                try
                {
                    result = JsonConvert.DeserializeObject<Book>(File.ReadAllText(fileName));
                    valid = true;
                }
                catch (Exception exception)
                {
                    valid = false;
                    Console.WriteLine($"This file cannot be opened for the following reason : {exception.Message}");
                    Console.WriteLine("Please try again.");
                }
            } while (!valid);

            return result;
        }

        private static string ReadFileName()
        {
            bool valid;
            string fileName;
            do
            {
                Console.WriteLine("Please enter the adventure file to load (.json) or q to quit");
                fileName = Console.ReadLine();
                if (fileName == "q")
                {
                    Quit();
                }
                valid = File.Exists(fileName);
                if (!valid)
                {
                    Console.WriteLine("This file doesn't exist! Please try again.");
                }
            } while (!valid);

            return fileName;
        }

        internal static void Quit()
        {
            Console.WriteLine("Goodbye!");
            Environment.Exit(0);
        }

        internal static void WriteLineInColor(string text, ConsoleColor color)
        {
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = temp;
        }
        
        internal static void WriteInColor(string text, ConsoleColor color)
        {
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = temp;
        }
    }
}