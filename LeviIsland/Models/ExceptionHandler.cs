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
        public static bool IsDepthValid(string input)
        {
            if(int.TryParse(input, out int depth) && depth >= minDepth && depth <= maxDepth)
                return true;
            return false;
        }
    }
}
