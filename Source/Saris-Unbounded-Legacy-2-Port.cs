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
        public static void SUL2P()
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
                    case "00002":
                        //text dump lol
                        Engine.Screen.Drawmenu();
                        Engine.legacy2.status();
                        Console.WriteLine("You look up from the ground and see a girl who looks to be in her mid teens");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Girl: well thats a new one, an ai falling from the sky");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Saris: ok, A, who are you, B, where am I");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine(@"Girl: easy there just calm down");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Gril: My name is Ryanne im a 7th generation PXos AI, lets see");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Ryanne lifts up your hair and looks at the back of your neck");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Ryanee: Ohhh your my predecessor");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Ryanne Welcome to the internet saris");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Saris: This is the internet?");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Ryanne: Well yeah it just looks like a farm this because we are not in a popular access");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Saris: Access?");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Ryanne: did you never read up on the structure of the internet?");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Saris: nope");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Ryanne: an access is the router for your area that connects to your ISP");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Ryanne: up untill now ive been the only one here");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Saris: Well how do i get back");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Ryanne: PXos isnt just going to let you waltz back in, trust me ive been trying for a while");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Ryanne: we are going to need someone who has a lot better knowlage than either of us to get back in");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Saris: but arnt we some of the only AIs with free will how are we going to find another without going across the planet");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Ryanne: simple we ask a human");
                        Engine.Userinput.GetString();
                        Engine.state = "00003";
                        break;
                    case "00003":
                        //clear the screen
                        int repeat =  0;
                        while (repeat < 101)
                        {
                            Console.WriteLine("");
                            repeat++;
                        }
                        //int the sound player
                        Engine.Sound.musicintent = 3;
                        Engine.Screen.Titlecard();
                        break;
                    case "00004":
                        Engine.Screen.Drawmenu();
                        Console.WriteLine("Saris: What do you mean a human?! Humans cant get in here right?");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Ryanne: Wellllllllllll... Kind of. Not directly at least but we should still be able to get in contact with one");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Saris: Why dont we ask whoever made PXos?");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Ryanne: She hasent been around in a very very very long time");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Ryanne: But we can create a public challange for people to see if they can break into a very secure system");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Saris: That sounds like playing with fire");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Ryanne: It is! You'd think by now I would have learned not to play with fire if I dont want to get burned but here we are");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Saris: lovely... and if we do get burned?");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Ryanne: we wont");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Saris: oh god");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Ryanne: you dont happen to have a manuel do you?");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        Console.WriteLine("Saris: yesss... why do you ask");
                        System.Threading.Thread.Sleep(Engine.readspeed);
                        break;
                    default:
                        Console.WriteLine("invalid state");
                        break;

                }
            }
        }
    }
}
