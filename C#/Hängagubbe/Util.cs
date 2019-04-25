using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Util
{
    private static bool m_DebugOn = false;

    public static void Initalize(bool debug)
    {
        m_DebugOn = debug;
    }

    public static void DebugPrint(string format, params Object[] objects)
    {
        if(m_DebugOn)
            Console.WriteLine(format, objects);
    }
}
