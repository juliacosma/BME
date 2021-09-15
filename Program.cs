using System;
using static System.Console;

namespace TEST
{
	static class Program
	{
		
		static bool Nonincreasing(int[] digits)
        {
        	for(int i=0; i<digits.Length-1; i++)
        	{
        		if(digits[i]<digits[i+1])
        		{
        			return false;
        		}
        	}

        	return true;
        }

		static void Main()
		{
			string arrString="";

			int[] arr= new int[3];

			for(int i=0;i<3;i++)
			{
				arr[i]= int.Parse(ReadLine());
				arrString+=arr[i];
			}

			Write(arrString);

		}
	}
}
