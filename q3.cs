#nullable enable
using System;
using static System.Console;
using MediCal;

namespace Bme121
{
    public enum SelfOrgMove { None, Back, Head }

    partial class LinkedList< TData >
    {
        // Determine whether the linked list contains a target TData object.
        // The search is self-organizing so the found element is moved towards the list head.
        // The parameter-variable 'move' controls the self-organization.
        // SelfOrgMove.None - the list is not changed.
        // SelfOrgMove.Back - the target node is swapped with the node before it
        // SelfOrgMove.Head - the target node is swapped with the node at the list head

        public bool Contains( Predicate< TData > IsTarget, SelfOrgMove move )
        {
        
            Node? currentNode = Head;
            Node? backOneNode = null;
            Node? backTwoNode = null;
            Node oldHead = Head;
            oldHead.Next = Head.Next;

            while( currentNode != null )
            {
                

                if( IsTarget( currentNode.Data ) )
                {
                    //do the move
                    switch (move)
                    {
                        case SelfOrgMove.None: 
                            break;
                        case SelfOrgMove.Back:
                            if(backOneNode == null); //head, do nothing
                            else if(backTwoNode == null)//second element, move to head
                            {
                                backOneNode.Next = currentNode.Next;
                                currentNode.Next = oldHead;
                                Head = currentNode;
                            }
                            else
                            {
                                backTwoNode.Next = currentNode;
                                backOneNode.Next = currentNode.Next;
                                currentNode.Next = backOneNode; 
                            }
                            break;
                        case SelfOrgMove.Head:
                            if (backOneNode == null); //do nothing, already head
                            else
                            {
                                backOneNode.Next = currentNode.Next;
                                currentNode.Next = oldHead;
                                Head = currentNode;  
                            }
                            break; 
                    }

                    return true;
                }//if statement end

                backTwoNode = backOneNode;
                backOneNode = currentNode;
                currentNode = currentNode.Next;
            }

            return false;
        }
    }
}
