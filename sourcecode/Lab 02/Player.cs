using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class Player
    {
        #region Variables / Objects / Collections

        const string playerOne = "X";
        const string playerTwo = "O";
        const string noMansLand = " ";

        #endregion

        #region Basic Movement

        public bool MovementRight(int posY, int posX, int destY, int destX, string[,] positionsArray, ref bool player1Turn)
        {
            
            if (player1Turn)
            {
                // To stop the if statement recieving an out of bounds exception
                if (posY > 0 && posX < 7)
                {
                    // Check if player 1 can move right
                    if ((positionsArray[destY, destX].Equals(noMansLand)) && (((posY - destY).Equals(1)) && ((posX - destX).Equals(-1))))
                    {
                        positionsArray[posY, posX] = noMansLand;
                        positionsArray[destY, destX] = playerOne;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // To stop the if statement recieving an out of bounds exception
                if (posY < 7 && posX < 7)
                {
                    // Check if player 2 can move right
                    if ((positionsArray[destY, destX].Equals(noMansLand)) && (((posY - destY).Equals(-1)) && ((posX - destX).Equals(-1))))
                    {
                        positionsArray[posY, posX] = noMansLand;
                        positionsArray[destY, destX] = playerTwo;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public bool MovementLeft(int posY, int posX, int destY, int destX, string[,] positionsArray, ref bool player1Turn)
        {
            if (player1Turn)
            {
                // To stop the if statement recieving an out of bounds exception
                if (posY > 0 && posX > 0)
                {
                    // Check if player 1 can move left
                    if ((positionsArray[destY, destX].Equals(noMansLand)) && (((posY - destY).Equals(1)) && ((posX - destX).Equals(1))))
                    {
                        positionsArray[posY, posX] = noMansLand;
                        positionsArray[destY, destX] = playerOne;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (posY < 7 && posX > 0)
                {
                    // Check if player 2 can move left                    
                    if ((positionsArray[destY, destX].Equals(noMansLand)) && (((posY - destY).Equals(-1)) && ((posX - destX).Equals(1))))
                    {
                        positionsArray[posY, posX] = noMansLand;
                        positionsArray[destY, destX] = playerTwo;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region Removing Pieces Checks

        public void ForcedCaptureCheck(ref bool player1Turn, string[,] positionsArray, int yOne, int xOne, int yTwo, int xTwo)
        {
            // Boolean value which represents whether there is a forced capture move or not
            bool forcedCapture = false;
            


            // A list to store the potential 'takes' that must be chosen from
            List<int> listOfForcedMoves = new List<int>();

            // If player 1, the programs loops through the array looking for all of players 1's pieces
            // Once it finds a piece, it checks if that piece can capture an opponents piece
            // If 'true' then it adds that piece of player 1's to a list, which stores all the forced moves
            // Available to player 1, that they must selected from.
            if (player1Turn)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if ((positionsArray[i, j]).Contains(playerOne))
                        {
                            if (CanAPieceBeCapturedRight(i, j, positionsArray, ref player1Turn).Equals(true))
                            {
                                int potentialMove = Convert.ToInt32(string.Format("{0}{1}", i, j));
                                listOfForcedMoves.Add(potentialMove);
                                forcedCapture = true;
                            }
                            if (CanAPieceBeCapturedLeft(i, j, positionsArray, ref player1Turn).Equals(true))
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

                    int potentialMoveCheck = Convert.ToInt32(string.Format("{0}{1}", yOne, xOne));
                    


                    // Checks that the destination co-ords to the right are the correct ones to perform the forced 'take'
                    if (listOfForcedMoves.Contains(potentialMoveCheck) && ((yOne - 2).Equals(yTwo) && (xOne + 2).Equals(xTwo)))
                    {
                        PlayerMove(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn);
                        return;
                    }

                    // Checks that the destination co-ords to the left are the correct ones to perform the forced 'take'
                    if (listOfForcedMoves.Contains(potentialMoveCheck) && ((yOne - 2).Equals(yTwo) && (xOne - 2).Equals(xTwo)))
                    {
                        PlayerMove(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn);
                        return;
                    }
                    else
                    {
                        Console.Beep();
                        Console.WriteLine("You must 'take' your opponents piece");
                        return;
                    }
                }


                PlayerMove(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn);
            }
            else
            {

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if ((positionsArray[i, j]).Contains(playerTwo))
                        {
                            if (CanAPieceBeCapturedRight(i, j, positionsArray, ref player1Turn).Equals(true))
                            {
                                int potentialMove = Convert.ToInt32(string.Format("{0}{1}", i, j));
                                listOfForcedMoves.Add(potentialMove);
                                forcedCapture = true;

                            }
                            if (CanAPieceBeCapturedLeft(i, j, positionsArray, ref player1Turn).Equals(true))
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

                    int potentialMoveCheck = Convert.ToInt32(string.Format("{0}{1}", yOne, xOne));

                    // Checks that the destination co-ords to the right are the correct ones to perform the forced 'take'
                    if (listOfForcedMoves.Contains(potentialMoveCheck) && ((yOne + 2).Equals(yTwo) && (xOne + 2).Equals(xTwo)))
                    {
                        PlayerMove(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn);
                        return;
                    }

                    // Checks that the destination co-ords to the left are the correct ones to perform the forced 'take'
                    if (listOfForcedMoves.Contains(potentialMoveCheck) && ((yOne + 2).Equals(yTwo) && (xOne - 2).Equals(xTwo)))
                    {
                        PlayerMove(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn);
                        return;
                    }
                    else
                    {
                        Console.Beep();
                        Console.WriteLine("You must 'take' your opponents piece");

                        return;
                    }
                }

                PlayerMove(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn);
            }
        }


        public bool CanAPieceBeCapturedRight(int yOne, int xOne, string[,] positionsArray, ref bool player1Turn)
        {
            if (player1Turn)
            {
                // To stop the if statement recieving an out of bounds exception
                if (yOne > 1 && xOne < 6)
                {
                    // Check if player 1 can remove a player 2 piece to the right
                    // If it can then it is still player 1's turn
                    if (positionsArray[(yOne - 1), (xOne + 1)].Equals(playerTwo) && (positionsArray[(yOne - 2), (xOne + 2)].Equals(noMansLand)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // To stop the if statement recieving an out of bounds exception
                if (yOne < 6 && xOne < 6)
                {
                    // Check if player 2 can remove a player 1 piece to the right
                    // If it can then it is still player 2's turn
                    if (positionsArray[(yOne + 1), (xOne + 1)].Equals(playerOne) && (positionsArray[(yOne + 2), (xOne + 2)].Equals(noMansLand)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public bool CanAPieceBeCapturedLeft(int yOne, int xOne, string[,] positionsArray, ref bool player1Turn)
        {
            if (player1Turn)
            {
                // To stop the if statement recieving an out of bounds exception
                if (yOne > 1 && xOne > 1)
                {
                    // Check if player 1 can remove a player 2 piece to the left
                    // If it can then it is still player 1's turn
                    if (positionsArray[(yOne - 1), (xOne - 1)].Equals(playerTwo) && (positionsArray[(yOne - 2), (xOne - 2)].Equals(noMansLand)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (yOne < 6 && xOne > 1)
                {
                    // Check if player 2 can remove a player 1 piece to the left
                    // If it can then it is still player 2's turn
                    if (positionsArray[(yOne + 1), (xOne - 1)].Equals(playerOne) && (positionsArray[(yOne + 2), (xOne - 2)].Equals(noMansLand)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        




        private void PlayerMove(int yOne, int xOne, int yTwo, int xTwo, string[,] positionsArray, ref bool player1Turn)
        {  
            // Player 1 Movement Logic
            if (player1Turn)
            {

                if (CanAPieceBeCapturedRight(yOne, xOne, positionsArray, ref player1Turn).Equals(true))
                {
                    // Checks if removing a piece to the right is the move made
                    if ((yOne - 2).Equals(yTwo) && (xOne + 2).Equals(xTwo))
                    {
                        // Sets the square clicked first to blank
                        positionsArray[yOne, xOne] = noMansLand;

                        // Sets the square with the oppositions pieces on it to empty
                        positionsArray[(yOne - 1), (xOne + 1)] = noMansLand;

                        // Sets the square clicked second to now show the player one piece
                        positionsArray[yTwo, xTwo] = playerOne;

                        //undoRedoReplay.StoreTheMovePositions(positionsArray, player1Turn);

                        if ((CanAPieceBeCapturedRight(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false) && (CanAPieceBeCapturedLeft(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false))
                        {
                            player1Turn = false;
                            //turnTxtBlock.Text = "Player O";
                        } 

                        return;
                    }
                }

                if (CanAPieceBeCapturedLeft(yOne, xOne, positionsArray, ref player1Turn).Equals(true))
                {
                    

                    // Checks if removing a piece to the left is the move made
                    if ((yOne - 2).Equals(yTwo) && (xOne - 2).Equals(xTwo))
                    {
                        // Sets the square clicked first to blank
                        positionsArray[yOne, xOne] = noMansLand;

                        // Sets the square with the oppositions pieces on it to empty
                        positionsArray[(yOne - 1), (xOne - 1)] = noMansLand;

                        // Sets the square clicked second to now show the player one piece
                        positionsArray[yTwo, xTwo] = playerOne;

                        //undoRedoReplay.StoreTheMovePositions(positionsArray, player1Turn);

                        if ((CanAPieceBeCapturedRight(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false) && (CanAPieceBeCapturedLeft(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false))
                        {
                            player1Turn = false;
                            //turnTxtBlock.Text = "Player O";
                        }
                        return;
                    }
                }

                if (positionsArray[yTwo, xTwo].Equals(noMansLand))
                {
                    // Basic Movement
                    if ((MovementRight(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn).Equals(true)) || (MovementLeft(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn).Equals(true)))
                    {
                        //undoRedoReplay.StoreTheMovePositions(positionsArray, player1Turn);
                        player1Turn = false;
                        //turnTxtBlock.Text = "Player O";                        
                        return;
                    }

                }
            }
            // Player 2's movement logic
            else
            {
                
                if (CanAPieceBeCapturedRight(yOne, xOne, positionsArray, ref player1Turn).Equals(true))
                {
                    // Checks if removing a piece to the right is the move made
                    if ((yOne + 2).Equals(yTwo) && (xOne + 2).Equals(xTwo))
                    {
                        // Sets the square clicked first to blank
                        positionsArray[yOne, xOne] = noMansLand;

                        // Sets the square with the oppositions pieces on it to empty
                        positionsArray[(yOne + 1), (xOne + 1)] = noMansLand;

                        // Sets the square clicked second to now show the player one piece
                        positionsArray[yTwo, xTwo] = playerTwo;

                        //undoRedoReplay.StoreTheMovePositions(positionsArray, player1Turn);

                        if ((CanAPieceBeCapturedRight(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false) && (CanAPieceBeCapturedLeft(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false))
                        {
                            player1Turn = true;
                            //turnTxtBlock.Text = "Player X";
                        }
                        return;
                    }
                }


                if (CanAPieceBeCapturedLeft(yOne, xOne, positionsArray, ref player1Turn).Equals(true))
                {
                    // Checks if removing a piece to the left is the move made
                    if ((yOne + 2).Equals(yTwo) && (xOne - 2).Equals(xTwo))
                    {
                        // Sets the square clicked first to blank
                        positionsArray[yOne, xOne] = noMansLand;

                        // Sets the square with the oppositions pieces on it to empty
                        positionsArray[(yOne + 1), (xOne - 1)] = noMansLand;

                        // Sets the square clicked second to now show the player one piece
                        positionsArray[yTwo, xTwo] = playerTwo;

                        //undoRedoReplay.StoreTheMovePositions(positionsArray, player1Turn);

                        if ((CanAPieceBeCapturedRight(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false) && (CanAPieceBeCapturedLeft(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false))
                        {
                            player1Turn = true;
                            //turnTxtBlock.Text = "Player X";
                        }  
                        return;
                    }
                }


                if (positionsArray[yTwo, xTwo].Equals(noMansLand))
                {
                    // Basic Movement
                    if ((MovementRight(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn).Equals(true)) || (MovementLeft(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn).Equals(true)))
                    {
                        //undoRedoReplay.StoreTheMovePositions(positionsArray, player1Turn);
                        player1Turn = true;
                        //turnTxtBlock.Text = "Player X";   
                        return;
                    }
                }
                
            }
        }













    }
}
