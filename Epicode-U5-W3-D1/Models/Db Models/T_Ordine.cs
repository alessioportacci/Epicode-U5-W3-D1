namespace Epicode_U5_W3_D1.Models.Db_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Ordine
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Indirizzo { get; set; }

        public DateTime? DataOrdine { get; set; }

        public DateTime? DataArrivo { get; set; }

        [StringLength(300)]
        public string Note { get; set; }

        public bool Evaso { get; set; }

        public int? FkUtente { get; set; }

        public int Quantita { get; set; }

        public int? T_Prodotto_Id { get; set; }

        public bool Confermato { get; set; }

        public int? FkProdotto { get; set; }

        public virtual T_Prodotto T_Prodotto { get; set; }

        public virtual T_Utenti T_Utenti { get; set; }
    }
}
