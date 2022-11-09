using Doors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TheThreeDoorsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Door DoorWithPrize = new();
        static Door DoorPickedByHost = new();
        static Door DoorPickedByContestant = new();
        static Image nextSprite = new();
        static MediaPlayer BGMusicPlayer = new();
        static MediaPlayer MusicPlayer = new();
        static Random random = new();
        static int wins = 0;
        static int losses = 0;
        static int TextNr = 1;
        static double previousVolume = 0;
        static string name = "";
        static string Choice = "";
        static string CurrentDir = Directory.GetCurrentDirectory();
        static bool music = true;
        static bool InGame = false;
        static bool win = false;
        public MainWindow()
        {
            InitializeComponent();
            BGMusicPlayer.MediaEnded += new EventHandler(repeatBG);
            BGMusicPlayer.Open (new Uri (CurrentDir + @"\BGMusic\TVStatic.mp3"));
            BGMusicPlayer.Volume = 0.3;
            BGMusicPlayer.Play(); //Constantly play TV Static noises
        }
        private void repeatBG(object sender, EventArgs e)
        {
            BGMusicPlayer.Position = TimeSpan.Zero;
            BGMusicPlayer.Play(); //Set back to beginning and play again
        }
        private void repeat(object sender, EventArgs e)
        {
            MusicPlayer.Position = TimeSpan.Zero;
            MusicPlayer.Play(); //Set back to beginning and play again
        }
        public void TVStartUp(object sender, RoutedEventArgs e) {
            TVStarter.Visibility = Visibility.Collapsed; //Button isnt needed anymore
            TVstatic.Opacity = 0.3;
            TVstatic.IsHitTestVisible = false; //Static is now see- and clickthrough
            if (music == true)
            {
                BGMusicPlayer.Volume = 0.009; // Reduce Music Volume
            } else
            {
                previousVolume = 0.009; // Reduce what would be Music Volume
            }
        }
        public void ToggleMusic(object sender, RoutedEventArgs e)
        {
            if(music == true)
            {
                previousVolume = BGMusicPlayer.Volume; //Neccessary due to it getting lowered
                BGMusicPlayer.Volume = 0;
                MusicPlayer.Volume = 0; //Mutes all
                music = false;
            } else
            {
                BGMusicPlayer.Volume = previousVolume;
                MusicPlayer.Volume = 0.5; //Set back to previous level
                music = true;
            }
        }
        public void ToggleFullscreen(object sender, RoutedEventArgs e)
        {
            //Toggles Fullscreen
            if(GameWindow.WindowState == WindowState.Normal || GameWindow.WindowStyle == WindowStyle.SingleBorderWindow)
            {
                GameWindow.WindowStyle = WindowStyle.None;
                GameWindow.WindowState = WindowState.Maximized;
            } else
            {
                GameWindow.WindowStyle = WindowStyle.SingleBorderWindow;
                GameWindow.WindowState = WindowState.Normal;
            }
        }
        public void EnterPlayerName(object sender, RoutedEventArgs e)
        {
            //Makes you enter a Name before it actually starts
            MainMenu.Visibility = Visibility.Hidden;
            EnterName.Visibility = Visibility.Visible;
        }
        public void StartGame(object sender, RoutedEventArgs e)
        {
            //Starts Game
            name = ContestantName.Text;
            MusicPlayer.Open(new Uri(CurrentDir + @"\Music\TheThreeDoorsTheme.mp3"));
            MusicPlayer.Play();
            EnterName.Visibility = Visibility.Hidden;
            GameShow.Visibility = Visibility.Visible;
            InGame = true;
        }
        public void HowtoplayToMainMenu(object sender, RoutedEventArgs e)
        {
            //Switching between How To Play and Main Menu
            if(MainMenu.Visibility == Visibility.Hidden)
            {
                HowToPlay.Visibility = Visibility.Hidden;
                MainMenu.Visibility = Visibility.Visible;
            }
            else
            {
                HowToPlay.Visibility = Visibility.Visible;
                MainMenu.Visibility = Visibility.Hidden;
            }
        }
        public void GameShowProcedure(object sender, KeyEventArgs e)
        {
            //Game Show Dialouge
            if(e.Key == Key.Z && InGame)
            {
                switch (TextNr)
                {
                    case 1:
                        DoorPickedByContestant.IsPrizeDoor = false;
                        win = false;
                        DoorWithPrize.DoorNr = random.Next(1, 4);
                        DoorPickedByHost.DoorNr = random.Next(1, 4);
                        DoorWithPrize.IsPrizeDoor = true; //resets in case youve already played a round
                        TextNr++;
                        nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/HostTalking.png", UriKind.Relative));
                        Host.Source = nextSprite.Source;                                    //Changes Sprite of Person who is talking/stopped talking
                        Talking.Content = "Host: ";                                         //Who is talking
                        Talked.Content = "Hello everybody and welcome to The Three Doors!"; //What is said
                        break;
                    case 2:
                        TextNr++;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "I am Mr. Breaker from the Breaking News Channel!";
                        break;
                    case 3:
                        TextNr++;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "Please welcome todays Contestant: " + name + "!";
                        break;
                    case 4:
                        TextNr++;
                        nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/HostSilent.png", UriKind.Relative));
                        Host.Source = nextSprite.Source;
                        Talking.Content = "Audience: ";
                        Talked.Content = "*applause*";
                        MusicPlayer.Open(new Uri(CurrentDir + @"\Music\TheThreeDoorsTheme.mp3"));
                        MusicPlayer.Play();
                        Contestant.Visibility = Visibility.Visible; //Contestant appears with Applause.
                        break;
                    case 5:
                        TextNr++;
                        nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/ContestantTalking.png", UriKind.Relative));
                        Contestant.Source = nextSprite.Source;
                        Talking.Content = name + ": ";
                        Talked.Content = "Thanks for having me here, Mr Breaker"; //Contestant thanks Host
                        break;
                    case 6:
                        nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/ContestantNeutral.png", UriKind.Relative));
                        if (random.Next(1, 11) == 10)
                        {
                            nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/ContestantCursed.png", UriKind.Relative));
                        }
                        Contestant.Source = nextSprite.Source;
                        nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/HostTalking.png", UriKind.Relative));
                        Host.Source = nextSprite.Source;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "No Problem! Are you ready to Start?"; //Host asks if Contestant is ready
                        MessageBoxResult Continue = MessageBox.Show("Are you ready to Start?", "Mr. Breaker asked", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (Continue == MessageBoxResult.Yes)
                        {
                            TextNr = 19;
                            nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/HostSilent.png", UriKind.Relative));
                            Host.Source = nextSprite.Source;
                            nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/ContestantTalking.png", UriKind.Relative));
                            Contestant.Source = nextSprite.Source;
                            Talking.Content = name + ": ";
                            Talked.Content = "Yes, Im ready!";
                        } else
                        {
                            TextNr++;
                            nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/HostSilent.png", UriKind.Relative));
                            Host.Source = nextSprite.Source;
                            nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/ContestantTalking.png", UriKind.Relative));
                            Contestant.Source = nextSprite.Source;
                            Talking.Content = name + ": ";
                            Talked.Content = "No, could you please explain the Rules?";
                        }
                        break;
                    case 7:
                        TextNr++;
                        nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/ContestantNeutral.png", UriKind.Relative));
                        Contestant.Source = nextSprite.Source;
                        nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/HostTalking.png", UriKind.Relative));
                        Host.Source = nextSprite.Source;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "But of Course! The Rules are simple:";
                        break;
                    case 8:
                        TextNr++;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "On the Stage over there are three Doors.";
                        break;
                    case 9:
                        TextNr++;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "Behind one of them is a prize,";
                        break;
                    case 10:
                        TextNr++;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "behind the others is nothing.";
                        break;
                    case 11:
                        TextNr++;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "You can choose a door, any door.";
                        break;
                    case 12:
                        TextNr++;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "Then, I'll will open a door that";
                        break;
                    case 13:
                        TextNr++;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "that doesnt contain the prize";
                        break;
                    case 14:
                        TextNr++;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "After that, you get to choose if you";
                        break;
                    case 15:
                        TextNr++;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "want to stay with your original Choice";
                        break;
                    case 16:
                        TextNr++;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "or if you want to switch.";
                        break;
                    case 17:
                        TextNr++;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "If you choose the Door with the Prize, you win.";
                        break;
                    case 18:
                        nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/HostSilent.png", UriKind.Relative));
                        Host.Source = nextSprite.Source;
                        nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/ContestantTalking.png", UriKind.Relative));
                        Contestant.Source = nextSprite.Source;
                        Talking.Content = name + ": ";
                        Talked.Content = "Thanks for explaining, Mr. Breaker!";
                        TextNr = 6;
                        break;
                    case 19:
                        TextNr++;
                        nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/ContestantFocused.png", UriKind.Relative));
                        if (random.Next(1, 11) == 10)
                        {
                            nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/ContestantCursedFocused.png", UriKind.Relative));
                        }
                        Contestant.Source = nextSprite.Source;
                        nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/HostTalking.png", UriKind.Relative));
                        Host.Source = nextSprite.Source;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "Alright, then. Now, you must choose a Door";
                        MusicPlayer.Open(new Uri(CurrentDir + @"\Music\TheChoosingGame.mp3"));
                        MusicPlayer.Play();
                        MusicPlayer.MediaEnded += new EventHandler(repeat);
                        PickDoor1.Visibility = Visibility.Visible;
                        PickDoor2.Visibility = Visibility.Visible;
                        PickDoor3.Visibility = Visibility.Visible;
                        InGame = false;
                        break;
                    case 20:
                        while (DoorPickedByHost.DoorNr == DoorPickedByContestant.DoorNr | DoorPickedByHost.DoorNr == DoorWithPrize.DoorNr)
                        {
                            DoorPickedByHost.DoorNr = random.Next(1, 4);
                        }
                        TextNr = 33;
                        nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/ContestantNeutral.png", UriKind.Relative));
                        Contestant.Source = nextSprite.Source;
                        nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/HostTalking.png", UriKind.Relative));
                        Host.Source = nextSprite.Source;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "Okay, Door " + DoorPickedByContestant.DoorNr + " is logged in.";
                        break;
                    case 21:
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "doesnt contain the Prize: Door " + DoorPickedByHost.DoorNr + "!";
                        Image HostPickedDoor = GameShow.FindName("Door" + DoorPickedByHost.DoorNr) as Image;
                        HostPickedDoor.Source = new BitmapImage(new Uri(@"/InportantSprites/DoorOpenNoPrize.png", UriKind.Relative));
                        if(random.Next(1, 11) == 10)
                        {
                            HostPickedDoor.Source = new BitmapImage(new Uri(@"/InportantSprites/DoorOpenMemeyNoPrize.png", UriKind.Relative));
                        }
                        MusicPlayer.Open(new Uri(CurrentDir + @"\Music\ADoorIsOpened.mp3"));
                        MusicPlayer.Play();
                        TextNr++;
                        break;
                    case 22:
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "Now, do you want to Switch to Door " + (6 - DoorPickedByHost.DoorNr - DoorPickedByContestant.DoorNr) + "?";
                        nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/ContestantMoreFocused.png", UriKind.Relative));
                        MusicPlayer.Open(new Uri(CurrentDir + @"\Music\ALastChoiceToBeMade.mp3"));
                        MusicPlayer.Play();
                        MusicPlayer.MediaEnded += new EventHandler(repeat);
                        MessageBoxResult switching = MessageBox.Show("Do you want to Switch to Door " + (6 - DoorPickedByHost.DoorNr - DoorPickedByContestant.DoorNr) + "?", "Mr. Breaker asked", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (switching == MessageBoxResult.Yes)
                        {
                            TextNr++;
                            nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/HostSilent.png", UriKind.Relative));
                            Host.Source = nextSprite.Source;
                            nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/ContestantTalking.png", UriKind.Relative));
                            Contestant.Source = nextSprite.Source;
                            Talking.Content = name + ": ";
                            Talked.Content = "Yes, I switch!";
                            Choice = "Switched";
                            DoorPickedByContestant.DoorNr = 6 - DoorPickedByHost.DoorNr - DoorPickedByContestant.DoorNr;
                        }
                        else
                        {
                            TextNr++;
                            nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/HostSilent.png", UriKind.Relative));
                            Host.Source = nextSprite.Source;
                            nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/ContestantTalking.png", UriKind.Relative));
                            Contestant.Source = nextSprite.Source;
                            Talking.Content = name + ": ";
                            Talked.Content = "No, ill stay!";
                            Choice = "Stayed";
                        }
                        if (DoorPickedByContestant.DoorNr == DoorWithPrize.DoorNr)
                        {
                            DoorPickedByContestant.IsPrizeDoor = true;
                        }
                        MusicPlayer.MediaEnded -= repeat;
                        MusicPlayer.Open(new Uri(CurrentDir + @"\Music\TheLastChoiceWasMade.mp3"));
                        MusicPlayer.Play();
                        break;
                    case 23:
                        TextNr++;
                        nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/ContestantNeutral.png", UriKind.Relative));
                        Contestant.Source = nextSprite.Source;
                        nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/HostTalking.png", UriKind.Relative));
                        Host.Source = nextSprite.Source;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "Okay, Your Choice is logged in.";
                        break;
                    case 24:
                        TextNr++;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "Now, its Time to show behind which Door the Prize is...";
                        MusicPlayer.Open(new Uri(CurrentDir + @"\Music\Drumroll.mp3"));
                        MusicPlayer.Play();
                        MusicPlayer.MediaEnded += new EventHandler(repeat);
                        break;
                    case 25:
                        TextNr++;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "Its behind...";
                        break;
                    case 26:
                        TextNr++;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "Door " + DoorWithPrize.DoorNr + "!";
                        Image PrizeDoor = GameShow.FindName("Door" + DoorWithPrize.DoorNr) as Image;
                        PrizeDoor.Source = new BitmapImage(new Uri(@"/InportantSprites/DoorOpenPrize.png", UriKind.Relative));
                        MusicPlayer.MediaEnded -= repeat;
                        losses = Convert.ToInt32(File.ReadAllText(CurrentDir + @"\Stats\" + Choice + @"\Losses.txt"));
                        wins = Convert.ToInt32(File.ReadAllText(CurrentDir + @"\Stats\" + Choice + @"\Wins.txt"));
                        if (DoorPickedByContestant.IsPrizeDoor)
                        {
                            MusicPlayer.Open(new Uri(CurrentDir + @"\Music\CorrectChoice.mp3"));
                            wins++;
                            File.WriteAllText(CurrentDir + @"\Stats\" + Choice + @"\Wins.txt", wins.ToString());
                            nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/ContestantHappy.png", UriKind.Relative));
                            Contestant.Source = nextSprite.Source;
                            win = true;
                        }
                        else
                        {
                            MusicPlayer.Open(new Uri(CurrentDir + @"\Music\WrongChoice.mp3"));
                            nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/ContestantSad.png", UriKind.Relative));
                            Contestant.Source = nextSprite.Source;
                            losses++;
                            File.WriteAllText(CurrentDir + @"\Stats\" + Choice + @"\Losses.txt", losses.ToString());
                            win = false;
                        }
                        MusicPlayer.Play();
                        break;
                    case 27:
                        TextNr++;
                        Talking.Content = "Mr. Breaker: ";
                        if (win)
                        {
                            Talked.Content = "Congrats, You won!";
                        } else
                        {
                            Talked.Content = "Welp, You lost!";
                        }
                        break;
                    case 28:
                        TextNr++;
                        Talking.Content = "Mr. Breaker: ";
                        if (win)
                        {
                            Talked.Content = "Just as " + wins + " out of " + (wins + losses) + " other people.";
                        } else
                        {
                            Talked.Content = "Just as " + losses + " out of " + (wins + losses) + " other people.";
                        }
                        break;
                    case 29:
                        TextNr++;
                        Talking.Content = "Mr. Breaker: ";
                        double percentage = 100.0 / (wins + losses);
                        if (win)
                        {
                            percentage *= wins;
                        }
                        else
                        {
                            percentage *= losses;
                        }
                        Talked.Content = "Thats " + Math.Round(percentage) + " Percent!";
                        break;
                    case 30:
                        Contestant.Visibility = Visibility.Hidden;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "I hope you enjoyed todays Episode.";
                        TextNr++;
                        break;
                    case 31:
                        Contestant.Visibility = Visibility.Hidden;
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "See you next Time on...";
                        TextNr++;
                        break;
                    case 32:
                        GameShow.Visibility = Visibility.Hidden;
                        MainMenu.Visibility = Visibility.Visible;
                        DoorWithPrize.DoorNr = random.Next(1, 4);
                        nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/HostSilent.png", UriKind.Relative));
                        Host.Source = nextSprite.Source;
                        nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/ContestantNeutral.png", UriKind.Relative));
                        Contestant.Source = nextSprite.Source;
                        nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/Door1Closed.png", UriKind.Relative));
                        Door1.Source = nextSprite.Source;
                        nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/Door2Closed.png", UriKind.Relative));
                        Door2.Source = nextSprite.Source;
                        nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/Door3Closed.png", UriKind.Relative));
                        Door3.Source = nextSprite.Source;
                        MusicPlayer.Open(new Uri(CurrentDir + @"\Music\TheThreeDoorsTheme.mp3"));
                        MusicPlayer.Play();
                        Talking.Content = "Audience: ";
                        Talked.Content = "*applause*";
                        TextNr = 1;
                        InGame = false;
                        break;
                    case 33:
                        Talking.Content = "Mr. Breaker: ";
                        Talked.Content = "Now, im going to open a Door that";
                        TextNr = 21;
                        break;
                }
            }
        }
        public void ContestantPicksDoor(object sender, RoutedEventArgs e)
        {
            MusicPlayer.MediaEnded -= repeat;
            MusicPlayer.Open(new Uri(CurrentDir + @"\Music\AChoiceWasMade.mp3"));
            MusicPlayer.Play();
            nextSprite.Source = new BitmapImage(new Uri(@"/InportantSprites/ContestantTalking.png", UriKind.Relative));
            Contestant.Source = nextSprite.Source;
            Button button = sender as Button;
            Choice = button.Content.ToString();
            DoorPickedByContestant.DoorNr = Convert.ToInt32(Choice);
            Talking.Content = name + ": ";
            Talked.Content = "Ill pick Door " + DoorPickedByContestant.DoorNr.ToString() + "!";
            PickDoor1.Visibility = Visibility.Hidden;
            PickDoor2.Visibility = Visibility.Hidden;
            PickDoor3.Visibility = Visibility.Hidden;
            InGame = true;
        }
        public void exit(object sender, RoutedEventArgs e)
        {
            MessageBoxResult WantToExit = MessageBox.Show("Are you sure you want to Quit?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(WantToExit == MessageBoxResult.Yes)
            {
                Close();
            }
        }
    }
}
