using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 There are two main differences between a struct and a class.
 Firstly, the struct data type does not support inheritance. 
 Hence you cannot derive one struct from another.
 However, a struct can implement an interface.
 The way to do it is identical to how it is done with classes.
*/

namespace EnumsStructs {
    class Program {
        static void Main(string[] args) {
            DaysOfWeek myDays = DaysOfWeek.Mon;
            Console.WriteLine(myDays);
            Console.WriteLine((int)myDays);
            Console.WriteLine((DaysOfWeek)10);

            MyStruct example = new MyStruct(2,3,5);
            example.PrintStatement();

            Console.Read();
        }
    }
    enum DaysOfWeek {
        Sun=7, Mon, Tues, Wed, Thurs, Fri, Sat
    }

    enum DaysOfWeekThree: byte {
        Sun=240, Mon, Tues, Wed, Thurs, Fri, Sat
    }

    struct MyStruct {
        private int x,y;
        private AnotherClass myClass;
        private Days myDays;
        
        public MyStruct(int a, int b, int c) {
            myClass = new AnotherClass();
            myClass.number = a;
            x = b;
            y = c;
            myDays = Days.Mon;
        }

        public void PrintStatement() {
            Console.WriteLine("x = {0}, y = {1}, myDays = {2}", x, y, myDays);
        }
    }

    class AnotherClass {
        public int number;
    }

    enum Days { Mon, Tues, Wed }
}
