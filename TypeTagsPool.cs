using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfToyDataForms
{
    public partial class TypeTagsPool
    {

        public static IDictionary<int, string> DictionaryOfTagTypes = new Dictionary<int, string>();


        static TypeTagsPool()
        {
            DictionaryOfTagTypes.Add(1, "string");
            DictionaryOfTagTypes.Add(2, "int");
            DictionaryOfTagTypes.Add(3, "double");
            DictionaryOfTagTypes.Add(4, "float");
            DictionaryOfTagTypes.Add(5, "long");
            DictionaryOfTagTypes.Add(6, "DateTime");
            DictionaryOfTagTypes.Add(7, "bool");
            DictionaryOfTagTypes.Add(8, "char");

        }


    }
}
