using System;
using System.Threading;

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
            Thread.Sleep(2660);
            Console.WriteLine(@"  _______ __              _______ __                         ______                          ");
            Console.WriteLine(@" |       |  |--.-----.   |       |  |--.----.-----.-----.   |   _  \ .-----.-----.----.-----.");
            Console.WriteLine(@" |.|   | |     |  -__|   |.|   | |     |   _|  -__|  -__|   |.  |   \|  _  |  _  |   _|__ --|");
            Console.WriteLine(@" `-|.  |-|__|__|_____|   `-|.  |-|__|__|__| |_____|_____|   |.  |    |_____|_____|__| |_____|");
            Console.WriteLine(@"   |:  |                   |:  |                            |:  1    /                       ");
            Console.WriteLine(@"   |::.|                   |::.|                            |::.. . /                        ");
            Console.WriteLine(@"   `---'                   `---'                            `------'                         ");
            Console.WriteLine("(Applause)");
            Thread.Sleep(5000);
            Console.WriteLine("Host: I am your Host, Mr Breaker from the Breaking News Channel.");
            Thread.Sleep(3980);
            Console.WriteLine("Mr. Breaker: Please welcome our Guest for today: Its " + name + "!");
            Console.WriteLine("(Applause)");
            Thread.Sleep(3850);
            Console.WriteLine(name + ": Thanks for having me here, Mr. Breaker.");
            Thread.Sleep(2710);
            ChoiceMade = false;
            while (!ChoiceMade)
            {
                Console.WriteLine("Mr. Breaker: You're welcome. Shall we begin? (Y/N)");
                Thread.Sleep(2510);
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
            Thread.Sleep(5670);
            Console.WriteLine("Mr. Breaker: But of course! The Game is simple:");
            Thread.Sleep(2880);
            Console.WriteLine("Mr. Breaker: On the Stage over there there are three Doors");
            Thread.Sleep(3170);
            Console.WriteLine("Mr. Breaker: Behind one of these Doors is a prize, behind the others is Nothing.");
            Thread.Sleep(4320);
            Console.WriteLine("Mr. Breaker: First, you get to choose a Door.");
            Thread.Sleep(2090);
            Console.WriteLine("Mr. Breaker: Then, I will open a door that doesnt have the prize.");
            Thread.Sleep(3950);
            Console.WriteLine("Mr. Breaker: After that, you get the Chance to switch Doors.");
            Thread.Sleep(3400);
            Console.WriteLine("Mr. Breaker: If you choose the correct Door, you win the Prize.");
            Thread.Sleep(4270);
            Console.WriteLine(name + ": Thanks for explaining, Mr. Breaker.");
            Thread.Sleep(2700);
        }
        static void Game()
        {
            DoorWithPrize = random.Next(1, 4);
            Console.WriteLine(name + ": Yes, I am ready!");
            Thread.Sleep(1300);
            Console.WriteLine("Mr. Breaker: Alright, then, lets begin!");
            Thread.Sleep(2540);
            RoundOne();
        }
        static void RoundOne()
        {
            isDoor = false;
            while (!isDoor)
            {
                Console.WriteLine("Mr. Breaker: Please pick a Door, any Door.");
                Thread.Sleep(2880);
                Choice = Console.ReadLine();
                if(int.TryParse(Choice, out DoorPickedByContestant))
                {
                    DoorPickedByContestant = Convert.ToInt32(Choice);
                    if(DoorPickedByContestant >= 1 && DoorPickedByContestant <= 3)
                    {
                        Console.WriteLine(name + ": Ill pick Door " + DoorPickedByContestant);
                        Thread.Sleep(1850);
                        isDoor = true;
                        Console.WriteLine("Mr. Breaker: Okay, Door " + DoorPickedByContestant + " is logged in.");
                        Thread.Sleep(2850);
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
            Thread.Sleep(5370);
            ChoiceMade = false;
            while (!ChoiceMade)
            {
                Console.WriteLine("Mr. Breaker: Would you switch to Door " + unpickedDoor + "?(Y/N)");
                Thread.Sleep(2710);
                Choice = Console.ReadLine();
                switch (Choice.ToLower())
                {
                    case "y":
                        DoorPickedByContestant = unpickedDoor;
                        Console.WriteLine(name + ": Yes, ill switch!");
                        Thread.Sleep(1270);
                        ChoiceMade = true;
                        break;
                    case "n":
                        ChoiceMade = true;
                        Console.WriteLine(name + ": No, i wont switch!");
                        Thread.Sleep(1610);
                        break;
                    default:
                        ChoiceMade = false;
                        break;
                }
            }
            Console.WriteLine("Mr. Breaker: Now ill reveal which door has the Prize...right after these Messages!");
            Thread.Sleep(6630);
            Console.WriteLine(@"  _______ __              _______ __                         ______                          ");
            Console.WriteLine(@" |       |  |--.-----.   |       |  |--.----.-----.-----.   |   _  \ .-----.-----.----.-----.");
            Console.WriteLine(@" |.|   | |     |  -__|   |.|   | |     |   _|  -__|  -__|   |.  |   \|  _  |  _  |   _|__ --|");
            Console.WriteLine(@" `-|.  |-|__|__|_____|   `-|.  |-|__|__|__| |_____|_____|   |.  |    |_____|_____|__| |_____|");
            Console.WriteLine(@"   |:  |                   |:  |                            |:  1    /                       ");
            Console.WriteLine(@"   |::.|                   |::.|                            |::.. . /                        ");
            Console.WriteLine(@"   `---'                   `---'                            `------'                         ");
            Console.WriteLine("will return after the Break");
            Thread.Sleep(2910);
            AdTime();
            Console.WriteLine(@"  _______ __              _______ __                         ______                          ");
            Console.WriteLine(@" |       |  |--.-----.   |       |  |--.----.-----.-----.   |   _  \ .-----.-----.----.-----.");
            Console.WriteLine(@" |.|   | |     |  -__|   |.|   | |     |   _|  -__|  -__|   |.  |   \|  _  |  _  |   _|__ --|");
            Console.WriteLine(@" `-|.  |-|__|__|_____|   `-|.  |-|__|__|__| |_____|_____|   |.  |    |_____|_____|__| |_____|");
            Console.WriteLine(@"   |:  |                   |:  |                            |:  1    /                       ");
            Console.WriteLine(@"   |::.|                   |::.|                            |::.. . /                        ");
            Console.WriteLine(@"   `---'                   `---'                            `------'                         ");
            Console.WriteLine("Mr. Breaker: Welcome back to The Three Doors. Now ill reveal which door has the Prize!");
            Thread.Sleep(7300);
            Console.WriteLine("Mr. Breaker: It's...");
            Thread.Sleep(2000);
            timer = new(BuildingTension, null, 0, 1000);
            Thread.Sleep(5000);
            timer.Dispose();
            Console.WriteLine("Mr. Breaker: Door " + DoorWithPrize);
            Thread.Sleep(1260);
            if (DoorPickedByContestant == DoorWithPrize)
            {
                Console.WriteLine("(Applause)");
                Thread.Sleep(2500);
                Console.WriteLine("Mr. Breaker: Congratulations, " + name + ", You just won 25 million Dollars");
                Thread.Sleep(5640);
                Console.WriteLine(name + ": (celebrating)");
                Thread.Sleep(3500);
            } else
            {
                Console.WriteLine("(Audible Aww)");
                Thread.Sleep(2500);
                Console.WriteLine("Mr. Breaker: Sorry, " + name + ", better Luck next time");
                Thread.Sleep(4180);
                Console.WriteLine(name + ": Yeah...(sighs)");
                Thread.Sleep(3141);
            }
            Console.WriteLine("Mr. Breaker and " + name + ": (Shake hands)");
            Thread.Sleep(2000);
            Console.WriteLine("(" + name + " leaves)");
            Thread.Sleep(2000);
            Console.WriteLine("Mr. Breaker: Well, thats it for Today. See you all in the next Episode of...");
            Thread.Sleep(6080);
            Console.WriteLine(@"  _______ __              _______ __                         ______                          ");
            Console.WriteLine(@" |       |  |--.-----.   |       |  |--.----.-----.-----.   |   _  \ .-----.-----.----.-----.");
            Console.WriteLine(@" |.|   | |     |  -__|   |.|   | |     |   _|  -__|  -__|   |.  |   \|  _  |  _  |   _|__ --|");
            Console.WriteLine(@" `-|.  |-|__|__|_____|   `-|.  |-|__|__|__| |_____|_____|   |.  |    |_____|_____|__| |_____|");
            Console.WriteLine(@"   |:  |                   |:  |                            |:  1    /                       ");
            Console.WriteLine(@"   |::.|                   |::.|                            |::.. . /                        ");
            Console.WriteLine(@"   `---'                   `---'                            `------'                         ");
            Thread.Sleep(1000);
            Console.WriteLine("Host: Mr. Breaker");
            Thread.Sleep(2000);
            Console.WriteLine("Contestant: " + name);
            Thread.Sleep(2000);
            Console.WriteLine("Camera Man: The Guy from The Ad");
            Thread.Sleep(2000);
            Console.WriteLine("Script by Samael Henkel");
            Thread.Sleep(2000);
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
        static void BuildingTension(Object o)
        {
            Console.WriteLine("(drumroll)");
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
                    break;
                case "MacroHard Doors OS":
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
                    break;
                case "Nintendont Inc":
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
                    break;
                case "Generic TV SitCom":
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
                    break;
                case "Pro Virus":
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
                    break;
                case "Upcoming Sports Event":
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
                    break;
                case "Shooty Shooty Bang Bang Movie":
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
                    break;
                case "spam":
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
                    break;
                default:
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
                    break;
            }
        }
    }
}
