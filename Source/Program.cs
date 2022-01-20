using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sar_engine
{
    class Program
    {
        static readonly string[] boottext = { "[Ok] initializing kernel", "[Ok] initializing PXos core", "[Ok] initializing IPv4", "[Ok] initializing ipv6", "[Ok] initializing AI Handler", "[Ok] connecting to PXos WAN nodes", "[Failed] Authenticating with PXOS internal network", "[Ok] starting fallback operations", "[Ok] initialized virtual env", "[Ok] boot complete" };

        private static void Main()
        {
            Engine.Startup.Start();
            Engine.Savesystem.Load();
            Engine.Screen.Clearscreeen();
            while (Engine.exitgame == false)
            {
                Engine.DiscordSDK.SetStatusDetails($"Current State: {Engine.state}");
                Engine.Savesystem.Save();
                switch (Engine.state)
                {
                    case "00000":
                        foreach (var item in boottext)
                        {
                            Console.WriteLine(item);
                            System.Threading.Thread.Sleep(30);
                        }
                        System.Threading.Thread.Sleep(700);
                        Engine.Screen.Drawmenu();
                        Engine.Userinput.Waitforinput();
                        Engine.Screen.Writetext("you wake up in a flat grassy area and imeadatly feel your head throbing");
                        Engine.Screen.Writetext("where am i?");
                        bool exitloop1 = false;
                        int choice = 0;
                        while(exitloop1== false)
                        {
                            Engine.Screen.Writetext("chose 1 2 or 3");
                            choice = Engine.Userinput.GetInt32number(1,3);
                            switch (choice)
                            {
                                case 1:
                                    Engine.Screen.Writetext("choice 1");
                                    exitloop1 = true;
                                    break;
                                case 2:
                                    Engine.Screen.Writetext("choice 2");
                                    exitloop1 = true;
                                    break;
                                case 3:
                                    Engine.Screen.Writetext("choice 3");
                                    exitloop1 = true;
                                    break;
                            }

                        }
                        break;
                    default:
                        Console.WriteLine("invalid state");
                        break;
                }
            }
        }
    }
}
