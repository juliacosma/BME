using System;
using static System.Console;
using static Bme121.Prime;

namespace Bme121
{
    class Prime
    {
        int lastPrime = 0;

        public int Next( )
        {
            lastPrime ++;
            while( ! IsPrime( lastPrime ) ) lastPrime ++;
            return lastPrime;
        }

        public static bool IsPrime( int n )
        {
            if( n < 2 ) return false;
            for( int d = 2; d <= n / 2; d ++ )
            {
                if( n % d == 0 ) return false;
            }
            return true;
        }
    }
    
    static class Program
    {
        // Remove the seed value in the Random allocation for different random values each run.
        // Random seed 76 used on the F2020 midterm.
        static Random rGen = new Random( 76 ); 
        static int[ , ] a; // the array
        static int[ ] aPrimeRows; // row locations of prime elements
        static int[ ] aPrimeCols; // col locations of prime elements
        static int[ ] aIslandIds; // id numbers for prime islands

//------ Part A ------
       
        // Method to draw the array.
        static void DrawArray( )
        {
            // Some useful constants for box drawing.
            const string h  = "\u2500"; // horizontal line
            const string v  = "\u2502"; // vertical line
            const string tl = "\u250c"; // top left corner
            const string tr = "\u2510"; // top right corner
            const string bl = "\u2514"; // bottom left corner
            const string br = "\u2518"; // bottom right corner
            const string vr = "\u251c"; // vertical join from right
            const string vl = "\u2524"; // vertical join from left
            const string hb = "\u252c"; // horizontal join from below
            const string ha = "\u2534"; // horizontal join from above
            const string hv = "\u253c"; // horizontal vertical cross
            
            // Some useful variables to avoid typing "a.GetLength( )" all the time.
            int rows = a.GetLength( 0 );
            int cols = a.GetLength( 1 );

            WriteLine( );
            WriteLine( "The array" );
            
            // Display each row.
            for( int r = 0; r < rows; r ++ )
            {
                // Draw content before the first row.
                if( r == 0 )
                {
                    // Draw the column coordinate numbers.
                    Write( "  col" ); // column coordinates label
                    for( int c = 0; c < cols; c++ )
                    {
                        Write( " {0,3} ", c );
                    }
                    WriteLine( );
                    
                    // Draw the border above the first row.
                    Write( "row  " ); // row coordinates label
                    for( int c = 0; c < cols; c ++ )
                    {
                        if( c == 0 ) // far left edge
                        {
                            Write( "{0}", tl );
                        }
                        Write( "{0}{0}{0}{0}", h ); // above the cell content
                        if( c == cols - 1 ) // far right edge
                        {
                            Write( "{0}", tr );
                        }
                        else // between two cells
                        {
                            Write( "{0}", hb );
                        }
                    }
                    WriteLine( );
                }

                // Draw the content of each cell in this row.
                Write( " {0,3} ", r ); // row number
                for( int c = 0; c < cols; c ++ )
                {
                    if( c == 0 ) // left edge of first cell
                    {
                        Write( "{0}", v );
                    }
                    Write( "{0,3} ", a[ r, c ] ); // the cell content
                    Write( "{0}", v ); // right edge of cell
                }
                WriteLine( );

                // Draw the border between rows.
                if( r != rows - 1 )
                {
                    Write( "     " ); // space over row coordinate numbers
                    for( int c = 0; c < cols; c ++ )
                    {
                        if( c == 0 ) // far left edge
                        {
                            Write( "{0}", vr );
                        }
                        Write( "{0}{0}{0}{0}", h ); // below the cell content
                        if( c == cols - 1 )  // far right edge
                        {
                            Write( "{0}", vl );
                        }
                        else // between cells
                        {
                            Write( "{0}", hv );
                        }
                    }
                    WriteLine( );
                }

                // Draw the border below the last row.
                else // r == rows - 1
                {
                    Write( "     " ); // space over row coordinate numbers
                    for( int c = 0; c < cols; c ++ )
                    {
                        if( c == 0 ) // far left edge
                        {
                            Write( "{0}", bl );
                        }
                        Write( "{0}{0}{0}{0}", h ); // below the cell content
                        if( c == cols - 1 ) // far right edge
                        {
                            Write( "{0}", br );
                        }
                        else // between cells
                        {
                            Write( "{0}", ha );
                        }
                    }
                    WriteLine( );
                }
            } // row loop
        } // DrawArray( )

//------ Part B ------
      
