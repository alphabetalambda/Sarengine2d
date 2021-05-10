using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Media;
#if NOSDKSLINUX
using LibVLCSharp;
#else
using NAudio;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using NAudio.Codecs;
using NAudio.FileFormats;
using NAudio.Midi;
using NAudio.Mixer;
using NAudio.Lame;
#endif
using Discord;
using System.Diagnostics;


namespace Sar_engine
{
    class Engine
    {
        public static string musicdir = @"./s/";
        public static bool exitgame = false;
        public static string curFile = @"./save.sav";
        public static string logFile = @"./log.log";
        public static string state = "00000";
        public static int readspeed = 2000;
        public static string gamename = "Saris Unbounded";
        public class Debug
        {
            static string PROCESSORIDENTIFIER = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
            static string OS = System.Environment.GetEnvironmentVariable("OS");
            static string PROCESSORARCHITECTURE = System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
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
            public static void Debugmenu()
            {
                Console.Write("PROCESSOR_IDENTIFIER: ");
                Console.WriteLine(PROCESSORIDENTIFIER);
                Console.Write("OS: ");
                Console.WriteLine(OS);
                Console.Write("PROCESSOR_ARCHITECTURE: ");
                Console.WriteLine(PROCESSORARCHITECTURE);
            }
            public static void Debugstartup()
            {
            }
            public class Log
            {
                public static StringBuilder sb;
                public static void Start()
                {
                    sb = new StringBuilder();
                }
                /// <summary>
                /// the function to be used for a thread to write to the console 
                /// </summary>
                /// <param name="ToWrite">the text to log to the console</param>
                public static void WriteAsThread(string ToWrite)
                {
                    string ParsedWrite;
                    string ThreadName = System.Threading.Thread.CurrentThread.Name;
                    ParsedWrite = $"[{ThreadName}] {ToWrite}";
                    sb.AppendLine(ParsedWrite);
                    File.AppendAllText(logFile, sb.ToString());
                    sb.Clear();
                }
            }
        }
        public class Startup
        {
            /// <summary>
            /// the start function that needs to be ran to properly initalize the engine
            /// </summary>
            static public void Start()
            {
                System.Threading.Thread.CurrentThread.Name = "Main";
                var debugfunctions = new Debug();
                string[] enginename = { @"  ___   _   ___   ___           _          ", @" / __| /_\ | _ \ | __|_ _  __ _(_)_ _  ___ ", @" \__ \/ _ \|   / | _|| ' \/ _` | | ' \/ -_)", @" |___/_/ \_\_|_\ |___|_||_\__, |_|_||_\___|", @"                          |___/            " };
                Console.WriteLine("Powered By");
                System.Threading.Thread.Sleep(500);
                foreach (var item in enginename)
                {
                    Console.WriteLine(item);
                    System.Threading.Thread.Sleep(5);
                }
                System.Threading.Thread.Sleep(3000);
                Console.Write("loading");
                Debug.Log.Start();
                Debug.Log.WriteAsThread("Logging started");
                System.Threading.ThreadStart musicref = new(Engine.Sound.Musicthread);
                System.Threading.ThreadStart discordref = new(Engine.DiscordSDK.Discordthread);
                Console.Write(".");
                System.Threading.Thread musicthread = new(musicref);
                System.Threading.Thread discordthread = new(discordref);
                Console.Write(".");
                musicthread.Start();
#if NOSDKS
                Debug.log.WriteAsThread("not starting discord thread as current version is NoSDKs");
#else
#if NOSDKSLINUX
                Debug.Log.WriteAsThread("not starting discord thread as current version is NoSDKs");
#else
                discordthread.Start();
#endif
#endif
                Console.WriteLine(" Done");
            }
        }
        public class Screen
        {
            /// <summary>
            /// write the text and delay by the read speed
            /// </summary>
            /// <param name="text">the text to write</param>
            public static void Write(string text)
            {
                Console.WriteLine(text);
                System.Threading.Thread.Sleep(readspeed);
            }
            /// <summary>
            /// prints as many lines as the window is tall
            /// </summary>
            public static void Clearscreeen()
            {
                int conhei = Console.WindowHeight + 1;
                for (int i = 0; i < conhei; i++)
                {
                    Console.WriteLine();
                }
            }
            /// <summary>
            /// Drawing the diffrent sections of the menu
            /// </summary>
            public static void Drawmenu(string[] topin = null )
            {
                int conhei = Console.WindowHeight + 1;
                for (int i = 0; i < conhei; i++)
                {
                    Console.WriteLine();
                }
                if (topin == null)
                {
                    topin = Engineconfig.logo;
                }
#if DEBUG
                Engine.Debug.Debugmenu();
#endif
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
                int repeat = width;
                for (int i = 0; i < repeat; i++)
                {
                    Console.Write("_");
                }
                Console.WriteLine();
            }
            public static void Credits()
            {
                Engine.Sound.musicintent = 3;
#if NOSDKSLINUX

#else
                var outroreader = new WaveFileReader("./s/a-first-goodbye.wav");
                var tickreader = new WaveFileReader("./s/tick.wav");
                var tick = new WaveOutEvent(); // or WaveOutEvent()
                var outro = new WaveOutEvent();
                outro.Init(outroreader);
                tick.Volume = 0.75f;
                tick.Init(tickreader);
                tick.Play();
                outro.Play();
#endif
                char[][] creditarray = Sar_engine.Engineconfig.creditsarray;
                // Display the array elements:
                for (int n = 0; n < creditarray.Length; n++)
                {

                    for (int k = 0; k < creditarray[n].Length; k++)
                    {

                        // Print the elements in the row
                        System.Console.Write("{0}", creditarray[n][k]);
#if NOSDKSLINUX
#else
                        tickreader.Seek(0, 0);
#endif
                        System.Threading.Thread.Sleep(150);
                    }
                    System.Console.WriteLine();
                }
                Engine.Sound.musicintent = 2;
            }
            /// <summary>
            /// the title card works by printing each character in a char array
            /// </summary>
            public static void Titlecard()
            {
                try
                {
                    char[] title = Sar_engine.Engineconfig.title;
                    Engine.Sound.musicintent = 3;
#if NOSDKSLINUX
#else
                    var tickreader = new WaveFileReader("./s/tick.wav");
                    var tick = new WaveOutEvent(); // or WaveOutEvent()
                    tick.Init(tickreader);
                    tick.Play();
#endif
                    foreach (var item in title)
                    {
                        Console.Write(item);
#if NOSDKSLINUX
#else
                        tickreader.Seek(0, 0);
#endif
                        System.Threading.Thread.Sleep(300);
                    }
                    Console.WriteLine();
                    Engine.Sound.musicintent = 2;

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
            public static void Writetext(string text)
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
                Console.WriteLine("input:");
                string output = Console.ReadLine();
                return output;
            }
            public static void Waitforinput()
            {
                Console.Write("press enter to continue");
                Console.ReadLine();
            }
        }
#pragma warning restore IDE0059 // Unnecessary assignment of a value due to the nature of this being a engine
        public class Savesystem
        {
            public static void Save()
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
            static public void Load()
            {
                bool exsistingsave = File.Exists(curFile);
                //haha now andrew cant bully me for haveing no catch here
                switch (exsistingsave)
                {
                    case true:
                        string[] lines2 = File.ReadAllLines(curFile);
                        StreamReader readingFile = new StreamReader(curFile);
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
        public class Sound
        {
#if NOSDKSLINUX
#endif
            public static int musicintent;
            public static void Musicthread()
            {
#if NOSDKSLINUX


#else
                musicintent = 1;
                var themelen = new System.TimeSpan(0, 0, 59);
                var musicout = new WaveOutEvent();
                try
                {
                    var musicthemereader = new WaveFileReader("./s/theme.wav");
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
#endif
        }
    }
        public class legacy2
        {
            public static string constatus;
            public static string cpustatus;
            public static string gpustatus;
            public static string wanstatus;
            public static string storestatus;
            public static string lanstatus;
            public static void status()
            {
                Console.WriteLine("PXos Cluster Control Server: " + constatus);
                System.Threading.Thread.Sleep(50);
                Console.WriteLine("CPU servers: " + cpustatus);
                System.Threading.Thread.Sleep(50);
                Console.WriteLine("GPU servers: " + gpustatus);
                System.Threading.Thread.Sleep(50);
                Console.WriteLine("Storage servers: " + storestatus);
                System.Threading.Thread.Sleep(50);
                Console.WriteLine("LAN: " + lanstatus);
                System.Threading.Thread.Sleep(50);
                Console.WriteLine("WAN: " + wanstatus);
            }
        }
        public class DiscordSDK
        {
            public static void SetStatusDetails(string Details)
            {
                DiscordStatTxt = Details;
                statusupdated = true;
            }
            volatile static string DiscordStatTxt;
            static bool statusupdated = true;
            public static void Discordthread()
            {
                Debug.Log.WriteAsThread("Thread started");
                System.Threading.Thread.CurrentThread.Name = "Discord";
                // Use your client ID from Discord's developer site.
                string clientID = null;
                if (clientID == null)
                {
                    clientID = "837008599951343706";
                }
                var discordapi = new Discord.Discord(Int64.Parse(clientID), (UInt64)Discord.CreateFlags.Default);
                var activitymanager = discordapi.GetActivityManager();
                if (DiscordStatTxt == null)
                {
                    DiscordStatTxt = "playing " + gamename;
                }
                var activity = new Discord.Activity
                {
                    Details = DiscordStatTxt,
                    Assets =
                        {
                            LargeImage = "main-icon",
                            LargeText = "Saris Unbounded",
                       }
                };
                activitymanager.UpdateActivity(activity, (res) =>
                {
                    if (Engine.Debug.IsDebug == true)
                    {

                    }
                });
                while (1 == 1)
                {
                    if (statusupdated == true)
                    {
                        var activitynew = new Discord.Activity
                        {
                            Details = DiscordStatTxt,
                            Assets =
                        {
                            LargeImage = "main-icon",
                            LargeText = "Saris Unbounded",
                       }
                        };
                        activitymanager.UpdateActivity(activitynew, (res) =>
                        {
                            if (Engine.Debug.IsDebug == true)
                            {

                            }
                        });
                        statusupdated = false;
                    }
                    discordapi.RunCallbacks();
                    Debug.Log.WriteAsThread("Updated status");
                    System.Threading.Thread.Sleep(4000);
                }
            }
        }
        public class Gameclasses
        {
            public class ItemsInv
            {
                public class InventorySystem
                {
                    private const int MAXIMUM_SLOTS_IN_INVENTORY = 10;

                    public readonly List<InventoryRecord> InventoryRecords = new List<InventoryRecord>();

                    public void AddItem(ObtainableItem item, int quantityToAdd)
                    {
                        while (quantityToAdd > 0)
                        {
                            if (InventoryRecords.Exists(x => (x.InventoryItem.ID == item.ID) && (x.Quantity < item.MaximumStackableQuantity)))
                            {
                                InventoryRecord inventoryRecord =
                                InventoryRecords.First(x => (x.InventoryItem.ID == item.ID) && (x.Quantity < item.MaximumStackableQuantity));
                                int maximumQuantityYouCanAddToThisStack = (item.MaximumStackableQuantity - inventoryRecord.Quantity);
                                int quantityToAddToStack = Math.Min(quantityToAdd, maximumQuantityYouCanAddToThisStack);
                                inventoryRecord.AddToQuantity(quantityToAddToStack);
                                quantityToAdd -= quantityToAddToStack;
                            }
                            else
                            {
                                if (InventoryRecords.Count < MAXIMUM_SLOTS_IN_INVENTORY)
                                {
                                    InventoryRecords.Add(new InventoryRecord(item, 0));
                                }
                                else
                                {
                                    throw new Exception("There is no more space in the inventory");
                                }
                            }
                        }
                    }
                    public class InventoryRecord
                    {
                        public ObtainableItem InventoryItem { get; private set; }
                        public int Quantity { get; private set; }

                        public InventoryRecord(ObtainableItem item, int quantity)
                        {
                            InventoryItem = item;
                            Quantity = quantity;
                        }

                        public void AddToQuantity(int amountToAdd)
                        {
                            Quantity += amountToAdd;
                        }
                    }
                }

                public abstract class ObtainableItem
                {
                    public Guid ID { get; set; }
                    public string Name { get; set; }
                    public int MaximumStackableQuantity { get; set; }

                    protected ObtainableItem()
                    {
                        MaximumStackableQuantity = 1;
                    }
                }
            }
            public class ClassesForCharacters
            {
                /// <summary>
                /// do not use for a character
                /// </summary>
                public class OriginClassForCharacters
                {
                    public string Name;
                    public int MaxHP;
                    public int HP;
                }
                public class MainCharacter : OriginClassForCharacters
                {
                    public string CharacterClass;
                }
                /// <summary>
                ///  do not use for a character
                ///  use to extend your own class 
                /// </summary>
                public class NPC : OriginClassForCharacters
                {
                    /// <summary>
                    /// how much currancy to give on kill
                    /// </summary>
                    public int value;
                }
            }
        }
    }
}
