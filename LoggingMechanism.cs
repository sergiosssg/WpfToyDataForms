using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfToyDataForms
{

    interface ILoggerTrivial
    {
        public int publicate(string msg);

    }

    public class SimpleLogger : ILoggerTrivial
    {
        public int publicate(string msg)
        {
            try
            {
                Console.Write(msg);

                return 1;
            }
            catch(Exception es)
            {
                Console.WriteLine("can't display exception ...");
                Console.WriteLine(es.Message);
            }
            throw new NotImplementedException();
        }
    }

}
