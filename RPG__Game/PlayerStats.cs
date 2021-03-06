﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG__Game
{
    public class PlayerStats
    {
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentMana { get; set; }
        public int MaxMana { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public float DodgeChance { get; set; }
        public int Position { get; set; }
        public int Stamina { get; set; }
        public int Intellect { get; set; }
        public int UpgradePoints { get; set; }

        public List<PlayerAttack> Attacks;

        public PlayerStats()
        {
            CurrentHealth = 20;
            CurrentMana = 20;
            MaxHealth = 20;
            MaxMana = 20;
            Level = 1;
            DodgeChance = 0.05F;
            Position = 0;
            Stamina = 0;
            Intellect = 0;
            UpgradePoints = 1;

            Name = "Vochcalpádlo";

            Attacks = new List<PlayerAttack>();

            Attacks.Add(new PlayerAttack("frostfirebolt", 5, 4));

            Attacks.Add(new PlayerAttack("pyroblast", 10, 4));

            Attacks.Add(new PlayerAttack("iceblock", 0, 4));

            Attacks.Add(new PlayerAttack("evocation", 0, 0));

            Attacks.Add(new PlayerAttack("escape", 0, 0));
        }

        public PlayerAttack GetByName(string name)
        {
            foreach (PlayerAttack i in Attacks)
            {
                if (i.Name == name)
                {
                    return i;
                }
            }
            return new PlayerAttack(name, 0, 0);
        }
    }
}
