using PersonDataApp;
using System;
using System.Runtime.InteropServices.Marshalling;

string inputName;
string inputLastName;
string inputAge;

int convertedInputAge;

bool isValidMain = false;

bool AreNamesValid(string inputName, string inputLastName)
{
    foreach (char c in inputName + inputLastName)
    {
        if (!Char.IsLetter(c))
        {
            Console.WriteLine("Names cannot contain special characters or numbers.");
            return false;
        }
    }
    return true;
}
bool AgeIsValid(string inputAge)
{
    if (int.TryParse(inputAge, out convertedInputAge))
    {
        if (convertedInputAge >= 18 && convertedInputAge <= 120)
        {
            return true;
        }
        else
        {
            Console.WriteLine("Person's age cannot be less than 18 years and more than 120 years.");
            return false;
        }

    }
    Console.WriteLine("Age must be an integer.");
    return false;
}

do
{
    Console.WriteLine("Please enter the person's first name:");
    inputName = Console.ReadLine();

    Console.WriteLine("Please enter the person's last name:");
    inputLastName = Console.ReadLine();

    Console.WriteLine("Please enter the person's age:");
    inputAge = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(inputName) || string.IsNullOrWhiteSpace(inputLastName) || string.IsNullOrWhiteSpace(inputAge))
    {
        Console.WriteLine("All fields are required. Please try again.");
        continue;
    }
    if (AreNamesValid(inputName, inputLastName) && AgeIsValid(inputAge))
    {
        isValidMain = true;
        var person = new Person(inputName, inputLastName, convertedInputAge);
        Console.WriteLine($"First Name: {person.FirstName}\nLast Name: {person.LastName}\nAge: {person.Age}");
    }
    else
    {
        Console.WriteLine("Please try again.");
    }
} while (!isValidMain);