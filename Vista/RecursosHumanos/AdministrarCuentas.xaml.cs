using Controlador;
using Entidades;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para AdministrarCuentas.xaml
    /// </summary>
    public partial class AdministrarCuentas : MetroWindow
    {
        private Empleado guardado;
        public AdministrarCuentas()
        {
            InitializeComponent();
        }

        public AdministrarCuentas(MenuRRHH page, Empleado sesionEmpleado)
        {
            InitializeComponent();
            guardado = sesionEmpleado;
            DataContext = new TipoUsuarioController(); 
        }

        private void VolverMenuPrincipal(object sender, RoutedEventArgs e)
        {
            MenuRRHH menuRRHHPage = new MenuRRHH(this, guardado);
            menuRRHHPage.Show();
            this.Close();
        }

        private void SplitButton_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void CrearCuenta(object sender, RoutedEventArgs e)
        {
            string msj = null;
            UsuarioController usc = new UsuarioController();
            TipoUsuario tipoUsuario = (TipoUsuario)spbtnTipoCuenta.SelectedItem;
            Usuario usuario = usc.UsuarioId(txtNombreUsuario.Text);
            int resultado = usc.CrearCliente(txtNombreUsuario.Text, txtContrasena.Password, tipoUsuario.Id, txtNombre.Text, txtAppaterno.Text, txtApmaterno.Text, Convert.ToDecimal(txtRut.Text));
            switch (resultado)
            {
                case 1:
                    msj = "Cuenta Creada";
                    break;
                case 2:
                    msj = "Rut vinculado a una cuenta existente";
                    break;
                case 3:
                    msj = "Nombre de usuario no disponible";
                    break;
            }
            await this.ShowMessageAsync("Alerta",msj);
        }

        private async void BuscarCuenta(object sender, RoutedEventArgs e)
        {
            string msj = "";
            UsuarioController usc = new UsuarioController();
            string rutBuscar = txtRutBuscar.Text;
            if (rutBuscar != "")
            {
                var empleado = usc.BuscarCuentaEmpleado(Convert.ToInt32(txtRutBuscar.Text));
                if (empleado != null)
                {
                    PropertyInfo piNombre = empleado.GetType().GetProperty("Nombre");
                    string nombre = (string)(piNombre.GetValue(empleado, null));
                    txtNombre.Text = nombre;

                    msj = "Cuenta Encontrada";
                }
                else
                {
                    var cliente = usc.BuscarCuentaCliente(Convert.ToInt32(txtRutBuscar.Text));
                    if (cliente != null)
                    {
                        PropertyInfo piNombre = cliente.GetType().GetProperty("Nombre");
                        string nombre = (string)(piNombre.GetValue(cliente, null));
                        txtNombre.Text = nombre;

                        msj = "Cuenta Encontrada";
                    }
                    else
                    {
                        msj = "Cuenta No Encontrada";
                    }

                }
                
            }
            else
            {
                msj = "Ingrese Rut a buscar";
            }
            await this.ShowMessageAsync("Alerta", msj);

        }

        private void DarDeBaja(object sender, RoutedEventArgs e)
        {

        }
    }
}
