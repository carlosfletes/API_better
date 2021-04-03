using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Distribuidor
    {
        public string Nombre { get; set; }
        public List<Asociado> ListaAsociados { get; set; }
    }
}
