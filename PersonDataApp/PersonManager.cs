
namespace PersonDataApp
{
    internal class PersonManager
    {
        private List<Person> users = new List<Person>();
        private readonly string userFilePath = "users.txt";

        public PersonManager() 
        {
            LoadUsersFromFile();
        }

        public void AddPerson(string firstName, string lastName, int age, float height, float weight, string phoneNumber, string email) 
        {
            var person = new Person(firstName, lastName, age, height, weight, phoneNumber, email);
            users.Add(person);
            Console.WriteLine($"Added new user {firstName} {lastName}");
            SaveUsersToFile();
        }

        public void AddPerson(string firstName, string lastName, int age, float height, float weight)
        {
            var person = new Person(firstName, lastName, age, height, weight, "N/A", "N/A");
            users.Add(person);
            Console.WriteLine($"Added new user {firstName} {lastName}");
            SaveUsersToFile();
        }

        public void AddAthlete(string firstName, string lastName, int age, float height, float weight, string sport, string bestPerformance, string phoneNumber, string email) 
        {
            var athlete = new Athlete(firstName, lastName, age, height, weight, sport, bestPerformance, phoneNumber, email);
            users.Add(athlete);
            Console.WriteLine($"Added new athlete {firstName} {lastName}");
            SaveUsersToFile();
        }

        public void AddAthlete(string firstName, string lastName, int age, float height, float weight, string sport, string bestPerformance)
        {
            var athlete = new Athlete(firstName, lastName, age, height, weight, sport, bestPerformance);
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
                Console.WriteLine($"{user.FirstName} {user.LastName}, Age: {user.Age}, Height: {user.Height}m, Weight: {user.Weight}kg, Status: {user.Status}");
            }
        }

        public void DisplayAthletes() 
        {
            var athletes = users.OfType<Athlete>().ToList();
            if (athletes.Count == 0)
            {
                Console.WriteLine("No athletes do display.");
                return;
            }

            Console.WriteLine("\n--- List of Athletes ---");
            foreach (var athlete in athletes)
            {
                Console.WriteLine($"{athlete.FirstName} {athlete.LastName}, Age: {athlete.Age}, Sport: {athlete.Sport}, Best performance: {athlete.BestPerformance}");
            }
        }

        public void DisplayContactInfo()
        {
            foreach(var person in users) 
            {
                Console.WriteLine($"{person.FirstName} {person.LastName} - Phone: {person.PhoneNumber}, Email: {person.Email}");
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
                    writer.WriteLine($"{user.FirstName};{user.LastName};{user.Age};{user.Height};{user.Weight};{user.Status};{user.PhoneNumber};{user.Email}");
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

                        if (parts.Length != 8)
                        {
                            Console.WriteLine($"Invalid data format in line: {line}");
                            continue;
                        }

                        try
                        {
                            string firstName = parts[0];
                            string lastName = parts[1];
                            int age = int.Parse(parts[2]);
                            float height = float.Parse(parts[3]);
                            float weight = float.Parse(parts[4]);
                            UserStatus status = Enum.Parse<UserStatus>(parts[5]);
                            string phoneNumber = parts[6];
                            string email = parts[7];

                            var person = new Person(firstName, lastName, age, height, weight, phoneNumber, email)
                            {
                                Status = status
                            };
                            users.Add(person);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error parsing line: {line}. Exception: {ex.Message}");
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
