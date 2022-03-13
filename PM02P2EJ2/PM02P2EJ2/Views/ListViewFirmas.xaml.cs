using PM02P2EJ2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM02P2EJ2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewFirmas : ContentPage
    {
        Firmas users = new Firmas();

        public ListViewFirmas()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var listviewfirmas = await App.BaseDatos.ListViewFirmas();
            ObservableCollection<Firmas> observableCollectionFirmas = new ObservableCollection<Firmas>();
            listview_firmas.ItemsSource = observableCollectionFirmas;

            foreach (Firmas firma in listviewfirmas)
            {
                observableCollectionFirmas.Add(firma);
            }
        }
    }
}