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
    /// Lógica de interacción para MenuMarketing.xaml
    /// </summary>
    public partial class MenuMarketing : MetroWindow
    {
        private Empleado guardado;
        string pagina = "Marketing";
        public MenuMarketing()
        {
            InitializeComponent();
        }

        public MenuMarketing(IniciarSesion iniciarSesion, Empleado sesionEmpleado)
        {
            InitializeComponent();
            guardado = sesionEmpleado;
        }

        public MenuMarketing(DetalleCuenta detalleCuenta, Empleado sesionEmpleado)
        {
            InitializeComponent();
            guardado = sesionEmpleado;
        }

        public MenuMarketing(MenuSemanal menuSemanal, Empleado sesionEmpleado)
        {
            InitializeComponent();
            guardado = sesionEmpleado;
        }

        public MenuMarketing(AdministrarPlatillos administrarPlatillos, Empleado sesionEmpleado)
        {
            InitializeComponent();
            guardado = sesionEmpleado;
        }

        private void AdministrarPlatos(object sender, RoutedEventArgs e)
        {
            AdministrarPlatillos admp = new AdministrarPlatillos(this, guardado);
            admp.Show();
            this.Close();
        }

        private void MenuSemanal(object sender, RoutedEventArgs e)
        {
            MenuSemanal menuSemanal = new MenuSemanal(this, guardado);
            menuSemanal.Show();
            this.Close();
        }

        private void CerrarSesion(object sender, RoutedEventArgs e)
        {
            IniciarSesion iniciarSesion = new IniciarSesion();
            iniciarSesion.Show();
            this.Close();
        }

        private void VerCuenta(object sender, RoutedEventArgs e)
        {
            DetalleCuenta detalleCuenta = new DetalleCuenta(this, guardado, pagina);
            detalleCuenta.Show();
            this.Close();
        }
    }
}
