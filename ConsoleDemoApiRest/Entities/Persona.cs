using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleDemoApiRest.Entities
{

    public class Persona
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string documento { get; set; }
        public float salario { get; set; }
        public int edad { get; set; }
        public string perfil { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
    }

}
