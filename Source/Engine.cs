using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Engine
{
    class Engine
    {
        class Menu
        {
            //Drawing the diffrent sections of the menu
            public static void Drawmenu(string[] topin)
            {
                Drawmenutop(topin);
                Drawmenumid();
                Drawmenubot();
            }
            static void Drawmenutop(string[] Topmenu)
            {
                foreach (var item in Topmenu)
                {
                    Console.WriteLine(item);
                }
            }
            static void Drawmenumid()
            {
                string curtime = DateTime.Now.ToString("en-US");
                Console.Write("The current time is:");
                Console.WriteLine(curtime);
            }
            static void Drawmenubot()
            {
                int width = Console.WindowWidth;
                int repeat = width + 1;
                for (int i = 0; i < repeat; i++)
                {
                    Console.Write("_");
                }
                Console.WriteLine();
            }
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            class Userinput
            {
                //functions to gather the diffrent types of user inputs
                public static int Int32number(int limitlow, int limithigh)
                {
                    Console.WriteLine("Please enter a number:");
                    string input;
                    input = Console.ReadLine();
                    bool canparse;
                    int number;
                    canparse = int.TryParse(input , out int num);
                    if(canparse == true)
                    {
                        number = int.Parse(input);
                        if(number <= limitlow )
                        {
                            canparse = false;
                        }
                        if(number >= limithigh)
                        {
                            canparse = false;
                        }
                    }
                    while(canparse == false)
                    {
                        Console.WriteLine("Please enter a valid number:");
                        input = Console.ReadLine();
                        canparse = int.TryParse(input, out num);
                        if (canparse == true)
                        {
                            number = int.Parse(input);
                            if (number <= limitlow)
                            {
                                canparse = false;
                            }
                            if (number >= limithigh)
                            {
                                canparse = false;
                            }
                        }
                    }
                    number = int.Parse(input);
                    return number;
                }
            }
#pragma warning restore IDE0059 // Unnecessary assignment of a value
        }
    }
}
