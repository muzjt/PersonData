using PersonDataApp;
using System;
using System.Runtime.InteropServices.Marshalling;

string inputName;
string inputLastName;
string inputAge;
string inputHeight;
string inputWeight;
int convertedInputAge;
float convertedInputHeight;
float convertedInputWeight;
bool isValidMain = false;

do
{
    Console.WriteLine("Please enter the person's first name:");
    inputName = Console.ReadLine();

    Console.WriteLine("Please enter the person's last name:");
    inputLastName = Console.ReadLine();

    Console.WriteLine("Please enter the person's age:");
    inputAge = Console.ReadLine();

    Console.WriteLine("Please enter the person's height (in meters):");
    inputHeight = Console.ReadLine();

    Console.WriteLine("Please enter the person's weight (in kilograms):");
    inputWeight = Console.ReadLine();

    string[] inputs = { inputName, inputLastName, inputAge, inputHeight, inputWeight };

    bool allFieldsFilled = true;

    for (int i = 0; i < inputs.Length; i++)
    {
        if (string.IsNullOrWhiteSpace(inputs[i]))
        {
            Console.WriteLine("All fields are required. Please try again.");
            allFieldsFilled = false;
            break;
        }
    }

    if (!allFieldsFilled) 
    {
        continue;
    }

    if (AreNamesValid(inputName, inputLastName) && IsAgeValid(inputAge) && AreDimmensionsValid(inputHeight, inputWeight))
    {
        isValidMain = true;
        var person = new Person(inputName, inputLastName, convertedInputAge, convertedInputHeight, convertedInputWeight);
        float bmi = CalculateBMI(person.Height, person.Weight);
        Console.WriteLine($"First Name:\t{person.FirstName}\nLast Name:\t{person.LastName}\nAge:\t\t{person.Age}\nHeight:\t\t{person.Height}m\nWeight:\t\t{person.Weight}kg\nBMI:\t\t{bmi:N2}");
    }
    else
    {
        Console.WriteLine("Please try again.");
    }
} while (!isValidMain);

bool AreNamesValid(string inputName, string inputLastName)
{
    if(inputName.Length >= 2 && inputLastName.Length >= 2) 
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
    Console.WriteLine($"Name and last name need to be at least 2 characters long.");
    return false;
}

bool IsAgeValid(string inputAge)
{
    if (int.TryParse(inputAge, out convertedInputAge))
    {
        if (convertedInputAge >= ValidationConstants.minAge && convertedInputAge <= ValidationConstants.maxAge)
        {
            return true;
        }
        else
        {
            Console.WriteLine($"Person's age cannot be less than {ValidationConstants.minAge} years and more than {ValidationConstants.maxAge} years.");
            return false;
        }
    }
    Console.WriteLine("Age must be an integer.");
    return false;
}

bool AreDimmensionsValid(string inputHeight, string inputWeight) 
{
    bool isHeightValid = float.TryParse(inputHeight, out convertedInputHeight) && convertedInputHeight >= ValidationConstants.minHeight && convertedInputHeight <= ValidationConstants.maxHeight;
    if (!isHeightValid) 
    {
        Console.WriteLine($"Person's height cannot be less than {ValidationConstants.minHeight} and more than {ValidationConstants.maxHeight} meters.");
    }
    bool isWeightValid = float.TryParse(inputWeight, out convertedInputWeight) && convertedInputWeight >= ValidationConstants.minWeight && convertedInputWeight <= ValidationConstants.maxWeight;
    if (!isWeightValid)
    {
        Console.WriteLine($"Person's weight cannot be less than {ValidationConstants.minWeight} and more than {ValidationConstants.maxWeight} kilograms.");
    }
    return isHeightValid && isWeightValid;
}

float CalculateBMI(float convertedInputHeight, float convertedInputWeight) 
{
    return convertedInputWeight / (convertedInputHeight * convertedInputHeight);
}

static class ValidationConstants
{
    public const int minAge = 18;
    public const int maxAge = 120;
    public const float maxHeight = 2.30f;
    public const float minHeight = 0.90f;
    public const float maxWeight = 210.00f;
    public const float minWeight = 30.00f;
}