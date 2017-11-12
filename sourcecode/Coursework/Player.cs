//////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////// Class Player ////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////// Code Written By: Marc Reid [03001588] ////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////

// Description:
// This class provides the logic for both king and normal playing pieces for both players


#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Coursework
{
    public class Player
    {
        #region Variables

        // Constant strings representing the different contents of a playable square
        const string playerOne = " X ";
        const string playerTwo = " O ";
        const string noMansLand = "   ";
        const string playerOneKing = "|X|";
        const string playerTwoKing = "|O|";

        #endregion

        #region Basic Movement

        /// <summary>
        /// Checks if a normal piece can move to the right of their current position
        /// If it can it makes the move based on the co-ordinates given
        /// </summary>
        /// <param name="yOne"> Needed to set to current position to blank, if the piece can move</param>
        /// <param name="xOne"> Needed to set to current position to blank, if the piece can move</param>
        /// <param name="yTwo"> Needed to check the position the player wants to move the piece to is empty</param>
        /// <param name="xTwo"> Needed to check the position the player wants to move the piece to is empty</param>
        /// <param name="positionsArray"> The array which stores the current playing piece positions</param>
        /// <param name="player1Turn"> Indicates whose turn it currently is</param>
        /// <returns> A boolean value depending if the normal piece can move right or not</returns>
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

        /// <summary>
        /// Checks if a normal piece can move to the left of their current position
        /// If it can it makes the move based on the co-ordinates given
        /// </summary>
        /// <param name="yOne"> Needed to set to current position to blank, if the piece can move</param>
        /// <param name="xOne"> Needed to set to current position to blank, if the piece can move</param>
        /// <param name="yTwo"> Needed to check the position the player wants to move the piece to is empty</param>
        /// <param name="xTwo"> Needed to check the position the player wants to move the piece to is empty</param>
        /// <param name="positionsArray"> The array which stores the current playing piece positions</param>
        /// <param name="player1Turn"> Indicates whose turn it currently is</param>
        /// <returns> A boolean value depending if the normal piece can move left or not</returns>
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

        /// <summary>
        /// Checks if a king can move in atleast 1 of the 4 directions available to the king
        /// If it can it makes the move based on the co-ordinates given
        /// </summary>
        /// <param name="yOne">Needed to set to current position to blank, if the piece can move</param>
        /// <param name="xOne">Needed to set to current position to blank, if the piece can move</param>
        /// <param name="yTwo">Needed to check the position the player wants to move the piece to is empty</param>
        /// <param name="xTwo">Needed to check the position the player wants to move the piece to is empty</param>
        /// <param name="positionsArray">The array which stores the current playing piece positions</param>
        /// <param name="player1Turn">Indicates whose turn it currently is</param>
        /// <returns>A boolean value depending if the king piece can move or not</returns>
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

        /// <summary>
        /// Checks if there are any available moves for the player whose turn it is
        /// </summary>
        /// <param name="positionsArray">The array which stores the current playing piece positions</param>
        /// <param name="player1Turn">Indicates whose turn it currently is</param>
        /// <returns>A boolean value depending if a player has any valid moves or not</returns>
        public bool AreThereAnyValidMoves(string[,] positionsArray, bool player1Turn)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (player1Turn.Equals(true))
                    {
                        if ((positionsArray[i, j]).Equals(playerOne))
                        {
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

                            // Checks Up Left for an empty tile                            
                            // To stop the if statement recieving an out of bounds exception
                            if (i > 0 && j > 0)
                            {
                                // Check if player 1 can move left                    
                                if (positionsArray[(i - 1), (j - 1)].Equals(noMansLand))
                                {
                                    return true;
                                }
                            }

                            // Checks Up Right for an empty tile                            
                            // To stop the if statement recieving an out of bounds exception
                            if (i > 0 && j < 7)
                            {
                                // Check if player 1 can move left                    
                                if (positionsArray[(i - 1), (j + 1)].Equals(noMansLand))
                                {
                                    return true;
                                }
                            }
                        }

                        if ((positionsArray[i, j]).Equals(playerOneKing))
                        {
                            // Movement Up Right
                            // To stop the if statement recieving an out of bounds exception
                            if (i > 0 && j < 7)
                            {
                                if (positionsArray[(i - 1), (j + 1)].Equals(noMansLand))
                                {
                                    return true;
                                }

                            }

                            // Movement Down Right
                            // To stop the if statement recieving an out of bounds exception
                            if (i < 7 && j < 7)
                            {
                                if (positionsArray[(i + 1), (j + 1)].Equals(noMansLand))
                                {
                                    return true;
                                }
                            }

                            // Movement Up Left
                            // To stop the if statement recieving an out of bounds exception
                            if (i > 0 && j > 0)
                            {
                                // Check if player 1 can move left
                                if (positionsArray[(i - 1), (j - 1)].Equals(noMansLand))
                                {
                                    return true;
                                }
                            }

                            // Movement Down Left
                            // To stop the if statement recieving an out of bounds exception
                            if (i < 7 && j > 0)
                            {
                                if (positionsArray[(i + 1), (j - 1)].Equals(noMansLand))
                                {
                                    return true;
                                }
                            }

                            // Checks All 4 directions for the king
                            if (CanAPieceBeCapturedKing(i, j, positionsArray, ref player1Turn).Equals(true))
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        if (positionsArray[i, j].Equals(playerTwo))
                        {
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
                            // To stop the if statement recieving an out of bounds exception
                            if (i < 7 && j > 0)
                            {
                                // Check if player 2 can move left                    
                                if (positionsArray[(i + 1), (j - 1)].Equals(noMansLand))
                                {
                                    return true;
                                }
                            }

                            // Checks Down Right for an empty tile                            
                            // To stop the if statement recieving an out of bounds exception
                            if (i < 7 && j < 7)
                            {
                                // Check if player 2 can move left                    
                                if (positionsArray[(i + 1), (j + 1)].Equals(noMansLand))
                                {
                                    return true;
                                }
                            }

                        }
                        if (positionsArray[i, j].Equals(playerTwoKing))
                        {
                            // Movement Up Right
                            // To stop the if statement recieving an out of bounds exception
                            if (i > 0 && j < 7)
                            {
                                if (positionsArray[(i - 1), (j + 1)].Equals(noMansLand))
                                {
                                    return true;
                                }

                            }

                            // Movement Down Right
                            // To stop the if statement recieving an out of bounds exception
                            if (i < 7 && j < 7)
                            {
                                if (positionsArray[(i + 1), (j + 1)].Equals(noMansLand))
                                {
                                    return true;
                                }
                            }

                            // Movement Up Left
                            // To stop the if statement recieving an out of bounds exception
                            if (i > 0 && j > 0)
                            {
                                // Check if player 1 can move left
                                if (positionsArray[(i - 1), (j - 1)].Equals(noMansLand))
                                {
                                    return true;
                                }
                            }

                            // Movement Down Left
                            // To stop the if statement recieving an out of bounds exception
                            if (i < 7 && j > 0)
                            {
                                if (positionsArray[(i + 1), (j - 1)].Equals(noMansLand))
                                {
                                    return true;
                                }
                            }

                            // Checks All 4 directions for the king
                            if (CanAPieceBeCapturedKing(i, j, positionsArray, ref player1Turn).Equals(true))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }


        /// <summary>
        /// Checks if the current player has a capture move available which they will be forced to take
        /// </summary>
        /// <param name="player1Turn">Indicates whose turn it currently is</param>
        /// <param name="positionsArray">The array which stores the current playing piece positions</param>     
        /// <param name="yOne">This value is used to determine whether the piece selected by the user, is on the list of forced moves or not</param>
        /// <param name="xOne">This value is used to determine whether the piece selected by the user, is on the list of forced moves or not</param>
        /// <param name="yTwo">This value is passed on when the method PlayerMove is called to determine the destination square</param>
        /// <param name="xTwo">This value is passed on when the method PlayerMove is called to determine the destination square</param>
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
                        if ((positionsArray[i, j]).Contains(playerOne))
                        {
                            if ((CanAPieceBeCapturedRight(i, j, positionsArray, ref player1Turn).Equals(true)) ||
                                (CanAPieceBeCapturedLeft(i, j, positionsArray, ref player1Turn).Equals(true)))
                            {
                                int potentialMove = Convert.ToInt32(string.Format("{0}{1}", i, j));
                                listOfForcedMoves.Add(potentialMove);
                                forcedCapture = true;
                            }
                        }

                        if ((positionsArray[i, j]).Contains(playerOneKing))
                        {
                            if (CanAPieceBeCapturedKing(i, j, positionsArray, ref player1Turn).Equals(true))
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
                        if ((positionsArray[i, j]).Contains(playerTwo))
                        {
                            if ((CanAPieceBeCapturedRight(i, j, positionsArray, ref player1Turn).Equals(true)) ||
                                (CanAPieceBeCapturedLeft(i, j, positionsArray, ref player1Turn).Equals(true)))
                            {
                                int potentialMove = Convert.ToInt32(string.Format("{0}{1}", i, j));
                                listOfForcedMoves.Add(potentialMove);
                                forcedCapture = true;
                            }

                        }

                        if ((positionsArray[i, j]).Contains(playerTwoKing))
                        {
                            if ((CanAPieceBeCapturedKing(i, j, positionsArray, ref player1Turn).Equals(true)))
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

        /// <summary>
        /// Checks if a normal piece can capture an opponents piece to the right
        /// </summary>
        /// <param name="yOne">This value is used to determine whether the piece selected by the user, can capture a piece to the right</param>
        /// <param name="xOne">This value is used to determine whether the piece selected by the user, can capture a piece to the right</param>        
        /// <param name="positionsArray">The array which stores the current playing piece positions</param>     
        /// <param name="player1Turn">Indicates whose turn it currently is</param>       
        /// <returns>A boolean value indicating if a piece can be captured to the right or not</returns>
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

        /// <summary>
        /// Checks if a normal piece can capture an opponents piece to the left
        /// </summary>
        /// <param name="yOne">This value is used to determine whether the piece selected by the user, can capture a piece to the left</param>
        /// <param name="xOne">This value is used to determine whether the piece selected by the user, can capture a piece to the left</param>        
        /// <param name="positionsArray">The array which stores the current playing piece positions</param>     
        /// <param name="player1Turn">Indicates whose turn it currently is</param>       
        /// <returns>A boolean value indicating if a piece can be captured to the left or not</returns>
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

        /// <summary>
        /// Checks if a king piece can capture an opponents piece in any of the 4 directions available
        /// </summary>
        /// <param name="yOne">This value is used to determine whether the piece selected by the user, can capture an opponents piece</param>
        /// <param name="xOne">This value is used to determine whether the piece selected by the user, can capture an opponents piece</param>        
        /// <param name="positionsArray">The array which stores the current playing piece positions</param>     
        /// <param name="player1Turn">Indicates whose turn it currently is</param>       
        /// <returns>A boolean value indicating if a king piece can be captured an opponents piece or not</returns>
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

        /// <summary>
        /// Checks that the first co-ordinates entered contain a piece belonging to the player attempting to play their turn
        /// </summary>
        /// <param name="yOne">This value is used to determine whether the piece selected belongs to the player whose turn it currently is</param>
        /// <param name="xOne">This value is used to determine whether the piece selected belongs to the player whose turn it currently is</param>        
        /// <param name="positionsArray">The array which stores the current playing piece positions</param>     
        /// <param name="player1Turn">Indicates whose turn it currently is</param>       
        /// <returns>A boolean value indicating if the piece selected belongs to the player whose turn it currently is</returns>
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


        /// <summary>
        /// Converts normal pieces into Kings, when the normal pieces land on the last row
        /// </summary>
        /// <param name="yTwo">This value is used to determine if the piece that has just moved, finishes their move on an end row square</param>
        /// <param name="xTwo">This value is used to determine if the piece that has just moved, finishes their move on an end row square</param>
        /// <param name="positionsArray">The array which stores the current playing piece positions</param>
        /// <param name="player1Turn">Indicates whose turn it currently is</param>
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

        /// <summary>
        /// Method which depending on the outcome of certain checks, will move the current players piece.
        /// </summary>
        /// <param name="yOne">Needed to check other tiles from this position and if a move is made this will be need to set this tiles content to empty</param>
        /// <param name="xOne">Needed to check other tiles from this position and if a move is made this will be need to set this tiles content to empty</param>
        /// <param name="yTwo">Needed to check if this tile is empty and if there if there has been a capture made</param>
        /// <param name="xTwo">Needed to check if this tile is empty and if there if there has been a capture made</param>
        /// <param name="positionsArray">The array which stores the current playing piece positions</param>
        /// <param name="player1Turn">Indicates whose turn it currently is</param>
        private void PlayerMove(int yOne, int xOne, int yTwo, int xTwo, string[,] positionsArray, ref bool player1Turn)
        {
            // Player 1 Movement Logic
            if (player1Turn)
            {
                if ((positionsArray[yOne, xOne]).Equals(playerOne))
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
                }

                if ((positionsArray[yOne, xOne]).Equals(playerOneKing))
                {
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

            /////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////// Player 2 Movement Logic //////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////

            else
            {
                if ((positionsArray[yOne, xOne]).Equals(playerTwo))
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
                }

                if ((positionsArray[yOne, xOne]).Equals(playerTwoKing))
                {
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
