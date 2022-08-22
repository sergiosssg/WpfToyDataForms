using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
            // modelBuilder.Entity<PO_TEL_OPERATOR>().HasOne(telefonOperator => telefonOperator.ParentIDConnect).WithMany(p => p.TelefonOperators).HasForeignKey(fk => fk.ParentIDConnect);
            //modelBuilder.Entity<PO_TEL_OPERATOR>().HasOne(telefonOperator => telefonOperator.ParentIDConnect).WithMany(p => p.TelefonOperators);
            modelBuilder.Entity<PO_TEL_OPERATOR>().HasOne( p => p.ParentIDConnect).WithMany( p => p.TelefonOperators).HasForeignKey( p => p.IDConnect);
        }


    }


    public partial class DataBaseFacilities
    {

        public static string GetConnectionString()
        {
            DbConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder["Data Source"] = "localhost";             //  Office setting string
            //builder["Data Source"] = @"localhost\SQLExpress";   //  Home setting string

            builder["Database"] = "sampd_cexs";

            builder["integrated Security"] = "true";

            return builder.ConnectionString;
        }


        public static DbContextOptions<DbAppContext> OptionsOfDbContext() => new DbContextOptionsBuilder<DbAppContext>().UseSqlServer(GetConnectionString()).Options;

    }






}
