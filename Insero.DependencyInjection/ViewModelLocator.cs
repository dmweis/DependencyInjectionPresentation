using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Insero.DependencyInjection.RandomCat;
using Insero.DependencyInjection.RandomUsers;


namespace Insero.DependencyInjection
{
    class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //if (ViewModelBase.IsInDesignModeStatic)
            //{
            //    // Create design time view services and models
            //    SimpleIoc.Default.Register<IRandomUserProvider, HardcodedUserProvider>();
            //}
            //else
            //{
            //    // Create run time view services and models
            //    SimpleIoc.Default.Register<IRandomUserProvider, RandomUserWebProvider>();

            //}

            // Select one or the other
            //SimpleIoc.Default.Register<IRandomUserProvider, HardcodedUserProvider>();
            SimpleIoc.Default.Register<IRandomUserProvider, RandomUserWebProvider>();

            SimpleIoc.Default.Register<IRandomCatProvider, RandomCatWebProvider>();

            SimpleIoc.Default.Register<UserDisplayViewModel>();
            SimpleIoc.Default.Register<RandomCatDisplayViewModel>();
        }

        public UserDisplayViewModel UserDisplayViewModel => ServiceLocator.Current.GetInstance<UserDisplayViewModel>();
        public RandomCatDisplayViewModel RandomCatDisplayViewModel => ServiceLocator.Current.GetInstance<RandomCatDisplayViewModel>();
    }
}
