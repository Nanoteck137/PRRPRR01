using System;
using System.Collections.Generic;
using System.Threading;

/** 
 * TODO List
 *  - Print meny
 *      - Let the user add words
 *  - Game restart
 *  - Game
 */

struct MenuItem
{
    public string name;
    public Action func;

    public MenuItem(string name, Action func)
    {
        this.name = name;
        this.func = func;
    }
}

class Program
{
    private List<MenuItem> menuItems;

    private List<String> newWords;

    public Program()
    {
        Util.Initalize(true);

        menuItems = new List<MenuItem>();
        menuItems.Add(new MenuItem("Add Word", AddWord));
        menuItems.Add(new MenuItem("Remove Word", RemoveWord));
        menuItems.Add(new MenuItem("Clear word list", RemoveWord));
        menuItems.Add(new MenuItem("Play", Play));
        menuItems.Add(new MenuItem("Quit", Quit));

        newWords = new List<string>();
    }

    public void AddWord()
    {
        while (true)
        {
            Console.Clear();

            Console.Write("Current word list: ");
            Util.PrintList(newWords);
            Console.WriteLine();

            Console.Write("Write a new word: ");
            string word = Console.ReadLine().ToLower();

            if (!newWords.Contains(word))
            {
                newWords.Add(word);
            }

            Console.Clear();

            Console.Write("Current word list: ");
            Util.PrintList(newWords);
            Console.WriteLine();

            ForbiddenMagic:
            Console.WriteLine("Add more words... (y/n)");
            string answer = Console.ReadLine();

            if (answer == "yes" || answer == "y")
            {
                continue;
            }
            else if (answer == "no" || answer == "n")
            {
                break;
            }
            else
            {
                goto ForbiddenMagic;
            }
        }
    }

    public void RemoveWord() { }
    public void ClearWordList() { }
    public void Play() { }
    public void Quit()
    {
        //TODO(patrik): Save the newWords list??
        Environment.Exit(0);
    }

    public void PrintMenu()
    {
        Console.Write("Current word list: ");
        Util.PrintList(newWords);
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("---------- Main Menu ----------");

        for (int i = 0; i < menuItems.Count; i++)
        {
            Console.WriteLine("{0} - {1}", i + 1, menuItems[i].name);
        }
    }

    public void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            PrintMenu();

            int index = int.Parse(Console.ReadLine()) - 1;
            Util.DebugPrintLine("Index: {0}", index);

            menuItems[index].func();
        }
    }

    public void Start()
    {
        MainMenu();

        //TODO(patrik): Load words from a file
        List<string> words = new List<string>() { "Hello", "Wooh", "Test" };

        if (words.Count <= 0)
        {
            Console.WriteLine("No words in the list");
            Console.WriteLine("Exiting...");

            Thread.Sleep(3000);

            Environment.Exit(-1);
        }

        Game game = new Game(words);
        game.Run();

        if (game.Won)
        {
            Console.WriteLine("You won wooow");
        }

        Console.Read();
    }
    /// <summary>
    /// Main method of the programs
    /// </summary>
    /// <param name="args">Command Line arguments</param>
    static void Main(string[] args)
    {
        Program program = new Program();
        program.Start();
    }
}
