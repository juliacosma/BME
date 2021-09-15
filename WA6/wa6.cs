#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace Bme121
{
    // Represent one record from the dataset by Office of the National Coordinator (ONC) 
    // Regional Extension Centers (REC) on Key Performance Indicators (KPIs) by county.
    // The ONC REC program provides assistance to health care providers to adopt
    // and meaningfully use certified Electronic Health Records (EHR) technology.
    // Data covers the date range from April 2012 to June 2015.
    // The Office of the National Coordinator for Health Information Technology
    // is a division of the U.S. Department of Health and Human Services.
    // See https://dashboard.healthit.gov/datadashboard/documentation/
    // ONC-REC-kpi-county-data-documentation.php. 
    
    class EhrKpiRecord
    {
        public string State                                { get; private set; }
        public string StateCode                            { get; private set; }
        public string CountyName                           { get; private set; }
        public string StateFips                            { get; private set; }
        public string CountyFips                           { get; private set; }
        public string Fips                                 { get; private set; }
        public string Period                               { get; private set; }
        public int?   NumProvidersSignedUp                 { get; private set; }
        public int?   NumPrimaryCareProvidersSignedUp      { get; private set; }
        public int?   NumProvidersGoLive                   { get; private set; }
        public int?   NumPrimaryCareProvidersGoLive        { get; private set; }
        public int?   NumProvidersMeaningfulUse            { get; private set; }
        public int?   NumPrimaryCareProvidersMeaningfulUse { get; private set; }
        
        public EhrKpiRecord
        (
            string state,
            string stateCode,
            string countyName,
            string stateFips,
            string countyFips,
            string fips,
            string period,
            int?   numProvidersSignedUp,
            int?   numPrimaryCareProvidersSignedUp,
            int?   numProvidersGoLive,
            int?   numPrimaryCareProvidersGoLive,
            int?   numProvidersMeaningfulUse,
            int?   numPrimaryCareProvidersMeaningfulUse
        )
        {
            State                                = state;        
            StateCode                            = stateCode;        
            CountyName                           = countyName;        
            StateFips                            = stateFips;        
            CountyFips                           = countyFips;        
            Fips                                 = fips;        
            Period                               = period;        
            NumProvidersSignedUp                 = numProvidersSignedUp;        
            NumPrimaryCareProvidersSignedUp      = numPrimaryCareProvidersSignedUp;        
            NumProvidersGoLive                   = numProvidersGoLive;        
            NumPrimaryCareProvidersGoLive        = numPrimaryCareProvidersGoLive;        
            NumProvidersMeaningfulUse            = numProvidersMeaningfulUse;        
            NumPrimaryCareProvidersMeaningfulUse = numPrimaryCareProvidersMeaningfulUse;       
        }
    }
    
    static class Program
    {
        static void Main( )
        {
        	//file stream variables, file stream and stream read
        	const string path = "REC_KPI_County.csv";
        	const FileMode mode = FileMode.Open;
        	const FileAccess access = FileAccess.Read;

        	using FileStream file = new FileStream(path, mode, access);
        	using StreamReader reader = new StreamReader(file);

            // Load the ONC REC KPI dataset on EHR adoption by county.
            
            List< EhrKpiRecord > ehrKpiRecords = new List< EhrKpiRecord >( );
           
            // TO DO: Complete this code.
            
            
            
            // Display all unique ( State, StateCode, StateFips ) three-tuples.
            
            HashSet< ( string, string, string ) > states 
                = new HashSet< ( string, string, string ) >( );

          
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
            	string line = reader.ReadLine();
            	WriteLine(line);
            	string[] split = line.Split(",");

            	string state = split[0];
            	string stateCode = split[1];
            	string countyName = split[2];
            	string stateFips = split[3];
            	string countyFips = split[4];
            	string fips = split[5];
            	string period = split[6];

            	int? numProvidersSignedUp;
            	if(split[7]=="NA"||split[7]=="0") numProvidersSignedUp = null;
            	else numProvidersSignedUp = int.Parse(split[7]);

            	int? numPrimaryCareProvidersSignedUp;
            	if(split[8]=="NA"||split[8]=="0") numPrimaryCareProvidersSignedUp = null;
            	else numPrimaryCareProvidersSignedUp = int.Parse(split[8]);

            	int? numProvidersGoLive;
            	if(split[9]=="NA"||split[9]=="0") numProvidersGoLive = null;
            	else numProvidersGoLive = int.Parse(split[9]);

            	int? numPrimaryCareProvidersGoLive;
            	if(split[10]=="NA"||split[10]=="0") numPrimaryCareProvidersGoLive = null;
            	else numPrimaryCareProvidersGoLive = int.Parse(split[10]);

            	int? numProvidersMeaningfulUse;
            	if(split[11]=="NA"||split[11]=="0") numProvidersMeaningfulUse = null;
            	else numProvidersMeaningfulUse = int.Parse(split[11]);

            	int? numPrimaryCareProvidersMeaningfulUse;
            	if(split[12]=="NA"||split[12]=="0") numPrimaryCareProvidersMeaningfulUse = null;
            	else numPrimaryCareProvidersMeaningfulUse = int.Parse(split[12]);

            	EhrKpiRecord n = new EhrKpiRecord
            	(state, stateCode, countyName, stateFips, countyFips, fips, period,
            	numProvidersSignedUp, numPrimaryCareProvidersSignedUp, numProvidersGoLive,
            	numPrimaryCareProvidersGoLive, numProvidersMeaningfulUse, numPrimaryCareProvidersMeaningfulUse);

            	//add to the list
            	ehrKpiRecords.Add(n);
            }

            foreach( EhrKpiRecord r in ehrKpiRecords )
	            {
	                states.Add( ( r.State, r.StateCode, r.StateFips ) );
	            }
	            
	        foreach( ( string, string, string ) s in states )
	            {
	                WriteLine( s );
	            }
                
            WriteLine( "ehrKpiRecords.Count = {0:n0}", ehrKpiRecords.Count );
        }
    }
}
