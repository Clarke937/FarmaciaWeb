//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FarmaciaWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class login
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public login()
        {
            this.registro = new HashSet<registro>();
        }
    
        public int id_login { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar un nombre de usuario")]
        public string usuario { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar una contraseña")]
        public string contrasenia { get; set; }
        public int fk_nivel { get; set; }
    
        public virtual nivel_acceso nivel_acceso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<registro> registro { get; set; }
    }
}
