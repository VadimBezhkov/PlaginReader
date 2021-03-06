using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaginReader
{
    interface IInfoReadable
    {
        void CompressBio(object obj);
        void DeCompressBio(object obj);
    }
}
