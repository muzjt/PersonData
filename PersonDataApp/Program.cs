using System;
namespace PersonDataApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var manager = new PersonManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- User Management Menu ---");
                Console.WriteLine("1. Add a person");
                Console.WriteLine("2. Display users");
                Console.WriteLine("3. Remove a person");
                Console.WriteLine("4. Calculate BMI fo a user");
                Console.WriteLine("5. Change user status");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                { 
                    case "1":
                    Console.WriteLine("Enter first name: ");
                    string firstName = Console.ReadLine();

                    Console.WriteLine("Enter last name: ");
                    string lastName = Console.ReadLine();

                    Console.WriteLine("Enter age: ");
                    if (!int.TryParse(Console.ReadLine(), out int age))
                    {
                        Console.WriteLine("Invalid age. Please try again.");
                        break;
                    }

                    Console.WriteLine("Enter height (in meters): ");
                    if (!float.TryParse(Console.ReadLine(), out float height))
                    {
                        Console.WriteLine("Invalid height. Please try again.");
                        break;
                    }

                    Console.WriteLine("Enter weight (in kilograms): ");
                    if (!float.TryParse(Console.ReadLine(), out float weight))
                    {
                        Console.WriteLine("Invalid weight. Please try again.");
                        break;
                    }

                    manager.AddPerson(firstName, lastName, age, height, weight);
                    break;

                    case "2":
                        manager.DisplayUsers();
                        break;

                    case "3":
                        Console.WriteLine("Enter first name of user to remove: ");
                        string removeFirstName = Console.ReadLine();

                        Console.WriteLine("Enter last name of user to remove: ");
                        string removeLastName = Console.ReadLine();

                        manager.RemovePerson(removeFirstName, removeLastName);
                        break;

                    case "4":
                        Console.WriteLine("Enter first name of user to calculate BMI: ");
                        string bmiFirstName = Console.ReadLine();

                        Console.WriteLine("Enter last name of user to calculate BMI: ");
                        string bmiLastName = Console.ReadLine();

                        manager.CalculateAndSaveBMI(bmiFirstName, bmiLastName);
                        break;

                    case "5":
                        Console.WriteLine("Enter first name of the user to change status: ");
                        string statusFirstName = Console.ReadLine();

                        Console.WriteLine("Enter last name of the user to change status: ");
                        string statusLastName = Console.ReadLine();

                        Console.WriteLine("Enter new status (Active, Inactive, Banned): ");
                        string newStatus = Console.ReadLine();

                        manager.ChangeUserStatus(statusFirstName, statusLastName, newStatus);
                        break;

                    case "6":
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}