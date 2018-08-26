using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CSProject {
    class Program {
        static void Main(string[] args) {
            List<Staff> myStaff;
            FileReader fr = new FileReader();
            int year = 0;
            int month = 0;
            while (year == 0) {
                Console.Write("\nPlease enter the year:");
                try {
                    string input = Console.ReadLine();
                    year = Int32.Parse(input);
                } catch (FormatException) {
                    Console.WriteLine("Please enter valid integers.");
                }
            }
            while (month == 0) {
                Console.Write("\nPlease enter the month:");
                try {
                    string input = Console.ReadLine();
                    month = Int32.Parse(input);
                }
                catch (FormatException) {
                    Console.WriteLine("Please enter valid integers.");
                }
            }

            myStaff = fr.ReadFile();

            for (int i = 0; i < myStaff.Count; i++) {
                try {
                    Console.Write("\nPlease enter the hours worked for {0}", myStaff[i].NameOfStaff);
                    string input = Console.ReadLine();
                    myStaff[i].HoursWorked = Int32.Parse(input);
                    myStaff[i].CalculatePay();
                    myStaff[i].ToString();
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }

            PaySlip ps = new PaySlip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);

            Console.Read();
        }
    }

    class Staff {
        private float hourlyRate;
        private int hWorked = 40;
        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }

        public Staff () {
            //Parameterless Constructor;
        }
        public Staff (string name, float rate) {
            NameOfStaff = name;
            hourlyRate = rate;
        }


        public int HoursWorked {
            get {
                return hWorked;
            }
            set {
                if (HoursWorked > 0)
                    hWorked = value;
                else {
                    hWorked = 0;
                }
            }
        }

        public virtual void CalculatePay() {
            Console.WriteLine("Calculating Pay...");
            BasicPay = hWorked  * hourlyRate;
            Console.WriteLine(hourlyRate);
            TotalPay = BasicPay;
        }

        public override string ToString() {
            Console.WriteLine("Total Pay: {0}",TotalPay);
            return base.ToString();
        }

    }

    class Manager : Staff {
        public Manager(string name): base(name, managerHourlyRate) {
            
        }

        private const float managerHourlyRate = 50;
        public int Allowance { get; private set; }

        public override void CalculatePay() {
            base.CalculatePay();
            Allowance = 1000;
            if (HoursWorked > 160)
                TotalPay = BasicPay + 1000;
            else
                TotalPay = BasicPay;
        }

        public override string ToString() {
            return base.ToString();
        }
    }

    class Admin : Staff {
        public Admin(string name): base(name, adminHourlyRate) {

        }

        private const float overtimeRate = 15.5f;
        private const float adminHourlyRate = 30;

        public float Overtime { get; private set; }

        public override void CalculatePay() {
            base.CalculatePay();
            if (HoursWorked > 160) {
                Overtime = overtimeRate * (HoursWorked - 160);
                TotalPay += Overtime;
            }
        }

        public override string ToString() {
            return base.ToString();
        }

    }

    class FileReader {
        public List<Staff> ReadFile() {
            string path = @"c:\Users\Chris\Documents\Projects\C#\staff.txt";
            Console.WriteLine(path);
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string[] separator = {","};
            if (File.Exists(path)) {
                using (StreamReader sr = new StreamReader(path)) {
                    while (sr.EndOfStream != true) {
                        Console.WriteLine(sr.ReadLine());
                    }
                    sr.Close();
                }
            } else {
                Console.WriteLine("Unable to locate file, please check the path");
            }
            return null;
        }
    }
    
    class PaySlip {
        private int month;
        private int year;

        public PaySlip(int payMonth, int payYear) {
            month = payMonth;
            year = payYear;
        }

        enum MonthsOfYear {
            JAN, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC
        }

        public void GeneratePaySlip(List<Staff> myStaff) {
            string path;
            foreach(Staff f in myStaff) {
                path = @"c:\Users\Chris\Documents\Projects\C#\" + f.NameOfStaff + ".txt";
                StreamWriter sw = new StreamWriter(path, true);
                sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear)month, year);
                sw.WriteLine("==========================");
                sw.WriteLine("Name of Staff: {0}", f.NameOfStaff);
                sw.WriteLine("Hours Worked: {0}", f.HoursWorked);
                sw.WriteLine("");
                sw.WriteLine("Basic Pay: {0:C}", f.BasicPay);
                if (f.GetType() == typeof(Manager)) 
                    sw.WriteLine("Allowance: {0:C}", ((Manager)f).Allowance);
                else 
                    sw.WriteLine("Allowance: None");
                sw.WriteLine("");
                sw.WriteLine("==========================");
                sw.WriteLine("Total Pay: {0}", f.TotalPay);
                sw.WriteLine("==========================");
                sw.Close();
            }
        }

        public void GenerateSummary(List<Staff> myStaff) {
            var lessThanTenHours = 
                from employee in myStaff
                where employee.HoursWorked < 10
                orderby employee.HoursWorked ascending
                select new { employee.NameOfStaff, employee.HoursWorked };

            string path = @"c:\Users\Chris\Documents\Projects\C#\summary.txt";
            StreamWriter sw = new StreamWriter(path,true);
            sw.WriteLine("Staff with less than 10 working hours");
            sw.WriteLine("");
            foreach (var employee in lessThanTenHours) {
                sw.WriteLine("Name = {0}, Hours Worked = {1}", employee.NameOfStaff, employee.HoursWorked);
            }
            sw.Close();

        }

        public override string ToString() {
            return base.ToString();
        }
    }
}
