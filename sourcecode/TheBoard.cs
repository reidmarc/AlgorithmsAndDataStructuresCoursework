//////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////// Class TheBoard ///////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////// Code Written By: Marc Reid [03001588] ////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////

// Description:
// This class provides methods which deal with the command line interface,
// The displaying of the score, the winning screens and the console settings



#region Usings

using System;
using System.Threading;

#endregion

namespace Coursework
{  
    public class TheBoard
    {
        #region Variables

        private int _playerOneCounter = 0;
        private int _playerTwoCounter = 0;
         
        private int _playerOneKingCounter = 0;
        private int _playerTwoKingCounter = 0;
         
        private int _playerOneWins = 0;
        private int _playerTwoWins = 0;
        private int _totalDraws = 0;
        private int _totalGames = 0;
        
        private int _fastTick = 150;
        private int _slowTick = 300;
        
        private string _stringPlayerOneCounter;
        private string _stringPlayerTwoCounter;
        private string _stringPlayerOneKingCounter;
        private string _stringPlayerTwoKingCounter;
        private string _stringPlayerOneWins;
        private string _stringPlayerTwoWins;
        private string _stringTotalGames;
        private string _stringTotalDraws;
        private string _theBoard;

        public string player;

        private const string _theWinnerIs = ("\n\n _____ _          \n|_   _| |         \n  | | | |__   ___ \n  | | | '_ \\ / _ \\\n  | | | | | |  __/\n  \\_/ |_| |_|\\___|\n\n\n _    _ _                       \n| |  | (_)                      \n| |  | |_ _ __  _ __   ___ _ __ \n| |/\\| | | '_ \\| '_ \\ / _ \\ '__|\n\\  /\\  / | | | | | | |  __/ |   \n \\/  \\/|_|_| |_|_| |_|\\___|_|   \n\n\n _     \n(_)    \n _ ___ \n| / __|\n| \\__ \\\n|_|___/\n");
        private const string _playerX = ("\n\n______ _                        __   __\n| ___ \\ |                       \\ \\ / /\n| |_/ / | __ _ _   _  ___ _ __   \\ V / \n|  __/| |/ _` | | | |/ _ \\ '__|  /   \\ \n| |   | | (_| | |_| |  __/ |    / /^\\ \\\n\\_|   |_|\\__,_|\\__, |\\___|_|    \\/   \\/\n                __/ |                  \n               |___/                   \n\n\n\n");
        private const string _playerO = ("\n\n______ _                         _____ \n| ___ \\ |                       |  _  |\n| |_/ / | __ _ _   _  ___ _ __  | | | |\n|  __/| |/ _` | | | |/ _ \\ '__| | | | |\n| |   | | (_| | |_| |  __/ |    \\ \\_/ /\n\\_|   |_|\\__,_|\\__, |\\___|_|     \\___/ \n                __/ |                  \n               |___/                   \n\n\n\n");

        #endregion

        #region Console Settings Method

        /// <summary>
        /// Method which sets up the console how I want it
        /// </summary>
        public void ConsoleSettings()
        {
            // Sets the title
            Console.Title = ("Check, Check, Checkers.... Marc Reid [03001588]");

            // Sets the width and height of the console window 
            int width = (Console.LargestWindowWidth - 75);
            int height = (Console.LargestWindowHeight - 10);
            Console.SetWindowSize(width, height);            
        }

        #endregion

        #region Display and Update the Board Methods

        /// <summary>
        /// Method updates the array when the Undo, Redo or Replay features are used.
        /// Passes in the positionsArray which holds the current positions for the board
        /// And the array savdPositions which are the positions retrieved from the stack or queue
        /// Depending on which feature is being used. 
        /// </summary>
        /// <param name="positionsArray"> The array which stores the current playing piece positions</param>
        /// <param name="savedPositions"> The array which stores the playing piece positions that are going to update positionsArray with</param>
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

            // Retrieves the which player made the last move, to display.
            player = savedPositions[64];
        }



