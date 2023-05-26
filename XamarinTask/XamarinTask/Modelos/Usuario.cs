using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTask.Modelos
{
    class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       
        public int DireccionID { get; set; }
        public virtual Direccion Direccion { get; set; }

        public int EmpleoID { get; set; }
        public virtual Empleo Empleo { get; set; }
    }
    class UsuarioDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Edad { get; set; }
        public String DireccionPais { get; set; }
        public String EmpleoNombre { get; set; }

    }
}
