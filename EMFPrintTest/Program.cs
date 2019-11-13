using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMFPrintTest
{
    class Program
    {
        static void Main(string[] args)
        {
            EMFPrinter.Run("Microsoft Print to PDF", "기본트레이.emf");
        }
    }
}
