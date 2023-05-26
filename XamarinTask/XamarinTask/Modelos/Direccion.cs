using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTask.Modelos
{
    internal class Direccion
    {
        public int ID { get; set; }
        public String Calle { get; set; }

        public String Colonia { get; set; }

        public String NumeroInterior { get; set; }

        public String Municipio { get; set; }

        public int CodigoPostal { get; set; }

        public String Pais { get; set; }
    }
}
