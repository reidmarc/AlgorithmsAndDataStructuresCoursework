using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    public class AI
    {
        Player aiPlayer = new Player();
        Random rng = new Random();

        const string playerOne = " X ";
        const string playerTwo = " O ";
        const string noMansLand = "   ";
        const string playerOneKing = "|X|";
        const string playerTwoKing = "|O|";

        bool downLeft = false;
        bool downRight = false;
        bool upRight = false;
        bool upLeft = false;

        int randomNumberGenCounter = 0;
        int randomMoveCounter = 0;
       



        public void GetMove(ref int yOne, ref int xOne, ref int yTwo, ref int xTwo, string[,] positionsArray, ref bool player1Turn)
        {

            if (player1Turn)
            {

            }
            else
            {

                // Loops through the array looking for king piece and whether it can 'take' an opponents piece
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (positionsArray[i, j].Equals(playerTwoKing))
                        {
                            if (aiPlayer.CanAPieceBeCapturedKing(i, j, positionsArray, ref player1Turn).Equals(true))
                            {
                                yOne = i;
                                xOne = j;



                                // Checks Up Right 
                                if ((yOne > 1 && xOne < 6) && (((positionsArray[(yOne - 1), (xOne + 1)].Equals(playerOne) || positionsArray[(yOne - 1), (xOne + 1)].Equals(playerOneKing)) && positionsArray[(yOne - 2), (xOne + 2)].Equals(noMansLand))))
                                {
                                    yTwo = yOne - 2;
                                    xTwo = xOne + 2;
                                    return;
                                }
                                // Checks Down Right
                                if ((yOne < 6 && xOne < 6) && (((positionsArray[(yOne + 1), (xOne + 1)].Equals(playerOne) || positionsArray[(yOne + 1), (xOne + 1)].Equals(playerOneKing)) && positionsArray[(yOne + 2), (xOne + 2)].Equals(noMansLand))))
                                {
                                    yTwo = yOne + 2;
                                    xTwo = xOne + 2;
                                    return;
                                }
                                // Checks Up Left
                                if ((yOne > 1 && xOne > 1) && (((positionsArray[(yOne - 1), (xOne - 1)].Equals(playerOne) || positionsArray[(yOne - 1), (xOne - 1)].Equals(playerOneKing)) && positionsArray[(yOne - 2), (xOne - 2)].Equals(noMansLand))))
                                {
                                    yTwo = yOne - 2;
                                    xTwo = xOne - 2;
                                    return;
                                }
                                // Checks Down Left
                                if ((yOne < 6 && xOne > 1) && (((positionsArray[(yOne + 1), (xOne - 1)].Equals(playerOne) || positionsArray[(yOne + 1), (xOne - 1)].Equals(playerOneKing)) && positionsArray[(yOne + 2), (xOne - 2)].Equals(noMansLand))))
                                {
                                    yTwo = yOne + 2;
                                    xTwo = xOne - 2;
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

                        if (positionsArray[i, j].Equals(playerTwo))
                        {
                            yOne = i;
                            xOne = j;

                            if ((yOne < 6 && xOne < 6) && (aiPlayer.CanAPieceBeCapturedRight(i, j, positionsArray, ref player1Turn).Equals(true)))
                            {     
                                yTwo = i + 2;
                                xTwo = j + 2;
                                return;
                            }
                            if ((yOne < 6 && xOne > 1) && (aiPlayer.CanAPieceBeCapturedLeft(i, j, positionsArray, ref player1Turn).Equals(true)))
                            {    
                                yTwo = i + 2;
                                xTwo = j - 2;
                                return;
                            }                            
                        }
                    }
                }

                

                // Loops through the array looking to make a legal move
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (positionsArray[i, j].Equals(playerTwoKing))
                        {
                            yOne = i;
                            xOne = j;                           

                            downLeft = false;
                            downRight = false;
                            upRight = false;
                            upLeft = false;


                            // Checks Down Left
                            if ((yOne < 7 && xOne > 0) && (positionsArray[(yOne + 1), (xOne - 1)].Equals(noMansLand)))
                            {
                                randomNumberGenCounter = randomNumberGenCounter + 1;
                                downLeft = true;                                
                            }  
                            // Checks Down Right
                            if ((yOne < 7 && xOne < 7) && (positionsArray[(yOne + 1), (xOne + 1)].Equals(noMansLand)))
                            {
                                randomNumberGenCounter = randomNumberGenCounter + 1;
                                downRight = true;                                
                            }  
                            // Checks Up Right 
                            if ((yOne > 0 && xOne < 7) && (positionsArray[(yOne - 1), (xOne + 1)].Equals(noMansLand)))
                            {
                                randomNumberGenCounter = randomNumberGenCounter + 1;
                                upRight = true;                                
                            }
                            // Checks Up Left
                            if ((yOne > 0 && xOne > 0) && (positionsArray[(yOne - 1), (xOne - 1)].Equals(noMansLand)))
                            {
                                randomNumberGenCounter = randomNumberGenCounter + 1;
                                upLeft = true;                                
                            }
                            

                            if (randomNumberGenCounter > 0)
                            {
                                int random = rng.Next(1, (randomNumberGenCounter + 1));

                                //int[] array = new int[(randomNumberGenCounter)];
                                List<int> rngList = new List<int>();


                                for (int w = 0; w < randomNumberGenCounter; w++)
                                {
                                    rngList.Add(w + 1);
                                }




                                if (downLeft.Equals(true))
                                {
                                    if ((rngList[randomMoveCounter]).Equals(random))
                                    {
                                        yTwo = yOne + 1;
                                        xTwo = xOne - 1;

                                        rngList.Clear();
                                        randomNumberGenCounter = 0;
                                        randomMoveCounter = 0;

                                        return;
                                    }
                                    randomMoveCounter = randomMoveCounter + 1;
                                }

                                if (downRight.Equals(true))
                                {
                                    if (rngList[randomMoveCounter].Equals(random))
                                    {
                                        yTwo = yOne + 1;
                                        xTwo = xOne + 1;

                                        rngList.Clear();
                                        randomNumberGenCounter = 0;
                                        randomMoveCounter = 0;

                                        return;
                                    }
                                    randomMoveCounter = randomMoveCounter + 1;
                                }

                                if (upRight.Equals(true))
                                {
                                    if (rngList[randomMoveCounter].Equals(random))
                                    {
                                        yTwo = yOne - 1;
                                        xTwo = xOne + 1;

                                        rngList.Clear();
                                        randomNumberGenCounter = 0;
                                        randomMoveCounter = 0;

                                        return;
                                    }
                                    randomMoveCounter = randomMoveCounter + 1;
                                }

                                if (upLeft.Equals(true))
                                {
                                    if (rngList[randomMoveCounter].Equals(random))
                                    {
                                        yTwo = yOne - 1;
                                        xTwo = xOne - 1;

                                        rngList.Clear();
                                        randomNumberGenCounter = 0;
                                        randomMoveCounter = 0;

                                        return;
                                    }
                                }                               

                            }

                        }
                    }

                }

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (positionsArray[i, j].Equals(playerTwo))
                        {
                            yOne = i;
                            xOne = j;

                            
                            // Checks Down Right
                            if ((yOne < 6 && xOne < 6) && (positionsArray[(yOne + 1), (xOne + 1)].Equals(noMansLand)))
                            {
                                yTwo = yOne + 1;
                                xTwo = xOne + 1;
                                return;
                            }                            
                            // Checks Down Left
                            if ((yOne < 6 && xOne > 1) && (positionsArray[(yOne + 1), (xOne - 1)].Equals(noMansLand)))
                            {
                                yTwo = yOne + 1;
                                xTwo = xOne - 1;
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
