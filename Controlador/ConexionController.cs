using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class ConexionController
    {
        private EntidadesAlimentos conexion;

        public EntidadesAlimentos Entidades
        {
            get
            {
                if (conexion == null)
                    conexion = new EntidadesAlimentos();
                    return conexion;
            }
        }
    }
}
