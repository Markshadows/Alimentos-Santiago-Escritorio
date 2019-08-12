using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Appaterno { get; set; }
        public string Apmaterno { get; set; }
        public int Rut { get; set; }
        public Usuario UsuarioId { get; set; }
        public TipoUsuario TipoUsuarioId { get; set; }
    }
}
