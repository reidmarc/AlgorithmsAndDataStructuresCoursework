//////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////// Class AI //////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////// Code Written By: Marc Reid [03001588] ////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////

// Description::   
// This class provides the logic for the AI.


#region Usings

using System;
using System.Collections.Generic;

#endregion

namespace Coursework
{
    public class AI
    {
        #region Variables / Objects

        // Instantiates a new object of the Player Class.
        private Player _aiPlayer = new Player();

        // Instantiates a new object of the Random Class.
        private Random _rng = new Random();

        // Constant strings representing the different contents of a playable square
        private const string _playerOne = " X ";
        private const string _playerTwo = " O ";
        private const string _noMansLand = "   ";
        private const string _playerOneKing = "|X|";
        private const string _playerTwoKing = "|O|";

        private bool _downLeft = false;
        private bool _downRight = false;
        private bool _upRight = false;
        private bool _upLeft = false;

        private int _randomNumberGenCounter = 0;
        private int _randomMoveCounter = 0;
         
        private int _getPlayerOneMoveCounter = 0;
        private int _getPlayerTwoMoveCounter = 0;
         
        private int _howManyMovesWithoutACapture = 0;

        #endregion

        #region A.I. Movement Logic

        /// <summary>
        /// Method searches for the current players pieces and checks if they can capture an opponents piece
        /// If they can this method changes the valuesof yOne, xOne, yTwo and xTwo and returns
        /// If they cannot then the method searches for the current players pieces and checks if they can make a legal move
        /// When a legal move is found the method changes the valuesof yOne, xOne, yTwo and xTwo and returns        
        /// </summary>
        /// <param name="yOne"> Used to change the Y co-ordinate of the piece the AI wants to move</param>
        /// <param name="xOne"> Used to change the X co-ordinate of the piece the AI wants to move</param>
        /// <param name="yTwo"> Used to change the Y co-ordinate of the destination tile the AI wants to move their piece to</param>
        /// <param name="xTwo"> Used to change the X co-ordinate of the destination tile the AI wants to move their piece to</param>
        /// <param name="positionsArray"> Used to search through to make decisions based on playing piece positions</param>
        /// <param name="player1Turn"> Indicates whose turn it currently is</param>
        public void GetMove(ref int yOne, ref int xOne, ref int yTwo, ref int xTwo, string[,] positionsArray, ref bool player1Turn)
        {
            if (player1Turn)
            {
                _getPlayerOneMoveCounter = _getPlayerOneMoveCounter + 1;

                if ((_getPlayerOneMoveCounter % 2).Equals(0))
                {
                    // Loops through the array looking for a king piece and whether it can 'take' an opponents piece
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (positionsArray[i, j].Equals(_playerOneKing))
                            {
                                if (_aiPlayer.CanAPieceBeCapturedKing(i, j, positionsArray, ref player1Turn).Equals(true))
                                {
                                    yOne = i;
                                    xOne = j;

                                    if (KingCapture(yOne, xOne, ref yTwo, ref xTwo, positionsArray, _playerTwo, _playerTwoKing).Equals(true))
                                    {
                                        _howManyMovesWithoutACapture = 0;
                                        return;
                                    }                                    
                                }
                            }
                        }
                    }

                    // Loops through the array looking for a normal piece and whether it can 'take' an opponents piece
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (positionsArray[i, j].Equals(_playerOne))
                            {
                                yOne = i;
                                xOne = j;

                                if (NormalCapture(yOne, xOne, ref yTwo, ref xTwo, positionsArray, ref player1Turn).Equals(true))
                                {
                                    _howManyMovesWithoutACapture = 0;
                                    return;
                                }                               
                            }
                        }
                    }

                    _howManyMovesWithoutACapture = _howManyMovesWithoutACapture + 1;                    

