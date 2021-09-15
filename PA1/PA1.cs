using System;
using static System.Console;

namespace PA1
{
	static class Program
	{
		static bool[,] board;
		static string startingPlatformA;
		static string positionA;
		static string startingPlatformB;
		static string positionB;
		static string[ ] letters = 
			{"a","b","c","d","e","f","g","h","i","j","k","l","m",
			"n","o","p","q","r","s","t","u","v","w","x","y","z"};

		static void Main()
		{
			int boardHeight;
			int boardWidth;
			string playerAName;
			string playerBName;
			string flag;
			bool gameActive = true;
			positionA = "ca";
			positionB = "dh";
			string move = "";
			string position;
			string name = "";

            //initialize game
            //get board config
			Write("Enter desired board height: ");
			boardHeight = int.Parse(ReadLine());
			if (boardHeight < 4 || boardHeight>26) boardHeight = 6;
			Write("Enter desired board width: ");
			boardWidth = int.Parse(ReadLine());
			if (boardWidth < 4 || boardWidth>26) boardWidth = 8;

			//create board bool
			board = new bool[boardHeight,boardWidth];//false if tiles removed

			//initialize values to true
			for (int r=0; r<board.GetLength(0); r++)
			{
				for (int c=0; c<board.GetLength(1); c++)
				{
					board[r,c] = true;
				}
			}

			//player names
			Write("Enter name of Player A: ");
			playerAName = ReadLine(); 
			if (playerAName == "") playerAName = "Player A";
			Write("Enter name of Player B: ");
			playerBName = ReadLine();
			if (playerBName == "") playerBName = "Player B";
			if (playerAName == playerBName)
			{
				playerAName = "Player A";
				playerBName = "Player B";
			}

			//set starting platform
			Write("{0} choose your starting platform: ",playerAName);
			positionA = ReadLine();
			startingPlatformA = positionA;
			positionA = positionA + "aa";
			Write("{0} choose your starting platform: ",playerBName);
			positionB = ReadLine();
			startingPlatformB = positionB;
			positionB = positionB + "aa";

			flag = "a";
			position = positionA;
			move = positionB;

			DrawBoard(boardHeight, boardWidth, position, move, flag);

			//game loop
			while(move != "q")
			{

				//get player input
				if (flag == "a") 
				{
					name = playerAName;
					position = positionA;
				}
				else if (flag == "b") 
				{
					name = playerBName;
					position = positionB;
				}
	            Write( "{0} enter a move, first two letters for pawn position, second two for tile removal (row then column) [abcd] or q to exit: ",name);
	            move = ReadLine();
	            bool validMove = ValidMove(position,move);
	            bool validTile = ValidTile(position,move);
	            while (validMove==false || validTile==false)
	            {
	            	Write("Please re-enter a valid move: ");
	            	move = ReadLine();
	            	validMove = ValidMove(position,move);
	            	validTile = ValidTile(position,move);
	            }
	            
	            //remove tile
	            board[Array.IndexOf(letters,move.Substring(2,1)),Array.IndexOf(letters,move.Substring(3,1))] = false;

	            //drawboard
	           if (flag=="a") 
	           {
	           	positionA = move;
	           	DrawBoard(boardHeight, boardWidth, positionB, move, flag);
	           }
	           else if (flag=="b") 
	           {
	           	positionB = move;
	           	DrawBoard(boardHeight, boardWidth, positionA, move, flag);
	           }

	            position = move;

	            //flip flag
	            if(flag == "a") flag = "b";
	            else if (flag == "b") flag = "a";

			}
		}

		static bool ValidMove(string position, string move)
		{
			int moveRow = Array.IndexOf(letters, move.Substring(0,1));
			int moveCol = Array.IndexOf(letters, move.Substring(1,1));
			int positionRow = Array.IndexOf(letters, position.Substring(0,1));
			int positionCol = Array.IndexOf(letters, position.Substring(1,1));
			if (moveRow==positionRow && moveCol==positionCol) return false;
			if (moveRow>board.GetLength(0)||moveCol>board.GetLength(1)) return false;
			else return true;
		}

