using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelList.ViewModel
{
    public class ViewModelLocator
    {
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            /*            if (ViewModelBase.IsInDesignModeStatic)
                        {
                            SimpleIoc.Default.Register<IDataService, DesignDataService>();
                        }
                        else
                        {
                            SimpleIoc.Default.Register<IDataService, DataService>();
                        }*/

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public static void CleanUp()
        {

        }
    }
}
