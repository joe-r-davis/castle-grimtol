using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }

        public Dictionary<string, Room> Directions { get; set; }
    
        public void UseItem(Item item)
        {           
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