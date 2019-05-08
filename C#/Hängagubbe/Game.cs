using System;
using System.Collections.Generic;

/// <summary>
/// A single game, handles all the logic for that game
/// </summary>
class Game
{
    #region Variables

    /// <summary>
    /// Global string array for the stages of the hangman
    /// </summary>
    private static string[] s_Art = {
@"       
       
       
       
       
       
         ",

@"       
       
       
       
       
       
=========",

@"      +
      |
      |
      |
      |
      |
=========",

@"  +---+
      |
      |
      |
      |
      |
=========",

@"  +---+
  |   |
      |
      |
      |
      |
=========",

@"  +---+
  |   |
  O   |
      |
      |
      |
=========",

@"  +---+
  |   |
  O   |
  |   |
      |
      |
=========",

@"  +---+
  |   |
  O   |
 /|   |
      |
      |
=========",

@"  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========",

@"  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========",

@"  +---+  
  |   |  
  O   |  
 /|\  |  
 / \  |  
      |  
========="
    };

    /// <summary>
    /// Current word used in this game
    /// </summary>
    private string m_Word;

    /// <summary>
    /// The right characters the user has guessed
    /// </summary>
    private List<char> m_RightGuesses;

    /// <summary>
    /// The wrong characters or words the user has guessed
    /// </summary>
    private List<string> m_WrongGuesses;

    /// <summary>
    /// A boolean too see if the user has won the current game used outside in the program
    /// </summary>
    private bool m_Won;

    /// <summary>
    /// Property to get the m_Won variable
    /// </summary>
    public bool Won
    {
        get { return m_Won; }
    }
     #endregion

    /// <summary>
    /// Constructor for the game initalize some variables
    /// </summary>
    /// <param name="word">The word for the game</param>
    public Game(string word)
    {
        m_Word = word;

        m_RightGuesses = new List<char>();
        m_WrongGuesses = new List<string>();

        m_Won = false;
    }

    /// <summary>
    /// Starts the game and loops here until the game is over and then returns back to the program
    /// </summary>
    public void Run()
    {
        char[] wordChar = new char[m_Word.Length];
        for (int i = 0; i < m_Word.Length; i++)
        {
            if (m_Word[i] == ' ')
            {
                wordChar[i] = ' ';
            }
            else
            {
                wordChar[i] = '_';
            }
        }

        while (true)
        {
            Console.Clear();

            Util.DebugPrintLine(m_Word);

            if (m_WrongGuesses.Count >= s_Art.Length - 1)
            {
                break;
            }

            Console.WriteLine(s_Art[m_WrongGuesses.Count]);

            if (m_WrongGuesses.Count > 0)
            {
                Console.WriteLine("Wrong Guesses");
                foreach (string str in m_WrongGuesses)
                {
                    Console.Write(str + " ");
                }
                Console.WriteLine();
            }

            foreach (char c in wordChar)
            {
                Console.Write(c + " ");
            }

            Console.WriteLine();

            if (m_Won)
            {
                return;
            }

            string word = Console.ReadLine().ToLower();

            if(word.Length <= 0)
            {
                continue;
            }

            if (word == m_Word)
            {
                //NOTE(patrik): The user wrote the right word
                m_Won = true;
            }
            else if (m_Word.Contains(word[0].ToString()))
            {
                for (int i = 0; i < m_Word.Length; i++)
                {
                    if (m_Word[i] == word[0])
                    {
                        wordChar[i] = m_Word[i];
                        if (m_RightGuesses.Contains(m_Word[i]))
                            m_RightGuesses.Add(m_Word[i]);
                    }
                }
            }
            else
            {
                if (!m_WrongGuesses.Contains(word))
                    m_WrongGuesses.Add(word);
            }

            if(m_Word == new string(wordChar))
            {
                m_Won = true;
                continue;
            }
        }

        if(!m_Won)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(s_Art[m_WrongGuesses.Count - 1]);
            Console.ResetColor();
        }
    }
}