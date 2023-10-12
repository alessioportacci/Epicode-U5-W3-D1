namespace Epicode_U5_W3_D1.Models.Db_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class T_Prodotto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Prodotto()
        {
            T_Ordine = new HashSet<T_Ordine>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string Img { get; set; }

        [NotMapped]
        public HttpPostedFileBase Immagine { get; set; }

        [Column(TypeName = "money")]
        public decimal? Costo { get; set; }

        [StringLength(400)]
        public string Ingredienti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Ordine> T_Ordine { get; set; }
    }
}
