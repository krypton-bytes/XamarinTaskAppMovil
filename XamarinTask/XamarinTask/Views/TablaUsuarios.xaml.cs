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
    public partial class TablaUsuarios : ContentPage
    {
        ModeloBD bd = new ModeloBD();
        public TablaUsuarios()
        {
            InitializeComponent();
        }
        private void ObtenerRegistros()
        {
            List<Usuario> registros = bd.Usuarios.ToList();
            listView.ItemsSource = registros;
        }
    }
}