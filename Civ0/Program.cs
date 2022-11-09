using System;

namespace Civ0
{
    class Program
    {
        static void Main()
        {
            string NameOfPlayer;
            string NameOfCountry;
            long food = 100;
            int workers = 10;
            int fighters = 10;
            int unassigned = 0;
            int engineers = 0;
            int totalpeeps = 20;
            long seeds = 10;
            long terretories = 10;
            int plantedseeds = 0;
            int takenterretories = 0;
            int year = 0;
            int foodperperson = 1;
            Console.WriteLine("Enter your Name");
            NameOfPlayer = Console.ReadLine();
            Console.WriteLine("Enter your country's Name");
            NameOfCountry = Console.ReadLine();
            while (terretories >= 1 && totalpeeps >= 1 && year < 100)
            {
                bool turn = true;
                Console.WriteLine(NameOfPlayer + " of " + NameOfCountry + ": Year " + year + "0");
                totalpeeps = workers + fighters + unassigned + engineers;
                Console.WriteLine("There are " + totalpeeps + " people in your country: " + workers + " Workers, " + fighters + " Fighters, " + engineers + " Engineers and " + unassigned + "unassigned.");
                Console.WriteLine("They will get " + foodperperson + "/1 Food to survive or /2 to have a chance to reproduce");
                Console.WriteLine("You have " + food + " Units of Food, " + seeds + " Units of Seeds and " + terretories + " Units of Land");
                while (turn)
                {
                    Console.WriteLine("What will you do:");
                    string toDo = Console.ReadLine();
                    bool IsNum = false;
                    string Input;
                    switch (toDo)
                    {
                        case "plantSeeds":
                            IsNum = false;
                            while (!IsNum)
                            {
                                Console.WriteLine("How Many Seeds do you want to plant?");
                                Input = Console.ReadLine();
                                IsNum = int.TryParse(Input, out plantedseeds);
                                if (IsNum)
                                {
                                    plantedseeds = Convert.ToInt32(Input);
                                    if (plantedseeds > workers)
                                    {
                                        Console.WriteLine("Not enougth Workers");
                                        IsNum = false;
                                    }
                                    else if (plantedseeds > seeds)
                                    {
                                        Console.WriteLine("Not enougth Seeds");
                                        IsNum = false;
                                    }
                                    else if (plantedseeds > terretories)
                                    {
                                        Console.WriteLine("Not enougth terretory");
                                        IsNum = false;
                                    }
                                    else
                                    {
                                        seeds -= plantedseeds;
                                        Console.WriteLine("Planted " + plantedseeds + " Seeds.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Thats not a number!");
                                }
                            }
                            break;
                        case "takeTerretory":
                            IsNum = false;
                            while (!IsNum)
                            {
                                Console.WriteLine("How much Terretory do you want to plant?");
                                Input = Console.ReadLine();
                                IsNum = int.TryParse(Input, out takenterretories);
                                if (IsNum)
                                {
                                    takenterretories = Convert.ToInt32(Input);
                                    if (takenterretories > fighters)
                                    {
                                        Console.WriteLine("Not enougth Fighters");
                                        IsNum = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Took " + takenterretories + " Units of Terretory.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Thats not a number!");
                                }
                            }
                            break;
                        case "reassignPeeps":
                            IsNum = false;
                            while (!IsNum)
                            {
                                Console.WriteLine("How many Workers do you want?");
                                Input = Console.ReadLine();
                                IsNum = int.TryParse(Input, out workers);
                                if (IsNum)
                                {
                                    if (totalpeeps < Convert.ToInt32(Input))
                                    {
                                        Console.WriteLine("Not enough People!");
                                        IsNum = false;
                                    }
                                    else
                                    {
                                        workers = Convert.ToInt32(Input);
                                        totalpeeps -= workers;
                                        Console.WriteLine("There are now " + workers + " Workers.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Thats not a number!");
                                }
                            }
                            IsNum = false;
                            while (!IsNum)
                            {
                                Console.WriteLine("How many Fighters do you want?");
                                Input = Console.ReadLine();
                                IsNum = int.TryParse(Input, out fighters);
                                if (IsNum)
                                {
                                    if (totalpeeps < Convert.ToInt32(Input))
                                    {
                                        Console.WriteLine("Not enough People!");
                                        IsNum = false;
                                    }
                                    else
                                    {
                                        fighters = Convert.ToInt32(Input);
                                        totalpeeps -= fighters;
                                        Console.WriteLine("There are now " + fighters + " Fighters.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Thats not a number!");
                                }
                            }
                            IsNum = false;
                            while (!IsNum)
                            {
                                Console.WriteLine("How many Engineers do you want?");
                                Input = Console.ReadLine();
                                IsNum = int.TryParse(Input, out engineers);
                                if (IsNum)
                                {
                                    if (totalpeeps < Convert.ToInt32(Input))
                                    {
                                        Console.WriteLine("Not enough People!");
                                        IsNum = false;
                                    }
                                    else
                                    {
                                        engineers = Convert.ToInt32(Input);
                                        totalpeeps -= engineers;
                                        Console.WriteLine("There are now " + engineers + " Engineers.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Thats not a number!");
                                }
                            }
                            unassigned = totalpeeps;
                            Console.WriteLine("There are " + unassigned + " People without assignment left.");
                            totalpeeps = unassigned + engineers + fighters + workers;
                            break;
                        case "changeFood":
                            IsNum = false;
                            while (!IsNum)
                            {
                                Console.WriteLine("How much Food do you want everyone to get?");
                                Input = Console.ReadLine();
                                IsNum = Int32.TryParse(Input, out foodperperson);
                                if (IsNum)
                                {
                                    foodperperson = Convert.ToInt32(Input);
                                    Console.WriteLine("Each Person now gets " + foodperperson + " Units of Food.");
                                }
                                else
                                {
                                    Console.WriteLine("Thats not a number!");
                                }
                            }
                            break;
                        case "endTurn":
                            turn = false;
                            Random random = new();
                            int weather = random.Next(1, 6) + random.Next(1, 6);
                            switch (weather)
                            {
                                case 2:
                                case 12:
                                    Console.WriteLine("Storms destroyed all the crops! No Food gained.");
                                    food += engineers + 1;
                                    seeds += engineers + 1;
                                    plantedseeds = 0;
                                    break;
                                case 3:
                                case 11:
                                    Console.WriteLine("Greatest Weather in recorded History! Quadruple the food gained");
                                    food += plantedseeds * 4 * (engineers + 1);
                                    seeds += plantedseeds * 2 * (engineers + 1);
                                    plantedseeds = 0;
                                    break;
                                case 4:
                                case 10:
                                    Console.WriteLine("Horrible Weather! Only half the Food gained.");
                                    food += plantedseeds / 2 * (engineers + 1);
                                    seeds += plantedseeds / 4 * (engineers + 1);
                                    plantedseeds = 0;
                                    break;
                                case 5:
                                case 9:
                                    Console.WriteLine("Good Weather! Double the Food gained");
                                    food += plantedseeds * 2 * (engineers + 1);
                                    seeds += plantedseeds * (3 / 2) * (engineers + 1);
                                    plantedseeds = 0;
                                    break;
                                default:
                                    Console.WriteLine("Regular Weather. Regular Food Gains");
                                    food += plantedseeds;
                                    seeds += plantedseeds;
                                    plantedseeds = 0;
                                    break;
                            }
                            if (takenterretories >= 1)
                            {
                                int millitarysuccess = random.Next(1, 6);
                                switch (millitarysuccess)
                                {
                                    case 1:
                                        Console.WriteLine("Crushing Defeat! We lost territory");
                                        takenterretories = 0;
                                        terretories -= 2;
                                        break;
                                    case 2:
                                        Console.WriteLine("Defeat! We have to pay in Food");
                                        takenterretories = 0;
                                        food -= fighters;
                                        break;
                                    case 3:
                                        Console.WriteLine("Stalemate! Nothing changed.");
                                        takenterretories = 0;
                                        break;
                                    case 4:
                                        Console.WriteLine("Victory! We gained all wanted Territories");
                                        terretories += takenterretories;
                                        takenterretories = 0;
                                        break;
                                    case 5:
                                        Console.WriteLine("Dominative Victory! They surrendered and handed over food and more Territory");
                                        terretories += (takenterretories * 3 / 2);
                                        food += takenterretories;
                                        takenterretories = 0;
                                        break;
                                    default:
                                        Console.WriteLine("Minor Victory! We gained some wanted Territories");
                                        terretories += takenterretories / 2;
                                        takenterretories = 0;
                                        break;
                                }
                            }
                            if (Convert.ToInt32(foodperperson * totalpeeps) <= food)
                            {
                                food -= Convert.ToInt32(foodperperson * totalpeeps);
                            }
                            else
                            {
                                foodperperson = Convert.ToInt32(food / totalpeeps);
                                Console.WriteLine("There wasnt enougth food for everybody, so everybody just got " + foodperperson + " each");
                            }
                            if (foodperperson >= 2)
                            {
                                Console.WriteLine((totalpeeps / 4 * Convert.ToInt32(4 / foodperperson)) + " new People were born.");
                                unassigned += totalpeeps / Convert.ToInt32(4 / foodperperson);
                                totalpeeps = unassigned + workers + fighters + engineers;
                            }
                            if (foodperperson < 1)
                            {
                                int previousPop = totalpeeps;
                                unassigned = Convert.ToInt32(unassigned * foodperperson);
                                workers = Convert.ToInt32(workers * foodperperson);
                                fighters = Convert.ToInt32(fighters * foodperperson);
                                engineers = Convert.ToInt32(engineers * foodperperson);
                                totalpeeps = unassigned + workers + fighters + engineers;
                                int lostPop = previousPop - totalpeeps;
                                Console.WriteLine(lostPop + " people starved to death");
                            }
                            if (seeds < 0)
                            {
                                seeds = Math.Abs(seeds);
                            }
                            year += 1;
                            turn = false;
                            break;
                        case "help":
                            Console.WriteLine("help - Brings up this list");
                            Console.WriteLine("plantSeeds - Plant seeds at 1 seed per terretory and worker");
                            Console.WriteLine("takeTerretory - Send warriors to take terretory with a random chance of Success");
                            Console.WriteLine("reassignPeeps - Change the Assignment of Jobs of your people");
                            Console.WriteLine("changeFood - Changes how much food you give");
                            Console.WriteLine("endTurn - Ends your turn");
                            Console.WriteLine("For other Kinds of Help, open manual.txt");
                            break;
                        default:
                            Console.WriteLine("Didnt recognize Command: Type 'help' for Help");
                            break;
                    }
                }
            }
            if (year == 100)
            {
                Console.WriteLine("Congrats! You have led your Country for 1000 years without falling to enemies or starvation.");
            }
            else
            {
                if (terretories >= 0)
                {
                    Console.WriteLine("You were defeated by a military campaign you started. Ironic, warmongerer!");
                }
                if (totalpeeps == 0)
                {
                    Console.WriteLine("All your people have died due to starvation. Maybe you were just unlucky, maybe youve mismanaged your Foodsupply. Anyways, you lost.");
                }
                Console.WriteLine("You lasted til Year " + year + "0");
            }
            long points = terretories + food + seeds + totalpeeps + (year * 10);
            Console.WriteLine("You ended up with a total of " + points + " Points");
        }
    }
}
