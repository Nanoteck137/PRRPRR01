using System;
using System.Collections.Generic;

class Game
{
    private List<string> m_WordList;

    private List<char> m_RightGuesses;
    private List<string> m_WrongGuesses;

    private bool m_Won;

    public bool Won
    {
        get { return m_Won; }
    }

    public Game(List<string> wordList)
    {
        m_WordList = wordList;

        m_RightGuesses = new List<char>();
        m_WrongGuesses = new List<string>();

        m_Won = false;
    }

    public void Run()
    {
        //TODO(patrik): Pick a random word
        Random random = new Random();
        int index = random.Next(0, m_WordList.Count);
        string answer = m_WordList[index].ToLower();

        char[] wordChar = new char[answer.Length];
        for (int i = 0; i < answer.Length; i++)
        {
            wordChar[i] = '_';
        }

        while (true)
        {
            Console.Clear();

            Util.DebugPrintLine(answer);

            //TODO(patrik): Draw the progress

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

            if (word == answer)
            {
                //NOTE(patrik): The user wrote the right word
                m_Won = true;
            }
            else if (answer.Contains(word[0].ToString()))
            {
                for (int i = 0; i < answer.Length; i++)
                {
                    if (answer[i] == word[0])
                    {
                        wordChar[i] = answer[i];
                        if (m_RightGuesses.Contains(answer[i]))
                            m_RightGuesses.Add(answer[i]);
                    }
                }
            }
            else
            {
                if (!m_WrongGuesses.Contains(word))
                    m_WrongGuesses.Add(word);
            }

            if(answer == new string(wordChar))
            {
                m_Won = true;
                continue;
            }
        }
    }
}
