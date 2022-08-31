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
    /// Логика взаимодействия для PageDataGrid001.xaml
    /// </summary>
    public partial class PageDataGrid001 : Page
    {
        public DataGrid MainDataGrid
        {
            private get;
            set;
        }




        public PageDataGrid001()
        {
            MainDataGrid = _innerDataGrid;
            InitializeComponent();
        }
    }
}

