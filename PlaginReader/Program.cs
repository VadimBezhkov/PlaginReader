using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace PlaginReader
{
    enum Serializable
    {
        serializable,
        deserializable,
        exit
    }
    //value Atrribute
    [Path(@"D:\Repozitoriy\PlaginReader\PlaginReader\Dll")]
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
                    object obj = Activator.CreateInstance(type);

                    MethodInfo method = type.GetMethod("GetBiography");

                    //calling method
                    method.Invoke(obj, new object[] { });
                    Console.WriteLine();
                    Console.WriteLine();
                }

                Biography my = new Biography("Vadim", "Bezhkov", "Alexandrovich",
                    new DateTime(1988, 12, 31), "Pinsk");

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Hello Friend");
                    Console.WriteLine("Press 0 to serializable");
                    Console.WriteLine("Press 1 to deserializable");
                    Console.WriteLine("Press 2 to exit this programm");
                    Console.ResetColor();

                    Serializable op;
                    Enum.TryParse(Console.ReadLine(), out op);

                    switch (op)
                    {
                        case Serializable.serializable:

                            Console.Clear();
                            my.CompressOrDecompress(my, ActionMode.Compress);
                            Console.WriteLine();

                            break;
                        case Serializable.deserializable:
                            Console.Clear();
                            my.CompressOrDecompress(my, ActionMode.Decompress);
                            Console.WriteLine();

                            break;
                        case Serializable.exit:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }
    }
}