        /// <summary>
        /// Method displays the board from the current values retrieved from the array
        /// </summary>
        /// <param name="positionsArray"> The array which stores the current playing piece positions</param>
        /// <param name="player1Turn"> Indicates whose turn it is</param>
        public void DisplayTheBoard(string[,] positionsArray, bool player1Turn)
        {   
            player = CheckPlayerTurn(player1Turn);

            Console.Clear();
            CheckHowManyPiecesRemain(positionsArray);
            FormatScoreOutput();
            TotalGames();

            _theBoard = string.Format("" +
                    "     v          ╔╦╦╦╦╦╦╦╦═══════╦╦╦╦╦╦╦╦╦═══════╦╦╦╦╦╦╦╦╦═══════╦╦╦╦╦╦╦╦╦═══════╗    ╔═════════════════╗      \n" +
                    "     v      ╔═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║    ║ Player {0}'s turn ║    \n" +
                    "     v      ║ 0 ╠╬╬╬╬╬╬╬╣  {1}  ╠╬╬╬╬╬╬╬╣  {2}  ╠╬╬╬╬╬╬╬╣  {3}  ╠╬╬╬╬╬╬╬╣  {4}  ║    ╚═════════════════╝      \n" +
                    "     v      ╚═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║\n" +
                    "     v          ╠╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╣\n" +
                    "     v      ╔═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣    ╔═════════════════╗      \n" +
                    "     v      ║ 1 ║  {5}  ╠╬╬╬╬╬╬╬╣  {6}  ╠╬╬╬╬╬╬╬╣  {7}  ╠╬╬╬╬╬╬╬╣  {8}  ╠╬╬╬╬╬╬╬╣    ║ Piece's Left    ║      \n" +
                    "     v      ╚═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣    ╠═════════════════╣      \n" +
                    "     v          ╠╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╣    ║  X  - {9}        ║     \n" +
                    "     v      ╔═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║    ║  O  - {10}        ║    \n" +
                    "     v      ║ 2 ╠╬╬╬╬╬╬╬╣  {11}  ╠╬╬╬╬╬╬╬╣  {12}  ╠╬╬╬╬╬╬╬╣  {13}  ╠╬╬╬╬╬╬╬╣  {14}  ║    ╚═════════════════╝  \n" +
                    "     v      ╚═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║\n" +
                    "     v          ╠╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╣\n" +
                    "     v      ╔═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣    ╔═════════════════╗      \n" +
                    "     v      ║ 3 ║  {15}  ╠╬╬╬╬╬╬╬╣  {16}  ╠╬╬╬╬╬╬╬╣  {17}  ╠╬╬╬╬╬╬╬╣  {18}  ╠╬╬╬╬╬╬╬╣    ║ King's Left     ║  \n" +
                    "     v      ╚═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣    ╠═════════════════╣      \n" +
                    "  [Y-Axis]      ╠╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╣    ║ |X| - {19}        ║    \n" +
                    "     v      ╔═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║    ║ |O| - {20}        ║    \n" +
                    "     v      ║ 4 ╠╬╬╬╬╬╬╬╣  {21}  ╠╬╬╬╬╬╬╬╣  {22}  ╠╬╬╬╬╬╬╬╣  {23}  ╠╬╬╬╬╬╬╬╣  {24}  ║    ╚═════════════════╝  \n" +
                    "     v      ╚═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║\n" +
                    "     v          ╠╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╣\n" +
                    "     v      ╔═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣    ╔═════════════════╗      \n" +
                    "     v      ║ 5 ║  {25}  ╠╬╬╬╬╬╬╬╣  {26}  ╠╬╬╬╬╬╬╬╣  {27}  ╠╬╬╬╬╬╬╬╣  {28}  ╠╬╬╬╬╬╬╬╣    ║ Session Info    ║  \n" +
                    "     v      ╚═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣    ╠═════════════════╣      \n" +
                    "     v          ╠╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╣    ║ X Won - {37}     ║     \n" +
                    "     v      ╔═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║    ║ O Won - {38}     ║     \n" +
                    "     v      ║ 6 ╠╬╬╬╬╬╬╬╣  {29}  ╠╬╬╬╬╬╬╬╣  {30}  ╠╬╬╬╬╬╬╬╣  {31}  ╠╬╬╬╬╬╬╬╣  {32}  ║    ║ Draws - {40}     ║ \n" +
                    "     v      ╚═══╬╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ║    ╠═════════════════╣      \n" +
                    "     v          ╠╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╬╩╩╩╩╩╩╩╬╦╦╦╦╦╦╦╣    ║ Total - {39}    ║      \n" +
                    " v v v v v  ╔═══╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣       ╠╬╬╬╬╬╬╬╣    ╚═════════════════╝      \n" +
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
                    "", player,
                        positionsArray[0, 1], positionsArray[0, 3], positionsArray[0, 5], positionsArray[0, 7],
                        positionsArray[1, 0], positionsArray[1, 2], positionsArray[1, 4], positionsArray[1, 6],
                        _stringPlayerOneCounter, _stringPlayerTwoCounter,
                        positionsArray[2, 1], positionsArray[2, 3], positionsArray[2, 5], positionsArray[2, 7],
                        positionsArray[3, 0], positionsArray[3, 2], positionsArray[3, 4], positionsArray[3, 6],
                        _stringPlayerOneKingCounter, _stringPlayerTwoKingCounter,
                        positionsArray[4, 1], positionsArray[4, 3], positionsArray[4, 5], positionsArray[4, 7],
                        positionsArray[5, 0], positionsArray[5, 2], positionsArray[5, 4], positionsArray[5, 6],
                        positionsArray[6, 1], positionsArray[6, 3], positionsArray[6, 5], positionsArray[6, 7],
                        positionsArray[7, 0], positionsArray[7, 2], positionsArray[7, 4], positionsArray[7, 6],
                        _stringPlayerOneWins, _stringPlayerTwoWins, _stringTotalGames, _stringTotalDraws);

            Console.Write(_theBoard);
        }

