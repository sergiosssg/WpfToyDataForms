using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfToyDataForms
{
    public partial class ScannedSeed
    {

        public string? TelefonOperator
        {
            get;
            set;
        }
        public AccountPeriodTime? AccountPeriodTimeProperty
        {
            get;
            set;
        }
        public Zone? ZoneProperty
        {
            get;
            set;
        }

        public string? AcountOfGivenService
        {
            get;
            set;
        }

        public string? FileNameOfDataSource
        {
            get;
            set;
        }

        public int? IndexOfFileInChain
        {
            get;
            set;
        }

        /**
         *    e.g. :
         *  "1,3,5,6,7,8"
         * 
         */
        public string? TypeOfSeed
        {
            get;
            set;
        }


        public string? RawValueOfCell
        {
            get;
            set;
        }

        public int? NumberOfStringInDocument
        {
            get;
            set;
        }

        public string? NameOfStringInDocument
        {
            get;
            set;
        }

        public string? ColumnOfCellInDocument
        {
            get;
            set;
        }


        /**
         *   e.g.  tag  in  inbound xls data file
         * 
         */
        public string? TagLabelName
        {
            get;
            set;
        }


        /**
         *     is corresponding  to  TypeTagsPool.DictionaryOfTagTypes set
         */
        public int? DataTypeOfStoredValue
        {
            get;
            set;
        }


        public string? ValueAsString
        {
            get;
            set;
        }

        public int? ValueAsInteger
        {
            get;
            set;
        }

        public double? ValueAsDouble
        {
            get;
            set;
        }

        public float? ValueAsFloat
        {
            get;
            set;
        }

        public long? ValueAsLong
        {
            get;
            set;
        }

        public long? ContractName
        {
            get;
            set;
        }

        public int? OtherSideTelefonOperatorName
        {
            set;
            get;
        }

        public int? OtherSideCountryName
        {
            set;
            get;
        }

    }
}
