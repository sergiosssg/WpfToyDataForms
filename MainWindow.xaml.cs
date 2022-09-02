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




        private bool? _PO_TEL_VID_CONNECTs_Is_changed;

        private PO_TEL_VID_CONNECT? _selectedCurrentPO_TE_VID_CONNECT;


        public static DbAppContext DbAppContext
        {
            private set;
            get;
        }


        static MainWindow()
        {
            DbContextOptions<DbAppContext> OptionsOFContext = DataBaseFacilities.OptionsOfDbContext();
            DbAppContext = new DbAppContext(OptionsOFContext);
        }

        public MainWindow()
        {
            this._selectedCurrentPO_TE_VID_CONNECT = null;
            this._PO_TEL_VID_CONNECTs_Is_changed = null;
            InitializeComponent();
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
            var Is_Loaded_PO_TEL_VID_CONNECT = Load_PO_TEL_VID_CONNECT() > 0;
            var Is_Loaded_PO_TEL_OPERATOR = Load_PO_TEL_OPERATOR() > 0;
            var Is_Loaded_PO_TEL_MOB_SPR = Load_PO_TEL_MOB_SPR() > 0;
            if (Is_Loaded_PO_TEL_VID_CONNECT || Is_Loaded_PO_TEL_OPERATOR)
            {
                btnShowFilterForm.IsEnabled = true;
                visualize_PO_TEL_VID_CONNECT__for_ordinary_DbGrid(dataGridSpr001, CollectionOf_TEL_VID_CONNECTs);
                visualize_PO_TEL_VID_CONNECT__for_ordinary_DataGridExtension(dataGridSpr002, CollectionOf_TEL_VID_CONNECTs);
                //btnSaveChanges.IsEnabled = true;
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

                dGrid.SetBinding(DataGrid.ItemsSourceProperty, binding);


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

            if (sender.GetType() == typeof(DataGrid))
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

        private void dataGridSpr002_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (sender != null)
            {
                DataGrid datagrid = (DataGrid)sender;
                PO_TEL_VID_CONNECT currentPO_TE_VID_CONNECT = (PO_TEL_VID_CONNECT)datagrid.CurrentItem;
                if (currentPO_TE_VID_CONNECT != null)
                {
                    if (this._PO_TEL_VID_CONNECTs_Is_changed == null && this._selectedCurrentPO_TE_VID_CONNECT == null)
                    {
                        this._PO_TEL_VID_CONNECTs_Is_changed = false;
                        this._selectedCurrentPO_TE_VID_CONNECT = currentPO_TE_VID_CONNECT;
                    }
                    else if (this._PO_TEL_VID_CONNECTs_Is_changed != null && this._PO_TEL_VID_CONNECTs_Is_changed == true && this._selectedCurrentPO_TE_VID_CONNECT != null && this._selectedCurrentPO_TE_VID_CONNECT.IDConnect != currentPO_TE_VID_CONNECT.IDConnect)
                    {
                        this._PO_TEL_VID_CONNECTs_Is_changed = null;
                        this._selectedCurrentPO_TE_VID_CONNECT = currentPO_TE_VID_CONNECT;
                    }
                }
            }
        }

        private void dataGridSpr002_PreparingCellForEdit(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            if (sender != null)
            {
                DataGrid datagrid = (DataGrid)sender;
                PO_TEL_VID_CONNECT currentPO_TE_VID_CONNECT = (PO_TEL_VID_CONNECT)datagrid.CurrentItem;
                if (currentPO_TE_VID_CONNECT != null)
                {
                    ; ; ;
                }

            }
        }

        private void dataGridSpr002_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (sender != null && e != null)
            {
                DataGridCellEditEndingEventArgs dgCellEditEndingEventArgs = (DataGridCellEditEndingEventArgs)e;

                var tTt = dgCellEditEndingEventArgs.GetType().Name;

                DataGrid datagrid = (DataGrid)sender;
                PO_TEL_VID_CONNECT currentPO_TE_VID_CONNECT = (PO_TEL_VID_CONNECT)datagrid.CurrentItem;
                PO_TEL_VID_CONNECT selectedPO_TE_VID_CONNECT = (PO_TEL_VID_CONNECT)datagrid.SelectedItem;
                if (currentPO_TE_VID_CONNECT != null)
                {
                    ; ; ;
                }
            }
        }

        private void MenuItem_FormFor001VIDCONNECT_Click(object sender, RoutedEventArgs e)
        {
            ; 
            ; 
            ; 
            ; 
            ;
        }







        /*
                private void dataGridSpr002_LostFocus(object sender, RoutedEventArgs e)
                {
                    DataGrid datagrid = (DataGrid)sender;
                    PO_TEL_VID_CONNECT currentPO_TE_VID_CONNECT = (PO_TEL_VID_CONNECT)datagrid.CurrentItem;
                    if (currentPO_TE_VID_CONNECT != null)
                    {
                        bool isEqualRecord = this._selectedCurrentPO_TE_VID_CONNECT.Equals(currentPO_TE_VID_CONNECT);
                        if (this._PO_TEL_VID_CONNECTs_Is_changed != null && this._PO_TEL_VID_CONNECTs_Is_changed == false && !isEqualRecord)
                        {

                        }
                        if (this._PO_TEL_VID_CONNECTs_Is_changed != null && this._PO_TEL_VID_CONNECTs_Is_changed == false && !isEqualRecord)
                        {
                            this._PO_TEL_VID_CONNECTs_Is_changed = true;
                            this._selectedCurrentPO_TE_VID_CONNECT = null;
                        }
                    }
                }
        */

        /*
                private void dataGridSpr002_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
                {
                    DataGrid datagrid = (DataGrid)sender;
                    PO_TEL_VID_CONNECT currentPO_TE_VID_CONNECT = (PO_TEL_VID_CONNECT)datagrid.CurrentItem;
                    if (currentPO_TE_VID_CONNECT != null)
                    {
                        bool isEqualRecord = this._selectedCurrentPO_TE_VID_CONNECT.Equals(currentPO_TE_VID_CONNECT);
                        if (!this._PO_TEL_VID_CONNECTs_Is_changed && !isEqualRecord)
                        {
                            this._PO_TEL_VID_CONNECTs_Is_changed = true;
                            this._selectedCurrentPO_TE_VID_CONNECT = null;
                        }
                    }
                }
        */

        /*
                private void dataGridSpr002_CurrentCellChanged(object sender, EventArgs e)
                {
                    DataGrid datagrid = (DataGrid)sender;
                    PO_TEL_VID_CONNECT currentPO_TE_VID_CONNECT = (PO_TEL_VID_CONNECT)datagrid.CurrentItem;
                    bool isEqualRecord = this._selectedCurrentPO_TE_VID_CONNECT.Equals(currentPO_TE_VID_CONNECT);
                    if (!this._PO_TEL_VID_CONNECTs_Is_changed && !isEqualRecord)
                    {
                        this._PO_TEL_VID_CONNECTs_Is_changed = true;
                        this._selectedCurrentPO_TE_VID_CONNECT = null;
                    }
                }
        */

        /*
                private void dataGridSpr002_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
                {
                    DataGrid datagrid = (DataGrid)sender;
                    PO_TEL_VID_CONNECT currentPO_TE_VID_CONNECT = (PO_TEL_VID_CONNECT)datagrid.CurrentItem;
                    bool isEqualRecord = this._selectedCurrentPO_TE_VID_CONNECT.Equals(currentPO_TE_VID_CONNECT);
                    if (!this._PO_TEL_VID_CONNECTs_Is_changed && !isEqualRecord)
                    {
                        this._PO_TEL_VID_CONNECTs_Is_changed = true;
                        this._selectedCurrentPO_TE_VID_CONNECT = null;
                    }
                }
        */




    }
}
