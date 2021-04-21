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
            string[] logo = { " ______   __  __     ______     ______    ", @"/\  == \ /\_\_\_\   /\  __ \   /\  ___\   ", @"\ \  _-/ \/_/\_\/_  \ \ \/\ \  \ \___  \  ", @" \ \_\     /\_\/\_\  \ \_____\  \/\_____\ ", @"  \/_/     \/_/\/_/   \/_____/   \/_____/   Version:8.6" };
            Engine.screen.Drawmenu(logo);
            char[] title = { 'l', 'o', 'l' };
            Engine.screen.titlecard(title);
            Engine.screen.credits();

        }
    }
}
