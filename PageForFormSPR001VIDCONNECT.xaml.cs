﻿using System;
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
    /// Логика взаимодействия для PageForFormSPR001VIDCONNECT.xaml
    /// </summary>
    public partial class PageForFormSPR001VIDCONNECT : Page
    {

        #region private members

        private DbAppContext _dbAppContext;

        private bool _shouldBeSaved;

        private PO_TEL_VID_CONNECT? _pO_TEL_VID_CONNECT__selected;

        private bool _isDirtyDataSource;

        private int? _ID_of_selectedRecord;


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


        public PageForFormSPR001VIDCONNECT()
        {
            this._pO_TEL_VID_CONNECT__selected = null;
            this._shouldBeSaved = false;
            this._isDirtyDataSource = false;
            this._ID_of_selectedRecord = null;
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
            int? id = getCurrentIdNumber(sender);  // getCurrentFieldNameOfDataGreed(object dataGrid)
            string? nameOfEditedField = null;

            if (id != null && this._ID_of_selectedRecord != null && this._ID_of_selectedRecord == id)
            {
                nameOfEditedField = getCurrentFieldNameOfDataGreed(sender);

                string newValue = getCurrentFieldValueOfDataGridForChanging( e);
                ;
            }


            /*
                        if (sender != null)
                        {
                            DataGrid? dg = sender as DataGrid;
                            if (dg != null)
                            {
                                this._shouldBeSaved = true;
                            }
                        }
            */


        }





        private void _innerDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            ;
        }

        private void _innerDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            ;
        }


        private void _innerDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int? id = getCurrentIdNumber(sender);

            if (id == null)
            {

            }
            else if (_ID_of_selectedRecord != id)
            {
                this.toolBarForForm001VIDCONNECT.Visibility = Visibility.Visible;
                this._pO_TEL_VID_CONNECT__selected = getCurrentElementBeforeChangingFormDataGrid(sender);
            }

            this._ID_of_selectedRecord = id;
        }


        private void btnSaveAll_Click(object sender, RoutedEventArgs e)
        {
            saveAll();
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
                this._isDirtyDataSource = false;
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



        private string? getCurrentFieldValueOfDataGridForChanging(EventArgs eventArgs)
        {
            DataGridCellEditEndingEventArgs? dataGridCellEditEndingEventArgs = eventArgs as DataGridCellEditEndingEventArgs;

            if (dataGridCellEditEndingEventArgs != null)
            {
                var valueOfField = dataGridCellEditEndingEventArgs.Column;

                //return dataGridCellEditEndingEventArgs;
            }
            return string.Empty;
        }


        private string? getCurrentFieldNameOfDataGreed(object dataGrid)
        {
            DataGrid dg = dataGrid as DataGrid;

            if (dg != null)
            {
                return dg.CurrentColumn.SortMemberPath;
            }
            return string.Empty;
        }



        private int? getCurrentIdNumber(object objDataGrid)
        {
            DataGrid? dg = objDataGrid as DataGrid;
            PO_TEL_VID_CONNECT? po_currrecord = null;

            int? idCurrent = null;

            if (dg != null)
            {
                po_currrecord = dg.CurrentItem as PO_TEL_VID_CONNECT;

                if (po_currrecord != null)
                {
                    idCurrent = po_currrecord.IDConnect;
                }
            }
            return idCurrent;
        }


        #endregion


    }
}

