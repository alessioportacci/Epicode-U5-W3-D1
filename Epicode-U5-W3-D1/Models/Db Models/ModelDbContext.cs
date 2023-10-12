using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Epicode_U5_W3_D1.Models.Db_Models
{
    public partial class ModelDbContext : DbContext
    {
        public ModelDbContext()
            : base("name=ModelDbContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<T_Ordine> T_Ordine { get; set; }
        public virtual DbSet<T_Prodotto> T_Prodotto { get; set; }
        public virtual DbSet<T_Utenti> T_Utenti { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_Prodotto>()
                .Property(e => e.Costo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<T_Prodotto>()
                .HasMany(e => e.T_Ordine)
                .WithOptional(e => e.T_Prodotto)
                .HasForeignKey(e => e.T_Prodotto_Id);

            modelBuilder.Entity<T_Utenti>()
                .HasMany(e => e.T_Ordine)
                .WithOptional(e => e.T_Utenti)
                .HasForeignKey(e => e.FkUtente);
        }
    }
}
