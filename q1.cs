#nullable enable
using System;
using static System.Console;
using static System.Math;



namespace Bme121
{
    static class Program
    {
        static Random rGen = new Random( );

        static double Psi(double r)
        {
        	return 0.994766*r - 0.285434*Pow(r,3) + 0.0760663*Pow(r,5);
        }

        static double Atan2Fast(double x, double y)
        {
        	double pi = Math.PI;

        	double atan = 0;

        	if(x==0 && y==0) return 0;

        	if(y<x && y>= -x) atan = Psi(y/x);
        	else if (y>=x && y>=-x) atan = pi/2 - Psi(x/y);
        	else if(y>=x && y<-x) atan =  pi + Psi(y/x);
        	else if(y<x && y<-x) atan = -pi/2 - Psi(x/y);

        	while(atan > pi)
        	{
        		atan -= 2*pi;
        	}

        	return atan;
        }
        
        static void Main( )
        {
            WriteLine("{0,10}{1,10}{2,10}{3,10}{4,10}","Y-Coord","X-Coord","Exact","Fast","Error" );
            for( int i = 0; i < 20; i ++ )
            {
            	double pi = PI;
                double yCoord = rGen.NextDouble( ) * 2 - 1;
                double xCoord = rGen.NextDouble( ) * 2 - 1;
                double x = xCoord;
                double y = yCoord;

                double exact = Atan2(xCoord, yCoord);
               /* if(y<x && y>= -x) exact = Atan2(y/x);
        		else if (y>=x && y>=-x) exact = pi/2 - Atan2(x/y);
        		else if(y>=x && y<-x) exact =  pi + Atan2(y/x);
        		else if(y<x && y<-x) exact = -pi/2 - Atan2(x/y);
        		else exact = 0;
        		while(exact > pi)
        		{
        		exact -= 2*pi;
        		}*/
                double fast = Atan2Fast(xCoord,yCoord);
                double error = exact - fast;
                
                WriteLine( "{0,10:f4}{1,10:f4}{2,10:f4}{3,10:f4}{4,10:f4}", yCoord, xCoord, exact, fast, error ); 
            }
            WriteLine( );
        }
    }
}
