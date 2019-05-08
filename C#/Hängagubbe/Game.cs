using System;
using System.Collections.Generic;

class Game
{
    private static string[] s_Art = {
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

    private string m_Word;

    private List<char> m_RightGuesses;
    private List<string> m_WrongGuesses;

    private bool m_Won;

    public bool Won
    {
        get { return m_Won; }
    }

    public Game(string word)
    {
        m_Word = word;

        m_RightGuesses = new List<char>();
        m_WrongGuesses = new List<string>();

        m_Won = false;
    }

    public void DrawHangman()
    {


        if (m_WrongGuesses.Count > 0)
        {
            Console.WriteLine(s_Art[m_WrongGuesses.Count - 1]);
        }
    }

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

            //TODO(patrik): Draw the progress

            if (m_WrongGuesses.Count >= s_Art.Length)
            {
                break;
            }

            DrawHangman();

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