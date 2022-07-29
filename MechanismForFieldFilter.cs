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


    public enum OperatorSign
    {
        EQ, NE, GT, LT, GE, LE
    }

    public enum LogicSign
    {
        _AND_, _OR_
    }


    public interface IFieldFilterPredicatable<T>
    {
        Func<bool?, T, bool> GetFieldFilterPredicate();
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

        public ColumnValueForFieldFilter(T newValu)
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



    public partial class OperatorForFieldValueChainForInteger : IFieldFilterPredicatable<int>
    {

        private IDictionary<OperatorSign, Func<bool?, int, bool>> _mapOfFuncsForOperatorSignForConjunction = new Dictionary<OperatorSign, Func<bool?, int, bool>>
        {
            [OperatorSign.EQ] = (prevResult, elem) =>  (prevResult != null)? true  :  true,
            [OperatorSign.NE] = (prevResult, elem) => (prevResult != null) ? false : false,
            [OperatorSign.GT] = (prevResult, elem) => (prevResult != null) ? false : false,
            [OperatorSign.LT] = (prevResult, elem) => (prevResult != null) ? false : false,
            [OperatorSign.GE] = (prevResult, elem) => (prevResult != null) ? false : false,
            [OperatorSign.LE] = (prevResult, elem) => (prevResult != null) ? false : false

        };

        private IDictionary<OperatorSign, Func<bool?, int, bool>> _mapOfFuncsForOperatorSignForDisjunction = new Dictionary<OperatorSign, Func<bool?, int, bool>> 
        { 
        };



        /*private static IDictionary<LogicSign, IDictionary<OperatorSign, Func<bool?, int, bool>>>  _mapOfFuncs =
        {
            null, 
            null
        }*/



        private LogicSign _logicSign;
        private OperatorSign _operatorSign;
        private ColumnValueForFieldFilter<int> _columnValueForFieldFilter;

        public OperatorForFieldValueChainForInteger()
        {
            this._logicSign = LogicSign._AND_;
            this._operatorSign = OperatorSign.EQ;
            this._columnValueForFieldFilter = new ColumnValueForFieldFilter<int>();
        }

        public OperatorForFieldValueChainForInteger(int iValue)
        {
            this._logicSign = LogicSign._AND_;
            this._operatorSign = OperatorSign.EQ;
            this._columnValueForFieldFilter = new ColumnValueForFieldFilter<int>(iValue);
        }

        public OperatorForFieldValueChainForInteger(OperatorSign operatorSign, int iValue)
        {
            this._logicSign = LogicSign._AND_;
            this._operatorSign = operatorSign;
            this._columnValueForFieldFilter = new ColumnValueForFieldFilter<int>(iValue);
        }

        public OperatorForFieldValueChainForInteger(OperatorSign operatorSign, ColumnValueForFieldFilter<int> columnValue)
        {
            this._logicSign = LogicSign._AND_;
            this._operatorSign = operatorSign;
            this._columnValueForFieldFilter = columnValue;
        }

        public LogicSign LogicSignProperety
        {
            get => this._logicSign;
            set => this._logicSign = value;
        }

        public OperatorSign OperatorSignProperty
        {
            get => this._operatorSign;
            set => this._operatorSign = value;
        }

        public ColumnValueForFieldFilter<int> ColumnValueForFieldFilterProperty
        {
            get => this._columnValueForFieldFilter;
            set => this._columnValueForFieldFilter = value;
        }

        public Func<bool? ,int, bool> GetFieldFilterPredicate()
        {
            throw new NotImplementedException();
        }
    }


}
