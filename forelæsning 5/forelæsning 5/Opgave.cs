using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forelæsning_5
{
    namespace Opgave
    {
        public class Staff
        {
            // Der laves en property med navnet Name
            // Når der lave skrives "virtual" så skal man ved nedarvning skrive "override" da man siger at man gerne vil ændre værdien i propertien 
            public virtual string Name { get; set; }
            public virtual double Salary()
            {
                return 0.0d;
            }
            /*
            // MEGA GRIMT, dette skal ikke gøre til eksamen 
            public Staff() { Name = "Unknown";}
            */

            public Staff(string n)
            {
                Name = n;
            }
            public override string ToString()
            {
                return String.Format("Name: {0}, Salary {1}", Name, Salary());
            }

        }

        public class MonthlyPaid : Staff
        {
            public virtual double MonthlySalary { get; set; }
            public MonthlyPaid(string n, double sal) : base(n)
            {
                MonthlySalary = sal;
            }

            public override double Salary()
            {
                return MonthlySalary;
            }

        }

        public class HourlyPaid : Staff
        {
            public virtual double HourSalary { get; set; }
            public int HourPerWeek { get; set; }
            public HourlyPaid(string n, double sal, int h) : base(n)
            {
                HourSalary = sal;
                HourPerWeek = h;
            }
            public override double Salary()
            {
                return HourSalary * HourPerWeek;
            }

        }
        public class Demo
        {
            /*
            static void TestStaff()
            {
                Staff s1 = new Staff("Anne");
                Staff s2 = new HourlyPaid("Bent", 981.98, 4);
                Staff s3 = new MonthlyPaid("Curt", 98.89);
                //Console.WriteLine(s3);
            }

            static void UseArray()
            {
                Staff[] persons = { new Staff("Arne"),
                                    new HourlyPaid("Niels", 1200, 4),
                                    new MonthlyPaid("Viggo", 34000.343)
                };
                foreach (var p in persons)
                    Console.WriteLine(p);
            }
            */
            static void Main_01(string[] args)
            {
               // TestStaff();
                
                var s = new Staff("Anna");
                Console.WriteLine(s);
                var mp = new MonthlyPaid("Mogens", 10.23);

                

                Console.WriteLine(mp);
                var hp = new HourlyPaid("Hanne", 4.67, 20);
                Console.WriteLine(hp);
                Console.WriteLine();
                
            }
        }
    }
}
