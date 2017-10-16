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
        int[] player1InnerArray = new int[] { 76, 74, 72, 65, 63, 61, 56, 54, 52, 45, 43, 41, 36, 34, 32, 25, 23, 21, 16, 14, 12 };
        int[] player1LeftArray = new int[] { 70, 50, 30, 10 };
        int[] player1RightArray = new int[] { 67, 47, 27 };

        int[] player2InnerArray = new int[] {65, 63, 61, 56, 54, 52, 45, 43, 41, 36, 34, 32, 25, 23, 21, 16, 14, 12 };
        int[] player2LeftArray = new int[] {50, 30, 10 };
        int[] player2RightArray = new int[] {67, 47, 27, 07  };

        //int[] kingArray = new int[] { };


        #region Basic Movement

        public bool Movement(int currentPosY, int currentPosX, int destinationPosY, int destinationPosX, string player)
        {
            int currentPos = Convert.ToInt32(string.Format("{0}{1}", currentPosY, currentPosX));
            int destinationPos = Convert.ToInt32(string.Format("{0}{1}", destinationPosY, destinationPosX));


            if (player.Equals("X"))
            {     
                // If one of the left hand side edge squares is selected
                if (player1LeftArray.Contains(currentPos))
                {
                    if (destinationPos.Equals(currentPos - 9))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                // If one of the right hand side edge squares is selected
                if (player1RightArray.Contains(currentPos))
                {
                    if (destinationPos.Equals(currentPos - 11))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                // If one of the inner squares is selected
                if (player1InnerArray.Contains(currentPos))
                {
                    if (destinationPos.Equals(currentPos - 9) || destinationPos.Equals(currentPos - 11))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                // The code 'should' never reach here.
                return false;
            }
            else
            {
                // If one of the left hand side edge squares is selected
                if (player2LeftArray.Contains(currentPos))
                {
                    if (destinationPos.Equals(currentPos + 11))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                // If one of the right hand side edge squares is selected
                if (player2RightArray.Contains(currentPos))
                {
                    if (destinationPos == (currentPos + 9))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                // If one of the inner squares is selected
                if (player2InnerArray.Contains(currentPos))
                {
                    if (destinationPos.Equals(currentPos + 9) || destinationPos.Equals(currentPos + 11))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                // The code 'should' never reach here.
                return false;
            }
        }
        #endregion

        public bool CanAPieceBeCaptured(int pos, string[] array)
        {
            return true;
        }

    }
}
