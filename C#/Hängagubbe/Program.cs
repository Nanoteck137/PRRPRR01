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

class Program
{
    /// <summary>
    /// Main method of the programs
    /// </summary>
    /// <param name="args">Command Line arguments</param>
    static void Main(string[] args)
    {
        //TODO(patrik): Load words from a file
        List<string> words = new List<string>() { };

        if(words.Count <= 0)
        {
            Console.WriteLine("No words in the list");
            Console.WriteLine("Exiting...");

            Thread.Sleep(3000);

            Environment.Exit(-1);
        }

        Game game = new Game(words);
        game.Run();

        if(game.Won)
        {
            Console.WriteLine("You won wooow");
        }

        Console.Read();
    }
}
