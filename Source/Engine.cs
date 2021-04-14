using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using NAudio;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using NAudio.Codecs;
using NAudio.FileFormats;
using NAudio.Midi;
using NAudio.Mixer;
using NAudio.Lame;

namespace Sar_engine
{
    class Engine
    {
        public static string curFile = @"./save.sav";
        public static string state = "00000";
        public static int readspeed = 2000;
        public static string gamename = "Saris Unbounded";
        public class Debug
        {
            public static bool IsDebug
            {
                get
                {

#if DEBUG
                    return true;
#else
                return false;
#endif

                }
            }
        }
        public class Startup
        {
            static void Start()
            {
                Console.WriteLine("Powered By SAR Engine");
            }
        }
        public class screen
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
                var curtime = DateTime.Now.ToString();
                Console.Write("The current time is: ");
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
            public static void titlecard(char[] title)
            {
                try
                {
                    Engine.sound.musicintent = 3;
                    var tickreader = new WaveFileReader("./sounds/tick.wav");
                    var tick = new WaveOutEvent(); // or WaveOutEvent()
                    tick.Init(tickreader);
                    tick.Play();
                    foreach (var item in title)
                    {
                        Console.WriteLine(item);
                        tickreader.Seek(0,0)
                    }

                }
                catch (System.IO.DirectoryNotFoundException)
                {
                    Console.WriteLine("error the sounds folder was not found");
                }
                catch (System.IO.FileNotFoundException)
                {
                    Console.WriteLine("error the sound was not found");
                }
            }
            public static void writetext(string text)
            {
                Console.WriteLine(text);
                System.Threading.Thread.Sleep(readspeed);
            }
        }
#pragma warning disable IDE0059 // Unnecessary assignment of a value
        public class Userinput
        {
            //functions to gather the diffrent types of user inputs
            public static int GetInt32number(int limitlow, int limithigh)
            {
                Console.WriteLine("Please enter a number:");
                string input;
                input = Console.ReadLine();
                bool canparse;
                int number;
                canparse = int.TryParse(input, out int num);
                int limithighp = limithigh + 1;
                int limitlowp = limitlow + 1;
                if (canparse == true)
                {
                    number = int.Parse(input);
                    if (number < limitlowp - 1)
                    {
                        canparse = false;
                    }
                    if (number > limithighp + 1)
                    {
                        canparse = false;
                    }
                }
                while (canparse == false)
                {
                    Console.WriteLine("Please enter a valid number:");
                    input = Console.ReadLine();
                    canparse = int.TryParse(input, out num);
                    if (canparse == true)
                    {
                        number = int.Parse(input);
                        if (number < limitlowp)
                        {
                            canparse = false;
                        }
                        if (number > limithighp)
                        {
                            canparse = false;
                        }
                    }
                }
                number = int.Parse(input);
                return number;
            }
            public static string GetString()
            {
                Console.WriteLine("input");
                string output = Console.ReadLine();
                return output;
            }
        }
#pragma warning restore IDE0059 // Unnecessary assignment of a value
        public class Savesystem
        {
            static void Save()
            {
                try
                {
                    string readspeedsave = readspeed.ToString();
                    string[] lines = { state, readspeedsave };
                    File.WriteAllLines(curFile, lines);
                    //SUG.Program.savegame(); ignore this it is a legacy 1 thing 
                }
                catch (System.IO.IOException savee1)
                {
                    System.Console.WriteLine("WARNING the following error is not part of the game!");
                    System.Console.WriteLine("I/O error: Failed to save file");
                    System.Console.WriteLine(savee1);
                }
            }
            static void Load()
            {
                bool exsistingsave = File.Exists(curFile);
                //haha now andrew cant bully me for haveing no catch here
                switch (exsistingsave)
                {
                    case true:
                        string[] lines2 = File.ReadAllLines(curFile);
                        System.IO.StreamReader readingFile = new System.IO.StreamReader(curFile);
                        state = readingFile.ReadLine();
                        string readspeedstring = readingFile.ReadLine();
                        try
                        {
                            readspeed = Int32.Parse(readspeedstring);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("unable to Parse");
                        }
                        Console.WriteLine("Welcome back to Saris Unbounded");
                        readingFile.Close();
                        break;
                    case false:
                        //first time running
                        Console.Write("Welcome to ");
                        Console.WriteLine(gamename);
                        Console.WriteLine("This seems to be the first time your playing the game so lets get some things set up");
                        Console.WriteLine("what is the speed(in ms) that lines should progress automaticaly?");
                        state = "00000";
                        readspeed = Sar_engine.Engine.Userinput.GetInt32number(0,10000);
                        Save();
                        //SUG.Program.savegame(); old save function on the legacy 1 version
                        break;
                }
            }
        }
        public class sound
        {
            public static int musicintent;
            public static void Musicthread()
            {
                musicintent = 1;
                var themelen = new System.TimeSpan(0, 0, 59);
                var musicout = new WaveOutEvent();
                try
                {
                    var musicthemereader = new WaveFileReader("./sounds/theme.wav");
                    if (Debug.IsDebug == true)
                    {
                        Console.WriteLine("music thread started");
                    }
                    while (true)
                    {
                        if (musicthemereader.CurrentTime == themelen)
                        {
                            musicintent = 2;
                        }
                        switch (musicintent)
                        {
                            case 0:
                                break;
                            case 1:
                                musicout.Init(musicthemereader);
                                musicintent = 0;
                                musicout.Play();
                                break;
                            case 2:
                                musicthemereader.Seek(0, 0);
                                musicintent = 0;
                                break;
                            case 3:
                                musicthemereader.Skip(100);
                                musicintent = 0;
                                break;
                        }
                    }
                }
                catch(System.IO.DirectoryNotFoundException)
                {
                    Console.WriteLine("error the sounds folder was not found");
                }
                catch(System.IO.FileNotFoundException)
                {
                        Console.WriteLine("error the sound was not found");
                }
            }
        }
    }
}
