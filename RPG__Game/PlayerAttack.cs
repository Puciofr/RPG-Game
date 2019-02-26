using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG__Game
{
    public class PlayerAttack
    {
        public string Name { get; set; }

        public int Damage { get; set; }

        public int Cost { get; set; }

        public PlayerAttack(string name, int damage, int cost)
        {
            Name = name;
            Damage = damage;
            Cost = cost;
        }
    }
}
