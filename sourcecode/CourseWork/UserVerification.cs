using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseWork
{
    class UserVerification
    {
        // Method which displays a messagebox asking the user if they are sure they want to exit the application
        // And gives them the option of answering 'yes' or 'no'
        public void ExitApplicationVerification()
        {
            MessageBoxResult yesOrNo = MessageBox.Show("Are you sure you want to exit the application?", "Exit Application", MessageBoxButton.YesNo);

            if (yesOrNo == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }

            else
            {
                return;
            }
        }


        // Method which displays a message box asking the user to confirm that they want to reset their turn.
        public bool ResetMoveVerification(bool player1Turn, bool canMove, string playerOne, string playerTwo)
        {
            string player = string.Empty;

            if (player1Turn.Equals(true))
            {
                player = playerOne;
            }
            else
            {
                player = playerTwo;
            }

            MessageBoxResult yesOrNo = MessageBox.Show("Are you sure you want to reset your turn?", "Reset Player " + player + "'s Turn?", MessageBoxButton.YesNo);

            player = string.Empty;

            if (yesOrNo == MessageBoxResult.Yes)
            {
                return canMove = false;                
            }
            else
            {
                return canMove = true;
            }
        }

        // Method which displays a message box asking the user to confirm that they want to end their turn.
        public bool EndMoveVerification(bool player1Turn, string playerOne, string playerTwo)
        {
            string player = string.Empty;           

            if (player1Turn.Equals(true))
            {
                player = playerOne;               
            }
            else
            {
                player = playerTwo;                
            }

            MessageBoxResult yesOrNo = MessageBox.Show("Are you sure you want to end your turn?", "End Player " + player + "'s Turn?", MessageBoxButton.YesNo);

            player = string.Empty;

            if (yesOrNo == MessageBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ReplayGameVerification()
        {
            MessageBoxResult yesOrNo = MessageBox.Show("Are you sure you want to view the replay of this game?\nIt will end the current game.", "Replay the current game?", MessageBoxButton.YesNo);

            if (yesOrNo == MessageBoxResult.Yes)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool RestartGameVerification()
        {
            MessageBoxResult yesOrNo = MessageBox.Show("Are you sure you want to restart the game?\nIt will end the current game.", "Restart the game?", MessageBoxButton.YesNo);

            if (yesOrNo == MessageBoxResult.Yes)
            {
                return true;
            }

            else
            {
                return false;
            }
        }


    }
}
