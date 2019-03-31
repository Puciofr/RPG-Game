using RPG__Game.inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG__Game
{
    public class Inventory
    {
        public int Golds { get; set; }
        public List<IPotion> PotionInventory { get; set; }
        public IPotion GetByName(string name)
        {
            foreach (IPotion i in PotionInventory)
            {
                if (i.Name == name)
                {
                    return i;
                }
            }
            if (name == new HealthPotion().Name)
            {
                HealthPotion healthpotion = new HealthPotion();
                healthpotion.Number = 0;
                PotionInventory.Add(healthpotion);
                return healthpotion;
            } else
            {
                ManaPotion manapotion = new ManaPotion();
                manapotion.Number = 0;
                PotionInventory.Add(manapotion);
                return manapotion;
            }
        }

        public Inventory()
        {
            PotionInventory = new List<IPotion>();
        }
    }
}
