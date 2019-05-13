using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using Newtonsoft.Json;

/// <summary>
/// Single Menu item for the main menu
/// </summary>
class MenuItem
{
    public string name;
    public Action func;

    public MenuItem(string name, Action func)
    {
        this.name = name;
        this.func = func;
    }
}

/// <summary>
/// Used when saving and loading words from a file
/// </summary>
class JsonWords
{
    public List<string> words;
}

/// <summary>
/// Main Program, handles the menu and start of a game
/// </summary>
class Program
{
    /// <summary>
    /// Constant for the file name used for saving/loading words
    /// </summary>
    private const string WORD_FILE_NAME = "words.json";

    /// <summary>
    /// Menu items used by the drawing of the menu, also a dynamic way to add items
    /// </summary>
    private List<MenuItem> m_MenuItems;

    /// <summary>
    /// Some words that can be choosen from when starting a new game
    /// </summary>
    private List<string> m_WordList;

    /// <summary>
    /// Used for getting out of the menu when the user wants to play
    /// </summary>
    private bool m_StartGame;

    /// <summary>
    /// Constructor for the program initalizes the menu and word list
    /// </summary>
    public Program()
    {
        //NOTE(patrik): Initalizing the menu items
        m_MenuItems = new List<MenuItem>();
        m_MenuItems.Add(new MenuItem("Add Word", AddWord));
        m_MenuItems.Add(new MenuItem("Remove Word", RemoveWord));
        m_MenuItems.Add(new MenuItem("Clear word list", ClearWordList));
        m_MenuItems.Add(new MenuItem("Play", Play));
        m_MenuItems.Add(new MenuItem("Quit", Quit));

        m_WordList = new List<string>();
    }

    #region File Saving/Loading
    /// <summary>
    /// Loads the words from a file and sets m_WordList to the loaded list
    /// </summary>
    public void LoadWordsFromFile()
    {
        if (File.Exists(WORD_FILE_NAME))
        {
            string fileContent = File.ReadAllText(WORD_FILE_NAME);
            JsonWords fileWords = JsonConvert.DeserializeObject<JsonWords>(fileContent);
            m_WordList = fileWords.words;
        }
    }

    /// <summary>
    /// Saves word list to a file
    /// </summary>
    public void SaveWordToFile()
    {
        JsonWords fileWords = new JsonWords();
        fileWords.words = m_WordList;

        string fileContent = JsonConvert.SerializeObject(fileWords, Formatting.Indented);

        File.WriteAllText(WORD_FILE_NAME, fileContent);
    }
    #endregion

    #region Menu Items

    /// <summary>
    /// Menu Item: Lets the user to add words
    /// </summary>
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

                SaveWordToFile();
            }

            Console.Clear();

            Console.Write("Current word list: ");
            Util.PrintList(m_WordList);
            Console.WriteLine();

            bool result = Util.YesNoQuestion("Add more words...");

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

    /// <summary>
    /// Menu Item: Lets the user remove words
    /// </summary>
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

    /// <summary>
    /// Menu Item: Clears the whole word list
    /// </summary>
    public void ClearWordList()
    {
        m_WordList.Clear();
    }

    /// <summary>
    /// Menu Item: Starts a game
    /// </summary>
    public void Play()
    {
        m_StartGame = true;
    }

    /// <summary>
    /// Menu Item: Quits the program
    /// </summary>
    public void Quit()
    {
        SaveWordToFile();

        Environment.Exit(0);
    }
    #endregion

    #region Menu
    /// <summary>
    /// Print the menu
    /// </summary>
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

    /// <summary>
    /// Starts the menu and stays here until the player starts a game
    /// </summary>
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
    #endregion

    /// <summary>
    /// Start a single game
    /// </summary>
    public void StartGame()
    {

        //NOTE(patrik): If their is not any word in the words list then the user can pick a word
        string word = "";

        if (m_WordList.Count <= 0)
        {
            //NOTE(patrik): Let the user pick a word
            Console.Write("Write a word: ");
            word = Console.ReadLine().Trim().ToLower();
        }
        else
        {
            //NOTE(patrik): If their is words in the list then choose a random word in their
            Random random = new Random();
            int index = random.Next(0, m_WordList.Count);
            word = m_WordList[index].ToLower();
        }

        //NOTE(patrik): Initalizes the game and starts it
        Game game = new Game(word);
        game.Run();

        Console.Clear();

        //NOTE(patrik): Checks if the user has won then print something
        if (game.Won)
        {
            //NOTE(patrik): The user won
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You won the round");
            Console.ResetColor();
        }
        else
        {
            //NOTE(patrik): The user lost
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You lost the round");
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Starts the game and loops here forever
    /// </summary>
    public void Start()
    {
        while (true)
        {
            LoadWordsFromFile();

            MainMenu();

            StartGame();

            m_StartGame = false;
        }
    }

    /// <summary>
    /// Main method of the programs
    /// </summary>
    /// <param name="args">Command Line arguments</param>
    static void Main(string[] args)
    {
        foreach(string arg in args)
        {
            if(arg == "--debug")
            {
                Util.Debug = true;
            }
        }

        Program program = new Program();
        program.Start();
    }
}
