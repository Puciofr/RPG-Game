using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG__Game
{
    public class Quest
    {
        public string Description { get; set; }
        public int CurrentProgress { get; set; }
        public int CompletedProgress { get; set; }
        public int Golds { get; set; }
    }
}
