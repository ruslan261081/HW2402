using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HW240219
{
   public class Car
   {
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        private int codan;
        protected int numberOfSeats;

        public Car()
        {

        }
       /* public Car(string fileName)
        {
            XmlSerializer myXmlSerialiazer = new XmlSerializer(typeof(Car));
            Car c2;
            using (Stream file = new FileStream(fileName, FileMode.Open))
            {
                c2 = myXmlSerialiazer.Deserialize(file) as Car;
            }
            Model = c2.Model;
            Brand = c2.Brand;
            Year = c2.Year;
            Color = c2.Color;
            this.codan = c2.codan;
            this.numberOfSeats = c2.numberOfSeats;

        }*/

        public Car(string model, string brand, int year, string color, int codan, int numberOfSeats)
        {
            Model = model;
            Brand = brand;
            Year = year;
            Color = color;
            this.codan = codan;
            this.numberOfSeats = numberOfSeats;
        }
        public int GetCoden()
        {
            return codan;
        }
        public int GetNumberOfSeats()
        {
            return numberOfSeats;
        }
        protected void ChangeNumberOfSeats(int newNumberOfSeats)
        {
            this.numberOfSeats = newNumberOfSeats;
        }
        public static void SerializeACar(string fileName, Car car)
        {
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car));
            using (Stream file = new FileStream(fileName, FileMode.Create))
            {
                myXmlSerializer.Serialize(file, car);
            }
        }
        public static void SeriliazeCarArray(string fileName, Car[] cars)
        {
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car[]));
            using (Stream file = new FileStream(fileName, FileMode.Create))
            {
                myXmlSerializer.Serialize(file, cars);
            }

        }
        public static Car DeserializeACar(string fileName)
        {
            Car c2;
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car));
            using (Stream file = new FileStream(fileName, FileMode.Open))
            {
                c2 = myXmlSerializer.Deserialize(file) as Car;

            }
            return c2;
        }
        public static  Car [] DeserializeCarArray(string filename)
        {
            Car[] carsFromFile;
            XmlSerializer myXmlSerializer = new XmlSerializer(typeof(Car[]));
            using (Stream file = new FileStream(filename, FileMode.Open))
            {
                carsFromFile = myXmlSerializer.Deserialize(file) as Car[];
            }
            return carsFromFile;
        }
        public bool CarCompare(string fileName)
        {
            Car carToCompare = DeserializeACar(fileName);
            return ((this.Model == carToCompare.Model) && (this.Brand == carToCompare.Brand) &&
                (this.Year == carToCompare.Year));
        }

        public override string ToString()
        {
            return $" MOdel Car: {Model}, Brand: {Brand}, Year: {Year}, Color: {Color}, Codan: {codan}, NumberOf Seats: {numberOfSeats}";
        }
    }
}
