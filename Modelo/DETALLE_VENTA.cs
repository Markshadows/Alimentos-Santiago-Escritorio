//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class DETALLE_VENTA
    {
        public int VENTA_ID { get; set; }
        public byte CLIENTE_PEDIDO_ID { get; set; }
        public Nullable<int> TOTAL { get; set; }
    
        public virtual CLIENTE_PEDIDO CLIENTE_PEDIDO { get; set; }
        public virtual VENTA VENTA { get; set; }
    }
}
