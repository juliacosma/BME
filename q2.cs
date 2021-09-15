#nullable enable
using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;
using static System.Math;

namespace Bme121
{
    static class Program
    {
        static void Main( )
        {
        	const string filePath = "HuGaDB_v1_walking_06_04.txt";
            const double gravity = 9.80665;
            List<double> x = new List<double>();
//step 1
            //file reading
            using(FileStream inFile = File.Open(filePath, FileMode.Open, FileAccess.Read))
			using(StreamReader reader = new StreamReader(inFile))
			{
				string line;
				double g = gravity;

				//skip header lines
				reader.ReadLine();
				reader.ReadLine();
				reader.ReadLine();
				reader.ReadLine();

				//read through data and add
				while(!reader.EndOfStream)
				{
					double accrsx;
					double accrsxG;

					line = reader.ReadLine();

					string[] lineSplit = line.Split(null);

					accrsx = Double.Parse(lineSplit[6]);

					accrsxG = accrsx*2*g/32768+g;

					x.Add(accrsxG);
				}

				

			}//end of file reading
//step 2
			double[] phi = new double[x.Count];

			//tk values
			//initialize to 0
			for(int n=0; n<phi.Length; n++) phi[n] = 0;
			for(int n=2; n<phi.Length-4; n++)
			{
				double tK;

				tK = 2*Pow(x[n],2) + Pow((x[n+1]-x[n-1]),2) - x[n]*(x[n+2]+x[n-2]);
				if(tK > 0) phi[n] = tK;
			}

//step 3
			double[] phiP = new double[phi.Length];
			//init to 0
			for(int n=0; n<phiP.Length; n++) phiP[n] = 0;
			//get max
			for(int n=1; n<phiP.Length-1; n++)
			{
				double a = phi[n-1];
				double b = phi[n];
				double c = phi[n+1];

				if(a>b&&a>c) phiP[n] = a;
				else if(b>c&&b>a) phiP[n] = b;
				else if (c>b&&c>a) phiP[n] = c;
			}
//step 4
			double[] phiPP = new double[phi.Length];
			//init to 0
			for(int n=0; n<phiP.Length; n++) phiPP[n] = 0;
			//move ave
			for(int n=2; n<phiP.Length-2; n++)
			{
				phiPP[n] = (phiP[n-2] + phiP[n-1] + phiP[n] + phiP[n+1] + phiP[n+2])/5;
			}
//step 5
			//display
			int nN = 146;
			WriteLine("{0,10}{1,10}{2,10}{3,10}{4,10}","n","x","phi","phiP","phiPP");

			for(int i=0; i<phi.Length; i++)
			{
				 WriteLine("{0,10:f0}{1,10:f1}{2,10:f1}{3,10:f1}{4,10:f1}",nN,x[i],phi[i],phiP[i],phiPP[i]);
				nN++;
			}
        }
    }
}
