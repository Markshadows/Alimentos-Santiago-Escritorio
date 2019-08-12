using System;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Controlador;
using Entidades;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class IniciarSesion : MetroWindow
    {
        public IniciarSesion()
        {
            InitializeComponent();
            DataContext = new TipoUsuarioController();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            //string usuario = "test";
            //string password = "test";
            //string servidor = "localhost:1521/xe";

            //string stringConexion = "User Id =" + usuario + "; Password =" + password + ";Data Source = " + servidor;

            //OracleConnection con = new OracleConnection();
            //con.ConnectionString = stringConexion;
            

            //OracleCommand cmd = con.CreateCommand();
            //cmd.CommandText = "select nombre from empleado";

            //OracleDataReader reader = cmd.ExecuteReader();

            //while (reader.Read())
            //{
            //    await this.ShowMessageAsync("hola", reader.GetString(0));
            //}

            //Console.ReadKey();

            //OracleCommand cmd = con.CreateCommand();
            //cmd.CommandText = "FN_LOGIN";
            //cmd.CommandType = CommandType.StoredProcedure;

            //OracleParameter _nombre = new OracleParameter();
            //_nombre.ParameterName = "v_nombre";
            //_nombre.OracleDbType = OracleDbType.Varchar2;
            //_nombre.Size = 200;
            //_nombre.Direction = ParameterDirection.ReturnValue;
            //cmd.Parameters.Add(_nombre);


            //OracleParameter _usuario = new OracleParameter();
            //_usuario.ParameterName = "usuario";
            //_usuario.OracleDbType = OracleDbType.Varchar2;
            //_usuario.Size = 200;
            ////_usuario.Direction = ParameterDirection.Input;
            //_usuario.Value = txtUsuario.Text;
            ////_usuario.Direction = ParameterDirection.Input;
            //cmd.Parameters.Add(_usuario);

            //OracleParameter _contrasena = new OracleParameter();
            //_contrasena.ParameterName = "contrasena";
            //_contrasena.OracleDbType = OracleDbType.Varchar2;
            //_contrasena.Size = 200;
            //_contrasena.Direction = ParameterDirection.Input;
            //_contrasena.Value = txtContrasena.Password;
            ////_usuario.Direction = ParameterDirection.Input;
            //cmd.Parameters.Add(_contrasena);
            //cmd.Parameters.Add("usuario", OracleDbType.Varchar2, 30).Value = "pep1";
            //cmd.Parameters.Add("contrasena", OracleDbType.Varchar2, 30).Value = "pep";
            //cmd.Parameters.Add("v_nombre_empleado", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.ReturnValue;



            try
            {
                //con.Open();
                //cmd.ExecuteNonQuery();

                //var nombre = Convert.ToString(cmd.Parameters["v_nombre"].Value);

                UsuarioController usuarioController = new UsuarioController();

                int _idempleado = usuarioController.IdEmpleado(txtUsuario.Text, txtContrasena.Password);
                if (_idempleado > 0)
                {
                    Empleado emp = usuarioController.ObtenerEmpleado(_idempleado);
                    switch (emp.TipoUsuarioId.Id)
                    {
                        case 1:
                            MenuRecepcion menuPrincipal = new MenuRecepcion(this, emp);
                            menuPrincipal.Show(); 
                            break;
                        case 2:
                            MenuMarketing menuMarketing = new MenuMarketing(this, emp);
                            menuMarketing.Show();
                            break;
                        case 4:
                            MenuRRHH menuRecursosHumanos = new MenuRRHH(this, emp);
                            menuRecursosHumanos.Show();
                            break;
                    }
                    await this.ShowMessageAsync("Bienvenido: ", emp.Nombre);
                    this.Hide();
                }
                else
                {
                    await this.ShowMessageAsync("Error", "Credenciales Incorrectas");
                }
            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Error", ex.Message);
            }

            


        }
    }
}
