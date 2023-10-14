using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using LeviIsland.Models;

namespace LeviIsland.ViewModels
{
    class LeviIslandWindowVM : ViewModel
    {
        public int Width = 1000;
        public int Height = 700;
        public int Depth;
        private Canvas _canvas = new Canvas();
        public Canvas Canvas
        {
            get { return _canvas; }
            set
            {
                _canvas = value;
                OnPropertyChanged();
            }
        }
        public static List<Line> Lines = new List<Line>();

        public ICommand ShowFractal => new CommandDelegate(param =>
        {
            Canvas.Children.Clear();
            Lines.Clear();
            Fractal fractal = new Fractal();
            fractal.GenerateIsland(Width, Height, Depth);
            Lines = fractal.Lines;
            DrawLines(Lines);
        });

        public ICommand End => new CommandDelegate(param =>
        {
            Lines.Clear();
            Fractal fractal = new Fractal();
            fractal.GenerateIsland(Width, Height, Depth);
            Lines = fractal.Lines;
            ShowResult(Lines);
        });

        public async void DrawLines(List<Line> lines)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                Canvas.Children.Add(lines[i]);
                await Task.Delay(5);
            }
        }

        public void ShowResult(List<Line> lines)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                Canvas.Children.Add(lines[i]);
            }
        }
    }
}
