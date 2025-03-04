using System;
using MySql.Data.MySqlClient;

namespace KCA_Result_Management_System
{
    class Program
    {
        // MySQL connection string
        private static string connectionString = "Server=localhost;Database=kca_university;User ID=root;Password=ventrix;";

        static void Main(string[] args)
        {
            Console.WriteLine("This is results database:");
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add student details");
                Console.WriteLine("2. Show results");
                Console.WriteLine("3. Exit database");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudentDetails();
                        break;
                    case "2":
                        ShowResults();
                        break;
                    case "3":
                        Console.WriteLine("Exiting the database. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Method to add student details to the database
        static void AddStudentDetails()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            Console.Write("Enter registration number: ");
            string regNo = Console.ReadLine();
            Console.Write("Enter unit code: ");
            string unitCode = Console.ReadLine();
            Console.Write("Enter unit name: ");
            string unitName = Console.ReadLine();
            Console.Write("Enter grade: ");
            string grade = Console.ReadLine();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO students (name, reg_no, unit_code, unit_name, grade) VALUES (@name, @regNo, @unitCode, @unitName, @grade)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@regNo", regNo);
                    command.Parameters.AddWithValue("@unitCode", unitCode);
                    command.Parameters.AddWithValue("@unitName", unitName);
                    command.Parameters.AddWithValue("@grade", grade);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Student details added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Failed to add student details.");
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySQL Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        // Method to retrieve and display results from the database
        static void ShowResults()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM students";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        Console.WriteLine("\nStudent Results:");
                        Console.WriteLine("ID\tName\t\tReg No\t\tUnit Code\tUnit Name\tGrade");
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["id"]}\t{reader["name"]}\t{reader["reg_no"]}\t{reader["unit_code"]}\t\t{reader["unit_name"]}\t\t{reader["grade"]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No results found. Please add results.");
                    }
                    reader.Close();

                    // Add option to delete a student record
                    Console.Write("\nDo you want to delete a student record? (yes/no): ");
                    string deleteChoice = Console.ReadLine().ToLower();

                    if (deleteChoice == "yes")
                    {
                        Console.Write("Enter the registration number of the student to delete: ");
                        string regNoToDelete = Console.ReadLine();

                        DeleteStudentByRegNo(regNoToDelete);
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySQL Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        // Method to delete a student record by registration number
        static void DeleteStudentByRegNo(string regNo)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM students WHERE reg_no = @regNo";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@regNo", regNo);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Student with registration number {regNo} deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine($"No student found with registration number {regNo}.");
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("MySQL Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}