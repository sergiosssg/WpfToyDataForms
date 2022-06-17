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

    public partial class DataBaseFacilities
    {

        public static string GetConnectionString()
        {
            DbConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder["Data Source"] = "localhost";
            //builder["Data Source"] = @"localhost\SQLExpress";

            builder["Database"] = "sampd_cexs";

            builder["integrated Security"] = "true";

            return builder.ConnectionString;
        }


        public static DbContextOptions<DbAppContext> OptionsOfDbContext() => new DbContextOptionsBuilder<DbAppContext>().UseSqlServer(GetConnectionString()).Options;

    }

    public partial class DbAppContext : DbContext
    {
        public DbAppContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PO_TEL_VID_CONNECT> pO_TEL_VID_CONNECTs { get; set; }

        public DbSet<PO_TEL_OPERATOR> pO_TEL_OPERATORs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<PO_TEL_OPERATOR>().HasOne(telefonOperator => telefonOperator.ParentIDConnect).WithMany(p => p.TelefonOperators).HasForeignKey(fk => fk.ParentIDConnect);
            //modelBuilder.Entity<PO_TEL_OPERATOR>().HasOne(telefonOperator => telefonOperator.ParentIDConnect).WithMany(p => p.TelefonOperators);
        }


    }





}
