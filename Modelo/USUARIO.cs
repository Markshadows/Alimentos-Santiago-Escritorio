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
    
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            this.USUARIO_TIPO_USUARIO = new HashSet<USUARIO_TIPO_USUARIO>();
        }
    
        public byte USUARIO_ID { get; set; }
        public string NOMBRE { get; set; }
        public string CONTRASENA { get; set; }
        public byte TIPO_USUARIO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO_TIPO_USUARIO> USUARIO_TIPO_USUARIO { get; set; }
    }
}
