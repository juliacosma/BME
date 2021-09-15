#nullable enable
using System;
using System.IO;
using static System.Console;
using MediCal;
using System.Collections.Generic;

namespace Bme121
{
    partial class LinkedList
    {
        // Method used to indicate a target Drug object when searching.
        
        public static bool IsTarget( Drug data ) 
        { 
            return data.Name.StartsWith( "FOSAMAX", StringComparison.OrdinalIgnoreCase ); 
        }
        
        // Method used to compare two Drug objects when sorting.
        // Return is -/0/+ for a<b/a=b/a>b, respectively.
        
        public static int Compare( Drug a, Drug b )
        {
            return string.Compare( a.Name, b.Name, StringComparison.OrdinalIgnoreCase );
        }

        
        // Method used to add a new Drug object to the linked list in sorted order.
        
        public void InsertInOrder( Drug newData )
        {
            Node? previousNode = Head!;
            Node? nextNode = Head!;

            if (Head==null) 
            {
                Append(newData);
                Count ++;
                return;
            }
            else if (Compare(newData,Head.Data)<0)
            {
                Prepend(newData);
                Count ++;
                return;
            } 
            else if (Compare(newData,Tail!.Data)>0)
            {
                Append(newData);
                Count ++;
                return;
            }
            
            while(previousNode!=null && nextNode!=null)
            {
                if((Compare(newData,previousNode.Data)>0)&&(Compare(newData,nextNode.Data)<0))
                {
                    Node  newNode = new Node( newData );

                    previousNode.Next = newNode;
                    newNode.Next = nextNode;
                    Count ++;
                    return;
                }

                previousNode = previousNode.Next!;
                nextNode = previousNode.Next!;
            }

            return;

        }
    }
    
    static class Program
    {
        // Method to test operation of the linked list.
        
        static void Main( )
        {
            Drug[ ] drugArray = Drug.ArrayFromFile( "RXQT1503-100.txt" );
            
            LinkedList drugList = new LinkedList( );
            foreach( Drug d in drugArray ) drugList.InsertInOrder( d );
            
            WriteLine( "drugList.Count = {0}", drugList.Count );
            foreach( Drug d in drugList.ToArray( ) ) WriteLine( d );
        }
    }
}
