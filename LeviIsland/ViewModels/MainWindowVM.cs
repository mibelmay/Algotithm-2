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
        public ICommand OpenFractalWindow => new CommandDelegate(param => 
        {
            LeviIslandWindow newWindow= new LeviIslandWindow();
            LeviIslandWindowVM newVM = new LeviIslandWindowVM();
            newWindow.DataContext= newVM;
            if(!IsDepthValid(Depth))
            {
                Depth = "Введена некорректная глубина";
                return;
            }
            newVM.Depth = int.Parse(Depth);
            newWindow.Show();
        });
    }
}
