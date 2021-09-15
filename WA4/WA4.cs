using System;
using static System.Console;

namespace Bme121
{
    class CauseOfDeathInfo
    {
    	public string causesOfDeath;
    	public string year;
    	public string age;
    	string sex;
    	int numOfDeathsPerDemoCause;
    	double percentagePerDemoCause;
    	double mortality;

    	public CauseOfDeathInfo(string causesOfDeath, string year, string age, string sex, int numOfDeathsPerDemoCause, double percentagePerDemoCause, double mortality)
    	{
    		this.causesOfDeath = causesOfDeath;
    		this.year = year;
    		this.age = age;
    		this.sex = sex;
    		this.numOfDeathsPerDemoCause = numOfDeathsPerDemoCause;
    		this.percentagePerDemoCause = percentagePerDemoCause;
    		this.mortality = mortality;
    	}

    	/*public override string ToString()
    	{
    		return "hello";
    	}*/
    }

    static partial class Program
    {
        static void Main( )
        {
        	int deaths15to24=0;
        	int deathsSalmonella=0;
            // Load the array of CauseOfDeathInfo objects.
            CauseOfDeathInfo[ ] stats = MakeStatsArray( );
            WriteLine( "stats.Length={0}", stats.Length );


            //loop through stats
            for(int i=0; i<stats.Length; i++)
            {
            	if(int.Parse(stats[i].year) >= 2009 && int.Parse(stats[i].year) <= 2018 && stats[i].causesOfDeath=="Salmonella infections") deathsSalmonella++;
            	if(stats[i].year == "2017" && stats[i].age == "15-24 years") deaths15to24++;
            }

            WriteLine("Total death due to Salmonella infections in 2009 to 2018 are {0}",deathsSalmonella);
            WriteLine("Total deaths for 2017 in the 15-24 age range are {0}",deaths15to24);
        }
    }
}
