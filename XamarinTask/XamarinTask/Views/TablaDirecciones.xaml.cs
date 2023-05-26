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
    public partial class TablaDirecciones : ContentPage
    {
        ModeloBD bd = new ModeloBD();
        public TablaDirecciones()
        {
            InitializeComponent();
        }
        private void ObtenerRegistros()
        {
            List<Direccion> registros = bd.Direcciones.ToList();
            listView.ItemsSource = registros;
        }
    }
}