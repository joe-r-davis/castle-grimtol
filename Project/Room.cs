using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }

        public Dictionary<string, Room> Directions { get; set; }

        public void UseItem(Item item, List<Room> rooms)
        {
            // figure out use item here
            if (Name.ToLower() == "office")
            {
                if (item.Name == "wrench")
                {
                    Description = @"
        You are still in your office dripping wet and realize you need to grab your
        --> powercable <-- otherwise your computer will die in the middle of Friday
        Kahoot and you will experience palpable imposter syndrome! You will need
        head --> north <-- up the stairs if you have any chance of getting to school 
        on time!

        *****************************************************************************************
        *   mini menu>> help | reset | quit | --> pick up item <-- | --> choose direction <--   *
        *****************************************************************************************
        ";
                    Directions.Add("north", rooms.Find(r => r.Name == "stairs"));
                }
            }
        }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
            Directions = new Dictionary<string, Room>();
        }
    }
}