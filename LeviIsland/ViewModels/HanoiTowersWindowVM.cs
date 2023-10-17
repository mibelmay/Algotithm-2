using LeviIsland.Models;
using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;
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
        private int _speed = 500;
        public int Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                OnPropertyChanged();
            }
        }
        private bool _isButtomEnabled = true;
        public bool IsButtonEnabled
        {
            get { return _isButtomEnabled;}
            set
            {
                _isButtomEnabled = value;
                OnPropertyChanged();
            }
        }
        public int NumberOfRings { get; set; }
        private int _totalSteps;
        private List<Movement> Movements= new List<Movement>();
        private int _ringHeight = 10;
        private int _ringWidth = 150;
        private string _step;
        public string Step
        {
            get { return _step; }
            set
            {
                _step = value;
                OnPropertyChanged();
            }
        }
        public static int MaxTime = 1000;
        public static int MinTime = 1;

        public ICommand Start => new CommandDelegate(param => 
        {
            GetReady();
            HanoiTowers towers = new HanoiTowers();
            Movements = towers.GetMoves(NumberOfRings);
            _totalSteps = Movements.Count;
            MakeAnimations();
        });

        public void GetReady()
        {
            Canvas0.Children.Clear();
            Canvas1.Children.Clear();
            Canvas2.Children.Clear();
            int ringWidth = _ringWidth;

            for(int i = 0; i < NumberOfRings; i++)
            {
                Rectangle rectangle = CreateRing(i, ringWidth);
                Canvas0.Children.Add(rectangle);
                ringWidth -= 5;
            }
        }
        private Rectangle CreateRing(int number, int ringWidth)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.RadiusX = 5;
            rectangle.RadiusY = 5;
            rectangle.Width = ringWidth;
            rectangle.Height = _ringHeight;

            Canvas.SetBottom(rectangle, (Canvas0.Children.Count - 30) * 10);
            Canvas.SetLeft(rectangle, 60 - ringWidth / 2);
            rectangle.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom(colors[number]);
            rectangle.StrokeThickness = 2;
            return rectangle;   
        }

        private async void MakeAnimations()
        {
            IsButtonEnabled= false;
            foreach (Movement move in Movements)
            {
                MoveRing(move.FromRing, move.ToRing);
                Step = $"{move.FromRing} -> {move.ToRing}";
                await Task.Delay(MaxTime + MinTime - Speed);
            }
            Step = "Total : " + _totalSteps;
            IsButtonEnabled = true;
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
             "#03071E",
            "#370617",
            "#6A040F",
            "#9D0208",
            "#D00000",
            "#DC2F02",
            "#E85D04",
            "#F48C06",
            "#FAA307",
            "#FFBA08",
            "#B98B73",
            "#CB997E",
            "#DDBEA9",
            "#FFE8D6",
            "#D4C7B0",
            "#B7B7A4",
            "#A5A58D",
            "#6B705C",
            "#3F4238",
            "#1b4332",
            "#240046",
            "#3c096c",
            "#5a189a"

        }; //23 colors
    }
}
