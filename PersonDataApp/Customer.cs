namespace PersonDataApp
{
    public class Customer : Person
    {
        public Customer(string firstName, string lastName, int age, float height, float weight, string phoneNumber, string email)
            : base(firstName, lastName, age, height, weight, phoneNumber, email)
        {

        }

        public Customer(string firstName, string lastName, int age, float height, float weight)
            : this(firstName, lastName, age, height, weight, "N/A", "N/A")
        {

        }

        public override string GetPersonSpecificInfo()
        {
            return $"{FirstName} {LastName}, phone number: {PhoneNumber}, email address: {Email}";
        }

        public override string GetPersonInfo()
        {
            return $"{FirstName} {LastName}, age: {Age}, height: {Height}, weight: {Weight}";
        }
    }
}