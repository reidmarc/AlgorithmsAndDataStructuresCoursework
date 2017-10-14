using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    class PlayerOne
    {
        public bool Movement(int currentPos, int destinationPos)
        {

            // If one of the left hand side edge squares is selected
            if (currentPos == 91 || currentPos == 71 || currentPos == 51 || currentPos == 31 || currentPos == 11)
            {
                if (destinationPos == (currentPos - 9))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            // If one of the right hand side edge squares is selected
            if (currentPos == 90 || currentPos == 70 || currentPos == 50 || currentPos == 30)
            {
                if (destinationPos == (currentPos - 11))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            // If one of the inner squares is selected
            if (currentPos == 99 || currentPos == 97 || currentPos == 95 || currentPos == 93 || currentPos == 88 || currentPos == 86 || currentPos == 84 || currentPos == 82 ||
                currentPos == 79 || currentPos == 77 || currentPos == 75 || currentPos == 73 || currentPos == 68 || currentPos == 66 || currentPos == 64 || currentPos == 62 ||
                currentPos == 59 || currentPos == 57 || currentPos == 55 || currentPos == 53 || currentPos == 48 || currentPos == 46 || currentPos == 44 || currentPos == 42 ||
                currentPos == 39 || currentPos == 37 || currentPos == 35 || currentPos == 33 || currentPos == 28 || currentPos == 26 || currentPos == 24 || currentPos == 22 ||
                currentPos == 19 || currentPos == 17 || currentPos == 15 || currentPos == 13)
            {
                if (destinationPos == (currentPos - 9) || destinationPos == (currentPos - 11))
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
}
