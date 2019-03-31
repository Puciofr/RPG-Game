using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RPG__Game.inventory
{
    class ManaPotion : IPotion
    {
        public BitmapImage Icon { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string ToolTip { get; set; }

        public ManaPotion()
        {
            Icon = new BitmapImage(new Uri("pack://application:,,,/resources/items/potion_mana.jpg"));
            Number = 5;
            Name = "ManaPotion";
            ToolTip = "Přidá 20 many";
        }
    }
}
