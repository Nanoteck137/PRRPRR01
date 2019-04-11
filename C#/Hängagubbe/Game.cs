using System;
using System.Collections.Generic;

class Game
{
    private List<string> m_WordList;

    private List<char> m_RightChars;
    private List<char> m_WrongChars;

    public Game(List<string> wordList)
    {
        m_WordList = wordList;

        m_RightChars = new List<char>();
        m_WrongChars = new List<char>();
    }

    public void Run()
    {
        //TODO(patrik): Pick a random word
        string answer = "Hello";

        char[] wordChar = new char[answer.Length];
        for (int i = 0; i < answer.Length; i++)
        {
            wordChar[i] = '_';
        }

        while (true)
        {
            Console.Clear();

            //TODO(patrik): Draw the progress

            if (m_WrongChars.Count > 0)
            {
                Console.WriteLine("Wrong characters");
                foreach (char c in m_WrongChars)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
            }

            foreach (char c in wordChar)
            {
                Console.Write(c + " ");
            }

            Console.WriteLine();

            string word = Console.ReadLine().ToLower();

            if (word.ToLower() == answer.ToLower())
            {
                //NOTE(patrik): The user wrote the right word
                Console.WriteLine("Right word");
            }
            else if (answer.ToLower().Contains(word[0].ToString()))
            {
                Console.WriteLine("Right char");
                for (int i = 0; i < answer.Length; i++)
                {
                    if (answer[i] == word[0])
                    {
                        wordChar[i] = answer[i];
                        if (m_RightChars.Contains(answer[i]))
                            m_RightChars.Add(answer[i]);
                    }
                }
            }
            else
            {
                if (!m_WrongChars.Contains(word[0]))
                    m_WrongChars.Add(word[0]);
            }
        }
    }
}
