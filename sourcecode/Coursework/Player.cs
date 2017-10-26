using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    public class Player
    {
        #region Variables

        const string playerOne = " X ";
        const string playerTwo = " O ";
        const string noMansLand = "   ";
        const string playerOneKing = "|X|";
        const string playerTwoKing = "|O|";


        #endregion

        #region Basic Movement

        private bool MovementRight(int yOne, int xOne, int yTwo, int xTwo, string[,] positionsArray, ref bool player1Turn)
        {

            if (player1Turn)
            {
                if ((positionsArray[yOne, xOne]).Equals(playerOne))
                {
                    // To stop the if statement recieving an out of bounds exception
                    if (yOne > 0 && xOne < 7)
                    {
                        // Check if player 1 can move right
                        if ((positionsArray[yTwo, xTwo].Equals(noMansLand)) && (((yOne - yTwo).Equals(1)) && ((xOne - xTwo).Equals(-1))))
                        {
                            positionsArray[yOne, xOne] = noMansLand;
                            positionsArray[yTwo, xTwo] = playerOne;
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
                    return false;
                }
            }
            else
            {
                if ((positionsArray[yOne, xOne]).Equals(playerTwo))
                {
                    // To stop the if statement recieving an out of bounds exception
                    if (yOne < 7 && xOne < 7)
                    {
                        // Check if player 2 can move right
                        if ((positionsArray[yTwo, xTwo].Equals(noMansLand)) && (((yOne - yTwo).Equals(-1)) && ((xOne - xTwo).Equals(-1))))
                        {
                            positionsArray[yOne, xOne] = noMansLand;
                            positionsArray[yTwo, xTwo] = playerTwo;
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
                    return false;
                }
            }
        }

        private bool MovementLeft(int yOne, int xOne, int yTwo, int xTwo, string[,] positionsArray, ref bool player1Turn)
        {
            if (player1Turn)
            {
                if ((positionsArray[yOne, xOne]).Equals(playerOne))
                {

                    // To stop the if statement recieving an out of bounds exception
                    if (yOne > 0 && xOne > 0)
                    {
                        // Check if player 1 can move left
                        if ((positionsArray[yTwo, xTwo].Equals(noMansLand)) && (((yOne - yTwo).Equals(1)) && ((xOne - xTwo).Equals(1))))
                        {
                            positionsArray[yOne, xOne] = noMansLand;
                            positionsArray[yTwo, xTwo] = playerOne;
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
                    return false;
                }
            }
            else
            {
                if ((positionsArray[yOne, xOne]).Equals(playerTwo))
                {
                    // To stop the if statement recieving an out of bounds exception
                    if (yOne < 7 && xOne > 0)
                    {
                        // Check if player 2 can move left                    
                        if ((positionsArray[yTwo, xTwo].Equals(noMansLand)) && (((yOne - yTwo).Equals(-1)) && ((xOne - xTwo).Equals(1))))
                        {
                            positionsArray[yOne, xOne] = noMansLand;
                            positionsArray[yTwo, xTwo] = playerTwo;
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
                    return false;
                }
            }
        }

        private bool MovementKing(int yOne, int xOne, int yTwo, int xTwo, string[,] positionsArray, ref bool player1Turn)
        {
            if (player1Turn.Equals(true))
            {
                if ((positionsArray[yOne, xOne]).Equals(playerOneKing))
                {

                    // Movement Up Right
                    // To stop the if statement recieving an out of bounds exception
                    if (yOne > 0 && xOne < 7)
                    {
                        if ((positionsArray[yTwo, xTwo].Equals(noMansLand)) && (((yOne - yTwo).Equals(1)) && ((xOne - xTwo).Equals(-1))))
                        {
                            positionsArray[yOne, xOne] = noMansLand;
                            positionsArray[yTwo, xTwo] = playerOneKing;
                            return true;
                        }

                    }

                    // Movement Down Right
                    // To stop the if statement recieving an out of bounds exception
                    if (yOne < 7 && xOne < 7)
                    {
                        if ((positionsArray[yTwo, xTwo].Equals(noMansLand)) && (((yOne - yTwo).Equals(-1)) && ((xOne - xTwo).Equals(-1))))
                        {
                            positionsArray[yOne, xOne] = noMansLand;
                            positionsArray[yTwo, xTwo] = playerOneKing;
                            return true;
                        }
                    }

                    // Movement Up Left
                    // To stop the if statement recieving an out of bounds exception
                    if (yOne > 0 && xOne > 0)
                    {
                        // Check if player 1 can move left
                        if ((positionsArray[yTwo, xTwo].Equals(noMansLand)) && (((yOne - yTwo).Equals(1)) && ((xOne - xTwo).Equals(1))))
                        {
                            positionsArray[yOne, xOne] = noMansLand;
                            positionsArray[yTwo, xTwo] = playerOneKing;
                            return true;
                        }
                    }

                    // Movement Down Left
                    // To stop the if statement recieving an out of bounds exception
                    if (yOne < 7 && xOne > 0)
                    {
                        if ((positionsArray[yTwo, xTwo].Equals(noMansLand)) && (((yOne - yTwo).Equals(-1)) && ((xOne - xTwo).Equals(1))))
                        {
                            positionsArray[yOne, xOne] = noMansLand;
                            positionsArray[yTwo, xTwo] = playerOneKing;
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
                    return false;
                }
            }
            else
            {
                if ((positionsArray[yOne, xOne]).Equals(playerTwoKing))
                {
                    // Movement Up Right
                    // To stop the if statement recieving an out of bounds exception
                    if (yOne > 0 && xOne < 7)
                    {
                        if ((positionsArray[yTwo, xTwo].Equals(noMansLand)) && (((yOne - yTwo).Equals(1)) && ((xOne - xTwo).Equals(-1))))
                        {
                            positionsArray[yOne, xOne] = noMansLand;
                            positionsArray[yTwo, xTwo] = playerTwoKing;
                            return true;
                        }

                    }

                    // Movement Down Right
                    // To stop the if statement recieving an out of bounds exception
                    if (yOne < 7 && xOne < 7)
                    {
                        if ((positionsArray[yTwo, xTwo].Equals(noMansLand)) && (((yOne - yTwo).Equals(-1)) && ((xOne - xTwo).Equals(-1))))
                        {
                            positionsArray[yOne, xOne] = noMansLand;
                            positionsArray[yTwo, xTwo] = playerTwoKing;
                            return true;
                        }
                    }

                    // Movement Up Left
                    // To stop the if statement recieving an out of bounds exception
                    if (yOne > 0 && xOne > 0)
                    {
                        // Check if player 1 can move left
                        if ((positionsArray[yTwo, xTwo].Equals(noMansLand)) && (((yOne - yTwo).Equals(1)) && ((xOne - xTwo).Equals(1))))
                        {
                            positionsArray[yOne, xOne] = noMansLand;
                            positionsArray[yTwo, xTwo] = playerTwoKing;
                            return true;
                        }
                    }

                    // Movement Down Left
                    // To stop the if statement recieving an out of bounds exception
                    if (yOne < 7 && xOne > 0)
                    {
                        if ((positionsArray[yTwo, xTwo].Equals(noMansLand)) && (((yOne - yTwo).Equals(-1)) && ((xOne - xTwo).Equals(1))))
                        {
                            positionsArray[yOne, xOne] = noMansLand;
                            positionsArray[yTwo, xTwo] = playerTwoKing;
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
                    return false;
                }
            }
        }

        #endregion

        #region Pre Move Checks

        public bool IsThereAnyValidMoves(string[,] positionsArray, bool player1Turn)
        {
            int yOne = 0;
            int xOne = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (player1Turn.Equals(true))
                    {
                        if ((positionsArray[i, j]).Equals(" X "))
                        {

                        }
                        if ((positionsArray[i, j]).Equals("|X|"))
                        {

                        }
                    }
                    else
                    {
                        if (positionsArray[i, j].Equals(playerTwo))
                        {
                            yOne = i;
                            xOne = j;

                            // Checks Down Right for a 'capture'
                            if (CanAPieceBeCapturedRight(i, j, positionsArray, ref player1Turn).Equals(true))
                            {                                
                                return true;
                            }
                            // Checks Down Left for a 'capture'
                            if (CanAPieceBeCapturedLeft(i, j, positionsArray, ref player1Turn).Equals(true))
                            {                                
                                return true;
                            }

                            // Checks Down Left for an empty tile
                            if (MovementLeft(i, j, (i + 1), (j - 1), positionsArray, ref player1Turn).Equals(true))
                            {
                                return true;
                            }

                            // Checks Down Right for an empty tile
                            if (MovementKing(i, j, (i + 1), (j + 1), positionsArray, ref player1Turn).Equals(true))
                            {
                                return true;
                            }
                        }
                        if (positionsArray[i, j].Equals(playerTwoKing))
                        {
                            if (CanAPieceBeCapturedKing(i, j, positionsArray, ref player1Turn).Equals(true))
                            {
                                return true;
                            }

                            // Checks Down Left for an empty tile
                            if (MovementKing(i ,j ,(i+1) ,(j-1) , positionsArray,ref player1Turn).Equals(true))
                            {
                                return true;
                            }

                            // Checks Down Right for an empty tile
                            if (MovementKing(i, j, (i + 1), (j + 1), positionsArray, ref player1Turn).Equals(true))
                            {
                                return true;
                            }

                            // Checks Up Right for an empty tile
                            if (MovementKing(i, j, (i - 1), (j - 1), positionsArray, ref player1Turn).Equals(true))
                            {
                                return true;
                            }

                            // Checks Up Left for an empty tile
                            if (MovementKing(i, j, (i - 1), (j - 1), positionsArray, ref player1Turn).Equals(true))
                            {
                                return true;
                            }                            
                        }
                    }
                }
            }
            return false;
        }



        public void ForcedCaptureCheck(ref bool player1Turn, string[,] positionsArray, int yOne, int xOne, int yTwo, int xTwo)
        {
            // Boolean value which represents whether there is a forced capture move or not
            bool forcedCapture = false;



            // A list to store the potential 'takes' that must be chosen from
            List<int> listOfForcedMoves = new List<int>();

            // If player 1, the application loops through the array looking for all of players 1's pieces
            // Once it finds a piece, it checks if that piece can capture an opponents piece
            // If 'true' then it adds that piece of player 1's to a list, which stores all the forced moves
            // Available to player 1, that they must selected from.
            if (player1Turn)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if ((positionsArray[i, j]).Contains(playerOne) || (positionsArray[i, j]).Contains(playerOneKing))
                        {
                            if ((CanAPieceBeCapturedRight(i, j, positionsArray, ref player1Turn).Equals(true)) ||
                                (CanAPieceBeCapturedLeft(i, j, positionsArray, ref player1Turn).Equals(true)) ||
                                (CanAPieceBeCapturedKing(i, j, positionsArray, ref player1Turn).Equals(true)))
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



                    // Checks that the destination co-ords to the up right are the correct ones to perform the forced 'take'
                    if (listOfForcedMoves.Contains(potentialMoveCheck) && ((yOne - 2).Equals(yTwo) && (xOne + 2).Equals(xTwo)))
                    {
                        PlayerMove(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn);
                        return;
                    }

                    // Checks that the destination co-ords to the up left are the correct ones to perform the forced 'take'
                    if (listOfForcedMoves.Contains(potentialMoveCheck) && ((yOne - 2).Equals(yTwo) && (xOne - 2).Equals(xTwo)))
                    {
                        PlayerMove(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn);
                        return;
                    }

                    // Checks that the destination co-ords to the down right are the correct ones to perform the forced 'take'
                    if (listOfForcedMoves.Contains(potentialMoveCheck) && ((yOne + 2).Equals(yTwo) && (xOne + 2).Equals(xTwo)))
                    {
                        PlayerMove(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn);
                        return;
                    }

                    // Checks that the destination co-ords to the down left are the correct ones to perform the forced 'take'
                    if (listOfForcedMoves.Contains(potentialMoveCheck) && ((yOne + 2).Equals(yTwo) && (xOne - 2).Equals(xTwo)))
                    {
                        PlayerMove(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn);
                        return;
                    }

                    else
                    {
                        Console.Beep();
                        Console.WriteLine("You must 'take' your opponents piece");
                        Console.ReadKey();
                        return;
                    }
                }


                PlayerMove(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn);
            }
            // If player 2, the application loops through the array looking for all of players 2's pieces
            // Once it finds a piece, it checks if that piece can capture an opponents piece
            // If 'true' then it adds that piece of player 2's to a list, which stores all the forced moves
            // Available to player 2, that they must selected from.
            else
            {

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if ((positionsArray[i, j]).Contains(playerTwo) || (positionsArray[i, j]).Contains(playerTwoKing))
                        {
                            if ((CanAPieceBeCapturedRight(i, j, positionsArray, ref player1Turn).Equals(true)) ||
                                (CanAPieceBeCapturedLeft(i, j, positionsArray, ref player1Turn).Equals(true)) ||
                                (CanAPieceBeCapturedKing(i, j, positionsArray, ref player1Turn).Equals(true)))
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

                    // Checks that the destination co-ords to the down right are the correct ones to perform the forced 'take'
                    if (listOfForcedMoves.Contains(potentialMoveCheck) && ((yOne + 2).Equals(yTwo) && (xOne + 2).Equals(xTwo)))
                    {
                        PlayerMove(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn);
                        return;
                    }

                    // Checks that the destination co-ords to the down left are the correct ones to perform the forced 'take'
                    if (listOfForcedMoves.Contains(potentialMoveCheck) && ((yOne + 2).Equals(yTwo) && (xOne - 2).Equals(xTwo)))
                    {
                        PlayerMove(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn);
                        return;
                    }
                    // Checks that the destination co-ords to the up right are the correct ones to perform the forced 'take'
                    if (listOfForcedMoves.Contains(potentialMoveCheck) && ((yOne - 2).Equals(yTwo) && (xOne + 2).Equals(xTwo)))
                    {
                        PlayerMove(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn);
                        return;
                    }

                    // Checks that the destination co-ords to the up left are the correct ones to perform the forced 'take'
                    if (listOfForcedMoves.Contains(potentialMoveCheck) && ((yOne - 2).Equals(yTwo) && (xOne - 2).Equals(xTwo)))
                    {
                        PlayerMove(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn);
                        return;
                    }
                    else
                    {
                        Console.Beep();
                        Console.WriteLine("You must 'take' your opponents piece");
                        Console.ReadKey();
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
                    if ((positionsArray[(yOne - 1), (xOne + 1)].Equals(playerTwo) || positionsArray[(yOne - 1), (xOne + 1)].Equals(playerTwoKing)) && positionsArray[(yOne - 2), (xOne + 2)].Equals(noMansLand))
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
                    if ((positionsArray[(yOne + 1), (xOne + 1)].Equals(playerOne) || positionsArray[(yOne + 1), (xOne + 1)].Equals(playerOneKing)) && positionsArray[(yOne + 2), (xOne + 2)].Equals(noMansLand))
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
                    if ((positionsArray[(yOne - 1), (xOne - 1)].Equals(playerTwo) || positionsArray[(yOne - 1), (xOne - 1)].Equals(playerTwoKing)) && positionsArray[(yOne - 2), (xOne - 2)].Equals(noMansLand))
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
                    if ((positionsArray[(yOne + 1), (xOne - 1)].Equals(playerOne) || positionsArray[(yOne + 1), (xOne - 1)].Equals(playerOneKing)) && positionsArray[(yOne + 2), (xOne - 2)].Equals(noMansLand))
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


        public bool CanAPieceBeCapturedKing(int yOne, int xOne, string[,] positionsArray, ref bool player1Turn)
        {
            if (player1Turn.Equals(true))
            {
                // Checks Up Right 
                if ((yOne > 1 && xOne < 6) && (((positionsArray[(yOne - 1), (xOne + 1)].Equals(playerTwo) || positionsArray[(yOne - 1), (xOne + 1)].Equals(playerTwoKing)) && positionsArray[(yOne - 2), (xOne + 2)].Equals(noMansLand))))
                {
                    return true;
                }
                // Checks Down Right
                if ((yOne < 6 && xOne < 6) && (((positionsArray[(yOne + 1), (xOne + 1)].Equals(playerTwo) || positionsArray[(yOne + 1), (xOne + 1)].Equals(playerTwoKing)) && positionsArray[(yOne + 2), (xOne + 2)].Equals(noMansLand))))
                {
                    return true;
                }
                // Checks Up Left
                if ((yOne > 1 && xOne > 1) && (((positionsArray[(yOne - 1), (xOne - 1)].Equals(playerTwo) || positionsArray[(yOne - 1), (xOne - 1)].Equals(playerTwoKing)) && positionsArray[(yOne - 2), (xOne - 2)].Equals(noMansLand))))
                {
                    return true;
                }
                // Checks Down Left
                if ((yOne < 6 && xOne > 1) && (((positionsArray[(yOne + 1), (xOne - 1)].Equals(playerTwo) || positionsArray[(yOne + 1), (xOne - 1)].Equals(playerTwoKing)) && positionsArray[(yOne + 2), (xOne - 2)].Equals(noMansLand))))
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
                // Checks Up Right 
                if ((yOne > 1 && xOne < 6) && (((positionsArray[(yOne - 1), (xOne + 1)].Equals(playerOne) || positionsArray[(yOne - 1), (xOne + 1)].Equals(playerOneKing)) && positionsArray[(yOne - 2), (xOne + 2)].Equals(noMansLand))))
                {
                    return true;
                }
                // Checks Down Right
                if ((yOne < 6 && xOne < 6) && (((positionsArray[(yOne + 1), (xOne + 1)].Equals(playerOne) || positionsArray[(yOne + 1), (xOne + 1)].Equals(playerOneKing)) && positionsArray[(yOne + 2), (xOne + 2)].Equals(noMansLand))))
                {
                    return true;
                }
                // Checks Up Left
                if ((yOne > 1 && xOne > 1) && (((positionsArray[(yOne - 1), (xOne - 1)].Equals(playerOne) || positionsArray[(yOne - 1), (xOne - 1)].Equals(playerOneKing)) && positionsArray[(yOne - 2), (xOne - 2)].Equals(noMansLand))))
                {
                    return true;
                }
                // Checks Down Left
                if ((yOne < 6 && xOne > 1) && (((positionsArray[(yOne + 1), (xOne - 1)].Equals(playerOne) || positionsArray[(yOne + 1), (xOne - 1)].Equals(playerOneKing)) && positionsArray[(yOne + 2), (xOne - 2)].Equals(noMansLand))))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }        
        
        // Method checks that the first co-ords entered contain a piece belonging to the player attempting to play their turn
        public bool PlayerCheck(int yOne, int xOne, string[,] positionsArray, bool player1Turn)
        {
            
            if (player1Turn.Equals(true))
            {
                if (!positionsArray[yOne, xOne].Equals(" X ") && !positionsArray[yOne, xOne].Equals("|X|"))
                {
                    return false;
                }
            }
            else
            {
                if (!positionsArray[yOne, xOne].Equals(" O ") && !positionsArray[yOne, xOne].Equals("|O|"))
                {
                    return false;
                }
            }

            return true;
        }
    

        // Method converts normal pieces into Kings, when the normal pieces land on the last row
        public void IsItAKing(int yTwo, int xTwo, string[,] positionsArrays, ref bool player1Turn)
        {
            if (yTwo.Equals(0) && (xTwo.Equals(1) || xTwo.Equals(3) || xTwo.Equals(5) || xTwo.Equals(7)))
            {
                if (positionsArrays[yTwo, xTwo].Equals(" X "))
                {
                    positionsArrays[yTwo, xTwo] = "|X|";
                    player1Turn = false;
                }
            }
            if (yTwo.Equals(7) && (xTwo.Equals(0) || xTwo.Equals(2) || xTwo.Equals(4) || xTwo.Equals(6)))
            {
                if (positionsArrays[yTwo, xTwo].Equals(" O "))
                {
                    positionsArrays[yTwo, xTwo] = "|O|";
                    player1Turn = true;
                }
            }
        }

        #endregion

        #region Advanced Movement

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

                        if ((CanAPieceBeCapturedRight(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false) && (CanAPieceBeCapturedLeft(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false) && (CanAPieceBeCapturedKing(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false))
                        {
                            player1Turn = false;
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

                        if ((CanAPieceBeCapturedRight(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false) && (CanAPieceBeCapturedLeft(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false) && (CanAPieceBeCapturedKing(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false))
                        {
                            player1Turn = false;
                        }

                        return;
                    }
                }

                if (CanAPieceBeCapturedKing(yOne, xOne, positionsArray, ref player1Turn).Equals(true))
                {

                    // Checks if removing a piece to the top left is the move made
                    if ((yOne - 2).Equals(yTwo) && (xOne - 2).Equals(xTwo))
                    {
                        // Sets the square clicked first to blank
                        positionsArray[yOne, xOne] = noMansLand;

                        // Sets the square with the oppositions pieces on it to empty
                        positionsArray[(yOne - 1), (xOne - 1)] = noMansLand;

                        // Sets the square clicked second to now show the player one piece
                        positionsArray[yTwo, xTwo] = playerOneKing;
                    }

                    // Checks if removing a piece to the top right is the move made
                    if ((yOne - 2).Equals(yTwo) && (xOne + 2).Equals(xTwo))
                    {
                        // Sets the square clicked first to blank
                        positionsArray[yOne, xOne] = noMansLand;

                        // Sets the square with the oppositions pieces on it to empty
                        positionsArray[(yOne - 1), (xOne + 1)] = noMansLand;

                        // Sets the square clicked second to now show the player one piece
                        positionsArray[yTwo, xTwo] = playerOneKing;
                    }

                    // Checks if removing a piece to the bottom right is the move made
                    if ((yOne + 2).Equals(yTwo) && (xOne + 2).Equals(xTwo))
                    {
                        // Sets the square clicked first to blank
                        positionsArray[yOne, xOne] = noMansLand;

                        // Sets the square with the oppositions pieces on it to empty
                        positionsArray[(yOne + 1), (xOne + 1)] = noMansLand;

                        // Sets the square clicked second to now show the player one piece
                        positionsArray[yTwo, xTwo] = playerOneKing;
                    }

                    // Checks if removing a piece to the bottom left is the move made
                    if ((yOne + 2).Equals(yTwo) && (xOne - 2).Equals(xTwo))
                    {
                        // Sets the square clicked first to blank
                        positionsArray[yOne, xOne] = noMansLand;

                        // Sets the square with the oppositions pieces on it to empty
                        positionsArray[(yOne + 1), (xOne - 1)] = noMansLand;

                        // Sets the square clicked second to now show the player one piece
                        positionsArray[yTwo, xTwo] = playerOneKing;
                    }

                    if ((CanAPieceBeCapturedRight(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false) && (CanAPieceBeCapturedLeft(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false) && (CanAPieceBeCapturedKing(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false))
                    {
                        player1Turn = false;
                    }
                }

                if (positionsArray[yTwo, xTwo].Equals(noMansLand))
                {
                    // Basic Movement
                    if ((MovementRight(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn).Equals(true)) || (MovementLeft(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn).Equals(true)) || (MovementKing(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn).Equals(true)))
                    {
                        player1Turn = false;
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

                        if ((CanAPieceBeCapturedRight(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false) && (CanAPieceBeCapturedLeft(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false) && (CanAPieceBeCapturedKing(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false))
                        {
                            player1Turn = true;
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

                        if ((CanAPieceBeCapturedRight(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false) && (CanAPieceBeCapturedLeft(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false) && (CanAPieceBeCapturedKing(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false))
                        {
                            player1Turn = true;
                        }

                        return;
                    }
                }

                if (CanAPieceBeCapturedKing(yOne, xOne, positionsArray, ref player1Turn).Equals(true))
                {

                    // Checks if removing a piece to the top left is the move made
                    if ((yOne - 2).Equals(yTwo) && (xOne - 2).Equals(xTwo))
                    {
                        // Sets the square clicked first to blank
                        positionsArray[yOne, xOne] = noMansLand;

                        // Sets the square with the oppositions pieces on it to empty
                        positionsArray[(yOne - 1), (xOne - 1)] = noMansLand;

                        // Sets the square clicked second to now show the player one piece
                        positionsArray[yTwo, xTwo] = playerTwoKing;
                    }

                    // Checks if removing a piece to the top right is the move made
                    if ((yOne - 2).Equals(yTwo) && (xOne + 2).Equals(xTwo))
                    {
                        // Sets the square clicked first to blank
                        positionsArray[yOne, xOne] = noMansLand;

                        // Sets the square with the oppositions pieces on it to empty
                        positionsArray[(yOne - 1), (xOne + 1)] = noMansLand;

                        // Sets the square clicked second to now show the player one piece
                        positionsArray[yTwo, xTwo] = playerTwoKing;
                    }

                    // Checks if removing a piece to the bottom right is the move made
                    if ((yOne + 2).Equals(yTwo) && (xOne + 2).Equals(xTwo))
                    {
                        // Sets the square clicked first to blank
                        positionsArray[yOne, xOne] = noMansLand;

                        // Sets the square with the oppositions pieces on it to empty
                        positionsArray[(yOne + 1), (xOne + 1)] = noMansLand;

                        // Sets the square clicked second to now show the player one piece
                        positionsArray[yTwo, xTwo] = playerTwoKing;
                    }

                    // Checks if removing a piece to the bottom left is the move made
                    if ((yOne + 2).Equals(yTwo) && (xOne - 2).Equals(xTwo))
                    {
                        // Sets the square clicked first to blank
                        positionsArray[yOne, xOne] = noMansLand;

                        // Sets the square with the oppositions pieces on it to empty
                        positionsArray[(yOne + 1), (xOne - 1)] = noMansLand;

                        // Sets the square clicked second to now show the player one piece
                        positionsArray[yTwo, xTwo] = playerTwoKing;
                    }

                    if ((CanAPieceBeCapturedRight(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false) && (CanAPieceBeCapturedLeft(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false) && (CanAPieceBeCapturedKing(yTwo, xTwo, positionsArray, ref player1Turn)).Equals(false))
                    {
                        player1Turn = true;
                    }
                }


                if (positionsArray[yTwo, xTwo].Equals(noMansLand))
                {
                    // Basic Movement
                    if ((MovementRight(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn).Equals(true)) || (MovementLeft(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn).Equals(true)) || (MovementKing(yOne, xOne, yTwo, xTwo, positionsArray, ref player1Turn).Equals(true)))
                    {
                        player1Turn = true;
                        return;
                    }
                }
            }
        }

        #endregion        
    }
}
