using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseWork
{
    class Player
    { 
        #region Basic Movement

        public bool MovementRight(int posY, int posX, int destY, int destX, string[,] positionsArray, string player)
        {
            if (player.Equals(MainWindow.playerOne))
            {
                // To stop the if statement recieving an out of bounds exception
                if (posY > 0 && posX < 7)
                {
                    // Check if player 1 can move right
                    if ((positionsArray[destY, destX].Equals(string.Empty)) && (((posY - destY).Equals(1)) && ((posX - destX).Equals(-1))))
                    {
                        positionsArray[posY, posX] = string.Empty;
                        positionsArray[destY, destX] = player;
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
                    if ((positionsArray[destY, destX].Equals(string.Empty)) && (((posY - destY).Equals(-1)) && ((posX - destX).Equals(-1))))
                    {
                        positionsArray[posY, posX] = string.Empty;
                        positionsArray[destY, destX] = player;
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

        public bool MovementLeft(int posY, int posX, int destY, int destX, string[,] positionsArray, string player)
        {
            if (player.Equals(MainWindow.playerOne))
            {
                // To stop the if statement recieving an out of bounds exception
                if (posY > 0 && posX > 0)
                {
                    // Check if player 1 can move left
                    if ((positionsArray[destY, destX].Equals(string.Empty)) && (((posY - destY).Equals(1)) && ((posX - destX).Equals(1))))
                    {
                        positionsArray[posY, posX] = string.Empty;
                        positionsArray[destY, destX] = player;
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
                    if ((positionsArray[destY, destX].Equals(string.Empty)) && (((posY - destY).Equals(-1)) && ((posX - destX).Equals(1))))
                    {
                        positionsArray[posY, posX] = string.Empty;
                        positionsArray[destY, destX] = player;
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

        public bool CanAPieceBeCapturedRight(int posY, int posX, string[,] positionsArray, string player)
        {
            if (player.Equals(MainWindow.playerOne))
            {
                // To stop the if statement recieving an out of bounds exception
                if (posY > 1 && posX < 6)
                {
                    // Check if player 1 can remove a player 2 piece to the right
                    // If it can then it is still player 1's turn
                    if (positionsArray[(posY - 1), (posX + 1)].Equals(MainWindow.playerTwo) && (positionsArray[(posY - 2), (posX + 2)].Equals(string.Empty)))
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
                if (posY < 6 && posX < 6)
                {
                    // Check if player 2 can remove a player 1 piece to the right
                    // If it can then it is still player 2's turn
                    if (positionsArray[(posY + 1), (posX + 1)].Equals(MainWindow.playerOne) && (positionsArray[(posY + 2), (posX + 2)].Equals(string.Empty)))
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

        public bool CanAPieceBeCapturedLeft(int posY, int posX, string[,] positionsArray, string player)
        {
            if (player.Equals(MainWindow.playerOne))
            {
                // To stop the if statement recieving an out of bounds exception
                if (posY > 1 && posX > 1)
                {
                    // Check if player 1 can remove a player 2 piece to the left
                    // If it can then it is still player 1's turn
                    if (positionsArray[(posY - 1), (posX - 1)].Equals(MainWindow.playerTwo) && (positionsArray[(posY - 2), (posX - 2)].Equals(string.Empty)))
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
                if (posY < 6 && posX > 1)
                {
                    // Check if player 2 can remove a player 1 piece to the left
                    // If it can then it is still player 2's turn
                    if (positionsArray[(posY + 1), (posX - 1)].Equals(MainWindow.playerOne) && (positionsArray[(posY + 2), (posX - 2)].Equals(string.Empty)))
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

    }
}
