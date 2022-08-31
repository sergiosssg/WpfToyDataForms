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
        private DbAppContext _dbAppContext;


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
            try
            {

                this._dbAppContext = MainWindow.DbAppContext;
                MainDataGrid = _innerDataGrid;
                InitializeComponent();

            }
            catch (NullReferenceException nre)
            {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine(nre.Message);
                errorWriter.WriteLine(nre.StackTrace);
            }
        }
    }
}

