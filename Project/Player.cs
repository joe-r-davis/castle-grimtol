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

        public string AssignItem()
        {
            System.Console.WriteLine("Which Item?");
            for (int i = 0; i < Inventory.Count; i++)
            {
                System.Console.WriteLine($"{i + 1}. {Inventory[i].Name}");
            }
            int pickedItem;
            string playerPick = System.Console.ReadLine();
            int.TryParse(playerPick, out pickedItem);
            if (pickedItem > -1 && pickedItem <= Inventory.Count)
            {
                return Inventory[pickedItem - 1].Name;
            }
            else
            {
                System.Console.WriteLine(@"
            Sorry, please make a valid selection. Or not.
            I will keep printing this until the skynet falls.");
                return null;
            }
        }
    }
}