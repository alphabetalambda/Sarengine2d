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
            System.Threading.ThreadStart musicref = new System.Threading.ThreadStart(Engine.sound.Musicthread);
            System.Threading.Thread musicthread = new System.Threading.Thread(musicref);
            musicthread.Start();
        }
    }
}
