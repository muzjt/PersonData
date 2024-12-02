using NUnit.Framework;
using System.IO;

namespace PersonDataApp.Tests
{
    public class PersonManagerTests
    {
        private PersonManager manager;
        private string testFilePath = "test_users.txt";

        [SetUp]
        public void Setup()
        {
            manager = new PersonManager(testFilePath);
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        [Test]
        public void AddCustomer_SavesToFile()
        {
            // Arrange
            string firstName = "Johny";
            string lastName = "Wick";
            int age = 60;
            float height = 1.90f;
            float weight = 85.0f;

            // Act
            manager.AddCustomer(firstName, lastName, age, height, weight);

            // Assert
            string[] lines = File.ReadAllLines(testFilePath);
            Assert.AreEqual(1, lines.Length);
            Assert.IsTrue(lines[0].Contains("Customer;Johny;Wick;60;1,9;85;Active;N/A;N/A"));
        }

        [Test]
        public void AddAthlete_SavesToFile()
        {
            // Arrange
            string firstName = "Krzysztof";
            string lastName = "Mycielski";
            int age = 48;
            float height = 1.85f;
            float weight = 90.0f;
            string sport = "Running";
            string personalRecord = "5k in 20 minutes";

            // Act
            manager.AddAthlete(firstName, lastName, age, height, weight, sport, personalRecord);

            // Assert
            string[] lines = File.ReadAllLines(testFilePath);
            Assert.AreEqual(1, lines.Length);
            Assert.IsTrue(lines[0].Contains("Athlete;Krzysztof;Mycielski;48;1,85;90;Active;Running;5k in 20 minutes"));
        }

        [Test]
        public void RemovePerson_RemovesFromFile()
        {
            // Arrange
            manager.AddCustomer("Bart³omiej", "Witczak", 30, 1.80f, 75.0f);
            manager.AddAthlete("Alina", "Kowalska", 25, 1.65f, 60.0f, "Running", "5k in 20 minutes");

            // Act
            manager.RemovePerson("Bart³omiej", "Witczak");

            // Assert
            string[] lines = File.ReadAllLines(testFilePath);
            Assert.AreEqual(1, lines.Length);
            Assert.IsTrue(lines[0].Contains("Alina;Kowalska"));
        }

        [Test]
        public void CalculateAndSaveBMI_CalculatesCorrectlyAndSavesToFile()
        {
            // Arrange
            manager.AddCustomer("Harry", "Pota", 30, 1.80f, 75.0f);
            string bmiFilePath = "bmi_results.txt";

            if (File.Exists(bmiFilePath))
            {
                File.Delete(bmiFilePath);
            }

            // Act
            manager.CalculateAndSaveBMI("Harry", "Pota");

            // Assert
            string[] bmiLines = File.ReadAllLines(bmiFilePath);
            Assert.AreEqual(1, bmiLines.Length);
            Assert.IsTrue(bmiLines[0].Contains("Harry Pota - BMI: 23,15"));
        }

        [Test]
        public void ChangeUserStatus_UpdatesFile()
        {
            // Arrange
            manager.AddCustomer("Ola", "Nowak", 30, 1.70f, 75.0f);

            // Act
            manager.ChangeUserStatus("Ola", "Nowak", "Banned");

            // Assert
            string[] lines = File.ReadAllLines(testFilePath);
            Assert.AreEqual(1, lines.Length);
            Assert.IsTrue(lines[0].Contains(";Banned"));
        }
    }
}
