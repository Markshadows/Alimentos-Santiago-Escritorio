using Controlador;
using Entidades;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections;
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
using System.Windows.Threading;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para MenuRecepcion.xaml
    /// </summary>
    public partial class ListaPedidos : MetroWindow
    {
        PedidoController ped = new PedidoController();
        Empleado guardado;

        public ListaPedidos()
        {
            InitializeComponent();
            DataContext = ped;
            RebindData();
            SetTimer();
        }

        public ListaPedidos(MenuRecepcion menuPrincipal, Empleado sessionEmpleado)
        {
            InitializeComponent();
            DataContext = ped;
            RebindData();
            SetTimer();
            guardado = sessionEmpleado;
        }

        private void dgListaCli_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgListaCli.SelectedItem != null)
            {
                //lblRut.Content = "RUT A BUSCAR: ";
                var pedido_seleccionado = dgListaCli.SelectedItem;
                PropertyInfo pi_rut = pedido_seleccionado.GetType().GetProperty("RutCliente");
                int rut = (int)(pi_rut.GetValue(pedido_seleccionado, null));
                //txtRut.Text = Convert.ToString(rut);

                PropertyInfo pi_id_pedido = pedido_seleccionado.GetType().GetProperty("IdPedido");
                Byte idPedido = (Byte)(pi_id_pedido.GetValue(pedido_seleccionado, null));

                DetallePedido detalle_pedido = new DetallePedido(this, idPedido, rut);
                detalle_pedido.Show();
                //dgListaCli.ItemsSource = (IEnumerable)ped.filtroPedidosCliente(rut);
            }

        }

       /* private async void btnBuscarPedidoCliente(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtRut.Text.Equals(""))
                {
                    await this.ShowMessageAsync("Error: ", "Debe seleccionar un rut");
                    
                }
                else
                {
                    //dgListaCli.ItemsSource = (IEnumerable)ped.filtroPedidosCliente(Convert.ToInt32(txtRut.Text));
                }
                
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error: ", ex.Message);
                throw;
            }
 
        }
        

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
        }

        private void cboFiltro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            //DataGridRow row = sender as DataGridRow;
            // Some operations with this row

            var pedido_seleccionado = dgListaCli.SelectedItem;
            PropertyInfo pi_rut = pedido_seleccionado.GetType().GetProperty("RutCliente");
            int rut = (int)(pi_rut.GetValue(pedido_seleccionado, null));
            txtRut.Text = Convert.ToString(rut);

            //DetallePedido detalle_pedido = new DetallePedido(this, );
            //detalle_pedido.Show();
        }*/

        //Refreshes grid data on timer tick
        protected void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            RebindData();
        }

        private void RebindData()
        {
            dgListaCli.ItemsSource = (IEnumerable)ped.Pedidos;
        }

        //Set and start the timer
        private void SetTimer()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Start();
        }

        private void VolverMenuPrincipal(object sender, RoutedEventArgs e)
        {
            MenuRecepcion menuPrincipal = new MenuRecepcion(this, guardado);
            menuPrincipal.Show();
            this.Close();
        }
    }
}
