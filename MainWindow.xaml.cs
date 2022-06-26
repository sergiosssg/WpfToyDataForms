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

        private bool _contextIsInitialized;

        public ICollection<PO_TEL_VID_CONNECT> CollectionOf_TEL_VID_CONNECTs
        {
            set;
            get;
        }


        public ICollection<PO_TEL_OPERATOR> CollectionOf_TEL_OPERATORs
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


        private bool InitializeDbContexts()
        {
            this.DbAppContext = new DbAppContext(OptionsOFContext);

            return (this._contextIsInitialized = true);
        }


        public int Load_PO_TEL_VID_CONNECT()
        {

            DbAppContext.pO_TEL_VID_CONNECTs.Load();

            this.CollectionOf_TEL_VID_CONNECTs = DbAppContext.pO_TEL_VID_CONNECTs.ToList<PO_TEL_VID_CONNECT>();

            return this.CollectionOf_TEL_VID_CONNECTs.Count;
        }

        public int Load_PO_TEL_OPERATOR()
        {

            DbAppContext.pO_TEL_OPERATORs.Load();

            this.CollectionOf_TEL_OPERATORs = DbAppContext.pO_TEL_OPERATORs.ToList<PO_TEL_OPERATOR>();

            return this.CollectionOf_TEL_OPERATORs.Count;
        }


        private void btnLoadAll_Click(object sender, RoutedEventArgs e)
        {
            if (!this._contextIsInitialized)
            {
                this.InitializeDbContexts();
            }
            if (this._contextIsInitialized)
            {
                var Is_Loaded_PO_TEL_VID_CONNECT = Load_PO_TEL_VID_CONNECT() > 0;
                var Is_Loaded_PO_TEL_OPERATOR = Load_PO_TEL_OPERATOR() > 0;
                if (Is_Loaded_PO_TEL_VID_CONNECT || Is_Loaded_PO_TEL_OPERATOR)
                {
                    btnShowFilterForm.IsEnabled = true;
                }
            }
        }

        private  void visualize_PO_TEL_VID_CONNECT(Control dataViewControl,   ICollection<PO_TEL_VID_CONNECT> vid_connects)
        {

        }

    }
}
