using System;
using static System.Console;

namespace Bme121
{
	static class WA1
	{
		static void Main()
		{
			string name;
			int age;
			double height;
			double weight;
			string sex;
			double restingEnergy;

			//get user inputs
			WriteLine("Enter your name: ");
			name = ReadLine();
			WriteLine("Enter your age (years): ");
			age = int.Parse(ReadLine());
			WriteLine("Enter your height (cm): ");
			height = double.Parse(ReadLine());
			WriteLine("Enter your weight (Kg): ");
			weight = double.Parse(ReadLine());
			WriteLine("Enter your sex: ");
			sex = ReadLine();

			//Calculate resting energy expenditure
			if (sex == "female" || sex == "Female")
			{
				restingEnergy = 10*weight + 6.25*height - 5*age - 161;
			}
			else
			{
				restingEnergy = 10*weight + 6.25*height - 5*age + 5;
			}

			//display inputs calculated energy expenditure
			WriteLine("Name: " + name);
			WriteLine("Age (years): " + age);
			WriteLine("Height (cm): " + height);
			WriteLine("Weight (Kg): " + weight);
			WriteLine("Sex: " + sex);
			WriteLine("Resting enery expenditure (cal/day): " + restingEnergy);

		}
	}
}
