using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
    public class GameControl
    {
        //starting up currentGame loop
        Game currentGame = new Game();
        string playerInput;
        public void Start()
        {
            //GAME START ANNOUNCE
            Console.Clear();
            System.Console.WriteLine(@"
      ******** THE SAGA BEGINS******************************************************************************
      * Learning is great but you picked the wrong time to sleep in. You are going to be late for school!  *
      ******************************************************************************************************
        ");
            bool playing = true;
            while (playing)
            {
                //Starting room
                System.Console.WriteLine($@"
        **********************************
        Player Name: {currentGame.CurrentPlayer.Name}"); // *|*|* Score: {currentGame.CurrentPlayer.Score}
                System.Console.WriteLine($@"
        ----------------------------------       
        {currentGame.CurrentPlayer.Name} is in the {currentGame.CurrentRoom.Name}
                ");
                System.Console.WriteLine(currentGame.CurrentRoom.Description);
                playerInput = Console.ReadLine();
                 
                currentGame.CheckPlayerInput(playerInput);


                if (currentGame.CurrentRoom.Name == "deathbycar") 
                {
                    Console.WriteLine(@"
        >>>>>>>>>>>>>>>>>> HOUSTON WE HAVE A PROBLEM <<<<<<<<<<<<<<<<<<<
        
        In addition to destroying the universe by using fossil fuels 
        you have also done worse by not getting to school on time! 
        The traffic jam consumes you like a campfire hungry for
        marshmallows. Or yeah something very much like that...


        *********** SORRY YOU LOSE ***********************  
        * You chose very badly by driving today...       *
        * Would you like to play again? (Y/N)            *
        **************************************************  
          ");
                    string playAgain = Console.ReadLine();
                    if (playAgain[0] == 'n')
                    {
                        playing = false;
                    }
                    else
                    {
                        Console.Clear();
                        currentGame.Reset();
                    }
                }
                else if (currentGame.CurrentRoom.Name == "school") 
                {

                    Console.WriteLine(@"
        >>>>>>>>>>>>>>>>>>>>>>>> WE HAVE A WINNER <<<<<<<<<<<<<<<<<<<<<<

        Climbing off your bike with mere moments to spare you rush 
        into class only to realize it is Saturday... 
        
        Oh Well! At least you get an A for Awesome Sauce!


        ********* OH YEAH YOU WON **************************
        *  If you have time (and aren't late for school),  *
        *  would you like to play again? (Y/N)             *
        ****************************************************       
             
             ");
                    string playAgain = Console.ReadLine();
                    if (playAgain[0] == 'n')
                    {
                        playing = false;
                    }
                    else
                    {
                        Console.Clear();
                        currentGame.Reset();
                    }
                }
            }
        }
    }
}