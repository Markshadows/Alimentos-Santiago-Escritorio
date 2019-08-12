using Entidades;
using Modelo;
using System.Collections.Generic;
using System.Linq;
namespace Controlador
{
    public class TipoUsuarioController
    {
        private ConexionController conexion;

        public TipoUsuarioController()
        {
            conexion = new ConexionController();
        }

        public List<TipoUsuario> Tipos
        {
            get
            {
                List<TipoUsuario> lista = new List<TipoUsuario>()
            {
                new TipoUsuario
                {
                    Id = 1,
                    Descripcion = "Repartidor"
                },
                new TipoUsuario
                {
                    Id = 2,
                    Descripcion = "Marketing"
                },
                 new TipoUsuario
                {
                    Id = 3,
                    Descripcion = "Empleador"
                },
                new TipoUsuario
                {
                    Id = 4,
                    Descripcion = "Cliente Normal"
                },
                new TipoUsuario
                {
                    Id = 5,
                    Descripcion = "Cliente Convenio"
                }
            };
                return lista;
            }
        }

        public List<TipoUsuario> Tipos2
        {
    
            get
            {
                List<TIPO_USUARIO> lista_bd = conexion.Entidades.TIPO_USUARIO.ToList();
                List<TipoUsuario> lista_clase = new List<TipoUsuario>();

                foreach (TIPO_USUARIO item in lista_bd)
                {
                    TipoUsuario tipoUsuario = new TipoUsuario
                    {
                        Id = item.TIPO_USUARIO_ID,
                        Descripcion = item.DESCRIPCION
                    };
                    lista_clase.Add(tipoUsuario);
                }
                return lista_clase;
            }
        }
    }

}
