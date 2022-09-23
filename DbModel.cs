using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfToyDataForms
{
    public partial class DbAppContext : DbContext
    {
        public DbAppContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PO_TEL_VID_CONNECT>? pO_TEL_VID_CONNECTs { get; set; } = null;

        public DbSet<PO_TEL_OPERATOR>? pO_TEL_OPERATORs { get; set; } = null;

        public DbSet<PO_TEL_MOB_SPR>? pO_TEL_MOB_SPRs { get; set; } = null;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("phone");
            // modelBuilder.Entity<PO_TEL_OPERATOR>().HasOne(telefonOperator => telefonOperator.ParentIDConnect).WithMany(p => p.TelefonOperators).HasForeignKey(fk => fk.ParentIDConnect);
            //modelBuilder.Entity<PO_TEL_OPERATOR>().HasOne(telefonOperator => telefonOperator.ParentIDConnect).WithMany(p => p.TelefonOperators);
            modelBuilder.Entity<PO_TEL_OPERATOR>().HasOne(p => p.ParentIDConnect).WithMany(p => p.TelefonOperators).HasForeignKey(p => p.IDConnect);
            base.OnModelCreating(modelBuilder);
        }


    }
}
