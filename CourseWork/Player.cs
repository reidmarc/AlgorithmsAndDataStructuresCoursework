using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    class Player
    {
        int[] player1InnerArray = new int[] {99,97,95,93,88,86,84,82,79,77,75,73,68,66,64,62,59,57,55,53,48,46,44,42,39,37,35,33,28,26,24,22,19,17,15,13};
        int[] player1LeftArray = new int[] {91,71,51,31,11};
        int[] player1RightArray = new int[] {90,70,50,30};

        int[] player2InnerArray = new int[] {88,86,84,82,79,77,75,73,68,66,64,62,59,57,55,53,48,46,44,42,39,37,35,33,28,26,24,22,19,17,15,13,8,6,4,2};
        int[] player2LeftArray = new int[] {71,51,31,11};
        int[] player2RightArray = new int[] {90,70,50,30,10};

        //int[] kingArray = new int[] { };


        #region Basic Movement

        public bool Movement(int currentPos, int destinationPos, string player)
        {
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
