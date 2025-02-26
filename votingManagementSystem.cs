using System;
using System.Collections.Generic;

namespace EVMS
{
    // Define the Voter class
    public class Voter
    {
        // Properties for voter details
        public string VoterCardID { get; set; }
        public string NationalID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string PollingStation { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }

        // Constructor to initialize voter details
        public Voter(string voterCardID, string nationalID, string firstName, string middleName, string surname, string pollingStation, string dateOfBirth, string gender)
        {
            VoterCardID = voterCardID;
            NationalID = nationalID;
            FirstName = firstName;
            MiddleName = middleName;
            Surname = surname;
            PollingStation = pollingStation;
            DateOfBirth = dateOfBirth;
            Gender = gender;
        }

        // Method to display voter details
        public void DisplayDetails()
        {
            Console.WriteLine("\nVoter Details:");
            Console.WriteLine($"Voter Card ID: {VoterCardID}");
            Console.WriteLine($"National ID: {NationalID}");
            Console.WriteLine($"Name: {FirstName} {MiddleName} {Surname}");
            Console.WriteLine($"Polling Station: {PollingStation}");
            Console.WriteLine($"Date of Birth: {DateOfBirth}");
            Console.WriteLine($"Gender: {Gender}");
        }
    }

    // Driver program
    class Program
    {
        static void Main(string[] args)
        {
            List<Voter> voters = new List<Voter>(); // List to store voters
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nElectronic Voting Management System (EVMS)");
                Console.WriteLine("1. Add New Voter");
                Console.WriteLine("2. Display All Voters");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewVoter(voters);
                        break;
                    case "2":
                        DisplayAllVoters(voters);
                        break;
                    case "3":
                        running = false;
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        // Method to add a new voter
        static void AddNewVoter(List<Voter> voters)
        {
            Console.WriteLine("\nEnter Voter Details:");

            Console.Write("Voter Card ID: ");
            string voterCardID = Console.ReadLine();

            Console.Write("National ID Number: ");
            string nationalID = Console.ReadLine();

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Middle Name: ");
            string middleName = Console.ReadLine();

            Console.Write("Surname: ");
            string surname = Console.ReadLine();

            Console.Write("Polling Station: ");
            string pollingStation = Console.ReadLine();

            Console.Write("Date of Birth (dd-mm-yyyy): ");
            string dateOfBirth = Console.ReadLine();

            Console.Write("Gender: ");
            string gender = Console.ReadLine();

            //  a new Voter object and add it to the list
            Voter newVoter = new Voter(voterCardID, nationalID, firstName, middleName, surname, pollingStation, dateOfBirth, gender);
            voters.Add(newVoter);

            Console.WriteLine("Voter added successfully!");
        }

        // display all voters
        static void DisplayAllVoters(List<Voter> voters)
        {
            if (voters.Count == 0)
            {
                Console.WriteLine("\nNo voters found.");
            }
            else
            {
                Console.WriteLine("\nList of Voters:");
                foreach (var voter in voters)
                {
                    voter.DisplayDetails();
                }
            }
        }
    }
}