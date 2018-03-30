using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
        public int Score { get; set; }
        public List<Item> Inventory { get; set; }

        public string Name { get; set; }
        public string ActiveItem { get; set; }

        public Player(string name, int score)
        {
            Name = name;
            Score = 0;
            ActiveItem = "";
            Inventory = new List<Item>();
        }

        // public void Inventory

        public void InventoryCheck()
        {
            for (int i = 0; i < this.Inventory.Count; i++)
            {
                System.Console.WriteLine($"{i + 1}. {this.Inventory[i].Name}");
            }
        }
    }
}