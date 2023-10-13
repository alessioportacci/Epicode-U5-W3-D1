namespace Epicode_U5_W3_D1.Models.Db_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Utenti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Utenti()
        {
            T_Ordine = new HashSet<T_Ordine>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Inserire un nome")]
        public string Nome { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Inserire un username")]
        public string Username { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Inserire una password")]
        public string Password { get; set; }

        [StringLength(50)]
        public string Ruolo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Ordine> T_Ordine { get; set; }
    }
}
