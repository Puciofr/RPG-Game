﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG__Game
{
    interface IPotion
    {
        string Name { get; set; }
        int Value { get; set; }
        int Price { get; set; }
    }
}
