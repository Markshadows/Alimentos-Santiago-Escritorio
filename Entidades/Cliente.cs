using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Appaterno { get; set; }
        public string Apmaterno { get; set; }
        public int Rut { get; set; }
        public TipoUsuario TipoUsuarioId { get; set; }
        public Usuario UsuarioId { get; set; }
        public Cl_ConvenioEmpresa ConvenioEmpresaId { get; set; }

        public override string ToString()
        {
            return this.Nombre;
        }

    }
}
