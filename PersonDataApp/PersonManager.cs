
namespace PersonDataApp
{
    public class PersonManager
    {
        private List<Person> users = new List<Person>();
        private readonly string userFilePath = "users.txt";
        public PersonManager(string filePath = "users.txt")
        {
            userFilePath = filePath;
            LoadUsersFromFile();
        }

        public PersonManager() 
        {
            LoadUsersFromFile();
        }

        public void AddCustomer(string firstName, string lastName, int age, float height, float weight, string phoneNumber, string email) 
        {
            var person = new Customer(firstName, lastName, age, height, weight, phoneNumber, email);
            users.Add(person);
            Console.WriteLine($"Added new customer {firstName} {lastName}");
            SaveUsersToFile();
        }

        public void AddCustomer(string firstName, string lastName, int age, float height, float weight)
        {
            var person = new Customer(firstName, lastName, age, height, weight);
            users.Add(person);
            Console.WriteLine($"Added new customer {firstName} {lastName}");
            SaveUsersToFile();
        }

        public void AddAthlete(string firstName, string lastName, int age, float height, float weight, string sport, string bestPerformance) 
        {
            var athlete = new Athlete(firstName, lastName, age, height, weight, sport, bestPerformance);
            users.Add(athlete);
            Console.WriteLine($"Added new athlete {firstName} {lastName}");
            SaveUsersToFile();
        }

        public void AddAthlete(string firstName, string lastName, int age, float height, float weight)
        {
            var athlete = new Athlete(firstName, lastName, age, height, weight);
            users.Add(athlete);
            Console.WriteLine($"Added new athlete {firstName} {lastName}");
            SaveUsersToFile();
        }

        public void DisplayUsers()
        {
            if(users.Count == 0) 
            {
                Console.WriteLine("No users to display.");
                return;
            }
            Console.WriteLine("\n--- List of Users ---");
            foreach(var user in users) 
            {
                Console.WriteLine($"{user.FirstName} {user.LastName}, Status: {user.Status}");
            }
        }

        public void DisplayAthletes()
        {
            var athletes = users.OfType<Athlete>().ToList();
            if (athletes.Count == 0)
            {
                Console.WriteLine("No athletes to display.");
                return;
            }

            Console.WriteLine("\n--- List of Athletes ---");
            foreach (var athlete in athletes)
            {
                Console.WriteLine($"{athlete.GetPersonInfo()}");
            }
        }

        public void DisplayCustomers()
        {
            var customers = users.OfType<Customer>().ToList();
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers to display.");
                return;
            }

            Console.WriteLine("\n--- List of Customers ---");
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.GetPersonInfo()}");
            }
        }

        public void DisplayAthleteSportDetails()
        {
            var athletes = users.OfType<Athlete>().ToList();
            if (athletes.Count == 0)
            {
                Console.WriteLine("No athletes sport details to display.");
                return;
            }

            Console.WriteLine("\n--- List of Athletes ---");
            foreach (var athlete in athletes)
            {
                Console.WriteLine($"{athlete.GetPersonSpecificInfo()}");
            }
        }

        public void DisplayCustomerContactDetails ()
        {
            var customers = users.OfType<Customer>().ToList();
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers contact details to display.");
                return;
            }

            Console.WriteLine("\n--- List of Customers ---");
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.GetPersonSpecificInfo()}");
            }
        }

        public void RemovePerson(string firstName, string lastName) 
        {
            var personToRemove = users.Find(u => u.FirstName == firstName && u.LastName == lastName);
            if(personToRemove != null)
            {
                users.Remove(personToRemove);
                Console.WriteLine($"User {firstName} {lastName} removed.");
                SaveUsersToFile();
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public void CalculateAndSaveBMI(string firstName, string lastName)
        {
            var person = users.Find(u => u.FirstName == firstName && u.LastName == lastName);
            if (person != null)
            {
                float bmi = person.Weight / (person.Height * person.Height);
                Console.WriteLine($"{person.FirstName} {person.LastName} has a BMI of {bmi:F2}");

                string filePath = "bmi_results.txt";
                string result = $"{person.FirstName} {person.LastName} - BMI: {bmi:F2}\n";
                System.IO.File.AppendAllText(filePath, result);

                Console.WriteLine($"BMI result for {person.FirstName} {person.LastName} has been saved to {filePath}");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        private void SaveUsersToFile()
        {
            using (var writer = new StreamWriter(userFilePath))
            {
                foreach (var user in users)
                {
                    if (user is Customer customer)
                    {
                        writer.WriteLine($"Customer;{customer.FirstName};{customer.LastName};{customer.Age};{customer.Height};{customer.Weight};{customer.Status};{customer.PhoneNumber};{customer.Email}");
                    }
                    else if (user is Athlete athlete)
                    {
                        writer.WriteLine($"Athlete;{athlete.FirstName};{athlete.LastName};{athlete.Age};{athlete.Height};{athlete.Weight};{athlete.Status};{athlete.Sport};{athlete.BestPerformance}");
                    }
                }
            }
            Console.WriteLine("User data saved to file.");
        }

        private void LoadUsersFromFile()
        {
            if (!File.Exists(userFilePath))
            {
                Console.WriteLine("No saved user data found.");
                return;
            }

            try
            {
                using (var reader = new StreamReader(userFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(';');
                        if (parts.Length < 6)
                        {
                            Console.WriteLine($"Invalid data format in line: {line}");
                            continue;
                        }

                        string userType = parts[0];
                        string firstName = parts[1];
                        string lastName = parts[2];
                        int age = int.Parse(parts[3]);
                        float height = float.Parse(parts[4]);
                        float weight = float.Parse(parts[5]);
                        UserStatus status = Enum.Parse<UserStatus>(parts[6]);

                        if (userType == "Customer" && parts.Length >= 8)
                        {
                            string phoneNumber = parts[7];
                            string email = parts[8];
                            var customer = new Customer(firstName, lastName, age, height, weight, phoneNumber, email)
                            {
                                Status = status
                            };
                            users.Add(customer);
                        }
                        else if (userType == "Athlete" && parts.Length >= 8)
                        {
                            string sport = parts[7];
                            string personalRecord = parts[8];
                            var athlete = new Athlete(firstName, lastName, age, height, weight, sport, personalRecord)
                            {
                                Status = status
                            };
                            users.Add(athlete);
                        }
                        else
                        {
                            Console.WriteLine($"Unrecognized user type or invalid data: {line}");
                        }
                    }
                }
                Console.WriteLine("User data loaded from file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading user data: {ex.Message}");
            }
        }


        public void ChangeUserStatus(string firstName, string lastName, string newStatus) 
        {
            var person = users.Find(u => u.FirstName == firstName && u.LastName == lastName);
            if(person != null) 
            { 
                if (Enum.TryParse(newStatus, true, out UserStatus status)) 
                {
                    person.Status = status;
                    Console.WriteLine($"Status of {firstName} {lastName} changed to {status}");
                    SaveUsersToFile();
                }
                else
                {
                    Console.WriteLine("Invalid status. Valid statuses are: Active, Inactive, Banned.");
                }
            }
            else 
            { 
                Console.WriteLine("User not found.");
            }
        }
    }
}
