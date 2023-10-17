using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Brushes = System.Windows.Media.Brushes;

namespace LeviIsland.Models
{
    class Fractal
    {
        public List<Line> Lines = new List<Line>();

        public void GenerateIsland(int width, int height, int depth)
        {
            // вызываем метод отрисовки для каждой стороны квадрата
            Draw_Levy(width, height, (width / 2 - 100), (width / 2 + 100), (height / 2 - 100), (height / 2 - 100), depth);
            Draw_Levy(width, height, (width / 2 + 100), (width / 2 + 100), (height / 2 - 100), (height / 2 + 100), depth);
            Draw_Levy(width, height, (width / 2 + 100), (width / 2 - 100), (height / 2 + 100), (height / 2 + 100), depth);
            Draw_Levy(width, height, (width / 2 - 100), (width / 2 - 100), (height / 2 + 100), (height / 2 - 100), depth);
        }

        void Draw_Levy(int width, int height, int x1, int x2, int y1, int y2, int i)
        {
            if (i == 0)
            {
                AddLine(x1, y1, x2, y2);
            }
            else
            {
                int x3 = (x1 + x2) / 2 + (y2 - y1) / 2;
                int y3 = (y1 + y2) / 2 - (x2 - x1) / 2;

                Draw_Levy(width, height, x1, x3, y1, y3, i - 1);
                Draw_Levy(width, height, x3, x2, y3, y2, i - 1);
            }
        }

        private void AddLine(int x1, int y1, int x2, int y2)
        {
            Line newLine = new Line();
            newLine.Stroke = Brushes.White;
            newLine.X1 = x1;
            newLine.Y1 = y1;
            newLine.X2 = x2;
            newLine.Y2 = y2;
            Lines.Add(newLine);
        }
    }
}
