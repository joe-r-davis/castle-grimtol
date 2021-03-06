using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public interface IGame
    {
        Room CurrentRoom { get; set; }
        Player CurrentPlayer { get; set; }

        void SetupPlayer();
        void Reset();

        //No need to Pass a room since Items can only be used in the CurrentRoom
        void UseItem(string itemName);

    }
}
