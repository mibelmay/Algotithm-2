using System;
using System.Collections.Generic;

namespace LeviIsland.Models
{
    public class HanoiTowers
    {
        private List<Tuple<int, int>> Movements = new List<Tuple<int, int>>();
        public List<Tuple<int, int>> GetMoves(int numberOfRings) 
        {
            DoAlgorithm(numberOfRings, 0, 1, 2);
            return Movements;
        }
        private void DoAlgorithm(int n, int from_rod, int to_rod, int aux_rod)
        {
            if (n > 0)
            {
                DoAlgorithm(n - 1, from_rod, aux_rod, to_rod);
                Movements.Add(new Tuple<int, int>(from_rod, to_rod));
                DoAlgorithm(n - 1, aux_rod, to_rod, from_rod);
            }
        }
    }
}
