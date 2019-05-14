using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Utilities class for some use full methods
/// </summary>
class Util
{
    public static bool Debug { set; get; } = false;

    /// <summary>
    /// Prints to the console but only if the debug flag is set to true
    /// </summary>
    /// <param name="format">Format</param>
    /// <param name="objects">Objects used by format</param>
    public static void DebugPrintLine(string format, params Object[] objects)
    {
        if (Debug)
        {
            Console.Write("DEBUG: ");
            Console.WriteLine(format, objects);
        }
    }

    /// <summary>
    /// Prints a list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list">The list to be printed</param>
    public static void PrintList<T>(List<T> list)
    {
        Console.Write("(");

        for(int i = 0; i <list.Count; i++)
        {
            Console.Write(list[i]);
            if(i < list.Count - 1)
                Console.Write(", ");
        }


        Console.Write(")");
    }

    /// <summary>
    /// Prints the message and waits for the user to type something
    /// </summary>
    /// <param name="message">The message to be printed</param>
    /// <returns>Returns true if the user types yes or y and false for everything else</returns>
    public static bool YesNoQuestion(string message)
    {
        Console.WriteLine("{0} (yes/no)", message);
        string answer = Console.ReadLine().Trim().ToLower();

        if (answer == "yes" || answer == "y")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
