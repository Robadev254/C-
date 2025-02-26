using System;

namespace ElectronicRewardSystem
{
    // Define the Subscriber class
    public class Subscriber
    {
        // Properties for subscriber details
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public double AirtimeAmount { get; set; }
        public int BonusPoints { get; private set; }

        // Constructor to initialize subscriber details
        public Subscriber(string name, string phoneNumber, double airtimeAmount)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            AirtimeAmount = airtimeAmount;
            BonusPoints = ComputeBonusPoints(); // Calculate bonus points
        }

        // Method to compute bonus points based on airtime
        private int ComputeBonusPoints()
        {
            if (AirtimeAmount >= 2000.00)
            {
                return 500;
            }
            else if (AirtimeAmount >= 1000.00 && AirtimeAmount <= 1999.00)
            {
                return 300;
            }
            else if (AirtimeAmount >= 500.00 && AirtimeAmount <= 999.00)
            {
                return 100;
            }
            else if (AirtimeAmount >= 100.00 && AirtimeAmount <= 499.00)
            {
                return 50;
            }
            else
            {
                return 0;
            }
        }

        // Method to display subscriber details and bonus points
        public void DisplayDetails()
        {
            Console.WriteLine($"{Name.ToUpper()} {{[PHONE NO: {PhoneNumber}]: AWARDED {BonusPoints} BONGA POINTS. STAY WITH SAFARICOM. THE BETTER OPTION!}}");
        }
    }

    // Driver program
    class Program
    {
        static void Main(string[] args)
        {
            // Capture subscriber details
            Console.WriteLine("Enter Subscriber Details:");
            Console.Write("Name: ");
            string name = Console.ReadLine() ?? string.Empty;

            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine() ?? string.Empty;

            Console.Write("Airtime Amount (KSh): ");
            double airtimeAmount = Convert.ToDouble(Console.ReadLine());

            // Create a new Subscriber object
            Subscriber subscriber = new Subscriber(name, phoneNumber, airtimeAmount);

            // Display the result
            subscriber.DisplayDetails();
        }
    }
}