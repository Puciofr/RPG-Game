using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RPG__Game
{
    public interface IPotion
    {
        BitmapImage Icon { get; set; }
        int Number { get; set; }
        string Name { get; set; }
        string ToolTip { get; set; }
    }
}