		static bool ValidTile(string position, string move)
		{
			int tileRow = Array.IndexOf(letters, move.Substring(2,1));
			int tileCol = Array.IndexOf(letters, move.Substring(3,1));
			int positionRow = Array.IndexOf(letters, position.Substring(0,1));
			int positionCol = Array.IndexOf(letters, position.Substring(1,1));

			int platformARow = Array.IndexOf(letters, startingPlatformA.Substring(0,1));
			int platformACol = Array.IndexOf(letters, startingPlatformA.Substring(1,1));
			int platformBRow = Array.IndexOf(letters, startingPlatformB.Substring(0,1));
			int platformBCol = Array.IndexOf(letters, startingPlatformB.Substring(1,1));

			if (board[tileRow,tileCol]==false) return false;
			else if (tileRow==positionRow || tileCol==positionCol) return false;
			else if(tileRow==platformARow && tileCol==platformBCol) return false;
			else if(tileRow==platformBRow && tileCol==platformBCol) return false;
			else if (move==positionA || move==positionB) return false;
			else return true;
		}

		static void DrawBoard(int boardHeight, int boardWidth, string position, string move, string flag)//as in position of other player, current move
		{
			string h  = "\u2500"; // horizontal line
            string v  = "\u2502"; // vertical line
            string tl = "\u250c"; // top left corner
            string tr = "\u2510"; // top right corner
            string bl = "\u2514"; // bottom left corner
            string br = "\u2518"; // bottom right corner
            string vr = "\u251c"; // vertical join from right
            string vl = "\u2524"; // vertical join from left
            string hb = "\u252c"; // horizontal join from below
            string ha = "\u2534"; // horizontal join from above
            string hv = "\u253c"; // horizontal vertical cross
            //string sp = " ";      // space
            //string pa = "A";      // pawn A
            //string pb = "B";      // pawn B
            string bb = "\u25a0"; // block
            string fb = "\u2588"; // full block
            string lh = "\u258c"; // left half block
            string rh = "\u2590"; // right half block
            string tile = rh+fb+lh;

			//get pawn position
			int pawnRow = Array.IndexOf(letters, move.Substring( 0, 1 ));
	        int pawnCol = Array.IndexOf(letters, move.Substring( 1, 1 ));
	        int tileRow = Array.IndexOf(letters, move.Substring( 2, 1 ));
	        int tileCol = Array.IndexOf(letters, move.Substring( 3, 1 ));

	        int otherPawnRow = Array.IndexOf(letters, position.Substring( 0, 1 ));
	        int otherPawnCol = Array.IndexOf(letters, position.Substring( 1, 1 ));

			//draw letters on the top
			Write("      ");
			for(int x=0; x<board.GetLength(1);x++)
			{
				Write("{0}   ",letters[x]);
			}
			WriteLine("");


			//draw top board boundary
			Write("    ");
			for(int c=0; c<board.GetLength(1); c++)
			{
				if(c==0) Write(tl);
				Write("{0}{0}{0}",h);
				if(c==board.GetLength(1)-1) Write("{0}",tr);
				else						Write("{0}",hb);
			}
			WriteLine();

			//draw board rows
			for(int r=0; r < board.GetLength(0); r++)
			{
				Write(" {0}  ",letters[r]);

				//draw row contents
				for(int c=0; c<board.GetLength(1); c++)
				{
					if(c==0) Write(v);

					//inside squares
					if (r==pawnRow && c==pawnCol)
					{
						if(flag=="a") Write(" A {0}",v);
						else if(flag=="b") Write(" B {0}",v);	
					}
					else if(r==otherPawnRow && c==otherPawnCol)
					{
						if(flag=="a") Write(" B {0}",v);
						else if(flag=="b") Write(" A {0}",v);
					}
					else if(r==Array.IndexOf(letters,startingPlatformA.Substring(0,1)) 
					&& c==Array.IndexOf(letters,startingPlatformA.Substring(1,1))) Write(" {0} {1}",bb,v);
					else if(r==Array.IndexOf(letters,startingPlatformB.Substring(0,1)) 
					&& c==Array.IndexOf(letters,startingPlatformB.Substring(1,1))) Write(" {0} {1}",bb,v);
					else if(board[r,c]==true) Write("{0}{1}",tile,v);
					else Write("{0}{1}","   ",v);
				}
				WriteLine();

				//draw the boundary after the row
				if(r!=board.GetLength(0)-1)
				{
					Write("    ");
					for(int c=0; c<board.GetLength(1); c++)
					{
						if(c==0) Write(vr);
						Write("{0}{0}{0}",h);
						if(c==board.GetLength(1)-1) Write("{0}",vl);
						else						Write("{0}",hv);
					}
					WriteLine();
				}
				else
				{
					Write("    ");
					for(int c=0; c<board.GetLength(1); c++)
					{
						if(c==0) Write(bl);
						Write("{0}{0}{0}",h);
						if(c==board.GetLength(1)-1) Write("{0}",br);
						else						Write("{0}",ha);
					}
					WriteLine();
				}
				
			}
		}
	}
}
