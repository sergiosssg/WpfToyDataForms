using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfToyDataForms
{

    public enum SortingDirection
    {
        Ascending, Descending
    }


    public partial class TypeOfColumnValueForFieldFilter
    {
        private string _columnName;
        private string _fieldName;

        


        public string ColumnNAme  { get => this._columnName; set  { this._columnName = value; } }

        public string FieldNAme { get => this._fieldName;   set { this._fieldName = value; } }

        public SortingDirection SortingDirection { get; set; }

        public string NameOfType { get; set; }


        public TypeOfColumnValueForFieldFilter()
        {
            this.SortingDirection = SortingDirection.Ascending;
        }
    }

    public partial class ColumnValueForFieldFilter
    {

    }


}
