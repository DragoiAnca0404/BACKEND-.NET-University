using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_Facultate.Utils
{
    public class LoginResponse
    {
        private string nume;
        private string prenume;
        private string rol;

        public string Rol { get => rol; set => rol = value; }
        public string Prenume { get => prenume; set => prenume = value; }
        public string Nume { get => nume; set => nume = value; }
    }
}
