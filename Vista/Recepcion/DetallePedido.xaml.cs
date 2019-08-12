using Controlador;
using MahApps.Metro.Controls;
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

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para DetallePedido.xaml
    /// </summary>
    public partial class DetallePedido : MetroWindow
    {
        //MenuRecepcion menuRecepcion;
        PedidoController ped;
        public DetallePedido()
        {
            InitializeComponent();
        }

        public DetallePedido(ListaPedidos window, Byte pIdPedido, int pRutCliente)
        {
            InitializeComponent();

            ped = new PedidoController();

            object objetoDetalle = ped.DetallePedido(pIdPedido, pRutCliente);

            PropertyInfo piRutCliente = objetoDetalle.GetType().GetProperty("RutCliente");
            int rutCliente = (int)(piRutCliente.GetValue(objetoDetalle, null));
            txtRut.Text = Convert.ToString(rutCliente);

            PropertyInfo piNombreCliente = objetoDetalle.GetType().GetProperty("NombreCliente");
            string nombreCliente = (string)(piNombreCliente.GetValue(objetoDetalle, null));
            txtNombre.Text = nombreCliente;

            PropertyInfo piHoraPedido = objetoDetalle.GetType().GetProperty("HoraPedido");
            DateTime horaPedido = (DateTime)(piHoraPedido.GetValue(objetoDetalle, null));
            txtHoraPedido.Text = Convert.ToString(horaPedido);

            PropertyInfo piHoraEntrega = objetoDetalle.GetType().GetProperty("HoraEntrega");
            DateTime horaEntrega = (DateTime)(piHoraEntrega.GetValue(objetoDetalle, null));
            txtHoraEntrega.Text = Convert.ToString(horaEntrega);

            PropertyInfo piEstado = objetoDetalle.GetType().GetProperty("Estado");
            string estado = (string)(piEstado.GetValue(objetoDetalle, null));
            txtEstado.Text = estado;

            PropertyInfo piFormaPago = objetoDetalle.GetType().GetProperty("FormaPago");
            string formaPago = (string)(piFormaPago.GetValue(objetoDetalle, null));
            txtFormaPago.Text = formaPago;

        }
    }
}
