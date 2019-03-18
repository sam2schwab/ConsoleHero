using System;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleHero
{
    public class Page
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public Dictionary<char, Option> Options { get; set; }

        public int? Read()
        {
            ShowTitle();
            ShowText();
            ShowOptions();
            return ReadOption();
        }

        private int? ReadOption()
        {
            if (Options.Count == 0)
            {
                ConsoleHero.WriteLineInColor(
                    "Oops, it looks like this page doesn't have any options!",
                    ConsoleColor.Red
                );
                return null;
            }
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (Options.ContainsKey(key.KeyChar))
                {
                    return Options[key.KeyChar].PageNb;
                }
            }
        }

        private void ShowOptions()
        {
            string manyChoices = Options.Count == 1 ? "" : "s";
            Console.WriteLine($"You have {Options.Count} choice{manyChoices} :");
            foreach (var pair in Options)
            {
                ConsoleHero.WriteInColor($"[{pair.Key}]", ConsoleColor.Red);
                Console.WriteLine($" - {pair.Value.Text}");
            }
        }

        private void ShowText()
        {
            Console.WriteLine($"{Text}\n");
        }

        private void ShowTitle()
        {
            ConsoleHero.WriteLineInColor($"+{new string('-', Title.Length + 2)}+", ConsoleColor.Magenta);
            ConsoleHero.WriteLineInColor($"| {Title} |", ConsoleColor.Magenta);
            ConsoleHero.WriteLineInColor($"+{new string('-', Title.Length + 2)}+", ConsoleColor.Magenta);
        }
    }
}