
namespace PersonDataApp
{
    internal class Athlete : Person
    {
        public string Sport { get; set; }
        public string BestPerformance { get; set; }

        public Athlete(string firstName, string lastname, int age, float height, float weight, string sport, string bestPerformance, string phoneNumber, string email) : base(firstName, lastname, age, height, weight, phoneNumber, email)
        {
            Sport = sport;
            BestPerformance = bestPerformance;
        }

        public Athlete(string firstName, string lastname, int age, float height, float weight, string sport, string bestPerformance) : base(firstName, lastname, age, height, weight)
        {
            Sport = sport;
            BestPerformance = bestPerformance;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Sport: {Sport}, Best Performance: {BestPerformance}";
        }
    }
}
