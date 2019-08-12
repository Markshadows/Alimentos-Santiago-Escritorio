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
    /// <summary>
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    public partial class MenuRecepcion : MetroWindow
    {
        private Empleado guardado;
        private const string pagina = "Recepcion";

        public MenuRecepcion()
        {
            InitializeComponent();
        }

        public MenuRecepcion(IniciarSesion mainWindow, Empleado empleadoSesion)
        {
            InitializeComponent();
            guardado = empleadoSesion;
        }

        public MenuRecepcion(DetalleCuenta detalleCuentaVentana, Empleado empleadoSesion)
        {
            InitializeComponent();
            guardado = empleadoSesion;
        }

        public MenuRecepcion(ListaPedidos listaPedidosVentana, Empleado empleadoSesion)
        {
            InitializeComponent();
            guardado = empleadoSesion;
        }

        private void VerCuenta(object sender, RoutedEventArgs e) {
            DetalleCuenta detalleCuenta = new DetalleCuenta(this, guardado, pagina);
            detalleCuenta.Show();
            this.Close();
        }

        private void VerPedido(object sender, RoutedEventArgs e) {
            ListaPedidos menuRecepcion = new ListaPedidos(this, guardado);
            menuRecepcion.Show();
            this.Close();
        }

        private void CerrarSesion(object sender, RoutedEventArgs e) {
            IniciarSesion iniciarSesion = new IniciarSesion();
            iniciarSesion.Show();
            this.Close();
        }
    }
}
