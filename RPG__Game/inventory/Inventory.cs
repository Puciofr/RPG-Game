using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG__Game
{
    class Inventory
    {
        public int Golds { get; set; }
        public List<IPotion> PotionInventory { get; set; }

        public Inventory()
        {
            PotionInventory = new List<IPotion>();
        }
    }
}