        #endregion

        #region New Game Method

        /// <summary>
        /// Method sets the values in the array to the starting positions
        /// </summary>
        /// <param name="positionsArray"> The array which stores the current playing piece positions</param>
        public void NewGame(string[,] positionsArray)
        {
            // Loops through the array and fills every index with a # 
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

            // Displays the starting positions and sets the player's turn to player 1
            DisplayTheBoard(positionsArray, true);

            return;
        }

        #endregion

        #region End Game Methods
        
        /// <summary>
        /// Method checks if an A.I. vs A.I. game is a draw
        /// </summary>
        public void IsItADraw()
        {
            _totalDraws = _totalDraws + 1;
        }

        /// <summary>
        /// Method checks for a winner
        /// </summary>
        /// <returns> A boolean value depending on if there is a winner or not</returns>
        public bool IsThereAWinner()
        {   
            if ((_playerOneCounter + _playerOneKingCounter).Equals(0))
            {
                Thread.Sleep(_slowTick);
                PlayerOWinningMessage();
                return true;
            }

            if ((_playerTwoCounter + _playerTwoKingCounter).Equals(0))
            {
                Thread.Sleep(_slowTick);
                PlayerXWinningMessage();
                return true;
            }

            return false;
        }


        /// <summary>
        /// Method to display the winning message, if player X wins
        /// </summary>
        public void PlayerXWinningMessage()
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Clear();
                Thread.Sleep(_slowTick);
                Console.WriteLine(_theWinnerIs);
                Thread.Sleep(_slowTick);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Thread.Sleep(_fastTick);
                Console.WriteLine(_playerX);
                Thread.Sleep(_fastTick);
            }

            Console.Clear();
            Console.WriteLine("{0}\n{1}\n\nPlease press enter to return to the menu.", _theWinnerIs, _playerX);
            _playerOneWins = _playerOneWins + 1;
            Console.ReadKey();            
        }


        /// <summary>
        /// Method to display the winning message, if player O wins
        /// </summary>
        public void PlayerOWinningMessage()
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Clear();
                Thread.Sleep(_slowTick);
                Console.WriteLine(_theWinnerIs);
                Thread.Sleep(_slowTick);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Thread.Sleep(_fastTick);
                Console.WriteLine(_playerO);
                Thread.Sleep(_fastTick);
            }

            Console.Clear();
            Console.WriteLine("{0}\n{1}\n\nPlease press enter to return to the menu.", _theWinnerIs, _playerO);
            _playerTwoWins = _playerTwoWins + 1;
            Console.ReadKey();            
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method that calculates the total number of games from each players win totals
        /// </summary>
        private void TotalGames()
        {
            _totalGames = _playerOneWins + _playerTwoWins + _totalDraws;
        }


        /// <summary>
        /// Method which checks which players turn it is
        /// </summary>
        /// <param name="player1Turn"> boolean indicating if its player 1's turn or not</param>
        /// <returns> Returns a different string depending on whose turn it currently is</returns>
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

        

        /// <summary>
        /// This method deals with a formatting issue that occurs when the number of characters displayed changes (i.e. from 9 to 10)
        /// As it moves the borders.
        /// </summary>
        private void FormatScoreOutput()
        {
            // Fixes formatting issue when the number of player X's normal pieces goes from double figures to single
            if (_playerOneCounter < 10)
            {
                _stringPlayerOneCounter = ("" + _playerOneCounter + " ").ToString();
            }
            else
            {
                _stringPlayerOneCounter = _playerOneCounter.ToString();
            }

            // Fixes formatting issue when the number of player O's normal pieces goes from double figures to single
            if (_playerTwoCounter < 10)
            {
                _stringPlayerTwoCounter = ("" + _playerTwoCounter + " ").ToString();
            }
            else
            {
                _stringPlayerTwoCounter = _playerTwoCounter.ToString();
            }

            // Fixes formatting issue when the number of player X's kings pieces goes from single figures to double
            if (_playerOneKingCounter < 10)
            {
                _stringPlayerOneKingCounter = ("" + _playerOneKingCounter + " ");
            }
            else
            {
                _stringPlayerOneKingCounter = _playerOneKingCounter.ToString();
            }

            // Fixes formatting issue when the number of player O's kings pieces goes from single figures to double
            if (_playerTwoKingCounter < 10)
            {
                _stringPlayerTwoKingCounter = ("" + _playerTwoKingCounter + " ");
            }
            else
            {
                _stringPlayerTwoKingCounter = _playerTwoKingCounter.ToString();
            }

            // If the value for playerOneWins is a single digit or double digit
            // This statement deals with a formatting issue
            if (_playerOneWins < 10)
            {
                _stringPlayerOneWins = ("" + _playerOneWins + "  ");                
            }
            else if ((_playerOneWins > 9) && (_playerOneWins < 100))
            {
                _stringPlayerOneWins = ("" + _playerOneWins + " ");
            }
            else
            {
                _stringPlayerOneWins = _playerOneWins.ToString();
            }

            // If the value for playerTwoWins is a single digit or double digit
            // This statement deals with a formatting issue
            if (_playerTwoWins < 10)
            {
                _stringPlayerTwoWins = ("" + _playerTwoWins + "  ");
            }
            else if ((_playerTwoWins > 9) && (_playerTwoWins < 100))
            {
                _stringPlayerTwoWins = ("" + _playerTwoWins + " ");
            }
            else
            {
                _stringPlayerTwoWins = _playerTwoWins.ToString();
            }

            // If the value for totalDraws is a single digit or double digit
            // This statement deals with a formatting issue
            if (_totalDraws < 10)
            {
                _stringTotalDraws = ("" + _totalDraws + "  ");
            }
            else if ((_totalDraws > 9) && (_totalDraws < 100))
            {
                _stringTotalDraws = ("" + _totalDraws + " ");
            }
            else
            {
                _stringTotalDraws = _totalDraws.ToString();
            }

            // If the value for totalGames is a single digit or double digit or triple
            // This statement deals with a formatting issue
            if (_totalGames < 10)
            {
                _stringTotalGames = ("" + _totalGames + "   ");
            }
            else if ((_totalGames > 9) && (_totalGames < 100))
            {
                _stringTotalGames = ("" + _totalGames + "  ");
            }
            else if ((_totalGames > 99) && (_totalGames < 1000))
            {
                _stringTotalGames = ("" + _totalGames + " ");
            }
            else
            {
                _stringTotalGames = _totalGames.ToString();
            }
        }

        /// <summary>
        /// Method checks how many pieces each player has on the board at that time
        /// </summary>
        /// <param name="positionsArray"> The array which stores all the positions on the playing pieces</param>
        private void CheckHowManyPiecesRemain(string[,] positionsArray)
        {
            _playerOneCounter = _playerTwoCounter = _playerOneKingCounter = _playerTwoKingCounter = 0;
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
                        _playerOneCounter = _playerOneCounter + 1;

                    }

                    if ((positionsArray[i, j]).Contains(" O "))
                    {
                        _playerTwoCounter = _playerTwoCounter + 1;

                    }

                    if ((positionsArray[i, j]).Contains("|X|"))
                    {
                        _playerOneKingCounter = _playerOneKingCounter + 1;

                    }

                    if ((positionsArray[i, j]).Contains("|O|"))
                    {
                        _playerTwoKingCounter = _playerTwoKingCounter + 1;

                    }
                }
            }
        }

        #endregion
    }
}
