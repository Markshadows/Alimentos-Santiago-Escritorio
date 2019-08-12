using System;
using System.Data;
using System.Linq;
using Oracle.ManagedDataAccess.Client;
using Entidades;
using Modelo;
using System.Data.Entity.Core.Objects;

namespace Controlador
{
    public class UsuarioController
    {
        private ConexionController conexion;
        public UsuarioController()
        {
            conexion = new ConexionController();
        }

        public int IdEmpleado(string _nombre, string _contrasena)
        {
            try
            {

                var cmd = conexion.Entidades.Database.Connection.CreateCommand() as OracleCommand;
                cmd.CommandText = "FN_LOGIN";
                cmd.CommandType = CommandType.StoredProcedure;
                var presultado = new OracleParameter("resultado", OracleDbType.Int32, ParameterDirection.ReturnValue);
                var pusuario = new OracleParameter("pnombre", _nombre);
                var pcontrasena = new OracleParameter("pcontrasena", _contrasena);
                cmd.Parameters.Add(presultado);
                cmd.Parameters.Add(pusuario);
                cmd.Parameters.Add(pcontrasena);

                if (conexion.Entidades.Database.Connection.State != ConnectionState.Open)
                {
                    conexion.Entidades.Database.Connection.Open();
                }
                cmd.ExecuteNonQuery();
                var res = Convert.ToInt32(Convert.ToString(cmd.Parameters["resultado"].Value));
                conexion.Entidades.Database.Connection.Close();
                return res;
            }
            catch (Exception)
            {

                return 0;
            }

}

        public Empleado ObtenerEmpleado(int _idempleado)
        {
            try
            {

                EMPLEADO emp = conexion.Entidades.EMPLEADO
                    .First
                    (em => em.EMPLEADO_ID == _idempleado);

                return new Empleado
                {
                    Id = emp.EMPLEADO_ID,
                    Nombre = emp.NOMBRE,
                    Appaterno = emp.APPATERNO,
                    Apmaterno = emp.APMATERNO,
                    Rut = emp.RUT,
                    TipoUsuarioId = new TipoUsuario { Id = emp.TIPO_USUARIO_ID, Descripcion = emp.USUARIO_TIPO_USUARIO.TIPO_USUARIO.DESCRIPCION},
                    UsuarioId = new Usuario { Id = emp.USUARIO_ID, Nombre = emp.USUARIO_TIPO_USUARIO.USUARIO.NOMBRE, Contrasena = emp.USUARIO_TIPO_USUARIO.USUARIO.CONTRASENA}
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /*public bool CrearUsuario(string nombre, string contrasena, decimal tipoUsuarioId) {
            try
            {
                ObjectParameter p_retorno = new ObjectParameter("p_retorno", typeof (int));
                var resultado = conexion.Entidades.PROCEDURE_INSERTAR_USUARIO(nombre, contrasena, tipoUsuarioId, p_retorno);
                return Convert.ToInt32(p_retorno.Value) == 2 ? true : false;
            }
            catch (Exception e)
            {
                return false;
            }
        }*/

        public Usuario UsuarioId(string nombreUsuario) {
            try
            {
                USUARIO usu = conexion.Entidades.USUARIO.First(u => u.NOMBRE == nombreUsuario);
                return new Usuario
                {
                    Id = usu.USUARIO_ID
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int CrearCliente(string nombreUsuario, string contrasena, decimal tipoUsuarioId, string nombre, string appaterno, string apmaterno, decimal rut) {
            try
            {
                ObjectParameter p_retorno = new ObjectParameter("P_RETORNO", typeof(int));
                var resultado = conexion.Entidades.PROCEDURE_CREAR_CUENTA(nombreUsuario, contrasena, tipoUsuarioId, nombre, appaterno, apmaterno, rut, p_retorno);
                return Convert.ToInt32(p_retorno.Value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
                return 0;
            }
        }

        public object BuscarCuentaEmpleado(int rut) {

            try
            {
                var x = from usu in conexion.Entidades.USUARIO
                        join tup in conexion.Entidades.TIPO_USUARIO
                        on usu.TIPO_USUARIO equals tup.TIPO_USUARIO_ID
                        join utp in conexion.Entidades.USUARIO_TIPO_USUARIO
                        on usu.USUARIO_ID equals utp.USUARIO_ID
                        join emp in conexion.Entidades.EMPLEADO
                        on usu.USUARIO_ID equals emp.USUARIO_ID
                        where emp.RUT == rut
                        select new
                        {
                            IdUsuario = usu.USUARIO_ID,
                            Nombre = emp.NOMBRE,
                            Rut = emp.RUT,
                            Appaterno = emp.APPATERNO,
                            Apmaterno = emp.APMATERNO,
                            TipoCuenta = tup.TIPO_USUARIO_ID,
                            NombreUsuario = usu.NOMBRE,
                            Contrasena = usu.CONTRASENA

                        };
                return x.First();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            
        }

        public object BuscarCuentaCliente(int rut)
        {

            try
            {
                var x = from usu in conexion.Entidades.USUARIO
                        join tup in conexion.Entidades.TIPO_USUARIO
                        on usu.TIPO_USUARIO equals tup.TIPO_USUARIO_ID
                        join utp in conexion.Entidades.USUARIO_TIPO_USUARIO
                        on usu.USUARIO_ID equals utp.USUARIO_ID
                        join cli in conexion.Entidades.CLIENTE
                        on usu.USUARIO_ID equals cli.USUARIO_ID
                        where cli.RUT == rut
                        select new
                        {
                            IdUsuario = usu.USUARIO_ID,
                            Nombre = cli.NOMBRE,
                            Rut = cli.RUT,
                            Appaterno = cli.APPATERNO,
                            Apmaterno = cli.APMATERNO,
                            TipoCuenta = tup.TIPO_USUARIO_ID,
                            NombreUsuario = usu.NOMBRE,
                            Contrasena = usu.CONTRASENA

                        };
                return x.First();
            }
            catch (Exception)
            {
                return null;
                throw;
            }

        }
    }
}
