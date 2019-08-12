using Controlador;
using Entidades;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections;
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
    /// Lógica de interacción para MenuSemanal.xaml
    /// </summary>
    public partial class MenuSemanal : MetroWindow
    {
        private Empleado guardado;
        public MenuSemanal()
        {
            InitializeComponent();
        }

        public MenuSemanal(MenuMarketing menuMarketing, Empleado sesionEmpleado)
        {
            InitializeComponent();
            guardado = sesionEmpleado;
            DataContext = new PlatilloController();
        }

        private void VolverMenuPrincipal(object sender, RoutedEventArgs e)
        {
            MenuMarketing menuMarketing = new MenuMarketing(this, guardado);
            menuMarketing.Show();
            this.Close();
        }

        private void SpbtnDias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlatilloController plc = new PlatilloController();
            Dia dia = (Dia)spbtnDias.SelectedItem;
            dgListaPlatillosDias.ItemsSource = (IEnumerable)plc.filtroDiaPlatillo(dia.DiaId);

        }

        private void SpbtnPlatillos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void AgregarDisponibilidad(object sender, RoutedEventArgs e)
        {
            PlatilloController plc = new PlatilloController();
            Dia dia = (Dia)spbtnDias.SelectedItem;
            Platillo pla = (Platillo)spbtnPlatillos.SelectedItem;
            int res = plc.AgregarDisponibilidad(dia.DiaId, pla.PlatilloId);
            string msj = null;
            msj = res == 1 ? pla.Nombre + " ahora disponible los días " + dia.Nombre : pla.Nombre + " actualmente disponible los días "+dia.Nombre;
            dgListaPlatillosDias.ItemsSource = (IEnumerable)plc.filtroDiaPlatillo(dia.DiaId);
            await this.ShowMessageAsync("Disponibilidad", msj);
        }

        private async void EliminarDisponibilidad(object sender, RoutedEventArgs e)
        {
            PlatilloController plc = new PlatilloController();
            Dia dia = (Dia)spbtnDias.SelectedItem;
            Platillo pla = (Platillo)spbtnPlatillos.SelectedItem;
            string msj = null;
            int res = plc.EliminarDisponibilidad(dia.DiaId, pla.PlatilloId);
            msj = res == 1 ? pla.Nombre + " ahora no disponible los días " + dia.Nombre : pla.Nombre + " actualmente no disponible los días " + dia.Nombre;
            dgListaPlatillosDias.ItemsSource = (IEnumerable)plc.filtroDiaPlatillo(dia.DiaId);
            await this.ShowMessageAsync("Disponibilidad", msj);
        }
    }
}
