using PersonDataApp;
using System;
using System.Runtime.InteropServices.Marshalling;

Console.WriteLine("Please enter the person's first name:");
string inputName = Console.ReadLine();

Console.WriteLine("Please enter the person's last name:");
string inputLastName = Console.ReadLine();

Console.WriteLine("Please enter the person's age:");
string inputAge = Console.ReadLine();

int ageResult = int.Parse(inputAge);

bool inputValidation = true;

foreach(char c in inputName) 
{
    int ageValidation;
    if (!Char.IsLetter(c))
    {
        inputValidation = false;
        Console.WriteLine("The name cannot contain special characters or numbers.");
        break;

    } else if (Char.IsLetter(c)) 
    { 
        foreach(char d in inputLastName) 
        {
            if (!Char.IsLetter(d)) 
            {
                inputValidation = false;
                Console.WriteLine("The last name cannot contain special characters or numbers.");
                break;
            }
        }
    } else if (!int.TryParse(inputAge, out ageValidation))
    {
            inputValidation = false;
            Console.WriteLine("Age must be an integer.");
        break;
    }
}

if (inputValidation)
{
    var person = new Person(inputName, inputLastName, ageResult);
    Console.WriteLine($"{person.FirstName + '\t' + person.LastName + '\t' + person.Age}");
    switch (inputName)
    {
        case string name:
            Console.WriteLine($"Added person's name: \"{name}\".");
            break;
        default:
            Console.WriteLine("Please enter the person's name again.");
            break;
    }
    switch (inputLastName)
    {
        case string name:
            Console.WriteLine($"Added person's last name: \"{name}\".");
            break;
        default:
            Console.WriteLine("Please enter the person's last name again.");
            break;
    }
    switch (inputAge)
    {
        case string age:
            Console.WriteLine($"Added person's age: \"{age}\".");
            break;
        default:
            Console.WriteLine("Please enter the person's age again.");
            break;
    }
}
