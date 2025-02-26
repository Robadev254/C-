using System;

namespace EmployeeDetails
{
    // Define the Employee class
    public class Employee
    {
        // Properties for employee details
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public char Gender { get; set; }
        public string DateOfBirth { get; set; }
        public double BasicSalary { get; set; }

        // Constructor to initialize employee details
        public Employee(string idNumber, string firstName, string secondName, string surname, char gender, string dateOfBirth, double basicSalary)
        {
            IdNumber = idNumber;
            FirstName = firstName;
            SecondName = secondName;
            Surname = surname;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            BasicSalary = basicSalary;
        }

        // Method to display employee details
        public void ShowEmployee()
        {
            Console.WriteLine("\nEMPLOYEE DETAILS");
            Console.WriteLine($"ID NUMBER: {IdNumber}");
            Console.WriteLine($"FIRST NAME: {FirstName}");
            Console.WriteLine($"SECOND NAME: {SecondName}");
            Console.WriteLine($"SURNAME: {Surname}");
            Console.WriteLine($"GENDER: {Gender}");
            Console.WriteLine($"DATE OF BIRTH: {DateOfBirth}");
            Console.WriteLine($"BASIC SALARY ksh.: {BasicSalary}");
        }

        // Friend function to compute pension contribution
        public static double ComputePension(Employee emp)
        {
            return emp.BasicSalary * 0.05; // 5% of basic salary
        }
    }

    // Driver program
    class Program
    {
        static void Main(string[] args)
        {
            // Capture employee details
            Console.WriteLine("ENTER EMPLOYEE DETAILS");

            Console.Write("ENTER ID NUMBER: ");
            string idNumber = Console.ReadLine() ?? string.Empty;

            Console.Write("ENTER FIRST NAME: ");
            string firstName = Console.ReadLine() ?? string.Empty;

            Console.Write("ENTER SECOND NAME: ");
            string secondName = Console.ReadLine() ?? string.Empty;

            Console.Write("ENTER SURNAME: ");
            string surname = Console.ReadLine() ?? string.Empty;

            Console.Write("ENTER GENDER <M or F>: ");
            char gender = Console.ReadLine()?.ToUpper()[0] ?? 'M'; // Default to 'M' if input is null

            Console.Write("ENTER DATE OF BIRTH <DD-MM-YYYY>: ");
            string dateOfBirth = Console.ReadLine() ?? string.Empty;

            Console.Write("ENTER BASIC SALARY IN KSH: ");
            double basicSalary = Convert.ToDouble(Console.ReadLine());

            // Create an Employee object
            Employee empObj = new Employee(idNumber, firstName, secondName, surname, gender, dateOfBirth, basicSalary);

            // Display employee details
            empObj.ShowEmployee();

            // Compute and display pension contribution
            double pension = Employee.ComputePension(empObj);
            Console.WriteLine($"PENSION CONTRIBUTION (5% of Basic Salary): ksh. {pension}");
        }
    }
}
