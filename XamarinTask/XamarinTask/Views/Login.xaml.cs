using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTask.Views;

namespace XamarinTask
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public ICommand OpenNewViewCommand { get; private set; }
        
        public Login()
        {
            InitializeComponent();
            OpenNewViewCommand = new Command(AbrirRegistro);
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (sender, e) =>
            {
                // Realizar la navegación a la página "Registro"
                Navigation.PushAsync(new Registro());
            };

            lblRegistro.GestureRecognizers.Add(tapGestureRecognizer);
        }

        private void AbrirRegistro()
        {
            // Aquí puedes agregar la lógica para abrir la nueva vista
            // Puedes navegar a través de un NavigationPage, por ejemplo:
            Navigation.PushAsync(new Registro());
        }

        private void btnEntrar_Clicked(object sender, EventArgs e)
        {
            if (txtEmail.Text == "admin" && txtPassword.Text == "admin")
            {
                Navigation.PushAsync(new PaginaHome());
            }
            else
            {
                DisplayAlert("Error", "Email o contraseña incorrectos", "OK");
            }
        }

        private void ckbRecordar_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            bool isChecked = e.Value;

            if (isChecked == true)
            {
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                bool recuerdame = ckbRecordar.IsChecked;
                // Guarda las credenciales en las preferencias del dispositivo
                GuardarPreferenciasUsuario(email, password, recuerdame);
            }
            else
            {
                // Elimina las preferencias de usuario
                Preferences.Clear();
            }
        }

        // Método para eliminar las preferencias de nombre de usuario y contraseña
        private void RemoverPreferenciasUsuario()
        {
            if (Preferences.ContainsKey("Email"))
            {
                Preferences.Remove("Email");
            }

            if (Preferences.ContainsKey("Password"))
            {
                Preferences.Remove("Password");
            }

            if (Preferences.ContainsKey("CheckBoxState"))
            {
                bool checkBoxState = Preferences.Get("CheckBoxState", false);
                ckbRecordar.IsChecked = checkBoxState;
            }

        }

        // Método para guardar el email y la contraseña en las preferencias
        private void GuardarPreferenciasUsuario(string email, string password, bool recuerdame)
        {
            Preferences.Set("Email", email);
            Preferences.Set("Password", password);
            Preferences.Set("Recuerdame", recuerdame);

        }

        private (string, string,bool) CargarPreferenciasUsuario()
        {
            // Carga el nombre de usuario y la contraseña almacenados en las preferencias
            var email = Preferences.Get("Email", string.Empty);
            var password = Preferences.Get("Password", string.Empty);
            bool recuerdame = Preferences.Get("Recuerdame", false);
            return (email, password, recuerdame);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Carga los valores de usuario y contraseña al aparecer la página
            var (email, password, recuerdame) = CargarPreferenciasUsuario();

            // Rellena los campos de usuario y contraseña con los valores cargados
            txtEmail.Text = email;
            txtPassword.Text = password;
            // Rellena el campo de usuario solo si el estado del CheckBox es verdadero
            if (recuerdame)
            {
                txtEmail.Text = email;
            }
            else
            {
                txtEmail.Text = string.Empty;
            }

            // Rellena el campo de contraseña solo si el estado del CheckBox es verdadero
            if (recuerdame)
            {
                txtPassword.Text = password;
            }
            else
            {
                txtPassword.Text = string.Empty;
            }
            ckbRecordar.IsChecked = recuerdame;
        }
    }
}
