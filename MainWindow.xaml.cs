using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfToyDataForms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ICollection<PO_TEL_VID_CONNECT> CollectionOf_TEL_VID_CONNECTs
        {
            set;
            get;
        }



        public DbContextOptions<DbAppContext> OptionsOFContext
        {
            get;
        }

        public DbAppContext DbAppContext
        {
            private set;
            get;
        }

        public MainWindow()
        {
            this.OptionsOFContext = DataBaseFacilities.OptionsOfDbContext();
            InitializeComponent();
        }


        private int InitializeDbContexts()
        {
            this.DbAppContext = new DbAppContext(OptionsOFContext);

            return 1;
        }


        public int Load_PO_TEL_VID_CONNECT()
        {

            DbAppContext.pO_TEL_VID_CONNECTs.Load();

            CollectionOf_TEL_VID_CONNECTs = DbAppContext.pO_TEL_VID_CONNECTs.ToList<PO_TEL_VID_CONNECT>();

            throw new NotImplementedException();
        }

    }
}
