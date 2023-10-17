using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeviIsland.Models
{
    public class Movement
    {
        public char FromRing { get; set; }
        public char ToRing { get; set; }

        public Movement(char fromRing, char toRing)
        {
            FromRing = fromRing;
            ToRing = toRing;
        }
    }
}
