using System;
using System.Collections.Generic;

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

        Game game = new Game(words);
        game.Run();
    }
}
