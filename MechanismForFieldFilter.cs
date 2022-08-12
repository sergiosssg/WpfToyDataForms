using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        _AS_IS_,_AND_, _OR_
    }




    public interface IFieldFilterPredicatableGetter<T>
    {
        Func<bool?, T, bool> GetFieldFilterPredicate();
    }


    public interface IFieldFilterPredicatableInitializer<T>
    {
        void InitializePredicates(T comparedT);
    }


    public interface IFieldFilterPredicatesIntializerAndGetter<T> : IFieldFilterPredicatableGetter<T>, IFieldFilterPredicatableInitializer<T>
    {

    }



    public partial class TypeOfColumnValueForFieldFilter
    {
        private string _columnName;
        private string _fieldName;


        public string ColumnName { get => this._columnName; set { this._columnName = value; } }

        public string FieldName { get => this._fieldName; set { this._fieldName = value; } }

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


    public  static  class StringsIntoEnumTransformator
    {
        readonly private  static Dictionary<String, OperatorSign> _dict_Strings2OperatorSign = new Dictionary<string, OperatorSign> { ["=="]= OperatorSign.EQ, [">"] = OperatorSign.GT, [">="] = OperatorSign.GE, ["<"] = OperatorSign.LT, ["<="] = OperatorSign.LE, ["!="] = OperatorSign.NE };

        readonly private static Dictionary<String, LogicSign> _dict_Strings2LogicSign = new Dictionary<string, LogicSign> { ["as is"] = LogicSign._AS_IS_, ["and"] = LogicSign._AND_, ["or"] = LogicSign._OR_ };

        static public OperatorSign GetOperatorSignFromString(String sOperatorSign) => _dict_Strings2OperatorSign[sOperatorSign];

        static public LogicSign GetLogicSignFromString(String sLogicSign) => _dict_Strings2LogicSign[sLogicSign];
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
            this._IamEmpty = false;
        }


        public ColumnValueForFieldFilter(T newValu, TypeOfColumnValueForFieldFilter typeOfColumnValueForFieldFilter)
        {
            this._typeOfColumnValueForFieldFilter = typeOfColumnValueForFieldFilter;
            this._value = newValu;
            this._IamEmpty = false;
        }


        public void clearValue()
        {
            this._IamEmpty = true;
            this._value = default(T);
        }

        public bool IsEmpty
        {
            get => this.IsEmpty;
        }

        public T? ValueProperty
        {
            get => this._value;
            set
            {
                if (value != null)
                {
                    this._value = value;
                    this._IamEmpty = false;
                }
                else
                {
                    this._value = default(T);
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


    public partial class OperatorForFieldValueChainForInteger : IFieldFilterPredicatesIntializerAndGetter<int>
    {
        private IDictionary<LogicSign, IDictionary<OperatorSign, Func<bool?, int, bool>>> _mapOfFuncs;

        public void InitializePredicates(int comparedValue)
        {
            IDictionary < OperatorSign, Func<bool?, int, bool> > mapOfFuncsForOperatorSignForConjunction = new Dictionary<OperatorSign, Func<bool?, int, bool>>
            {
                [OperatorSign.EQ] = (prevResult, elem) => (prevResult == null) ? ((elem == comparedValue) ? true : false ): (prevResult == true && elem == comparedValue)?  true : false,
                [OperatorSign.NE] = (prevResult, elem) => (prevResult == null) ? ((elem != comparedValue) ? true : false ): (prevResult == true && elem != comparedValue) ? true : false,
                [OperatorSign.GT] = (prevResult, elem) => (prevResult == null) ? ((elem > comparedValue) ? true : false) : (prevResult == true && elem > comparedValue) ? true : false,
                [OperatorSign.LT] = (prevResult, elem) => (prevResult == null) ? ((elem < comparedValue) ? true : false) : (prevResult == true && elem < comparedValue) ? true : false,
                [OperatorSign.GE] = (prevResult, elem) => (prevResult == null) ? ((elem >= comparedValue) ? true : false) : (prevResult == true && elem >= comparedValue) ? true : false,
                [OperatorSign.LE] = (prevResult, elem) => (prevResult == null) ? ((elem <= comparedValue) ? true : false) : (prevResult == true && elem <= comparedValue) ? true : false
            };

            IDictionary<OperatorSign, Func<bool?, int, bool>> mapOfFuncsForOperatorSignForDisjunction = new Dictionary<OperatorSign, Func<bool?, int, bool>>
            {
                [OperatorSign.EQ] = (prevResult, elem) => (prevResult == null) ? ((elem == comparedValue) ? true : false) : (prevResult == true || elem == comparedValue) ? true : false,
                [OperatorSign.NE] = (prevResult, elem) => (prevResult == null) ? ((elem != comparedValue) ? true : false) : (prevResult == true || elem != comparedValue) ? true : false,
                [OperatorSign.GT] = (prevResult, elem) => (prevResult == null) ? ((elem > comparedValue) ? true : false) : (prevResult == true || elem > comparedValue) ? true : false,
                [OperatorSign.LT] = (prevResult, elem) => (prevResult == null) ? ((elem < comparedValue) ? true : false) : (prevResult == true || elem < comparedValue) ? true : false,
                [OperatorSign.GE] = (prevResult, elem) => (prevResult == null) ? ((elem >= comparedValue) ? true : false) : (prevResult == true || elem >= comparedValue) ? true : false,
                [OperatorSign.LE] = (prevResult, elem) => (prevResult == null) ? ((elem <= comparedValue) ? true : false) : (prevResult == true || elem <= comparedValue) ? true : false
            };

            IDictionary<OperatorSign, Func<bool?, int, bool>> mapOfFuncsForOperatorSignForAsIs = new Dictionary<OperatorSign, Func<bool?, int, bool>>
            {
                [OperatorSign.EQ] = (prevResult, elem) => (prevResult == null) ? ((elem == comparedValue) ? true : false) : ( elem == comparedValue) ? true : false,
                [OperatorSign.NE] = (prevResult, elem) => (prevResult == null) ? ((elem != comparedValue) ? true : false) : ( elem != comparedValue) ? true : false,
                [OperatorSign.GT] = (prevResult, elem) => (prevResult == null) ? ((elem > comparedValue) ? true : false) : ( elem > comparedValue) ? true : false,
                [OperatorSign.LT] = (prevResult, elem) => (prevResult == null) ? ((elem < comparedValue) ? true : false) : ( elem < comparedValue) ? true : false,
                [OperatorSign.GE] = (prevResult, elem) => (prevResult == null) ? ((elem >= comparedValue) ? true : false) : ( elem >= comparedValue) ? true : false,
                [OperatorSign.LE] = (prevResult, elem) => (prevResult == null) ? ((elem <= comparedValue) ? true : false) : ( elem <= comparedValue) ? true : false
            };

            this._mapOfFuncs = new Dictionary<LogicSign, IDictionary<OperatorSign, Func<bool?, int, bool>>>
            {
                [LogicSign._AS_IS_] = mapOfFuncsForOperatorSignForAsIs,
                [LogicSign._AND_] = mapOfFuncsForOperatorSignForConjunction,
                [LogicSign._OR_] = mapOfFuncsForOperatorSignForDisjunction
            };
    }

        private LogicSign _logicSign;
        private OperatorSign _operatorSign;
        private ColumnValueForFieldFilter<int> _columnValueForFieldFilter;

        public OperatorForFieldValueChainForInteger()
        {
            this._logicSign = LogicSign._AND_;
            this._operatorSign = OperatorSign.EQ;
            this._columnValueForFieldFilter = new ColumnValueForFieldFilter<int>();
            this.InitializePredicates(this._columnValueForFieldFilter.ValueProperty);
        }

        public OperatorForFieldValueChainForInteger(int iValue) : this()
        {
            this._columnValueForFieldFilter = new ColumnValueForFieldFilter<int>(iValue);
            this.InitializePredicates(this._columnValueForFieldFilter.ValueProperty);
        }

        public OperatorForFieldValueChainForInteger(OperatorSign operatorSign, int iValue) : this()
        {
            this._operatorSign = operatorSign;
            this._columnValueForFieldFilter = new ColumnValueForFieldFilter<int>(iValue);
            this.InitializePredicates(this._columnValueForFieldFilter.ValueProperty);
        }

        public OperatorForFieldValueChainForInteger(OperatorSign operatorSign, ColumnValueForFieldFilter<int> columnValue) : this()
        {
            this._operatorSign = operatorSign;
            this._columnValueForFieldFilter = columnValue;
            this.InitializePredicates(this._columnValueForFieldFilter.ValueProperty);
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
            set  { this._columnValueForFieldFilter = value; this.InitializePredicates(this._columnValueForFieldFilter.ValueProperty); }
        }

        public Func<bool? ,int, bool> GetFieldFilterPredicate() => this._mapOfFuncs[this._logicSign][this._operatorSign];

    }


    public partial class OperatorForFieldValueChainForString : IFieldFilterPredicatesIntializerAndGetter<string>
    {
        private IDictionary<LogicSign, IDictionary<OperatorSign, Func<bool?, string, bool>>> _mapOfFuncs;

        public void InitializePredicates(string comparedValue)
        {
            IDictionary<OperatorSign, Func<bool?, string, bool>> mapOfFuncsForOperatorSignForConjunction = new Dictionary<OperatorSign, Func<bool?, string, bool>>
            {

                /*[OperatorSign.EQ] = (prevResult, elem) => (prevResult == null) ? (elem.Equals(comparedValue) ? true : false) : (prevResult == true && elem.Equals(comparedValue)) ? true : false,*/

                [OperatorSign.EQ] = (prevResult, elem) =>  
                     {
                       if( elem == null || comparedValue == null) 
                           {
                             return false;
                           }
                       if( prevResult == null)
                         {
                             return elem.Equals(comparedValue);
                         }
                       if( prevResult != null && prevResult == true)
                         {
                             return elem.Equals(comparedValue);
                         }
                       return false;
                     },
                [OperatorSign.NE] = (prevResult, elem) => (prevResult == null) ? (!elem.Equals(comparedValue) ? true : false) : (prevResult == true && !elem.Equals(comparedValue)) ? true : false
                
/*              ,

                [OperatorSign.GT] = (prevResult, elem) => (prevResult == null) ? ((elem > comparedValue) ? true : false) : (prevResult == true && elem > comparedValue) ? true : false
                [OperatorSign.LT] = (prevResult, elem) => (prevResult == null) ? ((elem < comparedValue) ? true : false) : (prevResult == true && elem < comparedValue) ? true : false,
                [OperatorSign.GE] = (prevResult, elem) => (prevResult == null) ? ((elem >= comparedValue) ? true : false) : (prevResult == true && elem >= comparedValue) ? true : false,
                [OperatorSign.LE] = (prevResult, elem) => (prevResult == null) ? ((elem <= comparedValue) ? true : false) : (prevResult == true && elem <= comparedValue) ? true : false
*/
            };

            IDictionary<OperatorSign, Func<bool?, string, bool>> mapOfFuncsForOperatorSignForDisjunction = new Dictionary<OperatorSign, Func<bool?, string, bool>>
            {
                [OperatorSign.EQ] = (prevResult, elem) => (prevResult == null) ? (elem.Equals(comparedValue) ? true : false) : (prevResult == true || elem.Equals(comparedValue)) ? true : false,
                [OperatorSign.NE] = (prevResult, elem) => (prevResult == null) ? (!elem.Equals(comparedValue) ? true : false) : (prevResult == true || !elem.Equals(comparedValue)) ? true : false
                
/*                ,

                [OperatorSign.GT] = (prevResult, elem) => (prevResult == null) ? ((elem > comparedValue) ? true : false) : (prevResult == true || elem > comparedValue) ? true : false,
                [OperatorSign.LT] = (prevResult, elem) => (prevResult == null) ? ((elem < comparedValue) ? true : false) : (prevResult == true || elem < comparedValue) ? true : false,
                [OperatorSign.GE] = (prevResult, elem) => (prevResult == null) ? ((elem >= comparedValue) ? true : false) : (prevResult == true || elem >= comparedValue) ? true : false,
                [OperatorSign.LE] = (prevResult, elem) => (prevResult == null) ? ((elem <= comparedValue) ? true : false) : (prevResult == true || elem <= comparedValue) ? true : false
*/
            };

            IDictionary<OperatorSign, Func<bool?, string, bool>> mapOfFuncsForOperatorSignForAsIs = new Dictionary<OperatorSign, Func<bool?, string, bool>>
            {
                [OperatorSign.EQ] = (prevResult, elem) => (prevResult == null) ? (elem.Equals(comparedValue) ? true : false) : (elem.Equals(comparedValue)) ? true : false,
                [OperatorSign.NE] = (prevResult, elem) => (prevResult == null) ? (!elem.Equals(comparedValue) ? true : false) : (!elem.Equals(comparedValue)) ? true : false
                
/*                ,

                [OperatorSign.GT] = (prevResult, elem) => (prevResult == null) ? ((elem > comparedValue) ? true : false) : (elem > comparedValue) ? true : false,
                [OperatorSign.LT] = (prevResult, elem) => (prevResult == null) ? ((elem < comparedValue) ? true : false) : (elem < comparedValue) ? true : false,
                [OperatorSign.GE] = (prevResult, elem) => (prevResult == null) ? ((elem >= comparedValue) ? true : false) : (elem >= comparedValue) ? true : false,
                [OperatorSign.LE] = (prevResult, elem) => (prevResult == null) ? ((elem <= comparedValue) ? true : false) : (elem <= comparedValue) ? true : false
*/
            };

            this._mapOfFuncs = new Dictionary<LogicSign, IDictionary<OperatorSign, Func<bool?, string, bool>>>
            {
                [LogicSign._AS_IS_] = mapOfFuncsForOperatorSignForAsIs,
                [LogicSign._AND_] = mapOfFuncsForOperatorSignForConjunction,
                [LogicSign._OR_] = mapOfFuncsForOperatorSignForDisjunction
            };
        }

        private LogicSign _logicSign;
        private OperatorSign _operatorSign;
        private ColumnValueForFieldFilter<string> _columnValueForFieldFilter;

        public OperatorForFieldValueChainForString()
        {
            this._logicSign = LogicSign._AND_;
            this._operatorSign = OperatorSign.EQ;
            this._columnValueForFieldFilter = new ColumnValueForFieldFilter<string>();
            this.InitializePredicates(this._columnValueForFieldFilter.ValueProperty);
        }

        public OperatorForFieldValueChainForString(string sValue) : this()
        {
            this._columnValueForFieldFilter = new ColumnValueForFieldFilter<string>(sValue);
            this.InitializePredicates(this._columnValueForFieldFilter.ValueProperty);
        }

        public OperatorForFieldValueChainForString(OperatorSign operatorSign, string sValue) : this()
        {
            this._operatorSign = operatorSign;
            this._columnValueForFieldFilter = new ColumnValueForFieldFilter<string>(sValue);
            this.InitializePredicates(this._columnValueForFieldFilter.ValueProperty);
        }

        public OperatorForFieldValueChainForString(OperatorSign operatorSign, ColumnValueForFieldFilter<string> columnValue) : this()
        {
            this._operatorSign = operatorSign;
            this._columnValueForFieldFilter = columnValue;
            this.InitializePredicates(this._columnValueForFieldFilter.ValueProperty);
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

        public ColumnValueForFieldFilter<string> ColumnValueForFieldFilterProperty
        {
            get => this._columnValueForFieldFilter;
            set { this._columnValueForFieldFilter = value; this.InitializePredicates(this._columnValueForFieldFilter.ValueProperty); }
        }

        public Func<bool?, string, bool> GetFieldFilterPredicate() => this._mapOfFuncs[this._logicSign][this._operatorSign];

    }



}
