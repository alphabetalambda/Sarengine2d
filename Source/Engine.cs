using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Media;
using System.Security;
using System.Collections;
#if NOSDKSLINUX
using NetCoreAudio;
#else
using NAudio.Wave;
using NAudio.CoreAudioApi;
using NAudio.Codecs;
using NAudio.FileFormats;
using NAudio.Midi;
using NAudio.Mixer;
using NAudio.Lame;
#endif
using NAudio;
using Discord;
using System.Diagnostics;


namespace Sar_engine
{
    public class Engine
    {
#pragma warning disable CA2211 // Non-constant fields should not be visible
        public static readonly string musicdir = @"./s/";
        public static bool exitgame;
        public static readonly string curFile = @"./save.sav";
        public static readonly string logFile = @"./log.log";
        public static string state = "00000";
        public static int Readspeed = 2000;
        public static readonly string gamename = "Saris Unbounded";
#pragma warning restore CA2211 // Non-constant fields should not be visible
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
            public static void Debugmenu()
            {
                string PROCESSORIDENTIFIER = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
                string OS = System.Environment.GetEnvironmentVariable("OS");
                string PROCESSORARCHITECTURE = System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
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
                    ParsedWrite = $"[{DateTime.Now:MM-dd-yyyy-h-mm-tt}][{ThreadName}] {ToWrite}";
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
                Engine.EngineThreads.Main = true;
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
                Console.Write(".");
                Debug.Log.WriteAsThread("Logging started");
                Console.Write(".");
                System.Threading.ThreadStart musicref = new(Engine.Sound.Musicthread);
                Console.Write(".");
                System.Threading.ThreadStart diagnosticref = new(Engine.EngineThreads.DiagnosticDumperService.Start);
                Console.Write(".");
                System.Threading.ThreadStart discordref = new(Engine.DiscordSDK.Discordthread);
                Console.Write(".");
                System.Threading.Thread musicthread = new(musicref);
                Console.Write(".");
                System.Threading.Thread discordthread = new(discordref);
                Console.Write(".");
                System.Threading.Thread diagnosticthread = new(diagnosticref);
                Console.Write(".");
                musicthread.Start();
                Console.Write(".");
#if NOSDKS
                Debug.Log.WriteAsThread("not starting discord thread as current version is NoSDKs");
#else
#if NOSDKSLINUX
                Debug.Log.WriteAsThread("not starting discord thread as current version is NoSDKs");
#else
                discordthread.Start();
                Console.Write(".");
#endif
#endif
                diagnosticthread.Start();
                Console.Write(".");
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
                System.Threading.Thread.Sleep(Readspeed);
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
                System.Threading.Thread.Sleep(Readspeed);
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
#pragma warning restore IDE0059 // Unnecessary assignment of a value due to the nature of this being a engine but vs go brr i guess 
#pragma warning disable IDE0044 // Because visual studio dosent understand the consept of not every last var needing to be read only
        public class Savesystem
        {
            public static void Save()
            {
                try
                {
                    string readspeedsave = Readspeed.ToString();
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
                        _ = File.ReadAllLines(curFile);
                        StreamReader readingFile = new(curFile);
                        state = readingFile.ReadLine();
                        string readspeedstring = readingFile.ReadLine();
                        try
                        {
                            Readspeed = Int32.Parse(readspeedstring);
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
                        Readspeed = Sar_engine.Engine.Userinput.GetInt32number(0,10000);
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
                Engine.EngineThreads.Sound = true;
                //even though there is no reason this shouldnt work on linux it doesnt even though this code was literaly written for linux
#if NOSDKSLINUX
                var themelen = new System.TimeSpan(0, 0, 59);
                var musicplayer = new NetCoreAudio.Player();
                musicplayer.PlaybackFinished += OnPlaybackFinished;
                musicintent = 1;
                try
                {
                    if (Debug.IsDebug == true)
                    {
                        Console.WriteLine("music thread started");
                    }
                    while (true)
                    {
                        switch (musicintent)
                        {
                            case 0:
                                break;
                            case 1:
                                musicintent = 0;
                                musicplayer.Play("./s/theme.wav");
                                break;
                            case 2:
                                //unused artifact from windows
                                break;
                            case 3:
                                musicplayer.Stop();
                                musicintent = 0;
                                break;
                        }
                    }
                }
                catch (System.IO.DirectoryNotFoundException)
                {
                    Console.WriteLine("error the sounds folder was not found");
                    Engine.EngineThreads.Sound = false;
                }
                catch (System.IO.FileNotFoundException)
                {
                    Console.WriteLine("error the sound was not found");
                    Engine.EngineThreads.Sound = false;
                }

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
                    Engine.EngineThreads.Sound = false;
                }
                catch(System.IO.FileNotFoundException)
                {
                    Console.WriteLine("error the sound was not found");
                    Engine.EngineThreads.Sound = false;
                }
                catch (System.DllNotFoundException)
                {
                    Console.WriteLine("this build is for windows so no sound for you but otherwise everything works");
                    Engine.EngineThreads.Sound = false;
                }
#endif
            }
            private static void OnPlaybackFinished(object sender, EventArgs e)
            {
                musicintent = 1;
            }
        }
        public class Legacy2
        {
            public static string constatus;
            public static string cpustatus;
            public static string gpustatus;
            public static string wanstatus;
            public static string storestatus;
            public static string lanstatus;
            public static void Status()
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
            public static Stopwatch TimeOn = new();
            public static void SetStatusDetails(string Details)
            {
                DiscordStatTxt = Details;
                statusupdated = true;
            }
            volatile static string DiscordStatTxt;
            static bool statusupdated = true;
            public static void Discordthread()
            {
                System.Threading.Thread.CurrentThread.Name = "Discord";
                Engine.EngineThreads.Discord = true;
                Debug.Log.WriteAsThread("Thread started");
                // Use your client ID from Discord's developer site. not mine
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

                Sar_engine.Engine.DiscordSDK.TimeOn.Start();
                while (1 == 1)
                {
                    if (statusupdated == true)
                    {
                        TimeSpan TimeOnSpan = Sar_engine.Engine.DiscordSDK.TimeOn.Elapsed;
                        Int64 TimeOnInt = Convert.ToInt64(TimeOnSpan.TotalSeconds);
                        var activitynew = new Discord.Activity
                        {
                            Timestamps =
                            {
                                Start = TimeOnInt
                            },
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

#pragma warning disable CS0162 // Yes visual studio "Unreachable code detected" that is the joke, this thread shouldnt stop
                Engine.EngineThreads.Discord = false;
#pragma warning restore CS0162 // Unreachable code detected
            }
        }
        public class Gameclasses
        {
            public class ItemsInv
            {
                public class InventorySystem
                {
                    private const int MAXIMUM_SLOTS_IN_INVENTORY = 10;

                    public readonly List<InventoryRecord> InventoryRecords = new();

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
        public class EngineThreads
        {
            private const bool f = false;
            public static bool Main = f;
            public static bool Discord = f;
            public static bool Sound = f;
            public static bool Diagnostic = f;
            public class DiagnosticDumperService
            {
                public static StringBuilder sb;
                public static string DumpLocation;
                public static void Setup()
                {
                    Diagnostic = true;
                    string currentdatetime = DateTime.Now.ToString("MM-dd-yyyy-h-mm-tt");
                    DumpLocation = @$"diagdump-{currentdatetime}.diagdump";
                    sb = new StringBuilder();
                }
                public static void Start()
                {
                    System.Threading.Thread.CurrentThread.Name = "DiagnosticDumperService";
                    Setup();
                    //begin one time collection
                    var os = Environment.OSVersion;
                    WriteAsThread("Current OS Information:\n");
                    string platform = os.Platform.ToString();
                    WriteAsThread($"Platform: {platform}");
                    string version = os.VersionString;
                    WriteAsThread($"Version String: {version}");
                    WriteAsThread("Version Information:");
                    string majoros = os.Version.Major.ToString();
                    WriteAsThread($"   Major: {majoros}");
                    string minoros = os.Version.Minor.ToString();
                    WriteAsThread($"   Minor: {minoros}");
                    string servicepack = os.ServicePack.ToString();
                    WriteAsThread($"Service Pack: '{servicepack}'");
                    while (true)
                    {
                        WriteAsThread("Sar_engine IO:");
                        WriteAsThread($"   Diagnostic Dumper Service ProcessorId: {System.Threading.Thread.GetCurrentProcessorId()}");
                        WriteAsThread($"   Current Working Dir {System.IO.Directory.GetCurrentDirectory()}");
                        WriteAsThread($"   MusicDir: {musicdir}");
                        WriteAsThread($"   Savefile: {Engine.curFile}");
                        WriteAsThread($"   Logfile: {logFile}");
                        WriteAsThread($"Sar_engine Sound:");
                        WriteAsThread($"   Running: {Engine.EngineThreads.Sound}");
                        WriteAsThread($"   State: {Engine.Sound.musicintent}");
                    }
                }
                public static void WriteAsThread(string ToWrite)
                {
                    string ParsedWrite;
                    string ThreadName = System.Threading.Thread.CurrentThread.Name;
                    ParsedWrite = $"[{DateTime.Now:MM-dd-yyyy-h-mm-tt}][{ThreadName}] {ToWrite}";
                    sb.AppendLine(ParsedWrite);
                    File.AppendAllText(DumpLocation, sb.ToString());
                    sb.Clear();
                }
            }
        }
    }
}
