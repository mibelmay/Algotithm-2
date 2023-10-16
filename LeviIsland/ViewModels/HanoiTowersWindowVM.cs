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
using System.Collections.ObjectModel;

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
        private List<Tuple<char, char>> Movements = new List<Tuple<char, char>>();
        private int _ringHeight = 10;
        private static int _ringMoveTime = 500;
        public ObservableCollection<string> Steps { get; set; } = new ObservableCollection<string>();

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
                rectangle.RadiusX = 5;
                rectangle.RadiusY = 5;
                rectangle.Width = ringWidth;
                rectangle.Height = _ringHeight;

                Canvas.SetBottom(rectangle, (Canvas0.Children.Count - 30) * 10);
                Canvas.SetLeft(rectangle, 60 - ringWidth / 2);
                rectangle.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(colors[i]);
                rectangle.StrokeThickness= 2;

                Canvas0.Children.Add(rectangle);
                ringWidth -= 5;
            }
        }

        private async void MakeAnimations()
        {
            HanoiTowers towers = new HanoiTowers();
            Movements = towers.GetMoves(NumberOfRings);
            foreach (Tuple<char, char> move in Movements)
            {
                MoveRing(move.Item1, move.Item2);
                //Steps.Add($"{move.Item1} -> {move.Item2}");
                Steps.Insert(0, $"{move.Item1} -> {move.Item2}");
                await Task.Delay(_ringMoveTime);
            }
        }

        private void MoveRing(char from, char to)
        {
            Canvas fromColumn = FindColumn(from);
            Canvas toColumn = FindColumn(to);

            Rectangle rectangle = (Rectangle)fromColumn.Children[fromColumn.Children.Count - 1];// берем верхнее кольцо
            Canvas.SetBottom(rectangle, (toColumn.Children.Count - 30) * _ringHeight);
            fromColumn.Children.Remove(rectangle);//удаляем со старого колышка
            toColumn.Children.Add(rectangle); //перемещаем
        }

        private Canvas FindColumn(char columnNumber)
        {
            switch (columnNumber)
            {
                case 'A':
                    return Canvas0;
                case 'B':
                    return Canvas1;
                case 'C':
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
            "#FFFDED",
            "#03071E",
            "#370617",
            "#6A040F",
            "#9D0208",
            "#D00000",
            "#DC2F02",
            "#E85D04",
            "#F48C06",
            "#FAA307",
            "#FFBA08"
        }; //10 colors
    }
}
