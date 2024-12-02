
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
                Console.WriteLine("1. Add a customer");
                Console.WriteLine("2. Add an athlete");
                Console.WriteLine("3. Display all users");
                Console.WriteLine("4. Display customers");
                Console.WriteLine("5. Display athletes");
                Console.WriteLine("6. Remove a user");
                Console.WriteLine("7. Calculate BMI for a user");
                Console.WriteLine("8. Change user status");
                Console.WriteLine("9. View customer contact details");
                Console.WriteLine("10. View athlete sport activity details");
                Console.WriteLine("11. Exit");
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
                    if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
                    {
                        Console.WriteLine("Invalid age, it must be a positive integer.");
                        break;
                    }

                    Console.WriteLine("Enter height (in meters): ");
                    if (!float.TryParse(Console.ReadLine(), out float height) || height <= 0)
                    {
                        Console.WriteLine("Invalid height, it must be a positive number.");
                        break;
                    }

                    Console.WriteLine("Enter weight (in kilograms): ");
                    if (!float.TryParse(Console.ReadLine(), out float weight) || weight <= 0)
                    {
                        Console.WriteLine("Invalid weight, it must be a positive number.");
                        break;
                    }

                    Console.WriteLine("Do you want to add contact information? (yes/no): ");
                    string addContactInfo = Console.ReadLine()?.ToLower();
                    
                    if(addContactInfo == "yes") 
                        {
                            Console.WriteLine("Enter phone number: ");
                            string phoneNumber = Console.ReadLine();

                            Console.WriteLine("Enter email address: ");
                            string email = Console.ReadLine();

                            manager.AddCustomer(firstName, lastName, age, height, weight, phoneNumber, email);
                        }
                    else
                        {
                            manager.AddCustomer(firstName, lastName, age, height, weight);
                        }
                    
                    break;

                    case "2":
                        Console.WriteLine("Enter first name: ");
                        string athleteFirstName = Console.ReadLine();

                        Console.WriteLine("Enter last name: ");
                        string athleteLastName = Console.ReadLine();

                        Console.WriteLine("Enter age: ");
                        if (!int.TryParse(Console.ReadLine(), out int athleteAge) || athleteAge <= 0)
                        {
                            Console.WriteLine("Invalid age, it must be a positive integer.");
                            break;
                        }

                        Console.WriteLine("Enter height (in meters): ");
                        if (!float.TryParse(Console.ReadLine(), out float athleteHeight) || athleteHeight <= 0)
                        {
                            Console.WriteLine("Invalid height, it must be a positive number.");
                            break;
                        }

                        Console.WriteLine("Enter weight (in kilograms): ");
                        if (!float.TryParse(Console.ReadLine(), out float athleteWeight) || athleteWeight <= 0)
                        {
                            Console.WriteLine("Invalid weight, it must be a positive number.");
                            break;
                        }

                        Console.WriteLine("Do you want to add sport activity information? (yes/no): ");
                        string addAthleteContact = Console.ReadLine()?.ToLower();

                        if (addAthleteContact == "yes") 
                        {
                            Console.WriteLine("Enter sport type: ");
                            string athleteSport = Console.ReadLine();

                            Console.WriteLine("Enter personal sports record: ");
                            string athletePersonalRecord = Console.ReadLine();

                            manager.AddAthlete(athleteFirstName, athleteLastName, athleteAge, athleteHeight, athleteWeight, athleteSport, athletePersonalRecord);
                        }
                        else 
                        {
                            manager.AddAthlete(athleteFirstName, athleteLastName, athleteAge, athleteHeight, athleteWeight);
                        }

                        break;

                    case "3":
                        manager.DisplayUsers();
                        break;

                    case "4":
                        manager.DisplayCustomers();
                        break;

                    case "5":
                        manager.DisplayAthletes();
                        break;

                    case "6":
                        Console.WriteLine("Enter first name of user to remove: ");
                        string removeFirstName = Console.ReadLine();

                        Console.WriteLine("Enter last name of user to remove: ");
                        string removeLastName = Console.ReadLine();

                        manager.RemovePerson(removeFirstName, removeLastName);
                        break;

                    case "7":
                        Console.WriteLine("Enter first name of user to calculate BMI: ");
                        string bmiFirstName = Console.ReadLine();

                        Console.WriteLine("Enter last name of user to calculate BMI: ");
                        string bmiLastName = Console.ReadLine();

                        manager.CalculateAndSaveBMI(bmiFirstName, bmiLastName);
                        break;

                    case "8":
                        Console.WriteLine("Enter first name of the user to change status: ");
                        string statusFirstName = Console.ReadLine();

                        Console.WriteLine("Enter last name of the user to change status: ");
                        string statusLastName = Console.ReadLine();

                        Console.WriteLine("Enter new status (Active, Inactive, Banned): ");
                        string newStatus = Console.ReadLine();

                        manager.ChangeUserStatus(statusFirstName, statusLastName, newStatus);
                        break;

                    case "9":
                        manager.DisplayCustomerContactDetails();
                        break;

                    case "10":
                        manager.DisplayAthleteSportDetails();
                        break;

                    case "11":
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