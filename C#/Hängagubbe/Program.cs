using System;
using System.Collections.Generic;

class Program
{

    static string[] art = {
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
    /// 
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World");
        Console.Clear();

        //Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("Woooh");
        foreach(string f in art)
        {
            Console.WriteLine(f);
            Console.WriteLine();
        }

        Console.ResetColor();

        Console.Read();
    }
}
