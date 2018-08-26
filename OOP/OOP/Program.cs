using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP {
    class Program {
        static void Main(string[] args) {
            Staff Bob = new Staff("Bob","Piggingston") {
                HoursWorked = 40
            };

            Staff Peter = new Staff("Peter") {
                HoursWorked = 160
            };
            //staff1.HoursWorked = 160;
            int PetersPay = Peter.CalculatePay(1000, 400);
            int BobsPay = Peter.CalculatePay(500,400);
            Console.WriteLine("PetersPay = {0}",PetersPay);
            Console.WriteLine("BobsPay = {0}",BobsPay);

            MyClass classA = new MyClass();
            Console.WriteLine(classA.message);
            classA.Name = "Jamie";
            classA.DisplayName();

            int[] myArray = { 1,2,3,4,5 };
            ArrayDemo.PrintFirstElement(myArray);

            List<int> myList = new List<int> { 6,7,8 };
            ListDemo.PrintFirstElement(myList);

            ArrayDemo.ReturnUserInput();
            ListDemo.ReturnUserInput();
            Console.WriteLine();

            ParamsDemo.PrintNames("Peter");
            ParamsDemo.PrintNames("Yvonne", "Jamie");
            ParamsDemo.PrintNames("Abigail", "Betty", "Carol", "David");

            int a = 2;
            int[] b = { 1,2,3 };
            MethodDemo obj = new MethodDemo();
            Console.WriteLine("a before = {0}",a);
            obj.PassByValue(a);
            Console.WriteLine("a after ={0}",a);
            Console.WriteLine("\n\n");

            Console.WriteLine("b[0] before = {0}",b[0]);
            obj.PassByReference(b);
            Console.WriteLine("b[0] after = {0}",b[0]);

            Console.ReadLine();
        }
    }

    class Staff {
        public Staff(string name) {
            nameOfStaff = name;
            Console.WriteLine("\n" + nameOfStaff);
            Console.WriteLine("----------------------");
        }
        public Staff(string firstName,string lastName) {
            nameOfStaff = firstName + " " + lastName;
            Console.WriteLine("\n" + nameOfStaff);
            Console.WriteLine("----------------------");
        }
        //private means they can only be accessed within this class.
        private string nameOfStaff;
        private const int hourlyRate = 30;
        private static int hWorked = 40;

        public int HoursWorked {
            get {
                return hWorked;
            }
            set {
                if (value > 0)
                    hWorked = value;
                else
                    hWorked = 0;
            }
        }
        public int AutoImplemented { get; set; }

        public static void PrintMessage() {
            Console.WriteLine("Calculating Pay...");
        }

        public int CalculatePay() {
            PrintMessage();
            int staffPay;
            staffPay = hWorked * hourlyRate;
            if (hWorked > 0) {
                return staffPay;
            }
            else {
                return 0;
            }
        }

        public int CalculatePay(int bonus, int allowance) {
            PrintMessage();
            if (hWorked > 0) {
                return hWorked * hourlyRate + bonus + allowance;
            }
            else {
                return 0;
            }
        }

        public override string ToString() {
            return "Name of Staff = " + nameOfStaff+ ", hourlyRate = " + hourlyRate + ", hWorked = " + hWorked;
        }
    }

    //Demo of static vs. non-static;
    class MyClass {
        public string message = "Hello World";
        public string Name { get; set; }
        public void DisplayName() {
            Console.WriteLine("Name = {0}",Name);
        }
        public static string greetings = "Good Morning";
        public static int Age { get; set; }
        public static void DisplayAge() {
            Console.WriteLine("Age = {0}",Age);
        }
    }

    class ArrayDemo {
        public static void PrintFirstElement(int[] a) {
            Console.WriteLine("The first element is {0}.\n",a[0]);
        }

        public static int[] ReturnUserInput() {
            int[] a = new int[3];

            for (int i = 0; i< a.Length; i++) {
                Console.Write("Enter an integer: ");
                a[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Integer added to array.\n");
            }
            foreach(var num in a) {
                Console.Write(num + ", ");
            }
            Console.WriteLine("");

            return a;
        }

    }

    class ListDemo {
        public static void PrintFirstElement(List<int> a) {
            Console.WriteLine("The first element is {0}.\n",a[0]);
        }

        public static List<int> ReturnUserInput() {
            List<int> a = new List<int>();
            int input;
            
            for (int i = 0; i < 3; i++) {
                Console.Write("Enter an integer: ");
                input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Integer added to list. \n");
                a.Add(input);
            }
            foreach (var num in a) {
                Console.Write(num + ", ");
            }
            return a;
        }
    }

    class ParamsDemo {
        public static void PrintNames(params string[] names) {
            for (int i = 0; i < names.Length; i++) {
                Console.Write(names[i] + " ");
            }
            Console.WriteLine();
        }
        /*
        Hence, the following method declaration is fine:
            public void PrintNames2(int a, double b, params int[] ages)

        but the following declarations are not :
            public void PrintNames3(int a, params string[] names, double b)
            public void PrintNames4(params string[] names, params int[] ages)
            
        PrintNames3 is not allowed because double b comes after params string[] names.
        PrintNames4 is not allowed because there are two params keywords.
         */
    }

    class MethodDemo {
        public void PassByValue(int a) {
            a = 10;
            Console.WriteLine("a inside method = {0}",a);
        }
        public void PassByReference(int[] b) {
            b[0] = 5;
            Console.WriteLine("b[0] inside method = {0}",b[0]);
        }
    }
}
