using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{

    class EmployeeException : Exception
    {
        public override string Message
        {
            get
            {
                return "Переполнение подчиненных!!!";
            }
        }
    }


    abstract class Employee
    {
        public string Name { get; set; }
        public abstract void AddSubordinate(Employee employee);
        public abstract void RemoveSubordinate(Employee employee);
        public abstract void Display();
    }

    

    class Manager : Employee
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();
        

        public override void AddSubordinate(Employee employee)
        {
           
            Employees.Add(employee);
        }

        public override void RemoveSubordinate(Employee employee)
        {
            Employees.Remove(employee);
        }

        public override void Display()
        {
            Console.WriteLine(Employees.Count());

            Console.WriteLine(Name);
            foreach (var item in Employees)
            {
                
                item.Display();
            }
        }
    }



    class Buhgalter : Employee
    {
        public List<Employee> Buhgalters { get; set; } = new List<Employee>();


        public override void AddSubordinate(Employee employee)
        {

            Buhgalters.Add(employee);
        }

        public override void RemoveSubordinate(Employee employee)
        {
            Buhgalters.Remove(employee);
        }

        public override void Display()
        {
            if (Buhgalters.Count() > 2)
            {
                throw new EmployeeException();
            }

            Console.WriteLine(Buhgalters.Count());

            Console.WriteLine(Name);
            foreach (var item in Buhgalters)
            {

                item.Display();
            }
        }
    }


   class Technical_staff : Employee
    {
        public List<Employee> Technical_staffs { get; set; } = new List<Employee>();


        public override void AddSubordinate(Employee employee)
        {

            Technical_staffs.Add(employee);
        }

        public override void RemoveSubordinate(Employee employee)
        {
            Technical_staffs.Remove(employee);
        }

        public override void Display()
        {

            if (Technical_staffs.Count() > 3)
            {
                throw new EmployeeException();
            }

            Console.WriteLine(Technical_staffs.Count());

            Console.WriteLine(Name);
            foreach (var item in Technical_staffs)
            {
                item.Display();
            }
        }

    }


    class Operator : Employee
    {

        public override void Display()
        {
            Console.WriteLine(Name);           
        }

        public override void AddSubordinate(Employee component)
        {
            throw new NotImplementedException();
        }

        public override void RemoveSubordinate(Employee component)
        {
            throw new NotImplementedException();
        }
         
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                Employee manager = new Manager() { Name = "Rassul" };
                Employee operatorOne = new Manager() { Name = "Abilay" };
                Employee operatorTwo = new Manager() { Name = "Baiangaly" };

                manager.AddSubordinate(operatorOne);
                manager.AddSubordinate(operatorTwo);


                manager.Display();

                Console.WriteLine("-----------------------");

                Employee technical_manager = new Technical_staff() { Name = "Nick" };
                Employee technical_staff1 = new Technical_staff() { Name = "Sten" };
                Employee technical_staff2 = new Technical_staff() { Name = "Ali" };
                Employee technical_staff3 = new Technical_staff() { Name = "Armin" };
                Employee technical_staff4 = new Technical_staff() { Name = "Nina" };

                technical_manager.AddSubordinate(technical_staff1);
                technical_manager.AddSubordinate(technical_staff2);


                technical_manager.Display();

               
                Console.WriteLine("-----------------------");
               
                Employee general_buhgalter = new Buhgalter() { Name = "Adil" };
                Employee buhgalter1 = new Buhgalter() { Name = "Aziza" };
                Employee buhgalter2 = new Buhgalter() { Name = "Kamil" };
                Employee buhgalter3 = new Buhgalter() { Name = "Ardak" };
                Employee buhgalter4 = new Buhgalter() { Name = "Petr" };
                Employee buhgalter5 = new Buhgalter() { Name = "Samat" };
               
                general_buhgalter.AddSubordinate(buhgalter1);
                general_buhgalter.AddSubordinate(buhgalter2);
                general_buhgalter.AddSubordinate(buhgalter3);

                general_buhgalter.Display();

                /*
                Console.WriteLine("-----------------------");
                Employee operator1 = new Operator() { Name = "Denis" };
                operator1.AddSubordinate(operatorOne);
                operator1.Display();
                */

            }

            catch (EmployeeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NotImplementedException ee)
            {
                Console.WriteLine(ee.Message);
            }
            

        }
    }
}