        // Method to display information about prime values in the array.
        static void PrimeElements()
        {
            // Some useful variables to avoid typing "a.GetLength( )" all the time.
            int rows = a.GetLength( 0 );
            int cols = a.GetLength( 1 );
            
            WriteLine( );
            WriteLine( "Prime elements in the array" );
            
            // Count the prime elements.
            int primeCount = 0;
            for(int r=0; r<rows;r++)
            {
                for(int c=0; c<cols; c++)
                {
                    bool isPrime = Prime.IsPrime(a[r,c]);
                    if(isPrime) primeCount++;
                }
            } 
            
            // Save locations of the prime elements.
            aPrimeRows = new int[ primeCount ];

            aPrimeCols = new int[ primeCount ];

            int ii=0;
            for(int r=0; r<rows;r++)
            {
                for(int c=0; c<cols; c++)
                {
                
                    bool isPrime = Prime.IsPrime(a[r,c]);
                    if(isPrime) 
                    {
                        aPrimeRows[ii] = r;
                        aPrimeCols[ii] = c;
                        ii++;
                    }
                    
                }
            } 
            
            // Made this format string a variable so field width can be adjusted in one place.
            string fmt = "{0,-12}:";
            
            Write( fmt, "Index" );
            for( int i = 0; i < primeCount; i ++ )
            {
                Write( "{0,3}", i );
            }
            WriteLine( );
            
            Write( fmt, "Row" );
            for( int i = 0; i < primeCount; i ++ )
            {
                Write( "{0,3}", aPrimeRows[i] );
            }
            WriteLine( );
            
            Write( fmt, "Column" );
            for( int i = 0; i < primeCount; i ++ )
            {
                Write( "{0,3}", aPrimeCols[i] );
            }
            WriteLine( );
            
            Write( fmt, "Prime" );
            for( int i = 0; i < primeCount; i ++ )
            {
                Write( "{0,3}", 0 );
            }
            WriteLine( );
        } // PrimeElements( )
        
//------ Part C ------
      
        // Method to display information about prime islands in the array.
        static void PrimeIslands( )
        {
            // Uncomment these lines if the PrimeElements method is not working.
            //aPrimeRows = new int[ ]{0,0,0,0,0,1,1,1,2,2,2,2, 2,3,3,3,3, 3, 3,4,4,4, 4, 4,5, 5};
            //aPrimeCols = new int[ ]{0,1,2,5,9,4,5,9,2,5,7,9,11,0,2,5,7,11,12,1,2,7,10,12,9,11};
            
            // A useful variable to avoid typing "aPrimeRows.Length" all the time.
            int primeCount = aPrimeRows.Length;
            
            WriteLine( );
            WriteLine( "Prime islands in the array" );
            
            // Initialize with each prime element as its own island.
            aIslandIds = new int[ primeCount ];
            for( int i = 0; i < primeCount; i ++ )
            {
                aIslandIds[ i ] = i;
            }
            
            // Made this format string a variable so field width can be adjusted in one place.
            string fmt = "{0,-12}:";
            
            Write( fmt, "Initial id" );
            for( int i = 0; i < primeCount; i ++ )
            {
                Write( "{0,3}", aIslandIds[ i ] );
            }
            WriteLine( );
            
            // Combine islands which touch.
            bool notDone = true;
            while( notDone )
            {
                notDone = false;
                
                if( notDone )
                {
                    Write( fmt, "Updated id" );
                    for( int i = 0; i < primeCount; i ++ )
                    {
                        Write( "{0,3}", aIslandIds[ i ] );
                    }
                    WriteLine( );
                }
            } // while( notDone )
        } // PrimeIslands( )
        
        static void Main( )
        {
            // Set the size of the array.
            const int rows = 6;
            const int cols = 13;

            // Allocate an array and fill with random values from 0 to 99.
            a = new int[ rows, cols ];
            for( int r = 0; r < rows; r ++ )
            {
                for( int c = 0; c < cols; c ++ )
                {
                    a[ r, c ] = rGen.Next( 0, 100 );
                }
            }
            DrawArray( );
            PrimeElements( );
            PrimeIslands( );
            WriteLine( );
        } // Main( )
    } // Program
} // Bme121
