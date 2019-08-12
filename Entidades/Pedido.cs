using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedido: INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int PlatoId { get; set; }
        public Cliente ClienteId { get; set; }
        public FormaPago FormaPagoId { get; set; }
        public EstadoPedido EstadoPedidoId { get; set; }
        public string Direccion { get; set; }
        public DateTime HoraPedido { get; set; }
        public DateTime HoraEntrega { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
