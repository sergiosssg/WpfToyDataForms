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

            builder["Data Source"] = "localhost";             //  Office setting string
            //builder["Data Source"] = @"localhost\SQLExpress";   //  Home setting string

            builder["Database"] = "sampd_cexs";

            builder["integrated Security"] = "true";

            return builder.ConnectionString;
        }


        public static DbContextOptions<DbAppContext> OptionsOfDbContext() => new DbContextOptionsBuilder<DbAppContext>().UseSqlServer(GetConnectionString()).Options;

    }






}
