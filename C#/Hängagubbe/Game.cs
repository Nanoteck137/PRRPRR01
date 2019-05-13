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
        // Create an array to hold the spaces in the word
        char[] wordChar = new char[m_Word.Length];
        for (int i = 0; i < m_Word.Length; i++)
        {
            // Keep the spaces in the word
            if (m_Word[i] == ' ')
            {
                wordChar[i] = ' ';
            }
            else
            {
                // Every character thats not a space becomes a undercore
                wordChar[i] = '_';
            }
        }

        while (true)
        {
            Console.Clear();

            // Debug print the word
            Util.DebugPrintLine(m_Word);

            // Exit the loop if the user has guesed too meny times
            if (m_WrongGuesses.Count >= s_Art.Length - 1)
            {
                break;
            }

            // Write the ASCII Art
            Console.WriteLine(s_Art[m_WrongGuesses.Count]);

            // Print the words and characters the user has guessed wrong
            if (m_WrongGuesses.Count > 0)
            {
                Console.WriteLine("Wrong Guesses");
                foreach (string str in m_WrongGuesses)
                {
                    Console.Write(str + " ");
                }
                Console.WriteLine();
            }

            // Prints the users progress
            foreach (char c in wordChar)
            {
                Console.Write(c + " ");
            }

            Console.WriteLine();

            // If the user has won return from this function
            if (m_Won)
            {
                return;
            }

            // Read a string from the console and make it lower case
            string word = Console.ReadLine().ToLower();

            // If the word length is less then and equal to zero restart the loop
            if(word.Length <= 0)
            {
                continue;
            }

            // If the user guessed the whole word then set m_Won to true
            if (word == m_Word)
            {
                //NOTE(patrik): The user wrote the right word
                m_Won = true;
            }
            // If the word contains the first character of the word taken from the console
            else if (m_Word.Contains(word[0].ToString()))
            {
                // Loop through the word character by character
                for (int i = 0; i < m_Word.Length; i++)
                {
                    // If the character matches the first character from the console then add the character to the m_RightGuesses list
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
                // Add the character to the wrong guesses list
                if (!m_WrongGuesses.Contains(word))
                    m_WrongGuesses.Add(word);
            }

            // Check if the user has guessed the word
            if(m_Word == new string(wordChar))
            {
                m_Won = true;
                continue;
            }
        }

        // If the user guessed too meny times print the ASCII Art in red
        if(!m_Won)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(s_Art[m_WrongGuesses.Count - 1]);
            Console.ResetColor();
        }
    }
}