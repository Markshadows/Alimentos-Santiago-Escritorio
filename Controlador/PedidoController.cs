using Entidades;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class PedidoController
    {
        private ConexionController conexion;

        public PedidoController()
        {
            conexion = new ConexionController();
        }

        public object Pedidos
        {

            get
            {
                DateTime fecha_filtro = DateTime.Now;
                DateTime fecha_final = DateTime.Parse(fecha_filtro.ToString("dd/MM/yyyy"));
                Console.WriteLine(fecha_final);
                var x = from clpe in conexion.Entidades.CLIENTE_PEDIDO
                        join cl in conexion.Entidades.CLIENTE
                        on clpe.CLIENTE_ID equals cl.CLIENTE_ID
                        join pepl in conexion.Entidades.PEDIDO_PLATILLO
                        on clpe.PEDIDO_ID equals pepl.PEDIDO_ID
                        join pe in conexion.Entidades.PEDIDO
                        on pepl.PEDIDO_ID equals pe.PEDIDO_ID
                        join ep in conexion.Entidades.ESTADO_PEDIDO
                        on pe.ESTADO_ID equals ep.ESTADO_ID
                        where DbFunctions.TruncateTime (pe.HORA_ENTREGA) == fecha_final
                        select new
                        {
                            IdPedido = pe.PEDIDO_ID,
                            RutCliente = cl.RUT,
                            NombreCliente = cl.NOMBRE + " " + cl.APPATERNO + " " + cl.APMATERNO,
                            HoraPedido = pe.HORA_PEDIDO,
                            HoraEntrega = pe.HORA_ENTREGA,
                            Estado = ep.DESCRIPCION
                        };
                return x.ToList();
            }
        }

        //public object filtroPedidosFecha(DateTime fecha)
        //{

        //    var x = from clpe in conexion.Entidades.CLIENTE_PEDIDO
        //            join cl in conexion.Entidades.CLIENTE
        //            on clpe.ID_CLIENTE equals cl.CLIENTE_ID
        //            join pepl in conexion.Entidades.PEDIDO_PLATILLO
        //            on clpe.ID_PEDIDO equals pepl.ID_PEDIDO
        //            join pe in conexion.Entidades.PEDIDO
        //            on pepl.ID_PEDIDO equals pe.IDPEDIDO
        //            join ep in conexion.Entidades.ESTADO_PEDIDO
        //            on pe.IDESTADO equals ep.IDESTADO
        //            where (pe.HORA_ENTREGA == fecha)
        //            select new
        //            {
        //                RutCliente = cl.RUT,
        //                NombreCliente = cl.NOMBRE + " " + cl.APPATERNO + " " + cl.APPATERNO,
        //                HoraPedido = pe.HORA_PEDIDO,
        //                HoraEntrega = pe.HORA_ENTREGA,
        //                Estado = ep.DESCRIPCION
        //            };
        //    return x.ToList();

        //}

        //public object filtroPedidosCliente(int rutCliente)
        //{
        //    try
        //    {

        //        var x = from clpe in conexion.Entidades.CLIENTE_PEDIDO
        //                join cl in conexion.Entidades.CLIENTE
        //                on clpe.ID_CLIENTE equals cl.CLIENTE_ID
        //                join pepl in conexion.Entidades.PEDIDO_PLATILLO
        //                on clpe.ID_PEDIDO equals pepl.ID_PEDIDO
        //                join pe in conexion.Entidades.PEDIDO
        //                on pepl.ID_PEDIDO equals pe.IDPEDIDO
        //                join ep in conexion.Entidades.ESTADO_PEDIDO
        //                on pe.IDESTADO equals ep.IDESTADO
        //                where (cl.RUT == rutCliente)
        //                pedidos que se deben enviar
        //                where(cl.RUT == rutCliente && pe.HORA_ENTREGA > DateTime.Now)
        //                select new
        //                {
        //                    RutCliente = cl.RUT,
        //                    NombreCliente = cl.NOMBRE + " " + cl.APPATERNO + " " + cl.APPATERNO,
        //                    HoraPedido = pe.HORA_PEDIDO,
        //                    HoraEntrega = pe.HORA_ENTREGA,
        //                    Estado = ep.DESCRIPCION
        //                };
        //        return x.ToList();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return null;
        //        throw;
        //    }
        //}

        public object DetallePedido(int idPedido, int rutCliente)
        {

            try
            {

                var x = from clpe in conexion.Entidades.CLIENTE_PEDIDO
                        join cl in conexion.Entidades.CLIENTE
                        on clpe.CLIENTE_ID equals cl.CLIENTE_ID
                        join pepl in conexion.Entidades.PEDIDO_PLATILLO
                        on clpe.PEDIDO_ID equals pepl.PEDIDO_ID
                        join pe in conexion.Entidades.PEDIDO
                        on pepl.PEDIDO_ID equals pe.PEDIDO_ID
                        join ep in conexion.Entidades.ESTADO_PEDIDO
                        on pe.ESTADO_ID equals ep.ESTADO_ID
                        join pla in conexion.Entidades.PLATILLO
                        on pepl.PLATILLO_ID equals pla.PLATILLO_ID
                        join fp in conexion.Entidades.FORMA_PAGO
                        on pe.FORMA_PAGO_ID equals fp.FORMA_PAGO_ID
                        where (cl.RUT == rutCliente && pe.PEDIDO_ID == idPedido)
                        //pedidos que se deben enviar
                        //where(cl.RUT == rutCliente && pe.HORA_ENTREGA > DateTime.Now)
                        select new
                        {
                            RutCliente = cl.RUT,
                            NombreCliente = cl.NOMBRE + " " + cl.APPATERNO + " " + cl.APMATERNO,
                            HoraPedido = pe.HORA_PEDIDO,
                            HoraEntrega = pe.HORA_ENTREGA,
                            Estado = ep.DESCRIPCION,
                            FormaPago = fp.DESCRIPCION
                        };
                return x.First();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
                throw;
            }
        }
    }
}
