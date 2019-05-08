﻿using System;
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
    private List<MenuItem> m_MenuItems;
    private List<String> m_WordList;

    private bool m_StartGame;

    public Program()
    {
        Util.Initalize(true);

        m_MenuItems = new List<MenuItem>();
        m_MenuItems.Add(new MenuItem("Add Word", AddWord));
        m_MenuItems.Add(new MenuItem("Remove Word", RemoveWord));
        m_MenuItems.Add(new MenuItem("Clear word list", ClearWordList));
        m_MenuItems.Add(new MenuItem("Play", Play));
        m_MenuItems.Add(new MenuItem("Quit", Quit));

        m_WordList = new List<string>();
    }

    public void AddWord()
    {
        while (true)
        {
            Console.Clear();

            Console.Write("Current word list: ");
            Util.PrintList(m_WordList);
            Console.WriteLine();

            Console.Write("Write a new word: ");
            string word = Console.ReadLine().ToLower();

            if (!m_WordList.Contains(word))
            {
                m_WordList.Add(word);
            }

            Console.Clear();

            Console.Write("Current word list: ");
            Util.PrintList(m_WordList);
            Console.WriteLine();

            bool result = YesNoQuestion("Add more words...");

            if(result)
            {
                continue;
            }
            else
            {
                break;
            }
        }
    }

    public void RemoveWord()
    {
        Console.Clear();

        if(m_WordList.Count <= 0)
        {
            Console.WriteLine("No words in the list");
            Thread.Sleep(1000);
            return;
        }

        while (true)
        {
            Console.Clear();

            if(m_WordList.Count <= 0)
            {
                return;
            }

            for (int i = 0; i < m_WordList.Count; i++)
            {
                Console.WriteLine("{0} - {1}", i + 1, m_WordList[i]);
            }

            Console.WriteLine("Choose a word to remove (1-{0})", m_WordList.Count);
            Console.WriteLine("To quit this screen write (quit/q)");

            string line = Console.ReadLine().Trim().ToLower();
            if(line == "quit" || line == "q")
            {
                break;
            }

            try
            {
                int index = int.Parse(line);
                m_WordList.RemoveAt(index - 1);
            }
            catch
            {
                continue;
            }
        }
    }

    public void ClearWordList()
    {
        m_WordList.Clear();
    }

    public void Play()
    {
        m_StartGame = true;
    }

    public void Quit()
    {
        //TODO(patrik): Save the newWords list??
        Environment.Exit(0);
    }

    public void PrintMenu()
    {
        Console.Write("Current word list: ");
        Util.PrintList(m_WordList);
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("---------- Main Menu ----------");

        for (int i = 0; i < m_MenuItems.Count; i++)
        {
            Console.WriteLine("{0} - {1}", i + 1, m_MenuItems[i].name);
        }
    }

    public void MainMenu()
    {
        while (true)
        {
            PrintMenu();

            int index = 0;

            try
            {
                 index = int.Parse(Console.ReadLine()) - 1;
            }
            catch
            {
                continue;
            }

            m_MenuItems[index].func();

            if (m_StartGame)
                break;

            Console.Clear();
        }
    }

    public void StartGame()
    {
        //TODO(patrik): Load words from a file

        string word = "";

        if (m_WordList.Count <= 0)
        {
            Console.Write("Write a word: ");
            word = Console.ReadLine().Trim().ToLower();
        }
        else
        {
            Random random = new Random();
            int index = random.Next(0, m_WordList.Count);
            word = m_WordList[index].ToLower();
        }

        Game game = new Game(word);
        game.Run();

        Console.Clear();

        if (game.Won)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You won the round");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You lost the round");
            Console.ResetColor();
        }
    }

    private bool YesNoQuestion(string message)
    {
        Console.WriteLine("{0} (yes/no)", message);
        string answer = Console.ReadLine().Trim().ToLower();

        if(answer == "yes" || answer == "y")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Start()
    {
        while (true)
        {
            MainMenu();

            StartGame();
        }
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
