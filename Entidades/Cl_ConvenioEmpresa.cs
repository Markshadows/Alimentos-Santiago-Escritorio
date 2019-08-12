using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cl_ConvenioEmpresa
    {
        public byte Id { get; set; }
        public string Nombre { get; set; }
        public int Rut { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }
    }
}
