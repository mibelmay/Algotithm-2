using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeviIsland.Models
{
    public class Coins
    {
        public int CountWays(int[] coins, int amount)
        {
            if (amount == 0)
            {
                return 1;
            }
            if (amount < 0)
            {
                return 0;
            }
            int ways = 0;
            foreach (int coin in coins)
            {
                ways += CountWays(coins, amount - coin);
            }
            return ways;
        }
    }
}
