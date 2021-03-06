using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PlaginReader
{
    [Serializable]
    class Biography
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string SecondName { get; }
        public DateTime Birthday { get; }
        public string PlaceOfBirth { get; }

        public Biography()
        {
        }

        public Biography(string firstName, string lastName, string secondName, DateTime data, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            SecondName = secondName;
            Birthday = data;
            PlaceOfBirth = city;
        }

        public void CompressOrDecompress(object name, ActionMode mode)
        {
            if (mode == ActionMode.Compress)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(@"D:\people.dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, name);

                    Console.WriteLine("Объект сериализован");
                }
            }

            if (mode == ActionMode.Decompress)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(@"D:\people.dat", FileMode.OpenOrCreate))
                {
                    Biography newPerson = (Biography)formatter.Deserialize(fs);

                    Console.WriteLine("Объект десериализован");
                    Console.WriteLine(newPerson.ToString());
                }
            }
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {SecondName}  Date of birthday :{Birthday} Place of birth {PlaceOfBirth}";
        }
    }
}

