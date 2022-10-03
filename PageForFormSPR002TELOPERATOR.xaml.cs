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
    /// Логика взаимодействия для PageForFormSPR002TELOPERATOR.xaml
    /// </summary>
    public partial class PageForFormSPR002TELOPERATOR : Page
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


        private EntityOperatorResultStateEnum _entityOperatorResultStateEnum;


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
            get => this._parrentMainWindow;
            set
            {
                MainWindow mw = value as MainWindow;
                if (mw != null)
                {
                    this._parrentMainWindow = mw;
                }
            }
        }


        #endregion



        public PageForFormSPR002TELOPERATOR()
        {
            InitializeComponent();
        }
    }
}