                    // Loops through the array looking to make a legal move with a king piece
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (positionsArray[i, j].Equals(_playerOneKing))
                            {
                                yOne = i;
                                xOne = j;

                                if (KingLegalMove(yOne, xOne, ref yTwo, ref xTwo, positionsArray).Equals(true))
                                {
                                    return;
                                }   
                            }
                        }
                    }

                    // Loops through the array looking to make a legal move with a normal piece
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (positionsArray[i, j].Equals(_playerOne))
                            {
                                yOne = i;
                                xOne = j;

                                if (NormalLegalMove(yOne, xOne, ref yTwo, ref xTwo, positionsArray).Equals(true))
                                {
                                    return;
                                }                                
                            }
                        }
                    }
                }
                else
                {

                    // Loops through the array looking for a king piece and whether it can 'take' an opponents piece
                    for (int i = 7; i >= 0; i--)
                    {
                        for (int j = 7; j >= 0; j--)
                        {
                            if (positionsArray[i, j].Equals(_playerOneKing))
                            {
                                if (_aiPlayer.CanAPieceBeCapturedKing(i, j, positionsArray, ref player1Turn).Equals(true))
                                {
                                    yOne = i;
                                    xOne = j;

                                    if (KingCapture(yOne, xOne, ref yTwo, ref xTwo, positionsArray, _playerTwo, _playerTwoKing).Equals(true))
                                    {
                                        _howManyMovesWithoutACapture = 0;
                                        return;
                                    }
                                }
                            }
                        }
                    }

                    // Loops through the array looking for a normal piece and whether it can 'take' an opponents piece
                    for (int i = 7; i >= 0; i--)
                    {
                        for (int j = 7; j >= 0; j--)
                        {
                            if (positionsArray[i, j].Equals(_playerOne))
                            {
                                yOne = i;
                                xOne = j;

                                if (NormalCapture(yOne, xOne, ref yTwo, ref xTwo, positionsArray, ref player1Turn).Equals(true))
                                {
                                    _howManyMovesWithoutACapture = 0;
                                    return;
                                }
                            }
                        }
                    }

                    _howManyMovesWithoutACapture = _howManyMovesWithoutACapture + 1;                    

                    // Loops through the array looking to make a legal move with a king piece
                    for (int i = 7; i >= 0; i--)
                    {
                        for (int j = 7; j >= 0; j--)
                        {
                            if (positionsArray[i, j].Equals(_playerOneKing))
                            {
                                yOne = i;
                                xOne = j;

                                if (KingLegalMove(yOne, xOne, ref yTwo, ref xTwo, positionsArray).Equals(true))
                                {
                                    return;
                                }                                
                            }
                        }
                    }

                    // Loops through the array looking to make a legal move with a normal piece
                    for (int i = 7; i >= 0; i--)
                    {
                        for (int j = 7; j >= 0; j--)
                        {
                            if (positionsArray[i, j].Equals(_playerOne))
                            {
                                yOne = i;
                                xOne = j;

                                if (NormalLegalMove(yOne, xOne, ref yTwo, ref xTwo, positionsArray).Equals(true))
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            /////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////// Player 2 AI Logic /////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////
            else
            {
                _getPlayerTwoMoveCounter = _getPlayerTwoMoveCounter + 1;

                if ((_getPlayerTwoMoveCounter % 2).Equals(0))
                {
                    // Loops through the array looking for a king piece and whether it can 'take' an opponents piece
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (positionsArray[i, j].Equals(_playerTwoKing))
                            {
                                if (_aiPlayer.CanAPieceBeCapturedKing(i, j, positionsArray, ref player1Turn).Equals(true))
                                {
                                    yOne = i;
                                    xOne = j;

                                    if (KingCapture(yOne, xOne, ref yTwo, ref xTwo, positionsArray, _playerOne, _playerOneKing).Equals(true))
                                    {
                                        _howManyMovesWithoutACapture = 0;
                                        return;
                                    }
                                }
                            }
                        }
                    }

                    // Loops through the array looking for a normal piece and whether it can 'take' an opponents piece
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (positionsArray[i, j].Equals(_playerTwo))
                            {
                                yOne = i;
                                xOne = j;

                                if (NormalCapture(yOne, xOne, ref yTwo, ref xTwo, positionsArray, ref player1Turn).Equals(true))
                                {
                                    _howManyMovesWithoutACapture = 0;
                                    return;
                                }  
                            }
                        }
                    }

                    _howManyMovesWithoutACapture = _howManyMovesWithoutACapture + 1;
                   

                    // Loops through the array looking to make a legal move with a king piece
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (positionsArray[i, j].Equals(_playerTwoKing))
                            {
                                yOne = i;
                                xOne = j;

                                if (KingLegalMove(yOne, xOne, ref yTwo, ref xTwo, positionsArray).Equals(true))
                                {
                                    return;
                                }   
                            }
                        }
                    }

                    // Loops through the array looking to make a legal move with a normal piece
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (positionsArray[i, j].Equals(_playerTwo))
                            {
                                yOne = i;
                                xOne = j;

                                if (NormalLegalMove(yOne, xOne, ref yTwo, ref xTwo, positionsArray).Equals(true))
                                {                                   
                                    return;
                                }    
                            }
                        }
                    }
                }
                else
                {
                    // Loops through the array looking for a king piece and whether it can 'take' an opponents piece
                    for (int i = 7; i >= 0; i--)
                    {
                        for (int j = 7; j >= 0; j--)
                        {
                            if (positionsArray[i, j].Equals(_playerTwoKing))
                            {
                                if (_aiPlayer.CanAPieceBeCapturedKing(i, j, positionsArray, ref player1Turn).Equals(true))
                                {
                                    yOne = i;
                                    xOne = j;

                                    if (KingCapture(yOne, xOne, ref yTwo, ref xTwo, positionsArray, _playerOne, _playerOneKing).Equals(true))
                                    {
                                        _howManyMovesWithoutACapture = 0;
                                        return;
                                    }   
                                }
                            }
                        }
                    }

                    // Loops through the array looking for a normal piece and whether it can 'take' an opponents piece
                    for (int i = 7; i >= 0; i--)
                    {
                        for (int j = 7; j >= 0; j--)
                        {
                            if (positionsArray[i, j].Equals(_playerTwo))
                            {
                                yOne = i;
                                xOne = j;

                                if (NormalCapture(yOne, xOne, ref yTwo, ref xTwo, positionsArray, ref player1Turn).Equals(true))
                                {
                                    _howManyMovesWithoutACapture = 0;
                                    return;
                                }   
                            }
                        }
                    }

                    _howManyMovesWithoutACapture = _howManyMovesWithoutACapture + 1;                    

                    // Loops through the array looking to make a legal move with a king piece
                    for (int i = 7; i >= 0; i--)
                    {
                        for (int j = 7; j >= 0; j--)
                        {
                            if (positionsArray[i, j].Equals(_playerTwoKing))
                            {
                                yOne = i;
                                xOne = j;

                                if (KingLegalMove(yOne, xOne, ref yTwo, ref xTwo, positionsArray).Equals(true))
                                {                                    
                                    return;
                                }
                            }
                        }
                    }

                    // Loops through the array looking to make a legal move with a normal piece
                    for (int i = 7; i >= 0; i--)
                    {
                        for (int j = 7; j >= 0; j--)
                        {

                            if (positionsArray[i, j].Equals(_playerTwo))
                            {
                                yOne = i;
                                xOne = j;

                                if (NormalLegalMove(yOne, xOne, ref yTwo, ref xTwo, positionsArray).Equals(true))
                                {
                                   return;
                                }                              
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Checks if the king found can capture an opponents piece
        /// </summary>
        /// <param name="yOne"> Used to determine where the king is on the boards Y axis</param>
        /// <param name="xOne"> Used to determine where the king is on the boards X axis</param>
        /// <param name="yTwo"> Passed in so that it can be changed if a successful capture happens</param>
        /// <param name="xTwo"> Passed in so that it can be changed if a successful capture happens</param>
        /// <param name="positionsArray">The array that stores all the positions of the current playing pieces</param>
        /// <param name="player"> The normal piece that is needed for a successful capture</param>
        /// <param name="king"> The king piece that is needed for a successful capture</param>
        /// <returns> A boolean value depending on whether the king has captured a piece or not</returns>
        private bool KingCapture(int yOne, int xOne, ref int yTwo, ref int xTwo, string[,] positionsArray, string player, string king)
        {
            // Checks Up Right 
            if ((yOne > 1 && xOne < 6) && (((positionsArray[(yOne - 1), (xOne + 1)].Equals(player) || positionsArray[(yOne - 1), (xOne + 1)].Equals(king)) && positionsArray[(yOne - 2), (xOne + 2)].Equals(_noMansLand))))
            {
                yTwo = yOne - 2;
                xTwo = xOne + 2;
                return true;
            }
           
            // Checks Down Right
            if ((yOne < 6 && xOne < 6) && (((positionsArray[(yOne + 1), (xOne + 1)].Equals(player) || positionsArray[(yOne + 1), (xOne + 1)].Equals(king)) && positionsArray[(yOne + 2), (xOne + 2)].Equals(_noMansLand))))
            {
                yTwo = yOne + 2;
                xTwo = xOne + 2;
                return true;
            }
            // Checks Down Left
            if ((yOne < 6 && xOne > 1) && (((positionsArray[(yOne + 1), (xOne - 1)].Equals(player) || positionsArray[(yOne + 1), (xOne - 1)].Equals(king)) && positionsArray[(yOne + 2), (xOne - 2)].Equals(_noMansLand))))
            {
                yTwo = yOne + 2;
                xTwo = xOne - 2;
                return true;
            }
            // Checks Up Left
            if ((yOne > 1 && xOne > 1) && (((positionsArray[(yOne - 1), (xOne - 1)].Equals(player) || positionsArray[(yOne - 1), (xOne - 1)].Equals(king)) && positionsArray[(yOne - 2), (xOne - 2)].Equals(_noMansLand))))
            {
                yTwo = yOne - 2;
                xTwo = xOne - 2;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the normal piece found can capture an opponents piece
        /// </summary>
        /// <param name="yOne"> Used to determine where the normal piece is on the boards Y axis</param>
        /// <param name="xOne"> Used to determine where the normal piece is on the boards X axis</param>
        /// <param name="yTwo"> Passed in so that it can be changed if a successful capture happens</param>
        /// <param name="xTwo"> Passed in so that it can be changed if a successful capture happens</param>
        /// <param name="positionsArray">The array that stores all the positions of the current playing pieces</param>
        /// <param name="player"> The normal piece that is needed for a successful capture</param>
        /// <param name="king"> The king piece that is needed for a successful capture</param>
        /// <returns> A boolean value depending on whether the normal piece has captured a piece or not</returns>
        private bool NormalCapture(int yOne, int xOne, ref int yTwo, ref int xTwo, string[,] positionsArray, ref bool player1Turn)
        {
            if ((positionsArray[yOne, xOne]).Equals(_playerOne))
            {
                if ((yOne > 1 && xOne < 6) && (_aiPlayer.CanAPieceBeCapturedRight(yOne, xOne, positionsArray, ref player1Turn).Equals(true)))
                {
                    yTwo = yOne - 2;
                    xTwo = xOne + 2;
                    return true;
                }
                if ((yOne > 1 && xOne > 1) && (_aiPlayer.CanAPieceBeCapturedLeft(yOne, xOne, positionsArray, ref player1Turn).Equals(true)))
                {
                    yTwo = yOne - 2;
                    xTwo = xOne - 2;
                    return true;
                }
            }

            if ((positionsArray[yOne, xOne]).Equals(_playerTwo))
            {
                if ((yOne < 6 && xOne < 6) && (_aiPlayer.CanAPieceBeCapturedRight(yOne, xOne, positionsArray, ref player1Turn).Equals(true)))
                {
                    yTwo = yOne + 2;
                    xTwo = xOne + 2;
                    return true;
                }
                if ((yOne < 6 && xOne > 1) && (_aiPlayer.CanAPieceBeCapturedLeft(yOne, xOne, positionsArray, ref player1Turn).Equals(true)))
                {
                    yTwo = yOne + 2;
                    xTwo = xOne - 2;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check if the king can make a legal move
        /// </summary>
        /// <param name="yOne"> Used to determine where the king is on the boards Y axis</param>
        /// <param name="xOne"> Used to determine where the king is on the boards X axis</param>
        /// <param name="yTwo"> Used to check if the destination tile is empty</param>
        /// <param name="xTwo"> Used to check if the destination tile is empty</param>
        /// <param name="positionsArray">The array that stores all the positions of the current playing pieces</param>
        /// <returns> A boolean value depending on whether the king can make a legal move or not</returns>
        private bool KingLegalMove(int yOne, int xOne, ref int yTwo, ref int xTwo, string[,] positionsArray)
        {        
            _downLeft = false;
            _downRight = false;
            _upRight = false;
            _upLeft = false;

            // Checks Down Left for an empty tile
            if ((yOne < 7 && xOne > 0) && (positionsArray[(yOne + 1), (xOne - 1)].Equals(_noMansLand)))
            {
                _randomNumberGenCounter = _randomNumberGenCounter + 1;
                _downLeft = true;
            }
            // Checks Down Right for an empty tile
            if ((yOne < 7 && xOne < 7) && (positionsArray[(yOne + 1), (xOne + 1)].Equals(_noMansLand)))
            {
                _randomNumberGenCounter = _randomNumberGenCounter + 1;
                _downRight = true;
            }
            // Checks Up Right for an empty tile
            if ((yOne > 0 && xOne < 7) && (positionsArray[(yOne - 1), (xOne + 1)].Equals(_noMansLand)))
            {
                _randomNumberGenCounter = _randomNumberGenCounter + 1;
                _upRight = true;
            }
            // Checks Up Left for an empty tile
            if ((yOne > 0 && xOne > 0) && (positionsArray[(yOne - 1), (xOne - 1)].Equals(_noMansLand)))
            {
                _randomNumberGenCounter = _randomNumberGenCounter + 1;
                _upLeft = true;
            }

            // If the king found on the board can legally move in 1 of the 4 directions
            // The counter 'randomNumberGenCounter' will be a value from 1 to 4
            if (_randomNumberGenCounter > 0)
            {
                // set the int random to a randomly generated number between 1 and The counter ('randomNumberGenCounter' + 1)
                int random = _rng.Next(1, (_randomNumberGenCounter + 1));

                //Creates a list to store the numbers added to the list by the following loop
                List<int> rngList = new List<int>();

                // Adds the numbers from 1 to the value for 'randomNumberGenCounter' to the list
                for (int w = 0; w < _randomNumberGenCounter; w++)
                {
                    rngList.Add(w + 1);
                }

                // If when checking which direction the king could move, the boolean value was changed to true
                // The app will enter this 'IF' statement and check if the value stored in the list[randomMoveCounter] is equal
                // To the randomly generated number 'random', if it is then the values yTwo and xTwo are changed to allow the king to move down left
                // If the move is available but the value stored in the list[randomMoveCounter] is not equal to the randomly generated number 'random'
                // Then the value for randomMoveCounter will increase by 1 and the app will check the next move available
                if (_downLeft.Equals(true))
                {
                    if ((rngList[_randomMoveCounter]).Equals(random))
                    {
                        yTwo = yOne + 1;
                        xTwo = xOne - 1;

                        rngList.Clear();
                        _randomNumberGenCounter = 0;
                        _randomMoveCounter = 0;

                        return true;
                    }
                    _randomMoveCounter = _randomMoveCounter + 1;
                }

                if (_downRight.Equals(true))
                {
                    if (rngList[_randomMoveCounter].Equals(random))
                    {
                        yTwo = yOne + 1;
                        xTwo = xOne + 1;

                        rngList.Clear();
                        _randomNumberGenCounter = 0;
                        _randomMoveCounter = 0;

                        return true;
                    }
                    _randomMoveCounter = _randomMoveCounter + 1;
                }

                if (_upRight.Equals(true))
                {
                    if (rngList[_randomMoveCounter].Equals(random))
                    {
                        yTwo = yOne - 1;
                        xTwo = xOne + 1;

                        rngList.Clear();
                        _randomNumberGenCounter = 0;
                        _randomMoveCounter = 0;

                        return true;
                    }
                    _randomMoveCounter = _randomMoveCounter + 1;
                }

                if (_upLeft.Equals(true))
                {
                    if (rngList[_randomMoveCounter].Equals(random))
                    {
                        yTwo = yOne - 1;
                        xTwo = xOne - 1;

                        rngList.Clear();
                        _randomNumberGenCounter = 0;
                        _randomMoveCounter = 0;

                        return true;
                    }
                }
            }
            return false;
        }


        /// <summary>
        /// Check if the normal piece can make a legal move
        /// </summary>
        /// <param name="yOne"> Used to determine where the normal piece is on the boards Y axis</param>
        /// <param name="xOne"> Used to determine where the normal piece is on the boards X axis</param>
        /// <param name="yTwo"> Used to check if the destination tile is empty</param>
        /// <param name="xTwo"> Used to check if the destination tile is empty</param>
        /// <param name="positionsArray">The array that stores all the positions of the current playing pieces</param>
        /// <returns> A boolean value depending on whether the normal piece can make a legal move or not</returns>
        private bool NormalLegalMove(int yOne,int xOne, ref int yTwo, ref int xTwo, string[,]positionsArray)
        {        
            _downLeft = false;
            _downRight = false;
            _upRight = false;
            _upLeft = false;


            if ((positionsArray[yOne, xOne]).Equals(_playerOne))
            {
                // Checks Up Left for an empty tile
                if ((yOne > 0 && xOne > 0) && (positionsArray[(yOne - 1), (xOne - 1)].Equals(_noMansLand)))
                {
                    _randomNumberGenCounter = _randomNumberGenCounter + 1;
                    _upLeft = true;
                }
                // Checks Up Right for an empty tile
                if ((yOne > 0 && xOne < 7) && (positionsArray[(yOne - 1), (xOne + 1)].Equals(_noMansLand)))
                {
                    _randomNumberGenCounter = _randomNumberGenCounter + 1;
                    _upRight = true;
                }
            }

            if ((positionsArray[yOne, xOne]).Equals(_playerTwo))
            {
                // Checks Down Left for an empty tile
                if ((yOne < 7 && xOne > 0) && (positionsArray[(yOne + 1), (xOne - 1)].Equals(_noMansLand)))
                {
                    _randomNumberGenCounter = _randomNumberGenCounter + 1;
                    _downLeft = true;
                }
                // Checks Down Right for an empty tile
                if ((yOne < 7 && xOne < 7) && (positionsArray[(yOne + 1), (xOne + 1)].Equals(_noMansLand)))
                {
                    _randomNumberGenCounter = _randomNumberGenCounter + 1;
                    _downRight = true;
                }
            }

            // If the piece found on the board can legally move in 1 of the 2 directions
            // The counter 'randomNumberGenCounter' will be a value from 1 to 2
            if (_randomNumberGenCounter > 0)
            {
                // set the int random to a randomly generated number between 1 and The counter ('randomNumberGenCounter' + 1)
                int random = _rng.Next(1, (_randomNumberGenCounter + 1));

                //Creates a list to store the numbers added to the list by the following loop
                List<int> rngList = new List<int>();

                // Adds the numbers from 1 to the value for 'randomNumberGenCounter' to the list
                for (int w = 0; w < _randomNumberGenCounter; w++)
                {
                    rngList.Add(w + 1);
                }

                // If when checking which direction the piece could move, the boolean value was changed to true
                // The app will enter this 'IF' statement and check if the value stored in the list[randomMoveCounter] is equal
                // To the randomly generated number 'random', if it is then the values yTwo and xTwo are changed to allow the piece to move down left
                // If the move is available but the value stored in the list[randomMoveCounter] is not equal to the randomly generated number 'random'
                // Then the value for randomMoveCounter will increase by 1 and the app will check the next move available
                if (_downLeft.Equals(true))
                {
                    if ((rngList[_randomMoveCounter]).Equals(random))
                    {
                        yTwo = yOne + 1;
                        xTwo = xOne - 1;

                        rngList.Clear();
                        _randomNumberGenCounter = 0;
                        _randomMoveCounter = 0;

                        return true;
                    }
                    _randomMoveCounter = _randomMoveCounter + 1;
                }

                if (_downRight.Equals(true))
                {
                    if (rngList[_randomMoveCounter].Equals(random))
                    {
                        yTwo = yOne + 1;
                        xTwo = xOne + 1;

                        rngList.Clear();
                        _randomNumberGenCounter = 0;
                        _randomMoveCounter = 0;

                        return true;
                    }
                    _randomMoveCounter = _randomMoveCounter + 1;
                }

                if (_upRight.Equals(true))
                {
                    if (rngList[_randomMoveCounter].Equals(random))
                    {
                        yTwo = yOne - 1;
                        xTwo = xOne + 1;

                        rngList.Clear();
                        _randomNumberGenCounter = 0;
                        _randomMoveCounter = 0;

                        return true;
                    }
                    _randomMoveCounter = _randomMoveCounter + 1;
                }

                if (_upLeft.Equals(true))
                {
                    if (rngList[_randomMoveCounter].Equals(random))
                    {
                        yTwo = yOne - 1;
                        xTwo = xOne - 1;

                        rngList.Clear();
                        _randomNumberGenCounter = 0;
                        _randomMoveCounter = 0;

                        return true;
                    }
                    _randomMoveCounter = _randomMoveCounter + 1;
                }
            }
            return false;
        }

        /// <summary>
        /// Method checks if both A.I. players have not captured an opponents piece in 
        /// 20 moves combined.
        /// </summary>
        /// <returns>Returns true if it is a draw, returns false if it is not</returns>
        public bool IsItADraw()
        {
            if (_howManyMovesWithoutACapture.Equals(20))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
