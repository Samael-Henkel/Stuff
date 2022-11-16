using System;
using System.Threading;
using System.Threading.Tasks;

namespace TheThreeDoorsGameConsoleApp
{
    class Program
    {
        static Random random = new();
        static int DoorWithPrize = random.Next(1, 4);
        static int DoorPickedByHost = DoorWithPrize;
        static int DoorPickedByContestant = 0;
        static string name = "";
        static string Choice = "";
        static bool ChoiceMade = false;
        static bool isDoor = false;
        static bool Continue = true;
        static Timer timer = null;
        static void Main(string[] args)
        {
            while (Continue)
            {
                GameShow();
                ChoiceMade = false;
                while (!ChoiceMade)
                {
                    Console.WriteLine("Play again?(Y/N)");
                    Choice = Console.ReadLine();
                    switch (Choice.ToLower())
                    {
                        case "y":
                            Continue = true;
                            ChoiceMade = true;
                            break;
                        case "n":
                            Continue = false;
                            ChoiceMade = true;
                            break;
                        default:
                            Continue = true;
                            ChoiceMade = false;
                            break;
                    }
                }
            }
        }
        static void GameShow()
        {
            Console.Write(@"Enter Contestants Name:");
            name = Console.ReadLine();
            Console.WriteLine("Host: Hello everybody and welcome to...");
            Task.Delay(2660).Wait();
            TheThreeDoorsLogo();
            Console.WriteLine("(Applause)");
            Task.Delay(5000).Wait();
            Console.WriteLine("Host: I am your Host, Mr Breaker from the Breaking News Channel.");
            Task.Delay(3980).Wait();
            Console.WriteLine("Mr. Breaker: Please welcome our Guest for today: Its " + name + "!");
            Console.WriteLine("(Applause)");
            Task.Delay(3850).Wait();
            Console.WriteLine(name + ": Thanks for having me here, Mr. Breaker.");
            Task.Delay(2710).Wait();
            ChoiceMade = false;
            while (!ChoiceMade)
            {
                Console.WriteLine("Mr. Breaker: You're welcome. Shall we begin? (Y/N)");
                Choice = Console.ReadLine();
                switch (Choice.ToLower())
                {
                    case "y":
                        ChoiceMade = true;
                        break;
                    case "n":
                        Explanation();
                        ChoiceMade = false;
                        break;
                    default:
                        ChoiceMade = false;
                        break;
                }
            }
            Game();
        }
        static void Explanation()
        {
            Console.WriteLine(name + ": No, could you please explain the rules? You see, its my first time here.");
            Task.Delay(5670).Wait();
            Console.WriteLine("Mr. Breaker: But of course! The Game is simple:");
            Task.Delay(2880).Wait();
            Console.WriteLine("Mr. Breaker: On the Stage over there there are three Doors");
            Task.Delay(3170).Wait();
            Console.WriteLine("Mr. Breaker: Behind one of these Doors is a prize, behind the others is Nothing.");
            Task.Delay(4320).Wait();
            Console.WriteLine("Mr. Breaker: First, you get to choose a Door.");
            Task.Delay(2090).Wait();
            Console.WriteLine("Mr. Breaker: Then, I will open a door that doesnt have the prize.");
            Task.Delay(3950).Wait();
            Console.WriteLine("Mr. Breaker: After that, you get the Chance to switch Doors.");
            Task.Delay(3400).Wait();
            Console.WriteLine("Mr. Breaker: If you choose the correct Door, you win the Prize.");
            Task.Delay(4270).Wait();
            Console.WriteLine(name + ": Thanks for explaining, Mr. Breaker.");
            Task.Delay(2700).Wait();
        }
        static void Game()
        {
            DoorWithPrize = random.Next(1, 4);
            Console.WriteLine(name + ": Yes, I am ready!");
            Task.Delay(1300).Wait();
            Console.WriteLine("Mr. Breaker: Alright, then, lets begin!");
            Task.Delay(2540).Wait();
            RoundOne();
        }
        static void RoundOne()
        {
            isDoor = false;
            while (!isDoor)
            {
                Console.WriteLine("Mr. Breaker: Please pick a Door, any Door.");
                Choice = Console.ReadLine();
                if(int.TryParse(Choice, out DoorPickedByContestant))
                {
                    DoorPickedByContestant = Convert.ToInt32(Choice);
                    if(DoorPickedByContestant >= 1 && DoorPickedByContestant <= 3)
                    {
                        Console.WriteLine(name + ": Ill pick Door " + DoorPickedByContestant);
                        Task.Delay(1850).Wait();
                        isDoor = true;
                        Console.WriteLine("Mr. Breaker: Okay, Door " + DoorPickedByContestant + " is logged in.");
                        Task.Delay(2850).Wait();
                    }
                }
            }
            RoundTwo();
        }
        static void RoundTwo()
        {
            while(DoorPickedByHost == DoorWithPrize || DoorPickedByHost == DoorPickedByContestant)
            {
                DoorPickedByHost = random.Next(1, 4);
            }
            int unpickedDoor = DoorWithPrize; 
            while (DoorPickedByHost == unpickedDoor || unpickedDoor == DoorPickedByContestant)
            {
                unpickedDoor = random.Next(1, 4);
            }
            Console.WriteLine("Mr. Breaker: Now ill reveal a door which doesnt have the Prize: Door " + DoorPickedByHost + "!");
            Task.Delay(5370).Wait();
            ChoiceMade = false;
            while (!ChoiceMade)
            {
                Console.WriteLine("Mr. Breaker: Would you switch to Door " + unpickedDoor + "?(Y/N)");
                Choice = Console.ReadLine();
                switch (Choice.ToLower())
                {
                    case "y":
                        DoorPickedByContestant = unpickedDoor;
                        Console.WriteLine(name + ": Yes, ill switch!");
                        Task.Delay(1270).Wait();
                        ChoiceMade = true;
                        break;
                    case "n":
                        ChoiceMade = true;
                        Console.WriteLine(name + ": No, i wont switch!");
                        Task.Delay(1610).Wait();
                        break;
                    default:
                        ChoiceMade = false;
                        break;
                }
            }
            Console.WriteLine("Mr. Breaker: Now ill reveal which door has the Prize...right after these Messages!");
            Task.Delay(6630).Wait();
            TheThreeDoorsLogo();
            Console.WriteLine("will return after the Break");
            Task.Delay(2910).Wait();
            AdTime();
            TheThreeDoorsLogo();
            Console.WriteLine("Mr. Breaker: Welcome back to The Three Doors. Now ill reveal which door has the Prize!");
            Task.Delay(7300).Wait();
            Console.WriteLine("Mr. Breaker: It's...");
            Task.Delay(2000).Wait();
            timer = new(BuildingTension, null, 0, 1000);
            Task.Delay(5000).Wait();
            timer.Dispose();
            Console.WriteLine("Mr. Breaker: Door " + DoorWithPrize);
            Task.Delay(1260).Wait();
            Thread.Sleep(1260);
            if (DoorPickedByContestant == DoorWithPrize)
            {
                Console.WriteLine("(Applause)");
                Task.Delay(2500).Wait();
                Thread.Sleep(2500);
                Console.WriteLine("Mr. Breaker: Congratulations, " + name + ", You just won 25 million Dollars");
                Task.Delay(5640).Wait();
                Thread.Sleep(5640);
                Console.WriteLine(name + ": (celebrating)");
                Task.Delay(3500).Wait();
                Thread.Sleep(3500);
            } else
            {
                Console.WriteLine("(Audible Aww)");
                Task.Delay(2500).Wait();
                Console.WriteLine("Mr. Breaker: Sorry, " + name + ", better Luck next time");
                Task.Delay(4180).Wait();
                Console.WriteLine(name + ": Yeah...(sighs)");
                Task.Delay(3141).Wait();
            }
            Console.WriteLine("Mr. Breaker and " + name + ": (Shake hands)");
            Task.Delay(2000).Wait();
            Console.WriteLine("(" + name + " leaves)");
            Task.Delay(2000).Wait();
            Console.WriteLine("Mr. Breaker: Well, thats it for Today. See you all in the next Episode of...");
            Task.Delay(6080).Wait();
            TheThreeDoorsLogo();
            Task.Delay(1000).Wait();
            Console.WriteLine("Host: Mr. Breaker");
            Task.Delay(2000).Wait();
            Console.WriteLine("Contestant: " + name);
            Task.Delay(2000).Wait();
            Console.WriteLine("Camera Man: The Guy from The Ad");
            Task.Delay(2000).Wait();
            Console.WriteLine("Script by Samael Henkel");
            Task.Delay(2000).Wait();
        }
        static void TheThreeDoorsLogo()
        {
            Console.WriteLine(@"  _______ __              _______ __                         ______                          ");
            Console.WriteLine(@" |       |  |--.-----.   |       |  |--.----.-----.-----.   |   _  \ .-----.-----.----.-----.");
            Console.WriteLine(@" |.|   | |     |  -__|   |.|   | |     |   _|  -__|  -__|   |.  |   \|  _  |  _  |   _|__ --|");
            Console.WriteLine(@" `-|.  |-|__|__|_____|   `-|.  |-|__|__|__| |_____|_____|   |.  |    |_____|_____|__| |_____|");
            Console.WriteLine(@"   |:  |                   |:  |                            |:  1    /                       ");
            Console.WriteLine(@"   |::.|                   |::.|                            |::.. . /                        ");
            Console.WriteLine(@"   `---'                   `---'                            `------'                         ");
        }
        static void AdTime()
        {
            int AdsLeft = 5;
            while(AdsLeft > 0)
            {
                Advert();
                timer = new(DuringTheAd, null, 0, 1000);
                Thread.Sleep(10000);
                timer.Dispose(); 
                Console.WriteLine();
                AdsLeft--;
            }
        }
        static void DuringTheAd(Object o)
        {
            Console.Write("*");
        }
        static void Advert()
        {
            string[] ads = {
                "Slurp-Ice", "MacroHard Doors OS", "Nintendont Inc", "Pro Virus", "Generic TV SitCom", "Upcoming Sports Event", "Shooty Shooty Bang Bang Movie", "error"
            };
            if(name.ToLower().Contains("spamton"))
            {
                ads[7] = "spam";
            }
            string randomAd = ads[random.Next(0, ads.Length)];
            switch (randomAd)
            {
                case "Slurp-Ice":
                    SlurpIce();
                    break;
                case "MacroHard Doors OS":
                    Doors();
                    break;
                case "Nintendont Inc":
                    Nintendont();
                    break;
                case "Generic TV SitCom":
                    Sitcom();
                    break;
                case "Pro Virus":
                    Provirus();
                    break;
                case "Upcoming Sports Event":
                    Sports();
                    break;
                case "Shooty Shooty Bang Bang Movie":
                    Shooty();
                    break;
                case "spam":
                    Spam();
                    break;
                default:
                    Error();
                    break;
            }
        }
        static void SlurpIce()
        {
            Console.WriteLine(@"_______________________________________________________________");
            Console.WriteLine(@"| ____  __    _  _  ____  ____      __  ___  ____             |");
            Console.WriteLine(@"|/ ___)(  )  / )( \(  _ \(  _ \ ___(  )/ __)(  __)            |");
            Console.WriteLine(@"|\___ \/ (_/\) \/ ( )   / ) __/(___))(( (__  ) _)             |");
            Console.WriteLine(@"|(____/\____/\____/(__\_)(__)      (__)\___)(____)            |");
            Console.WriteLine(@"|                                It's Ice, that you can Slurp!|");
            Console.WriteLine(@"|                                                             |");
            Console.WriteLine(@"|                                                ||           |");
            Console.WriteLine(@"|   Just                                       __||__         |");
            Console.WriteLine(@"|  ___     ___   ___                          /__||__\        |");
            Console.WriteLine(@"| / _ \   / _ \ / _ \                         |      |        |");
            Console.WriteLine(@"|(__  ( _ \__  )\__  )                        |      |        |");
            Console.WriteLine(@"|  (__/(_)(___/ (___/ or more at Brandstore   |______|        |");
            Console.WriteLine(@"|_____________________________________________________________|");
        }
        static void Doors()
        {
            Console.WriteLine(@"_______________________________________________________________");
            Console.WriteLine(@"|Introducing...                                               |");
            Console.WriteLine(@"|MacroHard                                                    |");
            Console.WriteLine(@"|  _____                        ____   _____   ._______.      |");
            Console.WriteLine(@"| |  __ \                      / __ \ / ____|  ||__|__||      |");
            Console.WriteLine(@"| | |  | | ___   ___  _ __ ___| |  | | (___    ||__|__||      |");
            Console.WriteLine(@"| | |  | |/ _ \ / _ \| '__/ __| |  | |\___ \   |     ()|      |");
            Console.WriteLine(@"| | |__| | (_) | (_) | |  \__ \ |__| |____) |  |       |      |");
            Console.WriteLine(@"| |_____/ \___/ \___/|_|  |___/\____/|_____/   |_______|      |");
            Console.WriteLine(@"|                                                             |");
            Console.WriteLine(@"|                                                             |");
            Console.WriteLine(@"|                                                             |");
            Console.WriteLine(@"|Now available as Free Update from MH-VOS                     |");
            Console.WriteLine(@"|_____________________________________________________________|");
        }
        static void Nintendont()
        {
            Console.WriteLine(@"_______________________________________________________________");
            Console.WriteLine(@"|                                                             |");
            Console.WriteLine(@"|                                                             |");
            Console.WriteLine(@"|            ___________________________.______________       |");
            Console.WriteLine(@"|           /             ___  ___      |              |      |");
            Console.WriteLine(@"|          /  |\ | | |\ |  |  |    |\ | |              |      |");
            Console.WriteLine(@"|         (   | \| | | \|  |  |--  | \| |     Don't    |      |");
            Console.WriteLine(@"|          \  |  | | |  |  |  |___ |  | |              |      |");
            Console.WriteLine(@"|           \___________________________|______________|      |");
            Console.WriteLine(@"|                                                             |");
            Console.WriteLine(@"|                           Buy our Games                     |");
            Console.WriteLine(@"|                                                             |");
            Console.WriteLine(@"|                                                             |");
            Console.WriteLine(@"|_____________________________________________________________|");
        }
        static void Provirus()
        {
            Console.WriteLine(@"_______________________________________________________________");
            Console.WriteLine(@"|                                                             |");
            Console.WriteLine(@"|        `I used to Use regluar Anti Virus, but than i disco- |");
            Console.WriteLine(@"|         vered Provirus and was nevr infected agan.`         |");
            Console.WriteLine(@"|        - Real Customor                                      |");
            Console.WriteLine(@"|                                                             |");
            Console.WriteLine(@"|  //|\\                                                      |");
            Console.WriteLine(@"|  |O O|                                                      |");
            Console.WriteLine(@"|  (___)                                                      |");
            Console.WriteLine(@"|   /|\                                                       |");
            Console.WriteLine(@"|  | | |                                                      |");
            Console.WriteLine(@"|   | |                                                       |");
            Console.WriteLine(@"|   | |                                       www.provirus.moc|");
            Console.WriteLine(@"|_____________________________________________________________|");
        }
        static void Sitcom()
        {
            Console.WriteLine(@"_______________________________________________________________");
            Console.WriteLine(@"| /||    ___/                                                 |");
            Console.WriteLine(@"|  ||___/              _________________                      |");
            Console.WriteLine(@"|___/                 /   \             |                     |");
            Console.WriteLine(@"|                    /     \            |                     |");
            Console.WriteLine(@"|                   /       \___________|                     |");
            Console.WriteLine(@"|       |_O_|  O    |   __  | ##  #  ## |                     |");
            Console.WriteLine(@"|         |   /|>   |  |  | | ##  #  ## |                     |");
            Console.WriteLine(@"|________<_>__/_\___|__|_°|_|___________|_____________________|");
            Console.WriteLine(@"|                                                             |");
            Console.WriteLine(@"|                                                             |");
            Console.WriteLine(@"|_____________________________________________________________|");
            Console.WriteLine(@"|   New Episodes: Generic TV SitCom Mo.-Fr. 20:15             |");
            Console.WriteLine(@"|_____________________________________________________________|");
        }
        static void Sports()
        {
            Console.WriteLine(@"_______________________________________________________________");
            Console.WriteLine(@"| /||    ___/                                                 |");
            Console.WriteLine(@"|  ||___/                                                     |");
            Console.WriteLine(@"|___/                                                         |");
            Console.WriteLine(@"|                  O    O                                     |");
            Console.WriteLine(@"|                 >|>  >|>                                    |");
            Console.WriteLine(@"|__________________>^___>^____________________________________|");
            Console.WriteLine(@"|                                                             |");
            Console.WriteLine(@"|                                                             |");
            Console.WriteLine(@"|                                                             |");
            Console.WriteLine(@"|                                                             |");
            Console.WriteLine(@"|_____________________________________________________________|");
            Console.WriteLine(@"|     Upcoming Sports Event: UNF vs. JOE Su. 15:00            |");
            Console.WriteLine(@"|_____________________________________________________________|");
        }
        static void Shooty()
        {
            Console.WriteLine(@"_______________________________________________________________");
            Console.WriteLine(@"| /||    ___/                                                 |");
            Console.WriteLine(@"|  ||___/                                                     |");
            Console.WriteLine(@"|___/                                                         |");
            Console.WriteLine(@"|                                                             |");
            Console.WriteLine(@"|                                                             |");
            Console.WriteLine(@"|                                                             |");
            Console.WriteLine(@"|                \O/                              ¬_O         |");
            Console.WriteLine(@"|                 |                                 |\        |");
            Console.WriteLine(@"|________________/_\_______________________________/_\________|");
            Console.WriteLine(@"|                                                             |");
            Console.WriteLine(@"|_____________________________________________________________|");
            Console.WriteLine(@"|     Shooty Shooty Bang Bang Movie Sa. 19:15                 |");
            Console.WriteLine(@"|_____________________________________________________________|");
        }
        static void Spam()
        {
            Console.WriteLine(@"_______________________________________________________________");
            Console.WriteLine(@"|NOWS#YOUR#CHANCE#TO#BE#A#[[Big#Shot]]########################|");
            Console.WriteLine(@"|IF#YOU#WANT#[[Free#Kromer]]##################################|");
            Console.WriteLine(@"|JUST#[Call Now]#AT#[[Hyperlink#blocked]]#####################|");
            Console.WriteLine(@"|[[What#are#you#waiting#for?#Just#Do#it!]]#IT#S#A#[[Limited###|");
            Console.WriteLine(@"|Time Offer]]#ONLY#FOR#THE#NEXT#[65#million#years]############|");
            Console.WriteLine(@"|#############################################################|");
            Console.WriteLine(@"|#############################################################|");
            Console.WriteLine(@"|#############################################################|");
            Console.WriteLine(@"|#############################################################|");
            Console.WriteLine(@"|#############################################################|");
            Console.WriteLine(@"|-------------------------------------------------------------|");
            Console.WriteLine(@"|   TECHNICAL DIFFICULTIES: PLEASE STAND BY! DO NOT PANIC!    |");
            Console.WriteLine(@"|_____________________________________________________________|");
        }
        static void Error()
        {
            Console.WriteLine(@"_______________________________________________________________");
            Console.WriteLine(@"|#.##########################################################S|");
            Console.WriteLine(@"|##.#################.#####.#################################P|");
            Console.WriteLine(@"|############################################################A|");
            Console.WriteLine(@"|####.############E##########################################M|");
            Console.WriteLine(@"|##############################.#############################T|");
            Console.WriteLine(@"|############################################################O|");
            Console.WriteLine(@"|#######M#####K##############################################N|");
            Console.WriteLine(@"|#############################################################|");
            Console.WriteLine(@"|###########I################################################G|");
            Console.WriteLine(@"|#############################################################|");
            Console.WriteLine(@"|-------------------------------------------------------------|");
            Console.WriteLine(@"|   TECHNICAL DIFFICULTIES: PLEASE STAND BY! DO NOT PANIC!    |");
            Console.WriteLine(@"|_____________________________________________________________|");
        }
        static void BuildingTension(Object o)
        {
            Console.WriteLine("(drumroll)");
        }
    }
}
