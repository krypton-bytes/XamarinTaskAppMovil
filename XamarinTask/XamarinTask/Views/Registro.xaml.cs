using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTask.Modelos;

namespace XamarinTask.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        ModeloBD bd = new ModeloBD();
        public Registro()
        {
            InitializeComponent();
        }

        private void btnEntrar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtApellidoPaterno.Text) ||
                string.IsNullOrEmpty(txtApellidoMaterno.Text) ||
                string.IsNullOrEmpty(txtEdad.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtPassword.Text) ||
                string.IsNullOrEmpty(txtRepetirPassword.Text))
            {
                // Validar si la contraseña coincide
                if (txtPassword.Text == txtRepetirPassword.Text)
                {
                    Usuario usuario = new Usuario
                    {
                        Nombre = txtNombre.Text,
                        ApellidoPaterno = txtApellidoPaterno.Text,
                        ApellidoMaterno = txtApellidoMaterno.Text,
                        Edad = Convert.ToInt32(txtEdad.Text),
                        Email = txtEmail.Text,
                        Password = txtPassword.Text,
                    };
                    DisplayAlert("Registro", "Usuario registrado correctamente", "OK");
                }
                else
                {
                    DisplayAlert("Error", "Las contraseñas no coinciden", "OK");
                }


                DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
            }
            else
            {
                DisplayAlert("Registro", "Usuario registrado correctamente", "OK");
                Navigation.PushAsync(new Login());
            }
        }

    }
}
