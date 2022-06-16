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

        
        public DbContextOptions<DbAppContext> OptionsOFContext
        {
            get;
        }

        public DbAppContext dbAppContext
        {
            private set;
            get;
        }

        public MainWindow()
        {
            OptionsOFContext = DataBaseFacilities.OptionsOfDbContext();
            InitializeComponent();
        }

        private DbAppContext GetDbAppContext()
        {
            return dbAppContext;
        }

        private int InitializeDbContexts()
        {
            
            dbAppContext = new DbAppContext(OptionsOFContext);


            return 1;
        }
    }
}
