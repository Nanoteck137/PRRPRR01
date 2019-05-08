using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Util
{
    private static bool m_DebugOn = false;

    public static bool Debug { 
        set { m_DebugOn = value; }
        get { return m_DebugOn; }
    }

    public static void DebugPrintLine(string format, params Object[] objects)
    {
        if (Debug)
        {
            Console.Write("DEBUG: ");
            Console.WriteLine(format, objects);
        }
    }

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
}
