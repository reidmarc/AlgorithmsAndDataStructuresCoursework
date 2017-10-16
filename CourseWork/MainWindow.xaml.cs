using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        Player playerOb = new Player();

        // 2D array to map store the piece locations
        string[,] positionsArray = new string[8, 8];

        Stack<string> undoStack = new Stack<string>();
        Stack<string> redoStack = new Stack<string>();
        Queue<string> replayQueue = new Queue<string>();


        public const string playerOne = "X";
        public const string playerTwo = "O";

        int firstClickY;
        int firstClickX;


        bool player1Turn;

        bool canMove = false;


        //bool isKing;

        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();

            player1Turn = NewGame();
            RefreshBoard();
            turnTxtBlock.Text = "Player X";
        }

        #endregion

        #region Board Methods

        public bool NewGame()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    positionsArray[i, j] = "UNPLAYABLESQUARE";
                }
            }



            // Player 2 starting positions            
            positionsArray[0, 1] = positionsArray[0, 3] = positionsArray[0, 5] = positionsArray[0, 7] =
            positionsArray[1, 0] = positionsArray[1, 2] = positionsArray[1, 4] = positionsArray[1, 6] =
            positionsArray[2, 1] = positionsArray[2, 3] = positionsArray[2, 5] = positionsArray[2, 7] = playerTwo;

            // Blank starting squares            
            positionsArray[3, 0] = positionsArray[3, 2] = positionsArray[3, 4] = positionsArray[3, 6] =
            positionsArray[4, 1] = positionsArray[4, 3] = positionsArray[4, 5] = positionsArray[4, 7] = string.Empty;

            // Player 1 starting positions
            positionsArray[5, 0] = positionsArray[5, 2] = positionsArray[5, 4] = positionsArray[5, 6] =
            positionsArray[6, 1] = positionsArray[6, 3] = positionsArray[6, 5] = positionsArray[6, 7] =
            positionsArray[7, 0] = positionsArray[7, 2] = positionsArray[7, 4] = positionsArray[7, 6] = playerOne;


            ///////////////////////////// FOR TESTING PURPOSES ONLY /////////////////////////////


            //positionsArray[0, 1] = positionsArray[0, 3] = positionsArray[0, 5] = positionsArray[0, 7] =
            //positionsArray[1, 0] = positionsArray[1, 2] = positionsArray[1, 4] = positionsArray[1, 6] =
            //positionsArray[2, 1] = positionsArray[2, 3] = positionsArray[2, 5] = positionsArray[2, 7] =
            //positionsArray[3, 0] = positionsArray[3, 2] = positionsArray[3, 4] = positionsArray[3, 6] =
            //positionsArray[4, 1] = positionsArray[4, 3] = positionsArray[4, 5] = positionsArray[4, 7] =
            //positionsArray[5, 0] = positionsArray[5, 2] = positionsArray[5, 4] = positionsArray[5, 6] =
            //positionsArray[6, 1] = positionsArray[6, 3] = positionsArray[6, 5] = positionsArray[6, 7] =
            //positionsArray[7, 0] = positionsArray[7, 2] = positionsArray[7, 4] = positionsArray[7, 6] = string.Empty;

            //positionsArray[7, 0] = playerOne;
            //positionsArray[5, 2] = playerTwo;
            //positionsArray[3, 4] = playerTwo;
            //positionsArray[1, 6] = playerTwo;
            //positionsArray[4, 5] = playerOne;




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

        private void clrBtn_Click(object sender, RoutedEventArgs e)
        {
            // Clears the board and resets the pieces
            ClearTheBoard();

            // Sets it back to player 1's turn
            player1Turn = true;

            // Sets the textbox to Player X indicating who's turn it is
            turnTxtBlock.Text = "Player X";
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            // Shuts down the application
            Application.Current.Shutdown();
        }

        private void undoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (undoStack.Count > 0)
            {
                MessageBox.Show(undoStack.Peek().ToString());
            }
            else
            {
                return;
            }
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            canMove = false;
            return;
        }

        private void endBtn_Click(object sender, RoutedEventArgs e)
        {
            if (player1Turn.Equals(true))
            {
                player1Turn = false;
                turnTxtBlock.Text = "Player O";
            }
            else
            {
                player1Turn = true;
                turnTxtBlock.Text = "Player X";
            }

            canMove = false;
            return;
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
            return yPos;        }

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

        private void Playable_Square_Click(object sender, RoutedEventArgs e)
        {
            bool forcedCapture = false;
            int count = 0;
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

                                    count = count + 1;
                                    forcedCapture = true;
                                }
                                if (playerOb.CanAPieceBeCapturedLeft(i, j, positionsArray, playerOne).Equals(true))
                                {
                                    int potentialMove = Convert.ToInt32(string.Format("{0}{1}", i, j));
                                    listOfForcedMoves.Add(potentialMove);


                                    count = count + 1;
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

                                    count = count + 1;
                                    forcedCapture = true;
                                }
                                if (playerOb.CanAPieceBeCapturedLeft(i, j, positionsArray, playerTwo).Equals(true))
                                {
                                    int potentialMove = Convert.ToInt32(string.Format("{0}{1}", i, j));
                                    listOfForcedMoves.Add(potentialMove);


                                    count = count + 1;
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
            
            //if (positionsArray[firstClickY,firstClickX] != player)
            //{
            //    MessageBox.Show("It is not currently your turn");
            //    return;
            //}

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

                        if ((playerOb.CanAPieceBeCapturedRight(y, x, positionsArray, player)).Equals(false) && (playerOb.CanAPieceBeCapturedLeft(y, x, positionsArray, player)).Equals(false))
                        {
                            player1Turn = false;
                            turnTxtBlock.Text = "Player O";

                            MessageBox.Show("There is another move available, if you do not wish to make the move please press 'End Turn'");
                        }

                        
                        RefreshBoard();
                        
                    }
                    else
                    {
                        MessageBox.Show("You must remove the piece available");
                        player1Turn = true;
                    }

                    canMove = false;
                    y = 0;
                    x = 0;
                    firstClickY = 0;
                    firstClickX = 0;
                    return;
                    
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



                        if ((playerOb.CanAPieceBeCapturedRight(y, x, positionsArray, player)).Equals(false) && (playerOb.CanAPieceBeCapturedLeft(y, x, positionsArray, player)).Equals(false))
                        {
                            player1Turn = false;
                            turnTxtBlock.Text = "Player O";

                            MessageBox.Show("There is another move available, if you do not wish to make the move please press 'End Turn'");
                        }


                        RefreshBoard();
                        

                    }
                    else
                    {
                        MessageBox.Show("You must remove the piece available");
                        player1Turn = true;
                    }

                    canMove = false;
                    y = 0;
                    x = 0;
                    firstClickY = 0;
                    firstClickX = 0;
                    return;
                }
                    
                            


                if (positionsArray[y, x].Equals(string.Empty))
                {
                    // Basic Movement
                    if (playerOb.Movement(firstClickY, firstClickX, y, x, player).Equals(true))
                    {
                        positionsArray[firstClickY, firstClickX] = string.Empty;
                        positionsArray[y, x] = player;

                        //StoringAMove(isSelectedStart, clickedPos, player);

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

                            if ((playerOb.CanAPieceBeCapturedRight(y, x, positionsArray, player)).Equals(false) && (playerOb.CanAPieceBeCapturedLeft(y, x, positionsArray, player)).Equals(false))
                            {
                                player1Turn = true;
                                turnTxtBlock.Text = "Player X";

                                MessageBox.Show("There is another move available, if you do not wish to make the move please press 'End Turn'");
                            }


                            RefreshBoard();
                            
                        }
                        else
                        {
                            MessageBox.Show("You must remove the piece available");
                            player1Turn = false;
                        }

                        canMove = false;
                        y = 0;
                        x = 0;
                        firstClickY = 0;
                        firstClickX = 0;
                        return;
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

                            if ((playerOb.CanAPieceBeCapturedRight(y, x, positionsArray, player)).Equals(false) && (playerOb.CanAPieceBeCapturedLeft(y, x, positionsArray, player)).Equals(false))
                            {
                                player1Turn = true;
                                turnTxtBlock.Text = "Player X";

                                MessageBox.Show("There is another move available, if you do not wish to make the move please press 'End Turn'");
                            }
                            RefreshBoard();
                            
                        }
                        else
                        {
                            MessageBox.Show("You must remove the piece available");
                            player1Turn = false;
                        }

                        canMove = false;
                        y = 0;
                        x = 0;
                        firstClickY = 0;
                        firstClickX = 0;
                        return;  
                    }


                    if (positionsArray[y, x].Equals(string.Empty))
                    {
                        // Basic Movement
                        if (playerOb.Movement(firstClickY, firstClickX, y, x, player).Equals(true))
                        {
                            positionsArray[firstClickY, firstClickX] = string.Empty;
                            positionsArray[y, x] = player;

                            //StoringAMove(isSelectedStart, clickedPos, player);

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
    }
}

