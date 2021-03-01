using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace PlaginReader
{
    //value Atrribute
    [Path(@"D:\C#\Homeworks\Plagin Reader\PlaginReader\PlaginReader\Dll")]
    class Program
    {
        static void Main(string[] args)
        {
            //pulling out the attribute
            Type name = typeof(Program);
            object[] atrrs = name.GetCustomAttributes(false);

            //getting attribute values
            foreach (PathAttribute atrr in atrrs)
            {
                //directory path
                string dirName = atrr.Path;
                string[] files = Directory.GetFiles(dirName);

                //I get files from the directory
                foreach (var item in files)
                {
                    Console.WriteLine(item);
                    //I connect the library
                    Assembly asm = Assembly.LoadFile(item);
                    Console.WriteLine(asm.FullName);

                    //I indicate my class
                    Type type = asm.GetType("ClassLibrary1.Class1");

                    Type[] types = asm.GetTypes();

                    foreach (Type t in types)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(t.Name);
                        Console.ResetColor();
                    }
                    GC.Collect();
                    object obj = Activator.CreateInstance(type);

                    MethodInfo method = type.GetMethod("GetBiography");
                    //calling method
                    method.Invoke(obj, new object[] { });
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ReadKey();
                }
            }
        }
    }
}
