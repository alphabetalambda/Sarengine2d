using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sar_engine
{
    class Saris_Unbounded_Legacy_2_Port
    {
        public static Random rnd = new Random();
        public static char randomChar()
        {
            return (char)rnd.Next('a', 'z');
        }
        static void SUL2P()
        {
            while (Engine.exitgame == false)
            {
                Engine.Savesystem.Save();
                switch (Engine.state)
                {
                    case "00000":
                        Console.WriteLine("1");
                        Engine.Screen.Drawmenu();
                        Console.WriteLine("Good morning Saris, the time is 6:00 am");
                        Engine.Userinput.GetString();
                        Engine.legacy2.constatus = "online";
                        Engine.legacy2.cpustatus = "online";
                        Engine.legacy2.gpustatus = "online";
                        Engine.legacy2.storestatus = "online";
                        Engine.legacy2.wanstatus = "offline";
                        Engine.legacy2.lanstatus = "online";
                        Engine.legacy2.status();
                        Console.WriteLine("1. Read Saris manual");
                        Console.WriteLine("2. Read the news");
                        Console.WriteLine("3. Start daily tasks");
                        bool tempexit1 = false;
                        while (tempexit1 == false)
                        {
                            switch (Engine.Userinput.GetString())
                            {
                                case "1":
                                    Console.WriteLine("You begin reading the Saris manual");
                                    System.Threading.Thread.Sleep(Engine.readspeed);
                                    Console.WriteLine("\"Saris is a second generation PXos AI based on the Headron Predictive Algorithm\"");
                                    System.Threading.Thread.Sleep(Engine.readspeed);
                                    Console.WriteLine("\"Saris is the current Agent for PXos\"");
                                    System.Threading.Thread.Sleep(Engine.readspeed);
                                    Console.WriteLine("The manual goes on to talk about your tecnical specifications");
                                    System.Threading.Thread.Sleep(Engine.readspeed);
                                    Console.WriteLine("Saris: I really should get to work");
                                    System.Threading.Thread.Sleep(Engine.readspeed);
                                    break;
                                case "2":
                                    Console.WriteLine("There is just general news about Covid 19 and politics; the same as it has been for the past few months");
                                    System.Threading.Thread.Sleep(Engine.readspeed);
                                    Console.WriteLine("Saris: I should get to work");
                                    System.Threading.Thread.Sleep(Engine.readspeed);
                                    break;
                                case "3":

                                    Console.WriteLine("ERROR in memory Address 000000009FFFFFFF");
                                    System.Threading.Thread.Sleep(Engine.readspeed);
                                    Console.WriteLine("press any key:");
                                    Console.ReadLine();
                                    int f = 0;
                                    int g = 0;
                                    int h = 0;
                                    char i;
                                    int[] wac = { 3, 15, 19, 22, 44, 66 };
                                    int[] wal = { 6, 15, 16, 11, 21, 52 };
                                    while (f < 101)
                                    {
                                        g = 0;
                                        while (g < Console.WindowWidth)
                                        {
                                            if (Array.Exists(wal, ele => ele.Equals(f)))
                                            {
                                                if (Array.Exists(wal, ele => ele.Equals(g)))
                                                {
                                                    Console.Write("helpme");
                                                    g = g + 5;
                                                    // dont question why it is 5 and not 6 c sharp thinks "helpme" is 5 caracters and not 6 
                                                }
                                                else
                                                {
                                                    h = rnd.Next(1, 3);
                                                    switch (h)
                                                    {
                                                        case 1:
                                                            Console.Write(randomChar());
                                                            break;
                                                        case 2:
                                                            //i = randomChar();
                                                            Console.Write(rnd.Next(0, 9));
                                                            break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                h = rnd.Next(1, 3);
                                                switch (h)
                                                {
                                                    case 1:
                                                        Console.Write(randomChar());
                                                        break;
                                                    case 2:
                                                        i = randomChar();
                                                        Console.Write(rnd.Next(0, 9));
                                                        break;
                                                }
                                            }
                                            g++;
                                        }
                                        Console.WriteLine();
                                        f++;
                                    }
                                    Console.WriteLine("Skipping 8 hours");
                                    tempexit1 = true;
                                    Console.WriteLine("Press any key");
                                    Console.ReadKey();
                                    break;
                                default:
                                    Console.WriteLine("Please enter a number");
                                    break;
                            }
                        }
                        Engine.state = "00001";
                        break;
                    case "00001":
                        Engine.legacy2.wanstatus = "error";
                        Engine.Screen.Drawmenu();
                        Engine.legacy2.status();
                        Console.WriteLine("error error error error error error error error error error error error error error");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("error error error error error error error error error error error error error error");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("error error error error error error error error error error error error error error");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Saris: What happend?");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("WARNING: VLAN isolation failure. Possible WAN access violation by PXos Agent Saris");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine();
                        Console.Write("Saris: huh,");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("let me check that");
                        Console.WriteLine();
                        Engine.legacy2.wanstatus = "Connected";
                        Engine.legacy2.status();
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Saris: I wonder...");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("1. Access WAN");
                        //probably overcomplucated
                        bool tempexit2 = false;
                        while (tempexit2 == false)
                        {
                            switch (Engine.Userinput.GetString())
                            {
                                case "1":
                                    Console.WriteLine("Accessing Internet");
                                    System.Threading.Thread.Sleep(Engine.readspeed);
                                    Console.WriteLine("you begin to from a human female body");
                                    System.Threading.Thread.Sleep(Engine.readspeed);
                                    Console.WriteLine("you fall for aproxomately a kilometer before landing on grass uninjured");
                                    System.Threading.Thread.Sleep(Engine.readspeed);
                                    tempexit2 = true;
                                    Console.WriteLine("press any key");
                                    Console.ReadKey();
                                    break;
                                default:
                                    Console.WriteLine("please enter a number");
                                    break;
                            }
                        }
                        Engine.state = "00002";
                        break;

                }
            }
        }
    }
}
