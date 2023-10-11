namespace Epicode_U5_W3_D1.Models.Db_Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_OrdineProdotto
    {
        public int Id { get; set; }

        public int? FkOrdine { get; set; }

        public int? FkProdotto { get; set; }

        public virtual T_Ordine T_Ordine { get; set; }

        public virtual T_Prodotto T_Prodotto { get; set; }
    }
}
