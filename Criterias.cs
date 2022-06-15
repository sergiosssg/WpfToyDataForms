using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfToyDataForms
{

    /**
     *   This class has dictionary of criteria string
     * 
     * 
     * 
     */
    public partial class GlobalCriteriasPool
    {
        public static IDictionary<int, string> DictionaryOfCriteraStrings = new Dictionary<int, string>();


        static GlobalCriteriasPool()
        {
            DictionaryOfCriteraStrings.Add(1, "тип значения строки - телефон");
            DictionaryOfCriteraStrings.Add(2, "тип значения строки - услуга");
            DictionaryOfCriteraStrings.Add(3, "тип значения строки - финансовая запись");
            DictionaryOfCriteraStrings.Add(4, "тип значения строки - контракт");
            DictionaryOfCriteraStrings.Add(5, "тип значения строки - передача данных");
            DictionaryOfCriteraStrings.Add(6, "тип значения ячейки - телефон А откуда");
            DictionaryOfCriteraStrings.Add(7, "тип значения ячейки - телефон В куда");
            DictionaryOfCriteraStrings.Add(8, "тип значения ячейки - услуга");
            DictionaryOfCriteraStrings.Add(9, "тип значения ячейки - время");
            DictionaryOfCriteraStrings.Add(10, "тип значения ячейки - длительность");
            DictionaryOfCriteraStrings.Add(11, "тип значения ячейки - направление");
            DictionaryOfCriteraStrings.Add(12, "тип значения ячейки - объём");
            DictionaryOfCriteraStrings.Add(13, "тип значения ячейки - колличество");
            DictionaryOfCriteraStrings.Add(14, "тип значения ячейки - Сумма");
            DictionaryOfCriteraStrings.Add(15, "подтип значения ячейки - без ПДВ");
            DictionaryOfCriteraStrings.Add(16, "подтип значения ячейки - с ПДВ");
            DictionaryOfCriteraStrings.Add(17, "тип значения ячейки - входной звонок");
            DictionaryOfCriteraStrings.Add(18, "тип значения ячейки - выходной звонок");
            DictionaryOfCriteraStrings.Add(19, "подтип значения ячейки - время начала");
            DictionaryOfCriteraStrings.Add(20, "подтип значения ячейки - время конца");
            DictionaryOfCriteraStrings.Add(21, "подтип значения ячейки - по Украине");
            DictionaryOfCriteraStrings.Add(22, "подтип значения ячейки - за границей");
            DictionaryOfCriteraStrings.Add(23, "подтип значения ячейки - Россия");
            DictionaryOfCriteraStrings.Add(24, "подтип значения строки - еденичное значение");
            DictionaryOfCriteraStrings.Add(25, "подтип значения строки - по услуге");
            DictionaryOfCriteraStrings.Add(26, "подтип значения строки - по звонку");
            DictionaryOfCriteraStrings.Add(27, "подтип значения строки - сумма");
            DictionaryOfCriteraStrings.Add(28, "подтип значения строки - скидка");
            DictionaryOfCriteraStrings.Add(29, "подтип значения ячейки - внутри сети");
            DictionaryOfCriteraStrings.Add(30, "подтип значения ячейки - внутри города");
            DictionaryOfCriteraStrings.Add(31, "подтип значения ячейки - Водафон");
            DictionaryOfCriteraStrings.Add(32, "подтип значения ячейки - Киевстар");
            DictionaryOfCriteraStrings.Add(33, "подтип значения ячейки - Укртелеком");
        }
    }

}
