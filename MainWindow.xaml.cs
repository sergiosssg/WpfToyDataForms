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

        //DataGrid _additionalDataGrid;


        #region private members


        private IDictionary<string, TabItem> _allTabItems;

        private bool? _PO_TEL_VID_CONNECTs_Is_changed;

        private PO_TEL_VID_CONNECT? _selectedCurrentPO_TE_VID_CONNECT;


        #endregion


        #region public Properties

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

        public static DbAppContext DbAppContext
        {
            private set;
            get;
        }

        #endregion



        #region public constructors

        static MainWindow()
        {
            DbContextOptions<DbAppContext> OptionsOFContext = DataBaseFacilities.OptionsOfDbContext();
            DbAppContext = new DbAppContext(OptionsOFContext);
        }

        public MainWindow()
        {

            this._allTabItems = new Dictionary<string, TabItem>();
            ;
            this._selectedCurrentPO_TE_VID_CONNECT = null;
            this._PO_TEL_VID_CONNECTs_Is_changed = null;
            InitializeComponent();
        }


        #endregion




        #region Public methods, should be spesific for each Form class



        public bool CloseSelectedTabItem()
        {
            if(mainTabCtrl.Items.Count > 0)
            {
                var selectedTabItem = mainTabCtrl.SelectedItem;



                //this._allTabItems

            }




            throw new NotImplementedException();
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




        #endregion





        #region Private methods, should be spesific for each Form class


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


        private TabItem createNewTabItem(string sHeader, string sToolTip = "", string sNameOfTabItem = "")
        {
            TabItem ti = new TabItem();


            ti.Header = sHeader;
            ti.ToolTip = sToolTip;

            return ti;
        }


        #endregion


        #region  Event Handlers


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
        }



        private void btnCloseTabItem_Click(object sender, RoutedEventArgs e)
        {
            if (!mainTabCtrl.Items.IsEmpty && mainTabCtrl.Items.Count > 0)
            {
                var currItem = mainTabCtrl.Items.CurrentItem;


            }
        }


        #endregion



        #region Menu Handlers



        private void MenuItem_FormFor001VIDCONNECT_Click(object sender, RoutedEventArgs e)
        {

            StackPanel stackPnl = new StackPanel();
            Frame frmForContentToInsert = new Frame();
            PageForFormSPR001VIDCONNECT pageDataGrid001 = new PageForFormSPR001VIDCONNECT();

            pageDataGrid001.ParrentMainWindow = this;

            TabItem tbItem;

            try
            {
                stackPnl.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE5E5E5"));


                stackPnl.Children.Add(frmForContentToInsert);

                if (!this._allTabItems.ContainsKey("Тип связи"))
                {

                    tbItem = createNewTabItem("Тип связи", "Справочник типов связи");
                    tbItem.Content = stackPnl;
                    this._allTabItems.Add("Тип связи", tbItem);

                    bool haveItemTabInCollectionAllready = false;

                    int indxOfCurrentTabItem = 0;

                    foreach (var elItemTab in this.mainTabCtrl.Items.SourceCollection)
                    {
                        TabItem tbi = elItemTab as TabItem;
                        if (tbi != null)
                        {
                            if (tbi.Header.Equals("Тип связи"))
                            {
                                haveItemTabInCollectionAllready = true;
                                indxOfCurrentTabItem = tbi.TabIndex;
                                break;
                            }
                        }
                    }

                    if (!haveItemTabInCollectionAllready && tbItem != null)
                    { //
                        int amount = pageDataGrid001.Load_PO_TEL_VID_CONNECT();

                        pageDataGrid001.LoadRecordsTo();


                        frmForContentToInsert.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                        frmForContentToInsert.VerticalContentAlignment = VerticalAlignment.Stretch;

                        frmForContentToInsert.Content = pageDataGrid001;
                        //frmForContentToInsert.Content = pageDataGrid001;


                        mainTabCtrl.Items.MoveCurrentToLast();
                        mainTabCtrl.Items.Add(tbItem);
                        mainTabCtrl.Items.MoveCurrentToLast();



                        tbItem.Focus();

                    }
                    else
                    {
                        mainTabCtrl.SelectedIndex = indxOfCurrentTabItem;
                    }
                }

                if (mainTabCtrl.Items.Count > 0)
                {
                    btnCloseTabItem.IsEnabled = true;
                }
            }
            catch (Exception es)
            {
                ;
            }
            ;
        }



        #endregion

    }
}
