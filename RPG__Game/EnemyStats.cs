using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG__Game
{
    public class EnemyStats
    {
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentRage { get; set; }
        public int MaxRage { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public float DodgeChance { get; set; }

        public List<EnemyAttack> Attacks;

        public EnemyStats()
        {
            CurrentHealth = 20;
            CurrentRage = 0;
            MaxHealth = 20;
            MaxRage = 20;
            Level = 1;
            DodgeChance = 0.05F;

            Name = "Wojak";

            Attacks = new List<EnemyAttack>();

            Attacks.Add(new EnemyAttack("Autoattack", 3, -5));
            Attacks.Add(new EnemyAttack("Slam", 5, 5));

        }

        public EnemyAttack PickBestAttack()
        {
            EnemyAttack bestAttack = new EnemyAttack("",0, 0);

            foreach (EnemyAttack i in Attacks)
            {
                if (i.Cost <= CurrentRage)
                {
                    if (i.Damage >= bestAttack.Damage)
                    {
                        bestAttack = i;
                    }
                }
            }
            return bestAttack;
        }
    }
}
