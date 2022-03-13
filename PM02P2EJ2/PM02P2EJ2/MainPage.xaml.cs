using PM02P2EJ2.Models;
using SignaturePad.Forms;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PM02P2EJ2
{
    public partial class MainPage : ContentPage
    {
        byte[] ImageBytes;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnagregar_Clicked(object sender, EventArgs e)
        {
            Stream Firma = await firmapadview.GetImageStreamAsync(SignatureImageFormat.Png);

            try
            {
                var firma = await firmapadview.GetImageStreamAsync(SignatureImageFormat.Png);
                var fSream = (MemoryStream)firma;
                byte[] data = fSream.ToArray();
                string base64Value = Convert.ToBase64String(data);
                ImageBytes = Convert.FromBase64String(base64Value);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }

            var firmas = new Firmas
            {
                Nombre = nombre_input.Text,
                Descripcion = descripcion_input.Text,
                Imagen = ImageBytes
            };

            if(String.IsNullOrEmpty(nombre_input.Text) || String.IsNullOrEmpty(descripcion_input.Text))
            {
                await DisplayAlert("Aviso", "Todos los campos son obligatorios!", "Ok");
            }
            else
            {
                await DisplayAlert("Aviso", "Firma Registrada con Exito!!!", "Ok");
                await App.BaseDatos.GuardarFirmas(firmas);
                firmapadview.Clear();
                nombre_input.Text = "";
                descripcion_input.Text = "";
            }

            await Navigation.PushAsync(new Views.ListViewFirmas());
        }

        private async void btnlistview_firmas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.ListViewFirmas());
        }
    }
}
