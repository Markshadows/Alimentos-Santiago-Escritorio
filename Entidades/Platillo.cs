using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Platillo
    {
        public int PlatilloId { get; set; }
        public int Valor { get; set; }
        public int TiempoPreparacion { get; set; }
        public string Descripcion { get; set; }
        public string Src { get; set; }
        public string Nombre { get; set; }
    }
}
