using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sar_engine
{
    public class Engineconfig
    {
        public static readonly char[] title = { 'S', 'a', 'r', 'i', 's', ' ', 'U', 'n', 'b', 'o', 'u', 'n', 'd', 'e', 'd'};
        public static readonly char[][] creditsarray = new char[][]
        {
            new char[] {'S','a','r','i','s',' ','U','n','b','o','u','n','d','e','d'},
            new char[] {'C','r','e','a','t','e','d',' ','B','y',':',' ','A','l','p','h','a','B','e','t','a' }

        };
        public static string[] logo = { " ______   __  __     ______     ______    ", @"/\  == \ /\_\_\_\   /\  __ \   /\  ___\   ", @"\ \  _-/ \/_/\_\/_  \ \ \/\ \  \ \___  \  ", @" \ \_\     /\_\/\_\  \ \_____\  \/\_____\ ", @"  \/_/     \/_/\/_/   \/_____/   \/_____/   Version:8.6" };
    }
}
