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
    
    public partial class PLANILLA_TRABAJADORES
    {
        public byte PLANILLA_ID { get; set; }
        public System.DateTime FECHA_SUBIDA { get; set; }
        public byte CONVENIO_EMPRESA_ID { get; set; }
        public string NOMBRE_ARCHIVO { get; set; }
    
        public virtual CONVENIO_EMPRESA CONVENIO_EMPRESA { get; set; }
    }
}
