using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace PlaginReader
{
    class PatchAttribute:Attribute
    {
        public static string Patch { get; set; }
        public PatchAttribute(string pa)
        {
            Patch = pa;
        }
        public PatchAttribute()
        {

        }
    }
}
