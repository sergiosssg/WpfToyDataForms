using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfToyDataForms
{

    public partial class AccountPeriodTime
    {
        public int Year
        {
            get;
            set;
        }
        public int Month
        {
            get;
            set;
        }

        public AccountPeriodTime()
        {

        }

    }

    public partial class BaseEnums
    {


    }


    public partial class Zone
    {
        public string Name
        {
            get;
            set;
        }
    }


    public partial class ZoneTagPool
    {
        public static IDictionary<string, string> DictionaryOfZoneTags = new Dictionary<string, string>();


        static ZoneTagPool()
        {
            DictionaryOfZoneTags.Add("00", "Сумы");
        }


    }

}
