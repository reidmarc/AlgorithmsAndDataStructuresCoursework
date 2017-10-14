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
        
        PlayerOne player1 = new PlayerOne();
        PlayerTwo player2 = new PlayerTwo();

        string[] positionsArray = new string[100];

        Stack<string> undoStack = new Stack<string>();
        Stack<string> redoStack = new Stack<string>();
        Queue<string> replayQueue = new Queue<string>();


        bool player1Turn;

        bool canMove = false;
        int isSelectedStart;

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
            

            for (int i = 1; i < 42; i++)
            {
                positionsArray[i] = "O"; 
            }

            for (int i = 42; i < 62; i++)
            {
                positionsArray[i] = string.Empty;
            }

            for (int i = 62; i < 100; i++)
            {
                positionsArray[i] = "X";
            }

            positionsArray[0] = "Blank";
            positionsArray[1] = "Blank";
            positionsArray[3] = "Blank";
            positionsArray[5] = "Blank";
            positionsArray[7] = "Blank";
            positionsArray[9] = "Blank";

            positionsArray[12] = "Blank";
            positionsArray[14] = "Blank";
            positionsArray[16] = "Blank";
            positionsArray[18] = "Blank";
            positionsArray[20] = "Blank";
        
            positionsArray[21] = "Blank";
            positionsArray[23] = "Blank";
            positionsArray[25] = "Blank";
            positionsArray[27] = "Blank";
            positionsArray[29] = "Blank";

            positionsArray[32] = "Blank";
            positionsArray[34] = "Blank";
            positionsArray[36] = "Blank";
            positionsArray[38] = "Blank";
            positionsArray[40] = "Blank";

            positionsArray[41] = "Blank";
            positionsArray[43] = "Blank";
            positionsArray[45] = "Blank";
            positionsArray[47] = "Blank";
            positionsArray[49] = "Blank";

            positionsArray[52] = "Blank";
            positionsArray[54] = "Blank";
            positionsArray[56] = "Blank";
            positionsArray[58] = "Blank";
            positionsArray[60] = "Blank";

            positionsArray[61] = "Blank";
            positionsArray[63] = "Blank";
            positionsArray[65] = "Blank";
            positionsArray[67] = "Blank";
            positionsArray[69] = "Blank";

            positionsArray[72] = "Blank";
            positionsArray[74] = "Blank";
            positionsArray[76] = "Blank";
            positionsArray[78] = "Blank";
            positionsArray[80] = "Blank";

            positionsArray[81] = "Blank";
            positionsArray[83] = "Blank";
            positionsArray[85] = "Blank";
            positionsArray[87] = "Blank";
            positionsArray[89] = "Blank";

            positionsArray[92] = "Blank";
            positionsArray[94] = "Blank";
            positionsArray[96] = "Blank";
            positionsArray[98] = "Blank";

            return true;

        }

        private void RefreshBoard()
        {
            // Player 2's Checkers
            POS2.Content = positionsArray[2];
            POS4.Content = positionsArray[4];
            POS6.Content = positionsArray[6];
            POS8.Content = positionsArray[8];
            POS10.Content = positionsArray[10];

            POS11.Content = positionsArray[11];
            POS13.Content = positionsArray[13];
            POS15.Content = positionsArray[15];
            POS17.Content = positionsArray[17];
            POS19.Content = positionsArray[19];

            POS22.Content = positionsArray[22];
            POS24.Content = positionsArray[24];            
            POS26.Content = positionsArray[26];
            POS28.Content = positionsArray[28];
            POS30.Content = positionsArray[30];

            POS31.Content = positionsArray[31];
            POS33.Content = positionsArray[33];
            POS35.Content = positionsArray[35];
            POS37.Content = positionsArray[37];
            POS39.Content = positionsArray[39];

            // Free Space
            POS42.Content = positionsArray[42];
            POS44.Content = positionsArray[44];
            POS46.Content = positionsArray[46];
            POS48.Content = positionsArray[48];
            POS50.Content = positionsArray[50];

            POS51.Content = positionsArray[51];
            POS53.Content = positionsArray[53];
            POS55.Content = positionsArray[55];
            POS57.Content = positionsArray[57];
            POS59.Content = positionsArray[59];

            // Player 1's Checkers
            POS62.Content = positionsArray[62];
            POS64.Content = positionsArray[64];
            POS66.Content = positionsArray[66];
            POS68.Content = positionsArray[68];
            POS70.Content = positionsArray[70];

            POS71.Content = positionsArray[71];
            POS73.Content = positionsArray[73];
            POS75.Content = positionsArray[75];
            POS77.Content = positionsArray[77];
            POS79.Content = positionsArray[79];

            POS82.Content = positionsArray[82];
            POS84.Content = positionsArray[84];
            POS86.Content = positionsArray[86];
            POS88.Content = positionsArray[66];
            POS90.Content = positionsArray[90];

            POS91.Content = positionsArray[91];
            POS93.Content = positionsArray[93];
            POS95.Content = positionsArray[95];
            POS97.Content = positionsArray[97];
            POS99.Content = positionsArray[99];
        }

        private void ClearTheBoard()
        {
            GameBoard.Children.Cast<Button>().ToList().ForEach(button =>
            {
                for (int i = 1; i < 100; i++)
                {
                    positionsArray[i] = string.Empty;
                    button.Content = string.Empty;
                }

            });

            NewGame();
            RefreshBoard();
        }

        #endregion

        #region Event Handlers

        private void clrBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearTheBoard();
            player1Turn = true;
            turnTxtBlock.Text = "Player X";
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
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

        private void Playable_Square_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            // Removes the POS from the start of the button
            //then converts the string to a number
            string btnClicked = button.Name.Replace("POS", "").ToString();

            int cellClicked;
            Int32.TryParse(btnClicked, out cellClicked);

            if (player1Turn)
            {
                PlayerMove(cellClicked, "X");
                //turnTxtBlock.Text = "Player 1";
            }
            else
            {
                PlayerMove(cellClicked, "O");
                //turnTxtBlock.Text = "Player 2";
            }
        }

        #endregion

        private void PlayerMove(int clickedPos, string player)
        {
            if (positionsArray[clickedPos] == player)
            {
                canMove = true;
                isSelectedStart = clickedPos;
                return;
            }           

            if (positionsArray[clickedPos] == string.Empty && canMove == true)
            {
                if (player.Equals("X"))
                {


                    if ((isSelectedStart - clickedPos).Equals(18))
                    {
                        int removePiece = (isSelectedStart - 9);
                        positionsArray[removePiece] = string.Empty;
                        positionsArray[clickedPos] = player;
                        positionsArray[isSelectedStart] = string.Empty;

                        RefreshBoard();
                        isSelectedStart = 0;
                        canMove = false;
                        player1Turn = false;
                        turnTxtBlock.Text = "Player O";
                        return;
                    }

                    if ((isSelectedStart - clickedPos).Equals(22))
                    {
                        int removePiece = (isSelectedStart - 11);
                        positionsArray[removePiece] = string.Empty;
                        positionsArray[clickedPos] = player;
                        positionsArray[isSelectedStart] = string.Empty; 

                        RefreshBoard();
                        isSelectedStart = 0;
                        canMove = false;
                        player1Turn = false;
                        turnTxtBlock.Text = "Player O";
                        return;
                    }




                    if (player1.Movement(isSelectedStart, clickedPos) == true)
                    {

                        positionsArray[clickedPos] = player;
                        positionsArray[isSelectedStart] = string.Empty;

                        StoringAMove(isSelectedStart, clickedPos, player);

                        RefreshBoard();
                        isSelectedStart = 0;
                        canMove = false;
                        player1Turn = false;
                        turnTxtBlock.Text = "Player O";
                        return;
                    }
                    else
                    {
                        MessageBox.Show("More functionality to be implemented");
                        return;
                    }
                }
                if (player.Equals("O"))
                {
                    if ((clickedPos - isSelectedStart).Equals(18))
                    {
                        int removePiece = (isSelectedStart + 9);
                        positionsArray[removePiece] = string.Empty;
                        positionsArray[clickedPos] = player;
                        positionsArray[isSelectedStart] = string.Empty;

                        RefreshBoard();
                        isSelectedStart = 0;
                        canMove = false;
                        player1Turn = true;
                        turnTxtBlock.Text = "Player X";
                        return;
                    }

                    if ((clickedPos - isSelectedStart).Equals(22))
                    {
                        int removePiece = (isSelectedStart + 11);
                        positionsArray[removePiece] = string.Empty;
                        positionsArray[clickedPos] = player;
                        positionsArray[isSelectedStart] = string.Empty;

                        RefreshBoard();
                        isSelectedStart = 0;
                        canMove = false;
                        player1Turn = true;
                        turnTxtBlock.Text = "Player X";
                        return;
                    }





                    if (player2.Movement(isSelectedStart, clickedPos) == true)
                    {

                        positionsArray[clickedPos] = player;
                        positionsArray[isSelectedStart] = string.Empty;

                        StoringAMove(isSelectedStart, clickedPos, player);

                        RefreshBoard();
                        isSelectedStart = 0;
                        canMove = false;

                        player1Turn = true;
                        turnTxtBlock.Text = "Player X";
                        return;
                    }
                    else
                    {
                        MessageBox.Show("More functionality to be implemented");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Error Code 202020202");
                }
            }
        }

        private void StoringAMove(int startingPos, int finishPos, string player)
        {
            startingPos.ToString();
            finishPos.ToString();

            string aMove = "Player " + player + " : " + startingPos.ToString() + " - " + finishPos.ToString() + "";
            undoStack.Push(aMove.ToString());
            //replayQueue.Enqueue(aMove.ToString());
            return;
        }
    }
}
