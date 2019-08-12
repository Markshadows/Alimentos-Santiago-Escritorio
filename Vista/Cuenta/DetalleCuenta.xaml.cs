using Entidades;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class DetalleCuenta : MetroWindow
    {
        private Empleado guardado;
        private string paginaRecibida;
        public DetalleCuenta()
        {
            InitializeComponent();
        }

        public DetalleCuenta(MenuMarketing menuMarketing, Empleado sesionEmpleado, string pagina)
        {
            InitializeComponent();
            guardado = sesionEmpleado;
            paginaRecibida = pagina;
            cargarDatosEmpleado();
        }

        public DetalleCuenta(MenuRecepcion window, Empleado sesionEmpleado, string pagina)
        {
            InitializeComponent();
            guardado = sesionEmpleado;
            paginaRecibida = pagina;
            cargarDatosEmpleado();
        }

        public DetalleCuenta(MenuRRHH window, Empleado sesionEmpleado, string pagina)
        {
            InitializeComponent();
            guardado = sesionEmpleado;
            paginaRecibida = pagina;
            cargarDatosEmpleado();
        }

        private void VolverMenuPrincipal(object sender, RoutedEventArgs e)
        {
            switch (paginaRecibida)
            {
                case "RRHH":
                    MenuRRHH menuRRHH = new MenuRRHH(this, guardado);
                    menuRRHH.Show();
                    break;

                case "Recepcion":
                    MenuRecepcion menuPrincipal = new MenuRecepcion(this, guardado);
                    menuPrincipal.Show();
                    break;
                case "Marketing":
                    MenuMarketing menuMarketing = new MenuMarketing(this, guardado);
                    menuMarketing.Show();
                    break;

            }
            this.Close();
        }

        public void cargarDatosEmpleado()
        {
            txtNombre.Text = guardado.Nombre;
            txtRut.Text = Convert.ToString(guardado.Rut);
            txtAppaterno.Text = guardado.Appaterno;
            txtApmaterno.Text = guardado.Apmaterno;
            txtTipoCuenta.Text = guardado.TipoUsuarioId.Descripcion;
            txtNombreUsuario.Text = guardado.UsuarioId.Nombre;
            txtContrasena.Password = guardado.UsuarioId.Contrasena;
        }
    }
}
