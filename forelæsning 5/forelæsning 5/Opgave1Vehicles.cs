using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forelæsning_5
{
    //Superclass Vehicles
    public class Vehicles
    {
        protected virtual string Model { get; set; }
        protected virtual string Make { get; set; }

        protected Vehicles(string Make, string Model)
        {
            this.Model = Model;
            this.Make = Make;
        }
        /*
        protected Vehicles()
        {

        }
        */
        public override string ToString()
        {
            return String.Format("Make: {0} Model: {1}", Make, Model);
        }
    }

    //Subclass 01 CAR
    class Car : Vehicles
    {
        public int NrOfDoors { get; set; }
        public Car(string Model, string Make, int NrOfDoors) : base (Model, Make)
        {
            this.NrOfDoors = NrOfDoors;
        }
        public override string ToString()
        {
            return base.ToString() + "Number of doors: " + NrOfDoors;
        }

    }

    //Subclass 02 Truck
    class Truck : Vehicles
    {
        public int MaxLoad { get; set; }

        public Truck(string Model, string Make, int MaxLoad) : base(Model, Make)
        {
            this.MaxLoad = MaxLoad;
        }
        public override string ToString()
        {
            return base.ToString() + "Max load: " + MaxLoad + "kg";
        }
    }

    //Subclass 03 Convertible 
    class Convertible : Car
    {
        public string RoofType { get; set; }
        public Convertible(string Model, string Make, int NrOfDoors, string RoofType) : base(Model, Make, NrOfDoors)
        {
            this.RoofType = RoofType;
        }
        public override string ToString()
        {
            return base.ToString() + " Roof type: " + RoofType;
        }
    }

    //class Main parametere - create a string array that represents the command-line arguments 
    // Print object Car, Truck and Convertible
    class Demo
    {
        static void Main(string[] args)
        {
            var car = new Car("WM ", "Up ", 3);
            Console.WriteLine(car);
            Console.WriteLine();
            var truck = new Truck("VM ", "Partner ", 3000);
            Console.WriteLine(truck);
            Console.WriteLine();
            var Convertible = new Convertible("Peugot ", "307cc ", 5, "Hard Top ");
            Console.WriteLine(Convertible);
            Console.WriteLine();
        }
    }
}
