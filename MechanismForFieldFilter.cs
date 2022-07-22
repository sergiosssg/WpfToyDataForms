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
            this._columnName =  this._fieldName = "ID";
            this.NameOfType = "string";
            this.SortingDirection = SortingDirection.Ascending;
        }
    }

    public partial class ColumnValueForFieldFilter<T>
    {
        private bool _IamEmpty;
        private T? _value;
        TypeOfColumnValueForFieldFilter _typeOfColumnValueForFieldFilter;

        public ColumnValueForFieldFilter()
        {
            this._typeOfColumnValueForFieldFilter = new TypeOfColumnValueForFieldFilter();
            this._IamEmpty = true;
            this._value = default(T);
        }

    }


}
