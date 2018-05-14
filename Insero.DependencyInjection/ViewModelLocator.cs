using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
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

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            
            SimpleIoc.Default.Register<IRandomUserProvider, RandomUserWebProvider>();
            SimpleIoc.Default.Register<IRandomCatProvider, RandomCatWebProvider>();

            SimpleIoc.Default.Register<UserDisplayViewModel>();
            SimpleIoc.Default.Register<RandomCatDisplayViewModel>();
        }

        public UserDisplayViewModel UserDisplayViewModel => ServiceLocator.Current.GetInstance<UserDisplayViewModel>();
        public RandomCatDisplayViewModel RandomCatDisplayViewModel => ServiceLocator.Current.GetInstance<RandomCatDisplayViewModel>();
    }
}
