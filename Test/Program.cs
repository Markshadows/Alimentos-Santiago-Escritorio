using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Controlador;
using Entidades;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //    string usuario = "test";
            //    string password = "test";
            //    string servidor = "localhost:1521/xe";

            //    string stringConexion = "User Id =" + usuario + "; Password =" + password + ";Data Source = " + servidor;

            //    OracleConnection con = new OracleConnection(stringConexion);

            //    OracleCommand cmd = new OracleCommand("fn_test2",con);


            //    //OracleCommand cmd = con.CreateCommand();
            //    //cmd.CommandText = "select nombre from empleado";

            //    //OracleDataReader reader = cmd.ExecuteReader();

            //    //while (reader.Read())
            //    //{
            //    //    await this.ShowMessageAsync("hola", reader.GetString(0));
            //    //}

            //    //Console.ReadKey();

            //    cmd.CommandType = CommandType.StoredProcedure;



            //    //OracleParameter _usuario = new OracleParameter();
            //    //_usuario.ParameterName = "usuario";
            //    //_usuario.OracleDbType = OracleDbType.Varchar2;
            //    //_usuario.Size = 200;
            //    ////_usuario.Direction = ParameterDirection.Input;
            //    //_usuario.Value = "pep1";
            //    ////_usuario.Direction = ParameterDirection.Input;
            //    //cmd.Parameters.Add(_usuario);

            //    //OracleParameter _contrasena = new OracleParameter();
            //    //_contrasena.ParameterName = "contrasena";
            //    //_contrasena.OracleDbType = OracleDbType.Varchar2;
            //    //_contrasena.Size = 200;
            //    //_contrasena.Direction = ParameterDirection.Input;
            //    //_contrasena.Value = "pep";
            //    ////_usuario.Direction = ParameterDirection.Input;
            //    //cmd.Parameters.Add(_contrasena);
            //    ////cmd.Parameters.Add("usuario", OracleDbType.Varchar2, 30).Value = "pep1";
            //    ////cmd.Parameters.Add("contrasena", OracleDbType.Varchar2, 30).Value = "pep";
            //    ////cmd.Parameters.Add("v_nombre_empleado", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.ReturnValue;

            //    //OracleParameter _nombre = new OracleParameter();
            //    //_nombre.ParameterName = "v_nombre";
            //    //_nombre.OracleDbType = OracleDbType.Varchar2;
            //    //_nombre.Size = 200;
            //    //_nombre.Direction = ParameterDirection.ReturnValue;
            //    //cmd.Parameters.Add(_nombre);

            //    cmd.Parameters.Add("v_suma", OracleDbType.Int32);
            //    cmd.Parameters["v_suma"].Direction = ParameterDirection.ReturnValue;

            //    cmd.Parameters.Add("n1", 1);
            //    cmd.Parameters["n1"].Direction = ParameterDirection.Input;


            //    try
            //    {
            //        con.Open();
            //        cmd.ExecuteNonQuery();

            //        var v_suma = (cmd.Parameters["v_suma"].Value);

            //        Console.WriteLine("v_suma" + v_suma);
            //        Console.ReadKey();
            //    }
            //    catch (Exception ex)
            //    {

            //        Console.WriteLine("error"+ex.Message);
            //        Console.ReadKey();
            //    }

            //TipoUsuarioController tipoucontroller = new TipoUsuarioController();
            //UsuarioController usuarioController = new UsuarioController();

            ////var tipousuarios = tipoucontroller.Tipos2;

            ////foreach (var item in tipousuarios)
            ////{
            ////    Console.WriteLine("id:{0}----------descripción:{1}", item.Id, item.Descripcion);
            ////}

            //int _idempleado = usuarioController.IdEmpleado("usuario2", "contrasena2");
            //if (_idempleado > 0)
            //{
            //    Empleado emp = usuarioController.ObtenerEmpleado(_idempleado);
            //    Console.WriteLine(emp.Nombre);
            //}
            //else
            //{
            //    Console.WriteLine("Credenciales Incorrectas");
            //}

            //LINQ FECHAS ESPECIFICAS
            PedidoController ped = new PedidoController();

            //DateTime fechafiltro = new DateTime(2019, 05, 13, 17, 38, 05);
            //fechafiltro.ToString("dd/MM/yyyy");
            //Console.WriteLine(Convert.ToDateTime(fechafiltro));

            //IEnumerable a = (IEnumerable)ped.filtroPedidosFecha(fechafiltro);

            //foreach (var item in a)
            //{
            //    Console.WriteLine(item);
            //}

            //var a = ped.filtroPedidosCliente(14654789);
            //foreach (var item in a)
            //{
            //    Console.WriteLine("Hora Entrega: {0}----------Hora Pedido: {1}----------" +
            //        "Cliente: {2}",item.HoraEntrega.ToString(), item.HoraPedido.ToString(), item.ClienteId.Nombre);
            //}

            //object a = ped.DetallePedido(3, 14654789);


            //PropertyInfo piPedido = a.GetType().GetProperty("Estado");
            //string formaPago = (string)(piPedido.GetValue(a, null));
            //Console.WriteLine(formaPago);

            //IEnumerable pedidos = (IEnumerable)ped.Pedidos;

            //foreach (var item in pedidos)
            //{
            //    Console.WriteLine(item);
            //}

            //EmpresaController empc = new EmpresaController();
            ////var planilla = empc.BuscarPlanilla(10, 1);

            ////PropertyInfo piNombreArchivo = planilla.GetType().GetProperty("NombreArchivo");
            ////string nombreArchivo = (string)(piNombreArchivo.GetValue(planilla, null));
            ////Console.WriteLine(nombreArchivo);

            ////empc.ReadObjectDataAsync(nombreArchivo).Wait();

            //UsuarioController usc = new UsuarioController();
            //var empleado = usc.BuscarCuentaEmpleado(18277364);

            PlatilloController plac = new PlatilloController();
            IEnumerable diaPlatillo = (IEnumerable)plac.filtroDiaPlatillo(1);
            foreach (var item in diaPlatillo)
            {
                Console.WriteLine(item);
            }
            //PropertyInfo piNombre = empleado.GetType().GetProperty("Nombre");
            //string nombre = (string)(piNombre.GetValue(empleado, null));
            //Console.WriteLine(nombre);
            //IEnumerable<Cl_ConvenioEmpresa> listaEmpresas = empc.Empresas;

            Console.ReadKey();
        }
    }
}
