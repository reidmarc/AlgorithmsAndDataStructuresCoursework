using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables / Objects / Collections

        Player playerOb =  new Player();
        UserVerification userVerification = new UserVerification();
        UndoRedoReplay undoRedoReplay = new UndoRedoReplay();

        // 2D array to map store the piece locations
        string[,] positionsArray = new string[8, 8];        


        public const string playerOne = "X";       
        public const string playerTwo = "O";
        public const string playerOneKing = "Ẍ"; // Ӿ Ӝ Ẍ
        public const string playerTwoKing = "Ӧ"; // Ѻ Ӫ Ӧ         

        int firstClickY;
        int firstClickX;

        int counterReplayOne = 0;
        int counterReplayTwo = 0;

        bool player1Turn;

        public bool canMove = false;


        //bool isKing;

        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();

            player1Turn = NewGame();            
            RefreshBoard();
            turnTxtBlock.Text = "Player X";
            undoRedoReplay.StoreTheMovePositions(positionsArray, player1Turn);
        }

        #endregion

        #region Board Methods

        public bool NewGame()
        {
            undoRedoReplay.undoStack.Clear();
            undoRedoReplay.redoStack.Clear();
            undoRedoReplay.replayQueue.Clear();

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
            //positionsArray[2, 1] = positionsArray[2, 3] = positionsArray[2, 5] = positionsArray[2, 7] = playerTwo;

            //// Blank starting squares            
            //positionsArray[3, 0] = positionsArray[3, 2] = positionsArray[3, 4] = positionsArray[3, 6] =
            //positionsArray[4, 1] = positionsArray[4, 3] = positionsArray[4, 5] = positionsArray[4, 7] = string.Empty;

            //// Player 1 starting positions
            //positionsArray[5, 0] = positionsArray[5, 2] = positionsArray[5, 4] = positionsArray[5, 6] =
            //positionsArray[6, 1] = positionsArray[6, 3] = positionsArray[6, 5] = positionsArray[6, 7] =
            //positionsArray[7, 0] = positionsArray[7, 2] = positionsArray[7, 4] = positionsArray[7, 6] = playerOne;


            /////////////////////////////// FOR TESTING PURPOSES ONLY /////////////////////////////


            positionsArray[0, 1] = positionsArray[0, 3] = positionsArray[0, 5] = positionsArray[0, 7] =
            positionsArray[1, 0] = positionsArray[1, 2] = positionsArray[1, 4] = positionsArray[1, 6] =
            positionsArray[2, 1] = positionsArray[2, 3] = positionsArray[2, 5] = positionsArray[2, 7] =
            positionsArray[3, 0] = positionsArray[3, 2] = positionsArray[3, 4] = positionsArray[3, 6] =
            positionsArray[4, 1] = positionsArray[4, 3] = positionsArray[4, 5] = positionsArray[4, 7] =
            positionsArray[5, 0] = positionsArray[5, 2] = positionsArray[5, 4] = positionsArray[5, 6] =
            positionsArray[6, 1] = positionsArray[6, 3] = positionsArray[6, 5] = positionsArray[6, 7] =
            positionsArray[7, 0] = positionsArray[7, 2] = positionsArray[7, 4] = positionsArray[7, 6] = string.Empty;

            positionsArray[7, 6] = playerOne;
            positionsArray[0, 1] = playerTwo;
            //positionsArray[3, 4] = playerTwo;
            //positionsArray[1, 6] = playerTwo;
            //positionsArray[1, 4] = playerTwo;

            return true;

        }

        private void RefreshBoard()
        {

            POS01.Content = positionsArray[0, 1];
            POS03.Content = positionsArray[0, 3];
            POS05.Content = positionsArray[0, 5];
            POS07.Content = positionsArray[0, 7];

            POS10.Content = positionsArray[1, 0];
            POS12.Content = positionsArray[1, 2];
            POS14.Content = positionsArray[1, 4];
            POS16.Content = positionsArray[1, 6];

            POS21.Content = positionsArray[2, 1];
            POS23.Content = positionsArray[2, 3];
            POS25.Content = positionsArray[2, 5];
            POS27.Content = positionsArray[2, 7];

            POS30.Content = positionsArray[3, 0];
            POS32.Content = positionsArray[3, 2];
            POS34.Content = positionsArray[3, 4];
            POS36.Content = positionsArray[3, 6];

            POS41.Content = positionsArray[4, 1];
            POS43.Content = positionsArray[4, 3];
            POS45.Content = positionsArray[4, 5];
            POS47.Content = positionsArray[4, 7];

            POS50.Content = positionsArray[5, 0];
            POS52.Content = positionsArray[5, 2];
            POS54.Content = positionsArray[5, 4];
            POS56.Content = positionsArray[5, 6];

            POS61.Content = positionsArray[6, 1];
            POS63.Content = positionsArray[6, 3];
            POS65.Content = positionsArray[6, 5];
            POS67.Content = positionsArray[6, 7];

            POS70.Content = positionsArray[7, 0];
            POS72.Content = positionsArray[7, 2];
            POS74.Content = positionsArray[7, 4];
            POS76.Content = positionsArray[7, 6]; 
        }

        private void ClearTheBoard()
        {
            // A loop which clears the array and content displayed in the buttons on the grid
            GameBoard.Children.Cast<Button>().ToList().ForEach(button =>
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        positionsArray[i, j] = string.Empty;
                        button.Content = string.Empty;
                    }
                }

            });

            NewGame();
            RefreshBoard();
        }

        #endregion

        #region Event Handlers

        #region UndoRedoReplay Click Events

        private void undoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (undoRedoReplay.RetrieveTheUndoMovePositions(positionsArray, player1Turn).Equals(true))
            {
                canMove = false;
                firstClickY = 0;
                firstClickX = 0;
                turnTxtBlock.Text = undoRedoReplay.turnTxtBlock;
                player1Turn = undoRedoReplay.player1TurnUndo;
            }  
            RefreshBoard();
            return;
        }

        private void redoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (undoRedoReplay.RetrieveTheRedoMovePositions(positionsArray).Equals(true))
            {
                canMove = false;
                firstClickY = 0;
                firstClickX = 0;
                turnTxtBlock.Text = undoRedoReplay.turnTxtBlock;
                player1Turn = undoRedoReplay.player1TurnUndo;
            }
            RefreshBoard();
            return;
        }

        private void replayBtn_Click(object sender, RoutedEventArgs e)
        {
            

            if (counterReplayOne > 0 || userVerification.ReplayGameVerification().Equals(true))
            {
                counterReplayOne = counterReplayOne + 1;
               
                undoRedoReplay.RetrieveTheReplayMovePositions(positionsArray);
                

                int milliseconds = 500;
                Thread.Sleep(milliseconds);

                
                undoBtn.IsEnabled = false;
                redoBtn.IsEnabled = false;
                resetBtn.IsEnabled = false;
                endBtn.IsEnabled = false;

                POS01.IsEnabled = false;
                POS03.IsEnabled = false;
                POS05.IsEnabled = false;
                POS07.IsEnabled = false;

                POS10.IsEnabled = false;
                POS12.IsEnabled = false;
                POS14.IsEnabled = false;
                POS16.IsEnabled = false;

                POS21.IsEnabled = false;
                POS23.IsEnabled = false;
                POS25.IsEnabled = false;
                POS27.IsEnabled = false;

                POS30.IsEnabled = false;
                POS32.IsEnabled = false;
                POS34.IsEnabled = false;
                POS36.IsEnabled = false;

                POS41.IsEnabled = false;
                POS43.IsEnabled = false;
                POS45.IsEnabled = false;
                POS47.IsEnabled = false;

                POS50.IsEnabled = false;
                POS52.IsEnabled = false;
                POS54.IsEnabled = false;
                POS56.IsEnabled = false;

                POS61.IsEnabled = false;
                POS63.IsEnabled = false;
                POS65.IsEnabled = false;
                POS67.IsEnabled = false;

                POS70.IsEnabled = false;
                POS72.IsEnabled = false;
                POS74.IsEnabled = false;
                POS76.IsEnabled = false;




                if (undoRedoReplay.replayQueue.Count.Equals(0))
                {
                    counterReplayTwo = counterReplayTwo + 1;

                    

                    if (counterReplayTwo > 1)
                    {
                        MessageBox.Show("There are no more moves to be 'replayed'");

                        undoBtn.IsEnabled = true;
                        redoBtn.IsEnabled = true;
                        resetBtn.IsEnabled = true;
                        endBtn.IsEnabled = true;



                        POS01.IsEnabled = true;
                        POS03.IsEnabled = true;
                        POS05.IsEnabled = true;
                        POS07.IsEnabled = true;

                        POS10.IsEnabled = true;
                        POS12.IsEnabled = true;
                        POS14.IsEnabled = true;
                        POS16.IsEnabled = true;

                        POS21.IsEnabled = true;
                        POS23.IsEnabled = true;
                        POS25.IsEnabled = true;
                        POS27.IsEnabled = true;

                        POS30.IsEnabled = true;
                        POS32.IsEnabled = true;
                        POS34.IsEnabled = true;
                        POS36.IsEnabled = true;

                        POS41.IsEnabled = true;
                        POS43.IsEnabled = true;
                        POS45.IsEnabled = true;
                        POS47.IsEnabled = true;

                        POS50.IsEnabled = true;
                        POS52.IsEnabled = true;
                        POS54.IsEnabled = true;
                        POS56.IsEnabled = true;

                        POS61.IsEnabled = true;
                        POS63.IsEnabled = true;
                        POS65.IsEnabled = true;
                        POS67.IsEnabled = true;

                        POS70.IsEnabled = true;
                        POS72.IsEnabled = true;
                        POS74.IsEnabled = true;
                        POS76.IsEnabled = true;
                    }
                }

                canMove = false;
                firstClickY = 0;
                firstClickX = 0;
                turnTxtBlock.Text = undoRedoReplay.turnTxtBlock;
                player1Turn = undoRedoReplay.player1TurnUndo;

                RefreshBoard();

            }
            else
            {
                return;
            }
        }

        #endregion

        #region Quality of Life Buttons

        // Click event which calls the method RestartGameVerification() when the 'Restart Game' button is clicked
        // A boolean value based on the users selection is returned to this click event
        private void restartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (userVerification.RestartGameVerification().Equals(true))
            {
                // Clears the board and resets the pieces
                ClearTheBoard();

                // Sets it back to player 1's turn
                player1Turn = true;

                // Sets the textbox to Player X indicating who's turn it is
                turnTxtBlock.Text = "Player X";

                undoBtn.IsEnabled = true;
                redoBtn.IsEnabled = true;
                resetBtn.IsEnabled = true;
                endBtn.IsEnabled = true;
            }
            else
            {
                return;
            }
        }

        // Click event which calls the method ExitApplicationVerification() when the 'Exit Application' button is clicked
        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {            
            userVerification.ExitApplicationVerification();
        }   

        // Click event which calls the method ResetMoveVerification() when the 'Reset Turn' button is clicked
        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            userVerification.ResetMoveVerification(player1Turn, canMove, playerOne, playerTwo);
        }

        // Click event which calls the method EndMoveVerification() when the 'End Turn' button is clicked
        // A boolean value based on the users selection is returned to this click event
        private void endBtn_Click(object sender, RoutedEventArgs e)
        { 
            if(userVerification.EndMoveVerification(player1Turn, playerOne, playerTwo).Equals(true))
            {
                string player;

                canMove = false;

                if (player1Turn.Equals(false))
                {
                    player = playerOne;
                }
                else
                {
                    player = playerTwo;
                }

                turnTxtBlock.Text = "Player " + player + "";
            }
            
            return;
        }

        #endregion



        private void Playable_Square_Click(object sender, RoutedEventArgs e)
        {
            bool forcedCapture = false;
            

            // A list to store the potential 'takes' that must be chosen from
            List<int> listOfForcedMoves = new List<int>();

            var button = (Button)sender;

            // Removes the POS from the start of the button            
            string btnClicked = button.Name.Replace("POS", "").ToString();            

            // Returns the Y co-ord as an int
            int yPos = ConvertButtonNameToIntY(btnClicked);

            // Returns the X co-ord as an int
            int xPos = ConvertButtonNameToIntX(btnClicked);

            if (player1Turn)
            {
                if (canMove.Equals(false))
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if ((positionsArray[i, j]).Contains(playerOne))
                            {
                                if (playerOb.CanAPieceBeCapturedRight(i, j, positionsArray, playerOne).Equals(true))
                                {
                                    int potentialMove = Convert.ToInt32(string.Format("{0}{1}", i, j));
                                    listOfForcedMoves.Add(potentialMove);

                                    
                                    forcedCapture = true;
                                }
                                if (playerOb.CanAPieceBeCapturedLeft(i, j, positionsArray, playerOne).Equals(true))
                                {
                                    int potentialMove = Convert.ToInt32(string.Format("{0}{1}", i, j));
                                    listOfForcedMoves.Add(potentialMove);


                                    
                                    forcedCapture = true;
                                }
                            }
                        }
                    }

                    if (forcedCapture.Equals(true))
                    {

                        int potentialMoveCheck = Convert.ToInt32(string.Format("{0}{1}", yPos, xPos));

                        if (listOfForcedMoves.Contains(potentialMoveCheck))
                        {
                            PlayerMove(yPos, xPos, playerOne);                            
                            return;
                        }
                        else
                        {
                            MessageBox.Show("You must 'take' your opponents piece");

                            return;
                        }
                    } 
                }

                PlayerMove(yPos, xPos, playerOne);                
            }
            else
            {
                if (canMove.Equals(false))
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if ((positionsArray[i, j]).Contains(playerTwo))
                            {
                                if (playerOb.CanAPieceBeCapturedRight(i, j, positionsArray, playerTwo).Equals(true))
                                {
                                    int potentialMove = Convert.ToInt32(string.Format("{0}{1}", i, j));
                                    listOfForcedMoves.Add(potentialMove);

                                    
                                    forcedCapture = true;
                                    
                                }
                                if (playerOb.CanAPieceBeCapturedLeft(i, j, positionsArray, playerTwo).Equals(true))
                                {
                                    int potentialMove = Convert.ToInt32(string.Format("{0}{1}", i, j));
                                    listOfForcedMoves.Add(potentialMove);


                                    
                                    forcedCapture = true;
                                }
                            }
                        }
                    }

                    if (forcedCapture.Equals(true))
                    {

                        int potentialMoveCheck = Convert.ToInt32(string.Format("{0}{1}", yPos, xPos));

                        if (listOfForcedMoves.Contains(potentialMoveCheck))
                        {
                            PlayerMove(yPos, xPos, playerTwo);                            
                            return;
                        }
                        else
                        {
                            MessageBox.Show("You must 'take' your opponents piece");

                            return;
                        }
                    }
                }

                PlayerMove(yPos, xPos, playerTwo);                

            }
        }

        #endregion

        #region Movement

        private void PlayerMove(int y, int x, string player)
        {
            
            // Checks the square clicked first belongs to the player whose turn it is
            if ((positionsArray[y, x].Equals(player)) && canMove.Equals(false))
            {                
                firstClickY = y;
                firstClickX = x;
                canMove = true;
                
                return;
            }

            if (positionsArray[firstClickY, firstClickX] != player)
            {
                MessageBox.Show("It is not currently your turn");
                return;
            }

            // Player 1 Movement Logic
            if (player.Equals(playerOne) && canMove.Equals(true))
            {               

                if (playerOb.CanAPieceBeCapturedRight(firstClickY, firstClickX, positionsArray, player).Equals(true))
                {
                    // Checks if removing a piece to the right is the move made
                    if ((firstClickY - 2).Equals(y) && (firstClickX + 2).Equals(x))
                    {
                        // Sets the square clicked first to blank
                        positionsArray[firstClickY, firstClickX] = string.Empty;

                        // Sets the square with the oppositions pieces on it to empty
                        positionsArray[(firstClickY - 1), (firstClickX + 1)] = string.Empty;

                        // Sets the square clicked second to now show the player one piece
                        positionsArray[y, x] = player;

                        undoRedoReplay.StoreTheMovePositions(positionsArray, player1Turn);

                        if ((playerOb.CanAPieceBeCapturedRight(y, x, positionsArray, player)).Equals(false) && (playerOb.CanAPieceBeCapturedLeft(y, x, positionsArray, player)).Equals(false))
                        {
                            player1Turn = false;
                            turnTxtBlock.Text = "Player O";
                        }

                        //undoRedoReplay.StoreTheMovePositions();
                        RefreshBoard();
                        canMove = false;
                        y = 0;
                        x = 0;
                        firstClickY = 0;
                        firstClickX = 0;
                        return;
                    } 
                }

                if (playerOb.CanAPieceBeCapturedLeft(firstClickY, firstClickX, positionsArray, player).Equals(true))
                {
                    // Checks if removing a piece to the left is the move made
                    if ((firstClickY - 2).Equals(y) && (firstClickX - 2).Equals(x))
                    {
                        // Sets the square clicked first to blank
                        positionsArray[firstClickY, firstClickX] = string.Empty;

                        // Sets the square with the oppositions pieces on it to empty
                        positionsArray[(firstClickY - 1), (firstClickX - 1)] = string.Empty;

                        // Sets the square clicked second to now show the player one piece
                        positionsArray[y, x] = player;

                        undoRedoReplay.StoreTheMovePositions(positionsArray, player1Turn);

                        if ((playerOb.CanAPieceBeCapturedRight(y, x, positionsArray, player)).Equals(false) && (playerOb.CanAPieceBeCapturedLeft(y, x, positionsArray, player)).Equals(false))
                        {
                            player1Turn = false;
                            turnTxtBlock.Text = "Player O";                            
                        }

                        
                        RefreshBoard();
                        canMove = false;
                        y = 0;
                        x = 0;
                        firstClickY = 0;
                        firstClickX = 0;
                        return;
                    }                     
                }   

                if (positionsArray[y, x].Equals(string.Empty))
                {   
                    // Basic Movement
                    if ((playerOb.MovementRight(firstClickY, firstClickX, y, x, positionsArray, player).Equals(true)) || (playerOb.MovementLeft(firstClickY, firstClickX, y, x, positionsArray, player).Equals(true)))
                    {
                        undoRedoReplay.StoreTheMovePositions(positionsArray, player1Turn);
                        player1Turn = false;
                        turnTxtBlock.Text = "Player O";                        
                        RefreshBoard();
                        y = 0;
                        x = 0;
                        firstClickY = 0;
                        firstClickX = 0;
                        canMove = false;
                        return;
                    }
                   
                }
            }
            else
            {
                // Player 2 Movement Logic
                if (player.Equals(playerTwo) && canMove.Equals(true))
                {
                    if (playerOb.CanAPieceBeCapturedRight(firstClickY, firstClickX, positionsArray, player).Equals(true))
                    {
                        // Checks if removing a piece to the right is the move made
                        if ((firstClickY + 2).Equals(y) && (firstClickX + 2).Equals(x))
                        {
                            // Sets the square clicked first to blank
                            positionsArray[firstClickY, firstClickX] = string.Empty;

                            // Sets the square with the oppositions pieces on it to empty
                            positionsArray[(firstClickY + 1), (firstClickX + 1)] = string.Empty;

                            // Sets the square clicked second to now show the player one piece
                            positionsArray[y, x] = player;

                            undoRedoReplay.StoreTheMovePositions(positionsArray, player1Turn);

                            if ((playerOb.CanAPieceBeCapturedRight(y, x, positionsArray, player)).Equals(false) && (playerOb.CanAPieceBeCapturedLeft(y, x, positionsArray, player)).Equals(false))
                            {
                                player1Turn = true;
                                turnTxtBlock.Text = "Player X";                                
                            }

                            
                            RefreshBoard();
                            canMove = false;
                            y = 0;
                            x = 0;
                            firstClickY = 0;
                            firstClickX = 0;
                            return;
                        }  
                    }


                    if (playerOb.CanAPieceBeCapturedLeft(firstClickY, firstClickX, positionsArray, player).Equals(true))
                    {                        
                        // Checks if removing a piece to the left is the move made
                        if ((firstClickY + 2).Equals(y) && (firstClickX - 2).Equals(x))
                        {
                            // Sets the square clicked first to blank
                            positionsArray[firstClickY, firstClickX] = string.Empty;

                            // Sets the square with the oppositions pieces on it to empty
                            positionsArray[(firstClickY + 1), (firstClickX - 1)] = string.Empty;

                            // Sets the square clicked second to now show the player one piece
                            positionsArray[y, x] = player;

                            undoRedoReplay.StoreTheMovePositions(positionsArray, player1Turn);

                            if ((playerOb.CanAPieceBeCapturedRight(y, x, positionsArray, player)).Equals(false) && (playerOb.CanAPieceBeCapturedLeft(y, x, positionsArray, player)).Equals(false))
                            {
                                player1Turn = true;
                                turnTxtBlock.Text = "Player X";                                
                            }

                            
                            RefreshBoard();
                            canMove = false;
                            y = 0;
                            x = 0;
                            firstClickY = 0;
                            firstClickX = 0;
                            return;
                        }        
                    }


                    if (positionsArray[y, x].Equals(string.Empty))
                    {
                        // Basic Movement
                        if ((playerOb.MovementRight(firstClickY, firstClickX, y, x, positionsArray, player).Equals(true)) || (playerOb.MovementLeft(firstClickY, firstClickX, y, x, positionsArray, player).Equals(true)))
                        {
                            undoRedoReplay.StoreTheMovePositions(positionsArray, player1Turn);
                            player1Turn = true;
                            turnTxtBlock.Text = "Player X";
                            
                            RefreshBoard();
                            y = 0;
                            x = 0;
                            firstClickY = 0;
                            firstClickX = 0;
                            canMove = false;
                            return;
                        }
                    }
                }
            }
        }


        private int ConvertButtonNameToIntY(string buttonClicked)
        {
            // Stores the 2 digit value in a Char Array
            var singleDigit = buttonClicked.ToCharArray();

            // Removes the first number as the Y co-ord
            string yPosString = singleDigit[0].ToString();

            // Converts the string to an int
            int yPos;
            Int32.TryParse(yPosString, out yPos);
            return yPos;
        }

        private int ConvertButtonNameToIntX(string buttonClicked)
        {
            // Stores the 2 digit value in a Char Array
            var singleDigit = buttonClicked.ToCharArray();

            // Removes the second number as the X co-ord
            string xPosString = singleDigit[1].ToString();

            int xPos;
            Int32.TryParse(xPosString, out xPos);
            return xPos;
        }

        #endregion

        
    }
}

