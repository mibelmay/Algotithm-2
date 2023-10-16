using System;
using System.Collections.Generic;

namespace LeviIsland.Models
{
    public class HanoiTowers
    {
        private List<Tuple<char, char>> Movements = new List<Tuple<char, char>>();
        public List<Tuple<char, char>> GetMoves(int numberOfRings) 
        {
            DoAlgorithm(numberOfRings, 'A', 'B', 'C');
            return Movements;
        }
        private void DoAlgorithm(int n, char from, char to, char temp)
        {
            if (n > 0)
            {
                DoAlgorithm(n - 1, from, temp, to);
                Movements.Add(new Tuple<char, char>(from, to));
                DoAlgorithm(n - 1, temp, to, from);
            }
        }

    }
}
