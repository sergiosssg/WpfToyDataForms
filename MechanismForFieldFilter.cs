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




        public string ColumnNAme { get => this._columnName; set { this._columnName = value; } }

        public string FieldNAme { get => this._fieldName; set { this._fieldName = value; } }

        public SortingDirection SortingDirection { get; set; }

        public string NameOfType { get; set; }


        public TypeOfColumnValueForFieldFilter()
        {
            this._columnName = this._fieldName = "ID";
            this.NameOfType = "string";
            this.SortingDirection = SortingDirection.Ascending;
        }

        public TypeOfColumnValueForFieldFilter(string fieldName)
        {
            this._fieldName = fieldName;
            this._columnName = fieldName;
            this.NameOfType = "string";
            this.SortingDirection = SortingDirection.Ascending;
        }
        public TypeOfColumnValueForFieldFilter(string fieldName, string columnName)
        {
            this._fieldName = fieldName;
            this._columnName = columnName;
            this.NameOfType = "string";
            this.SortingDirection = SortingDirection.Ascending;
        }
        public TypeOfColumnValueForFieldFilter(string fieldName, string columnName, string nameOfType)
        {
            this._fieldName = fieldName;
            this._columnName = columnName;
            this.NameOfType = nameOfType;
            this.SortingDirection = SortingDirection.Ascending;
        }

        public TypeOfColumnValueForFieldFilter(string fieldName, string columnName, Type typeOfField)
        {
            this._fieldName = fieldName;
            this._columnName = columnName;
            this.NameOfType = typeOfField.Name;
            this.SortingDirection = SortingDirection.Ascending;
        }

        public TypeOfColumnValueForFieldFilter(string fieldName, string columnName, string nameOfType, SortingDirection sortingDirection)
        {
            this._fieldName = fieldName;
            this._columnName = columnName;
            this.NameOfType = nameOfType;
            this.SortingDirection = sortingDirection;
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

        public ColumnValueForFieldFilter( T newValu)
        {
            this._typeOfColumnValueForFieldFilter = new TypeOfColumnValueForFieldFilter();
            this._value = newValu;
            this._IamEmpty = true;
        }


        public ColumnValueForFieldFilter(T newValu, TypeOfColumnValueForFieldFilter typeOfColumnValueForFieldFilter)
        {
            this._typeOfColumnValueForFieldFilter = typeOfColumnValueForFieldFilter;
            this._value = newValu;
            this._IamEmpty = true;
        }


        public bool IsEmpty
        {
            get => this.IsEmpty;
        }

        public T ValueProperty
        {
            get => this._value;
            set
            {
                if (value != null)
                {
                    this._value = value;
                    this._IamEmpty = true;
                }
            }
        }

        public TypeOfColumnValueForFieldFilter TypeOfColumnValueForFieldFilterProperty
        {
            get => this._typeOfColumnValueForFieldFilter;
            set => this._typeOfColumnValueForFieldFilter = value;
        }

    }


}
