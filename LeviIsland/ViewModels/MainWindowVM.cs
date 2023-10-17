using LeviIsland.Views;
using System.Windows.Input;
using static LeviIsland.Models.ExceptionHandler;

namespace LeviIsland.ViewModels
{
    public class MainWindowVM : ViewModel
    {
        private string _depth;
        public string Depth {
            get { return _depth; } 
            set {
                _depth = value;
                OnPropertyChanged();
            }
        }
        private string _numberOfRings;
        public string NumberOfRings
        {
            get { return _numberOfRings; }
            set
            {
                _numberOfRings = value;
                OnPropertyChanged();
            }
        }
        public ICommand OpenFractalWindow => new CommandDelegate(param => 
        {
            if (!IsDepthValid(Depth))
            {
                Depth = "Введена некорректная глубина";
                return;
            }
            LeviIslandWindow newWindow= new LeviIslandWindow();
            LeviIslandWindowVM newVM = new LeviIslandWindowVM();
            newWindow.DataContext= newVM;
            newVM.Depth = int.Parse(Depth);
            newWindow.Show();
        });

        public ICommand OpenHanoiWindow => new CommandDelegate(param =>
        {
            if (!IsDisksValid(NumberOfRings))
            {
                NumberOfRings = "Введено некорректное количество дисков";
                return;
            }
            HanoiTowersWindow newWindow = new HanoiTowersWindow();
            HanoiTowersWindowVM newVM = new HanoiTowersWindowVM();
            newWindow.DataContext= newVM;
            newVM.NumberOfRings = int.Parse(NumberOfRings);
            newWindow.Show();
            newVM.GetReady();
        });
    }
}
