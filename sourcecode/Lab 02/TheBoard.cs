using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    class TheBoard
    {
        //UndoRedoReplay undoRedoReplayTheBoard = new UndoRedoReplay();

        int playerOneCounter = 0;
        int playerTwoCounter = 0;

        int playerOneKingCounter = 0;
        int playerTwoKingCounter = 0;

        string theBoard;
        public string _player;




        public void ConsoleSettings()
        {
            // Sets the title
            Console.Title = ("Check, Check, Checkers....");

            // Sets the width and height of the console window
            int width = (Console.LargestWindowWidth - 100);
            int height = (Console.LargestWindowHeight - 10);            
            Console.SetWindowSize(width, height);            
        }

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
                    "     v          ╔╦╦╦╦╦╦╦╦═══════╦╦╦╦╦╦╦╦╦═══════╦╦╦╦╦╦╦╦╦═══════╦╦╦╦╦╦╦╦╦═══════╗\n" +
                    "     v      ╔═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║\n" +
                    "     v      ║ 0 ╠╬╬╬╬╬╬╬╣   {0}   ╠╬╬╬╬╬╬╬╣   {1}   ╠╬╬╬╬╬╬╬╣   {2}   ╠╬╬╬╬╬╬╬╣   {3}   ║       Player {4}'s turn.\n" +
                    "     v      ╚═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║\n" +
                    "     v          ╠╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╣\n" +
                    "     v      ╔═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣\n" +
                    "     v      ║ 1 ║   {5}   ╠╬╬╬╬╬╬╬╣   {6}   ╠╬╬╬╬╬╬╬╣   {7}   ╠╬╬╬╬╬╬╬╣   {8}   ╠╬╬╬╬╬╬╬╣\n" +
                    "     v      ╚═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣\n" +
                    "     v          ╠╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╣\n" +
                    "     v      ╔═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║\n" +
                    "     v      ║ 2 ╠╬╬╬╬╬╬╬╣   {9}   ╠╬╬╬╬╬╬╬╣   {10}   ╠╬╬╬╬╬╬╬╣   {11}   ╠╬╬╬╬╬╬╬╣   {12}   ║       Piece's Left:\n" +
                    "     v      ╚═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║       X  - {13}\n" +
                    "     v          ╠╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╣       O  - {14}\n" +
                    "     v      ╔═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣\n" +
                    "     v      ║ 3 ║   {15}   ╠╬╬╬╬╬╬╬╣   {16}   ╠╬╬╬╬╬╬╬╣   {17}   ╠╬╬╬╬╬╬╬╣   {18}   ╠╬╬╬╬╬╬╬╣       King's Left:\n" +
                    "     v      ╚═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣      |X| - {19}\n" +
                    "  [Y-Axis]      ╠╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╣      |O| - {20}\n" +
                    "     v      ╔═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║\n" +
                    "     v      ║ 4 ╠╬╬╬╬╬╬╬╣   {21}   ╠╬╬╬╬╬╬╬╣   {22}   ╠╬╬╬╬╬╬╬╣   {23}   ╠╬╬╬╬╬╬╬╣   {24}   ║\n" +
                    "     v      ╚═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║\n" +
                    "     v          ╠╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╣\n" +
                    "     v      ╔═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣\n" +
                    "     v      ║ 5 ║   {25}   ╠╬╬╬╬╬╬╬╣   {26}   ╠╬╬╬╬╬╬╬╣   {27}   ╠╬╬╬╬╬╬╬╣   {28}   ╠╬╬╬╬╬╬╬╣\n" +
                    "     v      ╚═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣\n" +
                    "     v          ╠╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╣\n" +
                    "     v      ╔═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║\n" +
                    "     v      ║ 6 ╠╬╬╬╬╬╬╬╣   {29}   ╠╬╬╬╬╬╬╬╣   {30}   ╠╬╬╬╬╬╬╬╣   {31}   ╠╬╬╬╬╬╬╬╣   {32}   ║\n" +
                    "     v      ╚═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║\n" +
                    "     v          ╠╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╣\n" +
                    " v v v v v  ╔═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣\n" +
                    "   v v v    ║ 7 ║   {33}   ╠╬╬╬╬╬╬╬╣   {34}   ╠╬╬╬╬╬╬╬╣   {35}   ╠╬╬╬╬╬╬╬╣   {36}   ╠╬╬╬╬╬╬╬╣\n" +
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
                    "", positionsArray[0, 1], positionsArray[0, 3], positionsArray[0, 5], positionsArray[0, 7], 
                        _player,
                        positionsArray[1, 0], positionsArray[1, 2], positionsArray[1, 4], positionsArray[1, 6],
                        positionsArray[2, 1], positionsArray[2, 3], positionsArray[2, 5], positionsArray[2, 7],
                        playerOneCounter, playerTwoCounter,                    
                        positionsArray[3, 0], positionsArray[3, 2], positionsArray[3, 4], positionsArray[3, 6],
                        playerOneKingCounter, playerTwoKingCounter,
                        positionsArray[4, 1], positionsArray[4, 3], positionsArray[4, 5], positionsArray[4, 7],
                        positionsArray[5, 0], positionsArray[5, 2], positionsArray[5, 4], positionsArray[5, 6],
                        positionsArray[6, 1], positionsArray[6, 3], positionsArray[6, 5], positionsArray[6, 7],
                        positionsArray[7, 0], positionsArray[7, 2], positionsArray[7, 4], positionsArray[7, 6]);

            Console.Write(theBoard);
            
                


        }

        public void NewGame(string[,] positionsArray)
        {
            // NEED MOVED
            //undoRedoReplay.undoStack.Clear();
            //undoRedoReplay.redoStack.Clear();
            //undoRedoReplay.replayQueue.Clear();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    positionsArray[i, j] = "#";
                }
            }



            //// Player 2 starting positions            
            //positionsArray[0, 1] = positionsArray[0, 3] = positionsArray[0, 5] = positionsArray[0, 7] =
            //positionsArray[1, 0] = positionsArray[1, 2] = positionsArray[1, 4] = positionsArray[1, 6] =
            //positionsArray[2, 1] = positionsArray[2, 3] = positionsArray[2, 5] = positionsArray[2, 7] = "O";

            //// Blank starting squares            
            //positionsArray[3, 0] = positionsArray[3, 2] = positionsArray[3, 4] = positionsArray[3, 6] =
            //positionsArray[4, 1] = positionsArray[4, 3] = positionsArray[4, 5] = positionsArray[4, 7] = " ";

            //// Player 1 starting positions
            //positionsArray[5, 0] = positionsArray[5, 2] = positionsArray[5, 4] = positionsArray[5, 6] =
            //positionsArray[6, 1] = positionsArray[6, 3] = positionsArray[6, 5] = positionsArray[6, 7] =
            //positionsArray[7, 0] = positionsArray[7, 2] = positionsArray[7, 4] = positionsArray[7, 6] = "X";


            /////////////////////////////// FOR TESTING PURPOSES ONLY /////////////////////////////
            positionsArray[0, 1] = positionsArray[0, 3] = positionsArray[0, 5] = positionsArray[0, 7] =
            positionsArray[1, 0] = positionsArray[1, 2] = positionsArray[1, 4] = positionsArray[1, 6] =
            positionsArray[2, 1] = positionsArray[2, 3] = positionsArray[2, 5] = positionsArray[2, 7] =
            positionsArray[3, 0] = positionsArray[3, 2] = positionsArray[3, 4] = positionsArray[3, 6] =
            positionsArray[4, 1] = positionsArray[4, 3] = positionsArray[4, 5] = positionsArray[4, 7] =
            positionsArray[5, 0] = positionsArray[5, 2] = positionsArray[5, 4] = positionsArray[5, 6] =
            positionsArray[6, 1] = positionsArray[6, 3] = positionsArray[6, 5] = positionsArray[6, 7] =
            positionsArray[7, 0] = positionsArray[7, 2] = positionsArray[7, 4] = positionsArray[7, 6] = " ";

            positionsArray[7, 0] = "X";
            positionsArray[5, 4] = "X";
            positionsArray[3, 2] = "X";
            positionsArray[1, 2] = "X";
            positionsArray[0, 3] = "O";

            


            // Displays the starting positions and sets the player's turn to player 1
            DisplayTheBoard(positionsArray, true);            

            return;

        }

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
                    
                    if ((positionsArray[i, j]).Contains("X"))
                    {
                        playerOneCounter = playerOneCounter + 1;

                    }
                   
                    if ((positionsArray[i, j]).Contains("O"))
                    {
                        playerTwoCounter = playerTwoCounter + 1;

                    }

                    if ((positionsArray[i, j]).Contains("X"))
                    {
                        playerOneKingCounter = playerOneKingCounter + 1;

                    }

                    if ((positionsArray[i, j]).Contains("O"))
                    {
                        playerTwoKingCounter = playerTwoKingCounter + 1;

                    }

                }
            }
        }

        #endregion

    }
}
