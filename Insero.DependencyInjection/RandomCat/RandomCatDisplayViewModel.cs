using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Insero.DependencyInjection.RandomCat
{
    class RandomCatDisplayViewModel : ViewModelBase
    {
        private readonly IRandomCatProvider _catProvider;

        private ImageSource _randomCatImageSource;
        public ImageSource RandomCatImageSource
        {
            get => _randomCatImageSource;
            set => Set(ref _randomCatImageSource, value);
        }

        public RelayCommand ReloadCatCommand { get; }

        public RandomCatDisplayViewModel(IRandomCatProvider catProvider)
        {
            _catProvider = catProvider;
            ReloadCatCommand = new RelayCommand(LoadNewCat);
            LoadNewCat();
        }

        private void LoadNewCat()
        {
            RandomCatImageSource = _catProvider.GetRandomCat();
        }
    }
}
