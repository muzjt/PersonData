
namespace PersonDataApp
{
    public class Athlete : Person
    {
        public string Sport { get; set; }
        public string BestPerformance { get; set; }

        public Athlete(string firstName, string lastName, int age, float height, float weight, string sport, string bestPerformance) 
            : base(firstName, lastName, age, height, weight)
        {
            Sport = sport;
            BestPerformance = bestPerformance;
        }

        public Athlete(string firstName, string lastName, int age, float height, float weight)
            : this(firstName, lastName, age, height, weight, "N/A", "N/A")
        {
        }

        public override string GetPersonSpecificInfo()
        {
            return $"{FirstName} {LastName}, sport: {Sport}, personal record: {BestPerformance}";
        }

        public override string GetPersonInfo()
        {
            return $"{FirstName} {LastName}, age: {Age}, height: {Height}, weight: {Weight}";
        }

    }
}
