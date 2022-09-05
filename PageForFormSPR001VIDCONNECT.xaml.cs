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
    /// Логика взаимодействия для PageDataGrid001.xaml
    /// </summary>
    public partial class PageDataGrid001 : Page
    {
        private DbAppContext _dbAppContext;

        private bool _shouldBeSaved;


        public DataGrid MainDataGrid
        {
            private get;
            set;
        }


        public ICollection<PO_TEL_VID_CONNECT> CollectionOf_TEL_VID_CONNECTs
        {
            set;
            get;
        }


        public PageDataGrid001()
        {
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

                if(MainWindow.DbAppContext == null)
                {
                    errorWriter.WriteLine(" DB Application Context is null");
                }

                errorWriter.WriteLine(nre.Message);
                errorWriter.WriteLine(nre.StackTrace);
            }
        }


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
                visualize_PO_TEL_VID_CONNECT__for_ordinary_DataGridExtension(  _innerDataGrid, CollectionOf_TEL_VID_CONNECTs);
                //visualize_PO_TEL_VID_CONNECT__for_ordinary_DataGridExtension( MainDataGrid, CollectionOf_TEL_VID_CONNECTs);

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

        private  void saveAll()
        {
            if (this._shouldBeSaved)
            {
                _dbAppContext.SaveChanges(true);

                this._shouldBeSaved = false;
            }

        }


        private void _innerDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if(sender != null)
            {
                DataGrid? dg = sender as DataGrid;
                if(dg != null)
                {
                    this._shouldBeSaved = true;
                }
            }
        }



/*
        private void Page_LostFocus(object sender, RoutedEventArgs e)
        {
            this.saveAll();
        }
*/



        private void _innerDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            ;
        }
    }
}

