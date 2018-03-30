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
      //Setting up the Heads Up Display!
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
        System.Console.WriteLine($"Player Name: {currentGame.CurrentPlayer.Name} *|*|* Score: {currentGame.CurrentPlayer.Score}");
        System.Console.WriteLine($@"
{currentGame.CurrentPlayer.Name} is in the {currentGame.CurrentRoom.Name}
");
        System.Console.WriteLine(currentGame.CurrentRoom.Description);
        playerInput = Console.ReadLine();
        //analyze playerInput and execute 
        currentGame.CheckPlayerInput(playerInput);

        //Have to figure out how to win the game.. and how to lose it!!
        if (currentGame.CurrentRoom.Name == "deathbycar" && !currentGame.AtSchool)
        {
          currentGame.CheckPlayerInput("west");
          Console.WriteLine(@"

        ***********OH NO THIS IS BAD**********************  
        * You chose very badly by driving today you lose *
        **************************************************  
          ");
        }
        else if (currentGame.CurrentRoom.Name == "bike" && currentGame.AtSchool)
        {
          Console.WriteLine(@"
        *********OH YEAH YOU WIN****************************
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