using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld {
    public class Examples {
        public static void Run() {
            byte userAge = 20;
            int numberOfEmployees = 510;

            double intNumberOfHours = 510;
            float intHourlyRate = 60;
            decimal intIncome = 25399;

            // float must have f to initialize it as a float, decimal must have m; otherwise these become double/decimal types respectively;
            double numberOfHours = 5120.5;
            float hourlyRate = 60.5f;
            decimal income = 25399.65m;

            Console.WriteLine("numberOfHours: {0}", numberOfHours);

            int x = (int)20.9;
            Console.WriteLine("int x = (int)20.9 === {0}", x);
            float num1 = (float)20.9;
            decimal num2 = (decimal)20.9;
            Console.WriteLine("float num1 = (float)20.9 === {0} \ndecimal num2 = (decimal)20.9 === {1}", num1, num2);
        }

        public static void Run2() {
            int[] userAge = { 21,22,23,24,25 };

            int[] userAge2;
            userAge2 = new[] { 26,27,28,29,30 };
            
            //This is { 0,0,0,0,0 }
            int[] userAge3 = new int[5];

            userAge[0] = 31;
            Console.WriteLine(userAge[0]);
            Console.WriteLine(userAge.Length);

            int[] source = { 12,1,5,-2,16,14 };
            int[] dest = { 1,2,3,4 };
            Console.WriteLine(dest[0]);

            Array.Copy(source,dest,3);
            //dest becomes { 12,1,5,4 } because the first 3 values in source are copied over;
            Console.WriteLine(dest[0]);

            int[] numbers = { 12,1,5,-2,16,14 };

            foreach(var number in numbers) {
                Console.Write(number + " ");
            }
            Array.Sort(numbers);
            Console.WriteLine("");
            foreach (var number in numbers) {
                Console.Write(number + " ");
            }
            Console.WriteLine("");
            int findSixteen = Array.IndexOf(numbers,16);
            Console.WriteLine("Index of 16: {0}",findSixteen);
            int findNone = Array.IndexOf(numbers,100);
            Console.WriteLine("Index of 100: {0}",findNone);
        }

        public static void Run3() {
            string message = "Hello World";
            Console.WriteLine(message.Length);
            //Starting from index 6, extract 5 characters;
            string newMessage = message.Substring(6,5);
            Console.WriteLine("Message: {0}, New Message: {1}",message,newMessage);

            string firstString = "This is Jamie";
            string secondString = "Hello";

            Console.WriteLine(firstString.Equals("This is Jamie"));
            Console.WriteLine(secondString.Equals("This is Jamie"));

            string[] separator = { ",",";" };
            string names = "Peter, John; Andy,, David";
            string[] substrings = names.Split(separator,StringSplitOptions.None);
            string[] substrings2 = names.Split(separator,StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in substrings) {
                Console.Write("{0},",name);
            }
            Console.WriteLine("");
            foreach (var name in substrings2) {
                Console.Write("{0},",name);
            }
            Console.WriteLine("");

        }

        public static void Run4() {
            List<int> userAgeList = new List<int> { 11,21,31,41 };
            Console.WriteLine(userAgeList[2]);
            userAgeList.Add(51);
            userAgeList.Add(61);
            Console.WriteLine(userAgeList[4]);
            Console.WriteLine(userAgeList[5]);

            int userAgeListCount = userAgeList.Count;
            Console.WriteLine(userAgeListCount);

            userAgeList.Insert(2,51);
            foreach(var age in userAgeList) {
                Console.Write("{0}, ",age);
            }
            Console.WriteLine("");
            userAgeList.Remove(51);
            foreach (var age in userAgeList) {
                Console.Write("{0}, ", age);
            }
            Console.WriteLine("");
            userAgeList.RemoveAt(3);
            foreach (var age in userAgeList) {
                Console.Write("{0}, ",age);
            }
            Console.WriteLine("");
            bool trueOrFalse = userAgeList.Contains(51);
            Console.WriteLine(trueOrFalse);
            userAgeList.Clear();

        }
        public static void Run5() {
            //This will round it to 123.46
            Console.WriteLine("The number is {0:F2}",123.45678);
            //C is used for currencies
            Console.WriteLine("Deposit = {0:C} Account balance = {1:C}",2125,12345.678);

            Console.WriteLine("Type something and I will show it back to you");
            string userInput = Console.ReadLine();
            Console.WriteLine("You typed: {0}",userInput);

            int makeInt = Convert.ToInt32("32");
            decimal makeDec = Convert.ToDecimal(32);
            Single makeSingle = Convert.ToSingle(32);
            Double makeDouble = Convert.ToDouble(32);

            Console.WriteLine(makeInt);
            Console.WriteLine(makeDec);
            Console.WriteLine(makeSingle);
            Console.WriteLine(makeDouble);
        }
        public static void YourAge() {
            string userName = "";
            int userAge = 0;
            int birthYear = 0;
            Console.WriteLine("Please enter your name:");
            userName = Console.ReadLine();
            Console.WriteLine("Please enter your age:");
            userAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the year you were born:");
            birthYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hello World! My name is {0} and I am {1} years old. I was born in {2}",userName,userAge,birthYear);

            if (userAge < 0 || userAge > 100) {
                Console.WriteLine("Invalid Age");
                Console.WriteLine("Age must be between 0 and 100");
            }
            else if (userAge < 13)
                Console.WriteLine("Sorry you are underage");
            else if (userAge < 18)
                Console.WriteLine("You need parental consent");
            else {
                Console.WriteLine("Congratulations!");
                Console.WriteLine("You may sign up for the event!");
            }


        }
        public static void ElseIfSwitch() {
            //Inline If
            // condition ? value if condition is true: value if condition is false
            // is num1 greater than num2? if so myNum = 1, else myNum equals 2;
            int num1 = 10;
            int num2 = 2;
            int myNum = num1 > num2 ? 1 : 2;
            Console.WriteLine(myNum);

            Console.WriteLine("Enter your grade: ");
            string userGrade = Console.ReadLine();

            switch (userGrade) {
                case "A+":
                case "A":
                    Console.WriteLine("Distinction");
                    break;
                case "B":
                    Console.WriteLine("B Grade");
                    break;
                case "C":
                    Console.WriteLine("C Grade");
                    break;
                default:
                    Console.WriteLine("Fail");
                    break;
            }

            for (int i=0; i<5; i++) {
                Console.WriteLine(i);
            }
            char[] message = { 'H','E','L','L','O' };
            foreach(char i in message) {
                Console.Write(i);
            }
            Console.WriteLine("");

            int counter = 5;
            while (counter > 0) {
                Console.WriteLine(counter);
                counter--;
            }

            int counter2 = 10;
            do {
                Console.WriteLine("Counter = {0}", counter2);
                counter2--;
            } while (counter2 > 0);

            int j = 0;
            for (j=0; j<5;j++) {
                Console.WriteLine("j = {0}",j);
                if (j == 2) {
                    Console.WriteLine("j == 2, breaking");
                    break;
                }
            }
            for (j = 0; j < 5; j++) {
                Console.WriteLine("j = {0}",j);
                if (j != 2) {
                    //If j != 2, then end stop this iteration and begin the next iteration. 
                    continue;
                }
                Console.WriteLine("I will be printed if j=2");
            }
            int numerator, denominator;

            try {
                Console.Write("Please enter the numerator: ");
                numerator = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please enter the denominator: ");
                denominator = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("The result is {0}", numerator/denominator);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            } finally {
                Console.WriteLine("---End of Error Handling Example---");
            }

            int choice = 0;
            int[] numbers = { 10,11,12,13,14,15 };
            Console.Write("Please enter the index of the array:");
            try {
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("numbers[{0}] = {1}",choice,numbers[choice]);
            } catch (IndexOutOfRangeException) {
                Console.WriteLine("Error: Index should be from 0 to 5");
            } catch (FormatException) {
                Console.WriteLine("Error: You did not enter an integer");
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }

    class Program {
        static void Main(string[] args) {
            //Examples.Run();
            //Examples.Run2();
            //Examples.Run3();
            //Examples.Run4();
            //Examples.Run5();
            //Examples.YourAge();
            Examples.ElseIfSwitch();

            Console.Read();
        }
    }
}
