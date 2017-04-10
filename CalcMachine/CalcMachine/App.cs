using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CalcMachine
{
    public class App : Application
    {
        CalcViewModel calcViewModel;
        public App()
        {
            // The root page of your application

            calcViewModel = new CalcViewModel();
            calcViewModel.RestoreState(Current.Properties);
            MainPage = new CalcMachinePage(calcViewModel);
           
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
