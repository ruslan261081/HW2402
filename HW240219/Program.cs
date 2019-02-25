using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HW240219
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car("Mitsubshi", "Outlender", 2019, "Blue", 3417, 7);
            XmlSerializer mySerializer = new XmlSerializer(typeof(Car));

            using (Stream file = new FileStream(@"c:\car\xml",FileMode.Create))
            { 
                mySerializer.Serialize(file, c1);
            }

            

            Car[] cars =
            {
                new Car("Land Rover", "Range Rover", 2007, "Black", 2610,5 ),
                new Car("Shkoda", "Fabia", 2003, "Green", 1223, 5),
                new Car("Lamborgini","Diablo", 2019,"Red", 5678,2)

            };

           



        }
    }
}
