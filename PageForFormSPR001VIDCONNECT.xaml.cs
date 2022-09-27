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

        private IDictionary<string, bool> _isCanceledTextEnterringInFields;


        private ISet<int> _setOfIDs;



        private MainWindow _parrentMainWindow;


        private EntityOperatorResultStateEnum  _entityOperatorResultStateEnum;



        #endregion



        #region public Properties

        public ICollection<PO_TEL_VID_CONNECT> CollectionOf_TEL_VID_CONNECTs
        {
            set;
            get;
        }


        public DataGrid MainDataGrid
        {
            get;
        }

        public Window ParrentMainWindow
        {
            get=>this._parrentMainWindow;
            set
            {
                MainWindow mw = value as MainWindow;
                if( mw != null){
                    this._parrentMainWindow = mw;
                }
            }
        }

        #endregion


        #region public constructors


        public PageForFormSPR001VIDCONNECT()
        {
            this._pO_TEL_VID_CONNECT__selected = null;
            this._shouldBeSaved = false;
            this._isDirtyDataSource = false;
            this._ID_of_selectedRecord = null;

            this._setOfIDs = new SortedSet<int>();

            this._isCanceledTextEnterringInFields = new Dictionary<string, bool>();
            {
                this._isCanceledTextEnterringInFields.Add("IDConnect", false);
                this._isCanceledTextEnterringInFields.Add("KOD_CONNECT", false);
                this._isCanceledTextEnterringInFields.Add("NameOfConnect", false);
            }

            try
            {
                this._entityOperatorResultStateEnum = EntityOperatorResultStateEnum.Undefinite;
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

            this.CollectionOf_TEL_VID_CONNECTs = new List<PO_TEL_VID_CONNECT>();

            /*foreach( var elPO in _dbAppContext.pO_TEL_VID_CONNECTs)
            {
                this.CollectionOf_TEL_VID_CONNECTs.Add(elPO);
            }*/

            this.CollectionOf_TEL_VID_CONNECTs = _dbAppContext.pO_TEL_VID_CONNECTs.ToList<PO_TEL_VID_CONNECT>();

            if (this.CollectionOf_TEL_VID_CONNECTs.Count > 0)
            {
                this._entityOperatorResultStateEnum = EntityOperatorResultStateEnum.AllRecordsSaved;
            }
            return this.CollectionOf_TEL_VID_CONNECTs.Count;
        }


        public void LoadRecordsTo()
        {
            int amount = this.Load_PO_TEL_VID_CONNECT();

            if (amount > 0)
            {
                visualize_PO_TEL_VID_CONNECT__for_ordinary_DataGridExtension(_innerDataGrid, CollectionOf_TEL_VID_CONNECTs);
                //visualize_PO_TEL_VID_CONNECT__for_ordinary_DataGridExtension( MainDataGrid, CollectionOf_TEL_VID_CONNECTs);
                this._entityOperatorResultStateEnum = EntityOperatorResultStateEnum.AllRecordsSaved;
            }
        }

        #endregion


        #region Event Handlers

        private void _innerDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int? id = getCurrentIdNumber(sender);  // getCurrentFieldNameOfDataGrid(object dataGrid)
            string? nameOfEditedField = getCurrentFieldNameOfDataGrid(sender);

            var record = getCurrentElementBeforeChangingFormDataGrid(sender);

            string newValue = clearDirtyStringFromControlsSystemCharacters(getCurrentFieldValueOfDataGridForChanging(e)).Trim();

            bool isStringsAreDifferent = false;

            bool isPreviousNotSuccessfullyEditingOfField = false;  // whether previous attempt to edit field was successfull
            foreach (var onKey in this._isCanceledTextEnterringInFields.Keys)
            {
                if (this._isCanceledTextEnterringInFields[onKey])
                {
                    isPreviousNotSuccessfullyEditingOfField = true;
                    break;
                }
            }

            if (id != null)
            {
                if (!isPreviousNotSuccessfullyEditingOfField && this._ID_of_selectedRecord != null && this._ID_of_selectedRecord == id)  // if all right in entering and previous attempt to entering new value in field was successful
                {
                    if (record != null && nameOfEditedField != null && !nameOfEditedField.Equals(string.Empty) && newValue != null && !newValue.Equals(string.Empty))
                    {
                        isStringsAreDifferent = checkIFCellChanged(record, newValue, nameOfEditedField);

                        if (isStringsAreDifferent)
                        {
                            this._isDirtyDataSource = true;
                            this._shouldBeSaved = true;
                            btnSaveAll.IsEnabled = true;
                            return;
                        }
                    }
                }
                else if ( id == 0)
                {
                    if (record != null && record.isIamEmpty())
                    {
                        if (!isPreviousNotSuccessfullyEditingOfField)// previous attempt was successfull
                        {
                            var isRecordHasValidIDfield = isNewRecordHasValidIDfield(record, newValue, nameOfEditedField);
                            if (!isRecordHasValidIDfield)
                            {
                                this._isCanceledTextEnterringInFields[nameOfEditedField] = true;
                                //e.Cancel = true;
                                return;
                            }
                        }
                        else if(isPreviousNotSuccessfullyEditingOfField && this._isCanceledTextEnterringInFields["IDConnect"])
                        {
                            var isRecordHasValidIDfield = isNewRecordHasValidIDfield(record, newValue, nameOfEditedField);
                            if (isRecordHasValidIDfield)
                            {
                                e.Cancel = false;
                                this._isDirtyDataSource = true;
                                this._shouldBeSaved = true;
                                btnSaveAll.IsEnabled = true;

                                foreach (var onKey in this._isCanceledTextEnterringInFields.Keys)
                                {
                                    this._isCanceledTextEnterringInFields[onKey] = false;
                                }
                                return;
                            }
                        }
                    }
                }
            }
        }





        private void _innerDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            bool isPreviousNotSuccessfullyEditingOfField = false;  // whether previous attempt to edit field was successfull
            foreach (var onKey in this._isCanceledTextEnterringInFields.Keys)
            {
                if (this._isCanceledTextEnterringInFields[onKey])
                {
                    isPreviousNotSuccessfullyEditingOfField = true;
                    break;
                }
            }

            PO_TEL_VID_CONNECT po_TEL_VID_CONNECT = getCurrentElementBeforeChangingFormDataGrid(sender);
            int? id = getCurrentIdNumber(sender);
            if (po_TEL_VID_CONNECT.isIamEmpty())
            {
                return;
            }
            else if (this._ID_of_selectedRecord == null && id != null)
            {
                this._ID_of_selectedRecord = id;
            }
            else if (!isPreviousNotSuccessfullyEditingOfField && this._ID_of_selectedRecord != null && this._ID_of_selectedRecord > 0 && this._pO_TEL_VID_CONNECT__selected != null && this._ID_of_selectedRecord != id)
            {
                this._pO_TEL_VID_CONNECT__selected = po_TEL_VID_CONNECT;
                this._ID_of_selectedRecord = id;

            }

            if(this._entityOperatorResultStateEnum != EntityOperatorResultStateEnum.RowEditingStart && this._entityOperatorResultStateEnum != EntityOperatorResultStateEnum.NewRowAddingStart && this._entityOperatorResultStateEnum != EntityOperatorResultStateEnum.RowDeletingStart)
            {
                this._entityOperatorResultStateEnum = EntityOperatorResultStateEnum.RowEditingStart;
            }

        }


        private void _innerDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            int? id = getCurrentIdNumber(sender);

            bool isPreviousSuccessfullyEditingOfField = false;  // whether previous attempt to edit field was successfull
            foreach (var onKey in this._isCanceledTextEnterringInFields.Keys)
            {
                if (this._isCanceledTextEnterringInFields[onKey])
                {
                    isPreviousSuccessfullyEditingOfField = true;
                    break;
                }

            }

            if (isPreviousSuccessfullyEditingOfField)
            {


                e.Cancel = true;
            }

        }


        private void _innerDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int? id = getCurrentIdNumber(sender);


            PO_TEL_VID_CONNECT? pO_TEL_VID_CONNECT = getRemovedItemsInDataGrid(e);

            if (id == null)
            {
                return;
            }
            else if (id != null && this._ID_of_selectedRecord != id)
            {
                //this.toolBarForForm001VIDCONNECT.Visibility = Visibility.Visible;
                //this.toolBarForForm001VIDCONNECT.Visibility = Visibility.Visible;

                this._pO_TEL_VID_CONNECT__selected = getCurrentElementBeforeChangingFormDataGrid(sender);
            }

            this._ID_of_selectedRecord = id;
        }


        private void btnSaveAll_Click(object sender, RoutedEventArgs e)
        {
            saveAll();
            this._setOfIDs = fillIDsFromDbSetOfEntities(this._dbAppContext);
            btnSaveAll.IsEnabled = false;

            foreach (var onekey in this._isCanceledTextEnterringInFields.Keys)
            {
                this._isCanceledTextEnterringInFields[onekey] = false;
            }
        }


        private void _innerDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            ;
            foreach (var onekey in this._isCanceledTextEnterringInFields.Keys)
            {
                this._isCanceledTextEnterringInFields[onekey] = false;
            }

            this._setOfIDs =  fillIDsFromDbSetOfEntities( this._dbAppContext);
        }



        /**
         * 
         *   Later I need to complete this event handler
         * 
         */
        private void _innerDataGrid_LostFocus(object sender, RoutedEventArgs e)
        {
            bool isPreviousNotSuccessfullyEditingOfField = false;  // whether previous attempt to edit field was successfull
            foreach (var onKey in this._isCanceledTextEnterringInFields.Keys)
            {
                if (this._isCanceledTextEnterringInFields[onKey])
                {
                    isPreviousNotSuccessfullyEditingOfField = true;
                    break;
                }
            }

            if (!isPreviousNotSuccessfullyEditingOfField)
            {
                DataGrid dg = e.Source as DataGrid;
                if(dg != null)
                {
                    if (this._ID_of_selectedRecord != null)
                    {

                    }
                }
            }
            ;
        }


        private void btnNewRecord_Click(object sender, RoutedEventArgs e)
        {
            this.popupRecordOperation.Visibility = Visibility.Visible;
            this.popupRecordOperation.IsEnabled = true;
            this.popupRecordOperation.IsOpen = true;
        }





        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {

        }


        private void btnRemoveLastTab_Click(object sender, RoutedEventArgs e)
        {
            ;
        }


        private void btn_Cancel_from_popupRecord_Click(object sender, RoutedEventArgs e)
        {
            this.popupRecordOperation.IsOpen = false;
            this.popupRecordOperation.IsEnabled = false;
            this.popupRecordOperation.Visibility = Visibility.Hidden;
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

                _shouldBeSaved = false;


                _isDirtyDataSource = false;

                _ID_of_selectedRecord = null;

                _pO_TEL_VID_CONNECT__selected = null;




            }
        }



        private void saveAll()
        {
            if (this._shouldBeSaved || this._isDirtyDataSource)
            {
                this._dbAppContext.SaveChanges(true);

                this._shouldBeSaved = false;
                this._isDirtyDataSource = false;
            }
        }


        private bool checkIFCellChanged(PO_TEL_VID_CONNECT pO_TEL_VID_CONNECT, string newValue, string nameOfField)
        {
            string? str_OfValue = null;

            string sClearedNewValue = clearDirtyStringFromControlsSystemCharacters(newValue);

            if (nameOfField.Equals("IDConnect"))
            {
                str_OfValue = pO_TEL_VID_CONNECT.IDConnect.ToString();
            }
            else if (nameOfField.Equals("KodOfConnect"))
            {
                str_OfValue = pO_TEL_VID_CONNECT.KodOfConnect.ToString();
            }
            else if (nameOfField.Equals("NameOfConnect"))
            {
                str_OfValue = pO_TEL_VID_CONNECT.NameOfConnect.ToString();
            }

            if (str_OfValue != null && !str_OfValue.Equals(sClearedNewValue))
            {
                return true;
            }
            return false;
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


        private string clearDirtyStringFromControlsSystemCharacters(string valueDirty)
        {
            //
            string returnedCleanString;

            if (valueDirty.Contains("System.Windows.Controls.TextBox:"))
            {
                int i = "System.Windows.Controls.TextBox:".Length;



                //string sS = valueDirty;
                string sS = valueDirty.Substring(i);

                returnedCleanString = sS.Trim();
            }
            else
            {
                returnedCleanString = valueDirty;
            }

            return returnedCleanString;
        }


        private string? getCurrentFieldValueOfDataGridForChanging(EventArgs eventArgs)
        {
            DataGridCellEditEndingEventArgs? dataGridCellEditEndingEventArgs = eventArgs as DataGridCellEditEndingEventArgs;

            if (dataGridCellEditEndingEventArgs != null)
            {
                return dataGridCellEditEndingEventArgs.EditingElement.ToString();
            }
            return string.Empty;
        }


        private string? getCurrentFieldNameOfDataGrid(object dataGrid)
        {
            DataGrid dg = dataGrid as DataGrid;

            if (dg != null)
            {
                return dg.CurrentColumn.SortMemberPath;
            }
            return string.Empty;
        }


        private bool isNewRecordHasValidIDfield(PO_TEL_VID_CONNECT pO_TEL_VID_CONNECT, string newValue, string nameOfField, string patternNameOfField = "IDConnect")
        {
            if (nameOfField != null && nameOfField.Equals(patternNameOfField))
            {
                int iID;
                bool isStringDigit = int.TryParse(newValue, out iID);
                if(isStringDigit && iID > 0 && !this._setOfIDs.Contains(iID))  //  check  that  new ID value have to be unique
                {
                    return true;
                }
            }
            else if (nameOfField != null && !nameOfField.Equals(patternNameOfField) && pO_TEL_VID_CONNECT != null && pO_TEL_VID_CONNECT.IDConnect > 0)
            {
                return true;
            }
            return false;
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


        private PO_TEL_VID_CONNECT? getRemovedItemsInDataGrid(SelectionChangedEventArgs e)
        {
            PO_TEL_VID_CONNECT? returnedPO = null;
            if (e.RemovedItems.Count == 1)
            {
                var elOf_PO = e.RemovedItems[0];
                if (elOf_PO != null)
                {
                    returnedPO = e.RemovedItems[0] as PO_TEL_VID_CONNECT;
                    if (returnedPO != null)
                    {
                        return returnedPO;
                    }
                }
            }
            returnedPO = new PO_TEL_VID_CONNECT();
            return returnedPO;
            throw new NotImplementedException();
        }



        private ISet<int> fillIDsFromDbSetOfEntities(DbAppContext dbAppContext)
        {
            var keysOfIDs = dbAppContext.pO_TEL_VID_CONNECTs.Select(o => o.IDConnect);

            var tTt = keysOfIDs.GetType().Name;

            ISet<int> returnedSet = keysOfIDs.ToHashSet(); /*= new SortedSet<int>();*/

            /*foreach (var oneID in keysOfIDs)
            {
                returnedSet.Add(oneID);
            }*/

            return returnedSet;
        }









        #endregion

    }
}

