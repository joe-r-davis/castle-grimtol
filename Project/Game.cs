using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        private List<Room> Rooms { get; set; } = new List<Room>();

        public bool AtSchool { get; set; }

        public Game()
        {
            AtSchool = false;
            CurrentPlayer = SetupPlayer();
            CurrentRoom = SetupRooms();
        }


        public Player SetupPlayer()
        {
            Console.Write("Welcome Please Provide UserName: ");
            string userInput = Console.ReadLine();
            Player player = new Player(userInput, 0);
            return player;
        }


        public Room SetupRooms()
        {
            //have to initialize first room. Add anything you need here that needs to load on start. -- may as well add rooms, etc
            Room bedroom = new Room("bedroom", @"
        You wake up from a great night of slumber. Stretching slowly you roll over and see you slept through your 
        alarms and you are running later for school! You dress as fast as possible and now you need to grab your 
        --> computer <-- (To add computer to Inventory, enter: take computer). Go --> east <-- to your office. 
        (to go east, enter: east).
        
        *****************************************************************************************
        *       mini menu>> help | reset | quit | --> take item <-- | --> go direction <--      *
        *****************************************************************************************
        
        
        ");

            Room office = new Room("office", @"
        You and realize it is flooding from the drains due to a laundry accident. 
        Even though you are running late you can't leave until you use the stop the leak! 
        First you much --> take wrench <-- and I wonder what you must ** use ** to keep this 
        water from throwing a ** wrench ** in your plans...

        *****************************************************************************************
        *       mini menu>> help | reset | quit | --> take item <-- | --> go direction <--      *
        *****************************************************************************************


        
        ");

            Room stairs = new Room("stairs", @"
        You climb the stairs and realize you are incredibly hungry. 
        You see a --> sandwich <-- on the counter next to your keys.
        Time is a wastin! Better head --> west <-- to the garage...
             
        *****************************************************************************************
        *       mini menu>> help | reset | quit | --> take item <-- | --> go direction <--      *
        *****************************************************************************************



        ");




            Room garage = new Room("garage", @"
        Even though you are running late, you see an alert on your phone that traffic is backed up. 
        You can either take your --> bike <-- or --> your car <--.
  
        *****************************************************************************************
        *       mini menu>> help | reset | quit | --> take item <-- | --> go direction <--      *
        *****************************************************************************************




        ");

            Room school = new Room("school", $@"
        Climbing off your bike with mere moments to spare you rush into class only to realize it is Saturday... 
        
        Oh Well! At least you get and A for Awesome Sauce!
                  





        ");

            Room deathbycar = new Room("deathbycar", @"
        In addition to destroying the universe by using fossil fuels you have also done worse by
        not getting to school on time! The traffic jam consumes you like a campfire hungry for
        marshmallows. Or yeah something very much like that...
                  
        *****************************************************************************************
        *       mini menu>> help | reset | quit | --> take item <-- | --> go direction <--      *
        *****************************************************************************************




        ");
            Rooms.Add(bedroom);
            Rooms.Add(office);
            Rooms.Add(stairs);
            Rooms.Add(garage);
            Rooms.Add(deathbycar);
            Rooms.Add(school);

            //bedroom directions
            bedroom.Directions.Add("east", office);


            //garage directions
            stairs.Directions.Add("west", garage);

            //bike directions
            garage.Directions.Add("bike", school);

            //car directions
            garage.Directions.Add("car", deathbycar);

            Item computer = new Item("computer", "Your laptop for school");
            Item powercable = new Item("powercable", "Won't work without it!");
            Item sandwich = new Item("sandwich", "Time to level up!");
            Item wrench = new Item("wrench", "Time to level up!");



            bedroom.Items.Add(computer);
            stairs.Items.Add(sandwich);
            office.Items.Add(wrench);
            office.Items.Add(powercable);

            return bedroom;
            //have to initialize first room
        }

        public void PickUpItem(string itemName)
        {

            Item foundItem = CurrentRoom.Items.Find(i => i.Name == itemName);

            if (foundItem != null)
            {
                CurrentRoom.Items.Remove(foundItem);
                CurrentPlayer.Inventory.Add(foundItem);
                System.Console.WriteLine("you have picked up the " + foundItem.Name);
            }
            else
            {
                System.Console.WriteLine("what there is no item found by that name");
                // joe removded + foundItem.Name
            }
        }


        public void UseItem(string itemName)
        {
            var foundItem = CurrentPlayer.Inventory.Find(i => i.Name == itemName);
            if (foundItem == null)
            {
                System.Console.WriteLine("You dont have a " + itemName);
                return;
            }

            CurrentRoom.UseItem(foundItem, Rooms);
        }
        //Have to reset room via look for min checkpoint reqs
        public void Look()
        {
            System.Console.WriteLine($"{CurrentRoom.Description}");
        }

        public static void Help()
        {
            System.Console.WriteLine(@"
            
        _________________________________________________________________________________________            
        |____HELP MENU _________________________________________________________________________|
        |    --> direction <--                                                                  |
        |        - Moves your player from room to room.                                         |
        |        - Directions: `north`, `south`, `east`, `west`                                 |
        |    --> take item <--                                                                  |
        |        - If an item can be picked up this command will put the item in your inventory |
        |    --> use item <--                                                                   |
        |        - MAY help you overcome an obstacle in the room to continue forward            |
        |    --> look <--                                                                       |
        |        - Displays the Description of the current room inventory                       |
        |    --> inventory <--                                                                  |
        |        - This command will list of the current items in your inventory                |
        |    --> reset <--                                                                      |
        |        - Start at the beginning again                                                 |
        |    --> quit <--                                                                       |
        |        - Quit playing and exit the application                                        |
        |_______________________________________________________________________________________|
            ");
        }
        public void Reset()
        {
            GameControl newGame = new GameControl();
            newGame.Start();
        }
        public void CheckPlayerInput(string playerInput)
        {
            string command = playerInput;
            string options = "";
            if (playerInput.Contains(" "))
            {
                var parsedInput = playerInput.Split(" ");
                command = parsedInput[0].ToLower();
                options = parsedInput[1].ToLower();
            }

            switch (command)
            {
                case "help":
                    Help();
                    break;
                case "reset":
                    Console.Clear();
                    Reset();
                    break;
                case "inventory":
                    CurrentPlayer.InventoryCheck();
                    break;
                case "go":
                    CurrentRoom = CurrentRoom.Directions[options];
                    break;
                case "look":
                    Look();
                    break;
                case "take":
                    PickUpItem(options);
                    break;
                case "use":
                    UseItem(options);
                    break;
                case "quit":
                    System.Environment.Exit(1);
                    break;
                default:
                    //The message the user gets when the enter the wrong choice e.g. !right choice..
                    Console.WriteLine(@"
        *********************************************************
        * Invalid Choice -- Try again                           *
        *********************************************************  

            ");
                    break;
            }

        }

        void IGame.SetupPlayer()
        {
            throw new NotImplementedException();
        }
    }
}