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

        //DataGridExtensions.DataGridFilter _dataGridFilter;

        DataGrid _additionalDataGrid;

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


        public ICollection<PO_TEL_MOB_SPR> CollectionOf_TEL_MOB_SPRs
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

            //this._dataGridFilter = new 
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

        public int Load_PO_TEL_MOB_SPR()
        {
            DbAppContext.pO_TEL_MOB_SPRs.Load();

            this.CollectionOf_TEL_MOB_SPRs = DbAppContext.pO_TEL_MOB_SPRs.ToList<PO_TEL_MOB_SPR>();

            return this.CollectionOf_TEL_MOB_SPRs.Count;
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
                    visualize_PO_TEL_VID_CONNECT__for_ordinary_DbGrid(dataGridSpr001, CollectionOf_TEL_VID_CONNECTs);
                    visualize_PO_TEL_VID_CONNECT__for_ordinary_DataGridExtension(dataGridSpr002, CollectionOf_TEL_VID_CONNECTs);
                    //btnSaveChanges.IsEnabled = true;
                }
            }
        }

        private void visualize_PO_TEL_VID_CONNECT__for_ordinary_DbGrid(Control dataViewControl, ICollection<PO_TEL_VID_CONNECT> vid_connects)
        {
            if ((dataViewControl != null) && (dataViewControl.GetType() == typeof(DataGrid)))
            {
                DataGrid dGrid = (DataGrid)dataViewControl;

                //dGrid.ItemsSource = vid_connects.t<PO_TEL_VID_CONNECT>().;


                DataGridTextColumn dataGridTextColumn1 = new DataGridTextColumn();


                //BetterDataGrid.AutoFilterDataGrid autoFilterDataGrid;

                //dGrid.DataContext = vid_connects;

                dGrid.ItemsSource = vid_connects;

                dGrid.IsEnabled = true;

                //dGrid.SetBinding();

                dGrid.IsSynchronizedWithCurrentItem = true;


                var columns = dGrid.Columns;



                foreach (var ccol in columns)
                {
                    var s = ccol.Header.ToString; ; ;
                }

                dataViewControl.Visibility = Visibility.Visible;

            }
        }

        private void visualize_PO_TEL_VID_CONNECT__for_ordinary_DataGridExtension(Control dataViewControl, ICollection<PO_TEL_VID_CONNECT> vid_connects)
        {
            if ((dataViewControl != null) && (dataViewControl.GetType() == typeof(DataGrid)))
            {
                DataGrid dGrid = (DataGrid)dataViewControl;

                Binding binding = new Binding();

                binding.Source = vid_connects;

                dGrid.SetBinding( DataGrid.ItemsSourceProperty , binding);


            }
        }



        private void dataGridSpr001_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            var isControlChanged = false;

            var typeOfSender = sender.GetType().ToString();

            var typeOfEvetArgs = e.GetType().ToString();

            if (!isControlChanged)
            {
                ; ; ;
            }
            ;
        }

        private void dataGridSpr001_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataGrid vvDataGrid;

            if (sender.GetType() == typeof(DataGrid))
            {
                vvDataGrid = (DataGrid)sender;
                var sss = vvDataGrid.RenderSize;



                var vvEventArg = e.GetPosition;


                

            }



            ;
        }

        private void dataGridSpr003_GotFocus(object sender, RoutedEventArgs e)
        {
            DataGrid dG;

            if(sender.GetType() == typeof(DataGrid))
            {
                dG = (DataGrid)sender;


                dG.SelectionUnit = DataGridSelectionUnit.CellOrRowHeader;


                var currColumn = dG.CurrentColumn;

                var tCurrColumn = currColumn.GetType().Name;

                var header = currColumn.Header;

                var tHeader = header.GetType().Name;

                var sortMemberPath = currColumn.SortMemberPath;

                var tSortMemberPath = sortMemberPath.GetType().Name;
            }

            ;
            ;
            ;
        }





    }
}
