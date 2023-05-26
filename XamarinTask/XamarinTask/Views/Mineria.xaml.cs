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
    public partial class Mineria : ContentPage
    {
        ModeloBD bd = new ModeloBD();
        public Mineria()
        {
            InitializeComponent();
            ObtenerDatos();
        }
        private void ObtenerDatos()
        {
            var users = (from Usuario usuario in bd.Usuarios
                         where usuario.Empleo.Sueldo >= 25000 && usuario.Empleo.Sueldo <= 50000
                         select new UsuarioDTO
                         {
                             ID = usuario.ID,
                             Nombre = usuario.Nombre,
                             ApellidoMaterno = usuario.ApellidoMaterno,
                             ApellidoPaterno = usuario.ApellidoPaterno,
                             Edad = usuario.Edad,
                             DireccionPais = usuario.Direccion.Pais,
                             EmpleoNombre = usuario.Empleo.Cargo
                         }).ToList();
        }
    }
}