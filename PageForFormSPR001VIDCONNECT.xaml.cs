using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для PageDataGrid001.xaml
    /// </summary>
    public partial class PageDataGrid001 : Page
    {

        #region private members

        private DbAppContext _dbAppContext;

        private bool _shouldBeSaved;

        private PO_TEL_VID_CONNECT? _pO_TEL_VID_CONNECT;


        #endregion





        #region public Properties

        public ICollection<PO_TEL_VID_CONNECT> CollectionOf_TEL_VID_CONNECTs
        {
            set;
            get;
        }


        public DataGrid MainDataGrid
        {
            private get;
            set;
        }

        #endregion


        #region public constructors


        public PageDataGrid001()
        {
            this._pO_TEL_VID_CONNECT = null;
            this._shouldBeSaved = false;
            try
            {

                this._dbAppContext = MainWindow.DbAppContext;
                MainDataGrid = _innerDataGrid;
                InitializeComponent();

            }
            catch (NullReferenceException nre)
            {
                TextWriter errorWriter = Console.Error;

                if (MainWindow.DbAppContext == null)
                {
                    errorWriter.WriteLine(" DB Application Context is null");
                }

                errorWriter.WriteLine(nre.Message);
                errorWriter.WriteLine(nre.StackTrace);
            }
        }
        #endregion


        #region methods for loading records into DataGrid

        public int Load_PO_TEL_VID_CONNECT()
        {
            CollectionOf_TEL_VID_CONNECTs = _dbAppContext.pO_TEL_VID_CONNECTs.Local;


            this.CollectionOf_TEL_VID_CONNECTs = _dbAppContext.pO_TEL_VID_CONNECTs.ToList<PO_TEL_VID_CONNECT>();

            return this.CollectionOf_TEL_VID_CONNECTs.Count;
        }


        public void LoadRecordsTo()
        {
            int amount = this.Load_PO_TEL_VID_CONNECT();

            if (amount > 0)
            {
                visualize_PO_TEL_VID_CONNECT__for_ordinary_DataGridExtension(_innerDataGrid, CollectionOf_TEL_VID_CONNECTs);
                //visualize_PO_TEL_VID_CONNECT__for_ordinary_DataGridExtension( MainDataGrid, CollectionOf_TEL_VID_CONNECTs);
            }
        }

        #endregion


        #region Event Handlers

        private void _innerDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (sender != null)
            {
                DataGrid? dg = sender as DataGrid;
                if (dg != null)
                {
                    this._shouldBeSaved = true;
                }
            }
        }





        private void _innerDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            ;
        }

        private void _innerDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            ;
        }

        #endregion

        #region Private methods, should be spesific for each Form class


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



        private void saveAll()
        {
            if (this._shouldBeSaved)
            {
                _dbAppContext.SaveChanges(true);

                this._shouldBeSaved = false;
            }
        }


        private bool checkIFCellChanged()
        {

            throw new NotImplementedException();
        }


        private PO_TEL_VID_CONNECT? getCurrentElementBeforeChangingFormDataGrid(object sender)
        {
            PO_TEL_VID_CONNECT? returnedRecord = null;

            if (sender != null)
            {
                DataGrid? dg = sender as DataGrid;
                if (dg != null)
                {
                    returnedRecord = dg.CurrentItem as PO_TEL_VID_CONNECT;
                }
            }
            return returnedRecord;
        }



        private string getCurrentFieldNameOfGreedReadyForChanging(EventArgs eventArgs)
        {
            DataGridCellEditEndingEventArgs? dataGridCellEditEndingEventArgs = eventArgs as DataGridCellEditEndingEventArgs;

            if (dataGridCellEditEndingEventArgs != null)
            {
                return dataGridCellEditEndingEventArgs.EditingElement.Name;
            }
            return string.Empty;
        }

        #endregion

    }
}

