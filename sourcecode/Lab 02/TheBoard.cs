using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace CourseWork
{
    class TheBoard
    {
        #region Variables

        int playerOneCounter = 0;
        int playerTwoCounter = 0;

        int playerOneKingCounter = 0;
        int playerTwoKingCounter = 0;

        string theBoard;
        public string _player;

        const string theWinnerIs = ("\n\n _____ _          \n|_   _| |         \n  | | | |__   ___ \n  | | | '_ \\ / _ \\\n  | | | | | |  __/\n  \\_/ |_| |_|\\___|\n\n\n _    _ _                       \n| |  | (_)                      \n| |  | |_ _ __  _ __   ___ _ __ \n| |/\\| | | '_ \\| '_ \\ / _ \\ '__|\n\\  /\\  / | | | | | | |  __/ |   \n \\/  \\/|_|_| |_|_| |_|\\___|_|   \n\n\n _     \n(_)    \n _ ___ \n| / __|\n| \\__ \\\n|_|___/\n");
        const string playerX = ("\n\n______ _                        __   __\n| ___ \\ |                       \\ \\ / /\n| |_/ / | __ _ _   _  ___ _ __   \\ V / \n|  __/| |/ _` | | | |/ _ \\ '__|  /   \\ \n| |   | | (_| | |_| |  __/ |    / /^\\ \\\n\\_|   |_|\\__,_|\\__, |\\___|_|    \\/   \\/\n                __/ |                  \n               |___/                   \n\n\n\n");
        const string playerO = ("\n\n______ _                         _____ \n| ___ \\ |                       |  _  |\n| |_/ / | __ _ _   _  ___ _ __  | | | |\n|  __/| |/ _` | | | |/ _ \\ '__| | | | |\n| |   | | (_| | |_| |  __/ |    \\ \\_/ /\n\\_|   |_|\\__,_|\\__, |\\___|_|     \\___/ \n                __/ |                  \n               |___/                   \n\n\n\n");

        #endregion

        #region Console Settings Method

        public void ConsoleSettings()
        {
            // Sets the title
            Console.Title = ("Check, Check, Checkers....");

            // Sets the width and height of the console window
            int width = (Console.LargestWindowWidth - 100);
            int height = (Console.LargestWindowHeight - 10);            
            Console.SetWindowSize(width, height);

            // Set the position of the console window to the top left
            Console.SetWindowPosition(0, 0);
        }

        #endregion

        #region Display and Update the Board Methods

        public void UpdateTheBoard(string[,] positionsArray, string[] savedPositions)
        {
            positionsArray[0, 1] = savedPositions[1];
            positionsArray[0, 3] = savedPositions[3];
            positionsArray[0, 5] = savedPositions[5];
            positionsArray[0, 7] = savedPositions[7];

            positionsArray[1, 0] = savedPositions[8];
            positionsArray[1, 2] = savedPositions[10];
            positionsArray[1, 4] = savedPositions[12];
            positionsArray[1, 6] = savedPositions[14];

            positionsArray[2, 1] = savedPositions[17];
            positionsArray[2, 3] = savedPositions[19];
            positionsArray[2, 5] = savedPositions[21];
            positionsArray[2, 7] = savedPositions[23];

            positionsArray[3, 0] = savedPositions[24];
            positionsArray[3, 2] = savedPositions[26];
            positionsArray[3, 4] = savedPositions[28];
            positionsArray[3, 6] = savedPositions[30];

            positionsArray[4, 1] = savedPositions[33];
            positionsArray[4, 3] = savedPositions[35];
            positionsArray[4, 5] = savedPositions[37];
            positionsArray[4, 7] = savedPositions[39];

            positionsArray[5, 0] = savedPositions[40];
            positionsArray[5, 2] = savedPositions[42];
            positionsArray[5, 4] = savedPositions[44];
            positionsArray[5, 6] = savedPositions[46];

            positionsArray[6, 1] = savedPositions[49];
            positionsArray[6, 3] = savedPositions[51];
            positionsArray[6, 5] = savedPositions[53];
            positionsArray[6, 7] = savedPositions[55];

            positionsArray[7, 0] = savedPositions[56];
            positionsArray[7, 2] = savedPositions[58];
            positionsArray[7, 4] = savedPositions[60];
            positionsArray[7, 6] = savedPositions[62];
        }


        public void DisplayTheBoard(string[,]positionsArray, bool player1Turn)
        {
            _player = CheckPlayerTurn(player1Turn);

            Console.Clear();
            CheckHowManyPiecesRemain(positionsArray);
            
            theBoard = string.Format("" +
                    "     v          ╔╦╦╦╦╦╦╦╦═══════╦╦╦╦╦╦╦╦╦═══════╦╦╦╦╦╦╦╦╦═══════╦╦╦╦╦╦╦╦╦═══════╗    ╔═════════════════╗  \n" +
                    "     v      ╔═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║    ║ Player {0}'s turn ║\n" +
                    "     v      ║ 0 ╠╬╬╬╬╬╬╬╣  {1}  ╠╬╬╬╬╬╬╬╣  {2}  ╠╬╬╬╬╬╬╬╣  {3}  ╠╬╬╬╬╬╬╬╣  {4}  ║    ╚═════════════════╝  \n" +
                    "     v      ╚═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║\n" +
                    "     v          ╠╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╣\n" +
                    "     v      ╔═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣    ╔═════════════════╗     \n" +
                    "     v      ║ 1 ║  {5}  ╠╬╬╬╬╬╬╬╣  {6}  ╠╬╬╬╬╬╬╬╣  {7}  ╠╬╬╬╬╬╬╬╣  {8}  ╠╬╬╬╬╬╬╬╣    ║ Piece's Left    ║     \n" +
                    "     v      ╚═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣    ╠═════════════════╣     \n" +
                    "     v          ╠╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╣    ║  X  - {9}        ║   \n" +
                    "     v      ╔═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║    ║  O  - {10}        ║  \n" +
                    "     v      ║ 2 ╠╬╬╬╬╬╬╬╣  {11}  ╠╬╬╬╬╬╬╬╣  {12}  ╠╬╬╬╬╬╬╬╣  {13}  ╠╬╬╬╬╬╬╬╣  {14}  ║    ╚═════════════════╝ \n" +
                    "     v      ╚═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║\n" +
                    "     v          ╠╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╣\n" +
                    "     v      ╔═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣    ╔═════════════════╗     \n" +
                    "     v      ║ 3 ║  {15}  ╠╬╬╬╬╬╬╬╣  {16}  ╠╬╬╬╬╬╬╬╣  {17}  ╠╬╬╬╬╬╬╬╣  {18}  ╠╬╬╬╬╬╬╬╣    ║ King's Left     ║ \n" +
                    "     v      ╚═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣    ╠═════════════════╣     \n" +
                    "  [Y-Axis]      ╠╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╣    ║ |X| - {19}         ║  \n" +
                    "     v      ╔═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║    ║ |O| - {20}         ║  \n" +
                    "     v      ║ 4 ╠╬╬╬╬╬╬╬╣  {21}  ╠╬╬╬╬╬╬╬╣  {22}  ╠╬╬╬╬╬╬╬╣  {23}  ╠╬╬╬╬╬╬╬╣  {24}  ║    ╚═════════════════╝ \n" +
                    "     v      ╚═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║\n" +
                    "     v          ╠╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╣\n" +
                    "     v      ╔═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣\n" +
                    "     v      ║ 5 ║  {25}  ╠╬╬╬╬╬╬╬╣  {26}  ╠╬╬╬╬╬╬╬╣  {27}  ╠╬╬╬╬╬╬╬╣  {28}  ╠╬╬╬╬╬╬╬╣\n" +
                    "     v      ╚═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣\n" +
                    "     v          ╠╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╣\n" +
                    "     v      ╔═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║\n" +
                    "     v      ║ 6 ╠╬╬╬╬╬╬╬╣  {29}  ╠╬╬╬╬╬╬╬╣  {30}  ╠╬╬╬╬╬╬╬╣  {31}  ╠╬╬╬╬╬╬╬╣  {32}  ║\n" +
                    "     v      ╚═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║\n" +
                    "     v          ╠╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╣\n" +
                    " v v v v v  ╔═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣\n" +
                    "   v v v    ║ 7 ║  {33}  ╠╬╬╬╬╬╬╬╣  {34}  ╠╬╬╬╬╬╬╬╣  {35}  ╠╬╬╬╬╬╬╬╣  {36}  ╠╬╬╬╬╬╬╬╣\n" +
                    "     v      ╚═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣\n" +
                    "                ╚═╦═══╦═╩╩╬╩╩╩╬╩╩═╦═══╦═╩╩╬╩╩╩╬╩╩═╦═══╦═╩╩╬╩╩╩╬╩╩═╦═══╦═╩╩╬╩╩╩╬╩╝\n" +                    
                    "                  ║ 0 ║   ║ 1 ║   ║ 2 ║   ║ 3 ║   ║ 4 ║   ║ 5 ║   ║ 6 ║   ║ 7 ║  \n" +
                    "                  ╚═══╝   ╚═══╝   ╚═══╝   ╚═══╝   ╚═══╝   ╚═══╝   ╚═══╝   ╚═══╝  \n" +
                    "                                                                                 \n" +
                    "                                                                           >     \n" +
                    "                                                                           > >   \n" +
                    "                > > > > > > > > > > > > > > > [X-Axis] > > > > > > > > > > > > > \n" +
                    "                                                                           > >   \n" +
                    "                                                                           >     \n" +
                    "", _player,
                        positionsArray[0, 1], positionsArray[0, 3], positionsArray[0, 5], positionsArray[0, 7],                       
                        positionsArray[1, 0], positionsArray[1, 2], positionsArray[1, 4], positionsArray[1, 6],
                        playerOneCounter, playerTwoCounter,
                        positionsArray[2, 1], positionsArray[2, 3], positionsArray[2, 5], positionsArray[2, 7],                                           
                        positionsArray[3, 0], positionsArray[3, 2], positionsArray[3, 4], positionsArray[3, 6],
                        playerOneKingCounter, playerTwoKingCounter,
                        positionsArray[4, 1], positionsArray[4, 3], positionsArray[4, 5], positionsArray[4, 7],
                        positionsArray[5, 0], positionsArray[5, 2], positionsArray[5, 4], positionsArray[5, 6],
                        positionsArray[6, 1], positionsArray[6, 3], positionsArray[6, 5], positionsArray[6, 7],
                        positionsArray[7, 0], positionsArray[7, 2], positionsArray[7, 4], positionsArray[7, 6]);

            Console.Write(theBoard);
        }

        #endregion

        #region New Game Method

        public void NewGame(string[,] positionsArray)
        {   
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    positionsArray[i, j] = "#";
                }
            }



            // Player 2 starting positions            
            positionsArray[0, 1] = positionsArray[0, 3] = positionsArray[0, 5] = positionsArray[0, 7] =
            positionsArray[1, 0] = positionsArray[1, 2] = positionsArray[1, 4] = positionsArray[1, 6] =
            positionsArray[2, 1] = positionsArray[2, 3] = positionsArray[2, 5] = positionsArray[2, 7] = " O ";

            // Blank starting squares            
            positionsArray[3, 0] = positionsArray[3, 2] = positionsArray[3, 4] = positionsArray[3, 6] =
            positionsArray[4, 1] = positionsArray[4, 3] = positionsArray[4, 5] = positionsArray[4, 7] = "   ";

            // Player 1 starting positions
            positionsArray[5, 0] = positionsArray[5, 2] = positionsArray[5, 4] = positionsArray[5, 6] =
            positionsArray[6, 1] = positionsArray[6, 3] = positionsArray[6, 5] = positionsArray[6, 7] =
            positionsArray[7, 0] = positionsArray[7, 2] = positionsArray[7, 4] = positionsArray[7, 6] = " X ";


            ///////////////////////////////// FOR TESTING PURPOSES ONLY /////////////////////////////
            //positionsArray[0, 1] = positionsArray[0, 3] = positionsArray[0, 5] = positionsArray[0, 7] =
            //positionsArray[1, 0] = positionsArray[1, 2] = positionsArray[1, 4] = positionsArray[1, 6] =
            //positionsArray[2, 1] = positionsArray[2, 3] = positionsArray[2, 5] = positionsArray[2, 7] =
            //positionsArray[3, 0] = positionsArray[3, 2] = positionsArray[3, 4] = positionsArray[3, 6] =
            //positionsArray[4, 1] = positionsArray[4, 3] = positionsArray[4, 5] = positionsArray[4, 7] =
            //positionsArray[5, 0] = positionsArray[5, 2] = positionsArray[5, 4] = positionsArray[5, 6] =
            //positionsArray[6, 1] = positionsArray[6, 3] = positionsArray[6, 5] = positionsArray[6, 7] =
            //positionsArray[7, 0] = positionsArray[7, 2] = positionsArray[7, 4] = positionsArray[7, 6] = "   ";

            //positionsArray[1, 2] = "|X|";
            //positionsArray[2, 1] = "|O|";
            ////positionsArray[2, 1] = " X ";
            ////positionsArray[5, 4] = " X ";
            ////positionsArray[6, 5] = "|O|";




            // Displays the starting positions and sets the player's turn to player 1
            DisplayTheBoard(positionsArray, true);            

            return;

        }

        #endregion

        #region End Game Method

        public bool IsThereAWinner()
        {            
            int fastTick = 150;
            int slowTick = 300;
            

            if ((playerOneCounter + playerOneKingCounter).Equals(0))
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Clear();
                    Thread.Sleep(slowTick);
                    Console.WriteLine(theWinnerIs);
                    Thread.Sleep(slowTick);
                }

                for (int i = 0; i < 100; i++)
                {
                    Console.Clear();
                    Thread.Sleep(fastTick);
                    Console.WriteLine(playerO);
                    Thread.Sleep(fastTick);
                }

                Console.Clear();
                Console.WriteLine("{0}\n{1}\n\nPlease press enter to return to the menu.", theWinnerIs, playerO);
                Console.ReadKey();
                return false;

            }

            if ((playerTwoCounter + playerTwoKingCounter).Equals(0))
            {
                for (int j = 0; j < 5; j++)
                {                    
                    Console.Clear();
                    Thread.Sleep(slowTick);
                    Console.WriteLine(theWinnerIs);
                    Thread.Sleep(slowTick);
                }

                for (int i = 0; i < 5; i++)
                {                    
                    Console.Clear();
                    Thread.Sleep(fastTick);
                    Console.WriteLine(playerX);
                    Thread.Sleep(fastTick);
                }

                Console.Clear();
                Console.WriteLine("{0}\n{1}\n\nPlease press enter to return to the menu.", theWinnerIs, playerX);
                Console.ReadKey();
                return false;
            }

            return true;

        }

        #endregion

        #region Private Methods

        private string CheckPlayerTurn(bool player1Turn)
        {
            if (player1Turn.Equals(true))
            {
                return "X";
            }
            else
            {
                return "O";
            }
        }

        private void CheckHowManyPiecesRemain(string[,] positionsArray)
        {
            playerOneCounter = playerTwoCounter = playerOneKingCounter = playerTwoKingCounter = 0;
            // Method loops through the array looking for each players pieces.
            // It adds 1 to a counter for each player when a piece is found
            // This allows the app to keep upto date with how many pieces remain on the board
            // For each player
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {                  
                    
                    if ((positionsArray[i, j]).Contains(" X "))
                    {
                        playerOneCounter = playerOneCounter + 1;

                    }
                   
                    if ((positionsArray[i, j]).Contains(" O "))
                    {
                        playerTwoCounter = playerTwoCounter + 1;

                    }

                    if ((positionsArray[i, j]).Contains("|X|"))
                    {
                        playerOneKingCounter = playerOneKingCounter + 1;

                    }

                    if ((positionsArray[i, j]).Contains("|O|"))
                    {
                        playerTwoKingCounter = playerTwoKingCounter + 1;

                    }
                }
            }           
        }      

        #endregion
    }
}
