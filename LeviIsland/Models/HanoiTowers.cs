using System;
using System.Collections.Generic;

namespace LeviIsland.Models
{
    public class HanoiTowers
    {
        private List<Movement> movements = new List<Movement>();
        public List<Movement> GetMoves(int numberOfRings) 
        {
            DoAlgorithm(numberOfRings, 'A', 'B', 'C');
            return movements;
        }
        private void DoAlgorithm(int n, char from, char to, char temp)
        {
            if (n > 0)
            {
                DoAlgorithm(n - 1, from, temp, to);
                movements.Add(new Movement(from, to));
                DoAlgorithm(n - 1, temp, to, from);
            }
        }

    }
}
