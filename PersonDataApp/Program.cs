
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
                Console.WriteLine("2. Add an athlete");
                Console.WriteLine("3. Display users");
                Console.WriteLine("4. Display athletes");
                Console.WriteLine("5. Remove a person");
                Console.WriteLine("6. Calculate BMI fo a user");
                Console.WriteLine("7. Change user status");
                Console.WriteLine("8. Display contact information");
                Console.WriteLine("9. Exit");
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
                    if (!float.TryParse(Console.ReadLine(), out float height))
                    {
                        Console.WriteLine("Invalid height, it must be a positive number.");
                        break;
                    }

                    Console.WriteLine("Enter weight (in kilograms): ");
                    if (!float.TryParse(Console.ReadLine(), out float weight))
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

                            manager.AddPerson(firstName, lastName, age, height, weight, phoneNumber, email);
                        }
                    else
                        {
                            manager.AddPerson(firstName, lastName, age, height, weight);
                        }
                    
                    break;

                    case "2":
                        Console.WriteLine("Enter first name: ");
                        string athleteFirstName = Console.ReadLine();

                        Console.WriteLine("Enter last name: ");
                        string athleteLastName = Console.ReadLine();

                        Console.WriteLine("Enter age: ");
                        if (!int.TryParse(Console.ReadLine(), out int athleteAge))
                        {
                            Console.WriteLine("Invalid age. Please try again.");
                            break;
                        }

                        Console.WriteLine("Enter height (in meters): ");
                        if (!float.TryParse(Console.ReadLine(), out float athleteHeight))
                        {
                            Console.WriteLine("Invalid height. Please try again.");
                            break;
                        }

                        Console.WriteLine("Enter weight (in kilograms): ");
                        if (!float.TryParse(Console.ReadLine(), out float athleteWeight))
                        {
                            Console.WriteLine("Invalid weight. Please try again.");
                            break;
                        }

                        Console.WriteLine("Enter sport: ");
                        string sport = Console.ReadLine();

                        Console.WriteLine("Enter best performance: ");
                        string bestPerformance = Console.ReadLine();

                        Console.WriteLine("Do you want to add contact information? (yes/no): ");
                        string addAthleteContact = Console.ReadLine()?.ToLower();

                        if (addAthleteContact == "yes") 
                        {
                            Console.WriteLine("Enter phone number: ");
                            string athletePhoneNumber = Console.ReadLine();

                            Console.WriteLine("Enter email adress: ");
                            string athleteEmail = Console.ReadLine();

                            manager.AddAthlete(athleteFirstName, athleteLastName, athleteAge, athleteHeight, athleteWeight, sport, bestPerformance, athletePhoneNumber, athleteEmail);
                        }
                        else 
                        {
                            manager.AddAthlete(athleteFirstName, athleteLastName, athleteAge, athleteHeight, athleteWeight, sport, bestPerformance);
                        }

                        break;

                    case "3":
                        manager.DisplayUsers();
                        break;

                    case "4":
                        manager.DisplayAthletes();
                        break;

                    case "5":
                        Console.WriteLine("Enter first name of user to remove: ");
                        string removeFirstName = Console.ReadLine();

                        Console.WriteLine("Enter last name of user to remove: ");
                        string removeLastName = Console.ReadLine();

                        manager.RemovePerson(removeFirstName, removeLastName);
                        break;

                    case "6":
                        Console.WriteLine("Enter first name of user to calculate BMI: ");
                        string bmiFirstName = Console.ReadLine();

                        Console.WriteLine("Enter last name of user to calculate BMI: ");
                        string bmiLastName = Console.ReadLine();

                        manager.CalculateAndSaveBMI(bmiFirstName, bmiLastName);
                        break;

                    case "7":
                        Console.WriteLine("Enter first name of the user to change status: ");
                        string statusFirstName = Console.ReadLine();

                        Console.WriteLine("Enter last name of the user to change status: ");
                        string statusLastName = Console.ReadLine();

                        Console.WriteLine("Enter new status (Active, Inactive, Banned): ");
                        string newStatus = Console.ReadLine();

                        manager.ChangeUserStatus(statusFirstName, statusLastName, newStatus);
                        break;

                    case "8":
                        manager.DisplayContactInfo();
                        break;

                    case "9":
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