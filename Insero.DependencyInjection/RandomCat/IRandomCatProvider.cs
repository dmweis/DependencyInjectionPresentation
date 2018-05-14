using System.Windows.Media;

namespace Insero.DependencyInjection.RandomCat
{
    interface IRandomCatProvider
    {
        ImageSource GetRandomCat();
    }
}
