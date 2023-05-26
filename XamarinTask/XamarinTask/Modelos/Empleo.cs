using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTask.Modelos
{
    internal class Empleo
    {
        public int ID { get; set; }
        public String Cargo { get; set; }

        public String Empresa { get; set; }

        public int Sueldo { get; set; }

        public String CorreoDeEmpresa { get; set; }

        public String Departamento { get; set; }
    }
}
