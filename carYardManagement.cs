using System;
using System.Collections.Generic;

// Define the Vehicle class
class Vehicle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public string EngineNumber { get; set; }
    public double SalePrice { get; set; }

    // Constructor to initialize vehicle details
    public Vehicle(string make, string model, string engineNumber, double salePrice)
    {
        Make = make;
        Model = model;
        EngineNumber = engineNumber;
        SalePrice = salePrice;
    }

    // Method to calculate profit
    public double GetProfit()
    {
        return SalePrice * 0.15; // 15% profit margin
    }

    // Method to display vehicle details and profit
    public void DisplayVehicle()
    {
        Console.WriteLine("\nVehicle Details:");
        Console.WriteLine($"Make: {Make}, Model: {Model}, Engine Number: {EngineNumber}, Sale Price: ${SalePrice}");
        Console.WriteLine($"Profit: ${GetProfit()}");
    }
}

// Main program
class Program
{
    static void Main()
    {
        List<Vehicle> vehicles = new List<Vehicle>();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Enter New Car Details");
            Console.WriteLine("2. Display Existing Cars");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input, please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Vehicle Make: ");
                    string make = Console.ReadLine();

                    Console.Write("Enter Vehicle Model: ");
                    string model = Console.ReadLine();

                    Console.Write("Enter Engine Number: ");
                    string engineNumber = Console.ReadLine();

                    Console.Write("Enter Sale Price: ");
                    double salePrice;
                    if (!double.TryParse(Console.ReadLine(), out salePrice))
                    {
                        Console.WriteLine("Invalid price. Please enter a numeric value.");
                        continue;
                    }

                    vehicles.Add(new Vehicle(make, model, engineNumber, salePrice));
                    Console.WriteLine("Car details added successfully!\n");
                    break;

                case 2:
                    if (vehicles.Count == 0)
                    {
                        Console.WriteLine("No vehicles available.");
                    }
                    else
                    {
                        Console.WriteLine("\nExisting Cars:");
                        foreach (var vehicle in vehicles)
                        {
                            vehicle.DisplayVehicle();
                        }
                    }
                    break;

                case 3:
                    Console.WriteLine("Exiting the program...");
                    return;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}
