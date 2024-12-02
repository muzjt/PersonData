
namespace PersonDataApp
{
    public enum UserStatus
    {
        Active,
        Inactive,
        Banned
    }
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public UserStatus Status { get; set; }
        public string PhoneNumber {  get; set; }
        public string Email { get; set; }


        protected Person(string firstName, string lastName, int age, float height, float weight, string phoneNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Height = height;
            Weight = weight;
            Status = UserStatus.Active;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        protected Person(string firstName, string lastName, int age, float height, float weight)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Height = height;
            Weight = weight;
            Status = UserStatus.Active;
            PhoneNumber = "N/A";
            Email = "N/A";
        }

        public abstract string GetPersonSpecificInfo();

        public abstract string GetPersonInfo();

    }
}


