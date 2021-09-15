using System;
using static System.Console;
using static System.Math;

namespace WA2
{
	static class WA2
	{
		static void Main()
		{
			int num;
			double leftOver;
			int numBase;
			//string[] digits;
			int exp = 0;
			int digit = 0;

			//ask for input
			Write("Enter a number: ");
			num = int.Parse(ReadLine());
			leftOver = num;

			Write("Enter a base: ");
			numBase = int.Parse(ReadLine());

			if(num < 0 || numBase < 2)
			{
				WriteLine("Invalid input.");
				return;
			}

			//loop for digits, digit*n^k

			//initialization loops
			//find highest power of base that fits
			while((leftOver-Pow(numBase,exp))>=0)
			{
				exp++;
			}
			exp--;
			//initialize array
			string[] digits = new string[exp+1];

			//set values to string 0
			for (int i = digits.Length-1;i>=0;i--)
			{
				digits[i]="0";
			}
			//DEBUG
			//WriteLine(exp);

			//find highest multiple of power that fits
			while(leftOver-(digit*Pow(numBase,exp))>0 && digit < numBase)
			{
				digit++;
			}
			if(leftOver-(digit*Pow(numBase,exp))<0)
			{
				digit--;
			}
			
			//set that element of the array to that digit, add a comma if > 10
			if(digit>=10)
			{
				digits[exp] = Convert.ToString(digit)+",";
			}
			else
			{
				digits[exp] = Convert.ToString(digit);
			}
			//DEBUG
			//WriteLine(digits[exp]);

			//subract digit value from original amount
			leftOver -= digit*Pow(numBase,exp);

			//reset values
			exp = 0;
			digit = 0;

			//MAIN LOOPS
			while (leftOver>0)
			{
				while((leftOver-Pow(numBase,exp))>=0)
					{
						exp++;
					}
					exp--;

				//DEBUG
				//WriteLine(exp);

				//find highest multiple of power that fits
				while(leftOver-(digit*Pow(numBase,exp))>0 && digit < numBase)
					{
						digit++;
					}
				if(leftOver-(digit*Pow(numBase,exp))<0)
					{
						digit--;
					}
					
				//set that element of the array to that digit, add a comma if > 10
				if(digit>=10)
					{
						digits[exp] = ","+Convert.ToString(digit)+",";
					}
				else
					{
						digits[exp] = Convert.ToString(digit);
					}
				//DEBUG
				//WriteLine(digits[exp]);

				//subract digit value from original amount
				leftOver -= digit*Pow(numBase,exp);

				//reset values
				exp = 0;
				digit = 0;
			}

			//final statement
			Write("The value of {0} in base {1} is: ", num, numBase);
			//print array backwards
			for (int i = digits.Length-1; i>=0; i--) 
			{
				Write(digits[i]); 
			}
		}
	}
}
