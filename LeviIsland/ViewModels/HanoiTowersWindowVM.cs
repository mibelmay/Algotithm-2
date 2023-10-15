using LeviIsland.Models;
using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media;
using System.Diagnostics;

namespace LeviIsland.ViewModels
{
    public class HanoiTowersWindowVM : ViewModel
    {
        private Canvas _canvas0 = new Canvas();
        public Canvas Canvas0 
        {
            get { return _canvas0; }
            set 
            { 
                _canvas0 = value;
                OnPropertyChanged();
            }
        }
        private Canvas _canvas1 = new Canvas();
        public Canvas Canvas1
        {
            get { return _canvas1; }
            set
            {
                _canvas1 = value;
                OnPropertyChanged();
            }
        }
        private Canvas _canvas2 = new Canvas();
        public Canvas Canvas2
        {
            get { return _canvas2; }
            set
            {
                _canvas2 = value;
                OnPropertyChanged();
            }
        }
        public int NumberOfRings { get; set; }
        private List<Tuple<int, int>> Movements = new List<Tuple<int, int>>();
        public ICommand Start => new CommandDelegate(param => 
        {
            GetReady();
            //HanoiTowers towers= new HanoiTowers();
            //Movements = towers.GetMoves(NumberOfRings);
        });

        private void GetReady()
        {
            Canvas0.Children.Clear();
            Canvas1.Children.Clear();
            Canvas2.Children.Clear();

            int ringWidth = 100;

            for(int i = 0; i < NumberOfRings; i++)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Width = ringWidth;
                rectangle.Height = 10;

                Canvas.SetBottom(rectangle, (Canvas0.Children.Count - 30) * 10);
                Canvas.SetLeft(rectangle, 60 - ringWidth / 2);
                rectangle.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(colors[i]);
                rectangle.StrokeThickness= 1;

                Canvas0.Children.Add(rectangle);
                ringWidth -= 5;
            }
        }

        private List<string> colors = new List<string> 
        { 
            "#FFC567", 
            "#FD5A46", 
            "#552CB7", 
            "#00995E", 
            "#058CD7",
            "#FB7DA8",
            "#DDC192",
            "#982062", 
            "#33A9AC",
            "#FFFDED"
        }; //10 colors
    }
}
