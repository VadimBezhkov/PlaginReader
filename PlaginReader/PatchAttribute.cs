using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace PlaginReader
{
    //create my attribyte
    class PathAttribute:Attribute
    {
        public string Path { get; set; }
        public PathAttribute(string pa)
        {
            Path = pa;
        }

    }
}
