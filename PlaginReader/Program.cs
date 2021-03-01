using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace PlaginReader
{
    [Patch(@"D:\C#\Homeworks\Plagin Reader\PlaginReader\PlaginReader\Dll\ClassLibrary1.dll") ]
    class Program
    {
        static void Main(string[] args)
        {
            string dirName = @"D:\C#\Homeworks\Plagin Reader\PlaginReader\PlaginReader\Dll";
            string[] files = Directory.GetFiles(dirName);
            foreach (var item in files)
            {
                Console.WriteLine(item);

                Assembly asm = Assembly.LoadFile(item);
                Console.WriteLine(asm.FullName);

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
                method.Invoke(obj, new object[] { });

                Console.ReadKey();
            }
        }

    }
}
