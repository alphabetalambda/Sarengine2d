using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sar_engine
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine.Startup.Start();
            Engine.Sound.musicintent = 1;
            Engine.Screen.Drawmenu();
            Engine.Screen.Titlecard();
            Engine.Screen.Credits();

        }
    }
}
