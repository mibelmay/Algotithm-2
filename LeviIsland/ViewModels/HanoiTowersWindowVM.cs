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
using System.Drawing.Printing;
using System.Threading.Tasks;

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
        private int _ringHeight = 10;
        private static int _ringMoveTime = 1000;

        public ICommand Start => new CommandDelegate(param => 
        {
            GetReady();
            MakeAnimations();
        });

        public void GetReady()
        {
            Canvas0.Children.Clear();
            Canvas1.Children.Clear();
            Canvas2.Children.Clear();

            int ringWidth = 100;

            for(int i = 0; i < NumberOfRings; i++)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Width = ringWidth;
                rectangle.Height = _ringHeight;

                Canvas.SetBottom(rectangle, (Canvas0.Children.Count - 30) * 10);
                Canvas.SetLeft(rectangle, 60 - ringWidth / 2);
                rectangle.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(colors[i]);
                rectangle.StrokeThickness= 1;

                Canvas0.Children.Add(rectangle);
                ringWidth -= 5;
            }
        }

        private async void MakeAnimations()
        {
            HanoiTowers towers = new HanoiTowers();
            Movements = towers.GetMoves(NumberOfRings);
            foreach (Tuple<int, int> move in Movements)
            {
                MoveRing(move.Item1, move.Item2);
                await Task.Delay(_ringMoveTime);
            }
        }

        private void MoveRing(int from, int to)
        {
            Canvas fromColumn = FindColumn(from);
            Canvas toColumn = FindColumn(to);

            Rectangle rectangle = (Rectangle)fromColumn.Children[fromColumn.Children.Count - 1];// берем верхнее кольцо
            Canvas.SetBottom(rectangle, (toColumn.Children.Count - 30) * _ringHeight);
            fromColumn.Children.Remove(rectangle);//удаляем со старого колышка
            toColumn.Children.Add(rectangle); //перемещаем
        }

        private Canvas FindColumn(int columnNumber)
        {
            switch (columnNumber)
            {
                case 0:
                    return Canvas0;
                case 1:
                    return Canvas1;
                case 2:
                    return Canvas2;
                default:
                    break;
            }
            throw new ArgumentException("Колонка не найдена");
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
