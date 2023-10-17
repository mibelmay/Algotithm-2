using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeviIsland.Models
{
    public static class ExceptionHandler
    {
        private static int minDepth = 1;
        private static int maxDepth = 17;


        private static int minRings = 1;
        private static int maxRings = 23;
        public static bool IsDepthValid(string input)
        {
            if(int.TryParse(input, out int depth) && depth >= minDepth && depth <= maxDepth)
                return true;
            return false;
        }

        public static bool IsDisksValid(string input)
        {
            if (int.TryParse(input, out int disks) && disks >= minRings && disks <= maxRings)
                return true;
            return false;
        }
    }
}
