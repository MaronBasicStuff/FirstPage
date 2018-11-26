//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.Anuncios = new HashSet<Anuncio>();
        }

        public int UsuarioID { get; set;

        }


        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Este Campo es Requerido")]
        public string Email { get; set; }
        


        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Este Campo es Requerido")]
        public string Pass { get; set; }
    

        public string Privilegio { get; set; }
        public string Phone { get; set; }
        
        public string LoginErrorMessage { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anuncio> Anuncios { get; set; }
    }
}
