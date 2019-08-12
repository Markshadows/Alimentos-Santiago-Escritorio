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

namespace Vista { 
    /// <summary>
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    public partial class MenuRRHH : MetroWindow
    {
        private Empleado guardado;
        private const string pagina = "RRHH";
        public MenuRRHH()
        {
            InitializeComponent();
        }

        public MenuRRHH(IniciarSesion paginaIniciarSesion, Empleado sesionEmpleado)
        {
            InitializeComponent();
            guardado = sesionEmpleado;
        }

        public MenuRRHH(DetalleCuenta detalleCuentaVentana, Empleado sesionEmpleado)
        {
            InitializeComponent();
            guardado = sesionEmpleado;
        }

        public MenuRRHH(ConvenioEmpresa convenioEmpresa, Empleado sesionEmpleado)
        {
            InitializeComponent();
            guardado = sesionEmpleado;
        }

        public MenuRRHH(AdministrarCuentas administrarCuentasPage, Empleado sesionEmpleado) {
            InitializeComponent();
            guardado = sesionEmpleado;
        }

        private void VerCuenta(object sender, RoutedEventArgs e)
        {
            DetalleCuenta detalleCuenta = new DetalleCuenta(this, guardado, pagina);
            detalleCuenta.Show();
            this.Close();
        }

        private void CerrarSesion(object sender, RoutedEventArgs e)
        {
            IniciarSesion iniciarSesion = new IniciarSesion();
            iniciarSesion.Show();
            this.Close();
        }

        private void VerConvenios(object sender, RoutedEventArgs e)
        {
            ConvenioEmpresa convenioPage = new ConvenioEmpresa(this, guardado);
            convenioPage.Show();
            this.Close();
        }

        private void AdministrarCuentas(object sender, RoutedEventArgs e)
        {
            AdministrarCuentas administrarCuentasPage = new AdministrarCuentas(this, guardado);
            administrarCuentasPage.Show();
            this.Close();
        }
    }
}
