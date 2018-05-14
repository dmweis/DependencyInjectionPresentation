using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Insero.DependencyInjection.RandomCat
{
    class RandomCatWebProvider : IRandomCatProvider
    {
        public ImageSource GetRandomCat()
        {
            var image = new BitmapImage();
            image.BeginInit();
            // this is needed to prevent WPF from cahcing the image and showing the same one on each load
            image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = new Uri(@"http://thecatapi.com/api/images/get?format=src&type=png");
            image.EndInit();
            return image;
        }
    }
}
