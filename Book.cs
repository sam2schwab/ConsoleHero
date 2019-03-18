using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleHero
{
    public class Book
    {
        public string Title { get; set; }
        public Dictionary<int,Page> Pages { get; set; }
        private int? _nextPage;

        public void Read()
        {
            _nextPage = 1;
            while (_nextPage.HasValue)
            {
                if (!Pages.ContainsKey(_nextPage.Value))
                {
                    ConsoleHero.WriteLineInColor(
                        $"Oops, it seems the page {_nextPage.Value} has not been written yet!",
                        ConsoleColor.Red
                    );
                    break;
                }
                Console.Clear();
                ConsoleHero.WriteLineInColor($"Book : {Title}, Page {_nextPage}/{Pages.Count()}", ConsoleColor.Gray);
                _nextPage = Pages[_nextPage.Value].Read();
            }
            Console.WriteLine($"Thanks for reading {Title}!");
        }
    }
}