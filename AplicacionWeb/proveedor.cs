//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AplicacionWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class proveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public proveedor()
        {
            this.registroentrada = new HashSet<registroentrada>();
        }
    
        public int codprov { get; set; }
        public string nomprov { get; set; }
        public string repprov { get; set; }
        public string dirprov { get; set; }
        public string telprov { get; set; }
        public string celprov { get; set; }
        public string corprov { get; set; }
        public bool estprov { get; set; }
        public int coddis { get; set; }
    
        public virtual distrito distrito { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<registroentrada> registroentrada { get; set; }
    }
}
