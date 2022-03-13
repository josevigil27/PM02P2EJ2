using PM02P2EJ2.Controllers;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM02P2EJ2
{
    public partial class App : Application
    {
        static FirmasDB basedatos;

        public static FirmasDB BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new FirmasDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FirmasDB.db3"));
                }
                return basedatos;

            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
