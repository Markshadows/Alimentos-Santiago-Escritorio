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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using Controlador;
using System.Collections;
using System.Reflection;
using System.Net;
using Entidades;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para Page1.xaml
    /// </summary>
    public partial class ConvenioEmpresa : MetroWindow
    {
        private Empleado guardado;
        public ConvenioEmpresa()
        {
            InitializeComponent();
            DataContext = new EmpresaController();
        }

        public ConvenioEmpresa(MenuRRHH page, Empleado sesionEmpleado)
        {
            InitializeComponent();
            DataContext = new EmpresaController();
            guardado = sesionEmpleado;
        }

        private void VolverMenuPrincipal(object sender, RoutedEventArgs e)
        {
            MenuRRHH menuRRHHPage = new MenuRRHH(this, guardado);
            menuRRHHPage.Show();
            this.Close();
        }

        private void SplitButton_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EmpresaController emp = new EmpresaController();
            Cl_ConvenioEmpresa empresa = (Cl_ConvenioEmpresa)spbtnEmpresas.SelectedItem;
            dgListaPlanillas.ItemsSource = (IEnumerable)emp.PlanillasEmpresa(empresa.Id);
            txtNombreEmpresa.Text = empresa.Nombre;
            txtRutEmpresa.Text = Convert.ToString(empresa.Rut);
            txtDireccionEmpresa.Text = empresa.Direccion;
            txtFechaInicio.Text = empresa.FechaInicio.ToString("dd-MM-yyyy");
            txtFechaTermino.Text = empresa.FechaTermino.ToString("dd-MM-yyyy");
        }

        private async void DgListaPlanillas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgListaPlanillas.SelectedItem != null)
            {
                var planillaSeleccionada = dgListaPlanillas.SelectedItem;

                PropertyInfo piEmpresaId = planillaSeleccionada.GetType().GetProperty("IdEmpresa");
                Byte idEmpresa = (Byte)(piEmpresaId.GetValue(planillaSeleccionada, null));

                PropertyInfo piPlanillaId = planillaSeleccionada.GetType().GetProperty("IdPlanilla");
                Byte idPlanilla = (Byte)(piPlanillaId.GetValue(planillaSeleccionada, null));

                PropertyInfo piNombreArchivo = planillaSeleccionada.GetType().GetProperty("NombreArchivo");
                string nombreArchivo = (string)(piNombreArchivo.GetValue(planillaSeleccionada, null));

                EmpresaController empc = new EmpresaController();

                await empc.ReadObjectDataAsync(nombreArchivo);

            }
        }
    }
}
