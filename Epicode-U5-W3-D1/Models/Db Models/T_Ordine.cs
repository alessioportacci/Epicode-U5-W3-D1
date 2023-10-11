namespace Epicode_U5_W3_D1.Models.Db_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Ordine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Ordine()
        {
            T_OrdineProdotto = new HashSet<T_OrdineProdotto>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        public string Indirizzo { get; set; }

        public DateTime? DataOrdine { get; set; }

        public DateTime? DataArrivo { get; set; }

        [StringLength(300)]
        public string Note { get; set; }

        [DefaultValue(false)]
        public bool Evaso { get; set; }

        [DefaultValue(false)]
        public bool Confermato { get; set; }

        public int? FkUtente { get; set; }

        public virtual T_Utenti T_Utenti { get; set; }

        public int? FkProdotto { get; set; }

        public virtual T_Prodotto T_Prodotto { get; set; }

        public int Quantita { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_OrdineProdotto> T_OrdineProdotto { get; set; }
    }
}
