using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseWork
{
    public class UndoRedoReplay
    {
        public Stack<string> undoStack = new Stack<string>();
        public Stack<string> redoStack = new Stack<string>();
        public Queue<string> replayQueue = new Queue<string>();
        public string turnTxtBlock = string.Empty;
        public bool player1TurnUndo; 



        string positions;
        string positionsTemp;


        public void StoreTheMovePositions(string[,] positionsArray, bool player1Turn)
        {
            // Loops through the 2D array and outputs the strings to a varible then concatenates them with a comma inbetween each value.
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    positionsTemp = positionsArray[i, j];

                    // Replaces the tiles that have no content with a symbol
                    if (positionsTemp.Equals(string.Empty))
                    {
                        positionsTemp = "-";
                    }

                    // Stops the string from starting with a comma
                    if (i.Equals(0) && j.Equals(0))
                    {
                        positions = positionsTemp;
                    }
                    else
                    {
                        positions = string.Concat(string.Concat(positions, ","), positionsTemp);
                    }
                }
            }

            // Sets the last value of the string according to whose turn it is
            if (player1Turn.Equals(true))
            {
                positions = string.Concat(string.Concat(positions, ","), "X");
            }
            else
            {
                positions = string.Concat(string.Concat(positions, ","), "O");
            }

            
            // Pushes the string 'positions' on to the stack 'undoStack'
            undoStack.Push(positions);

            // Enqueues the string 'positions' in the queue 'replayQueue'
            replayQueue.Enqueue(positions);
            
            
            
        }

        public bool RetrieveTheUndoMovePositions(string[,] positionsArray, bool player1Turn)
        {
            // Stops the program from trying to pop the top value off the stack 'undoStack'
            // When there is nothing stored on the stack
            if (undoStack.Count > 1)
            {   
                string positionsOfPieces = undoStack.Pop();

                
                redoStack.Push(positionsOfPieces);


                string positionsOfPiecesNow = undoStack.Peek();

                string[] savedPositions = positionsOfPiecesNow.Split(',');

                // Replaces the '-' with string.empty like it was before being saved
                for (int i = 0; i < savedPositions.Length; i++)
                {
                    if (savedPositions[i].Equals("-"))
                    {
                        savedPositions[i] = string.Empty;
                    }
                }

                if (savedPositions[64].Equals("X"))
                {
                    player1TurnUndo = true;
                    turnTxtBlock = "Player X";
                }
                else
                {
                    player1TurnUndo = false;
                    turnTxtBlock = "Player O";
                }



                UpdateTheBoard(positionsArray, savedPositions);
                return true;

            }
            else
            {                
                MessageBox.Show("There are no more move to 'undo'");
                return false;
            }
        }

        public bool RetrieveTheRedoMovePositions(string[,] positionsArray)
        {

            // Stops the program from trying to pop the top value off the stack 'undoStack'
            // When there is nothing stored on the stack
            if (redoStack.Count > 0)
            {
                string positionsOfPieces = redoStack.Pop();

                undoStack.Push(positionsOfPieces);
                

                string[] savedPositions = positionsOfPieces.Split(',');

                // Replaces the '-' with string.empty like it was before being saved
                for (int i = 0; i < savedPositions.Length; i++)
                {
                    if (savedPositions[i].Equals("-"))
                    {
                        savedPositions[i] = string.Empty;
                    }
                }

                if (savedPositions[64].Equals("X"))
                {
                    player1TurnUndo = true;
                    turnTxtBlock = "Player X";
                }
                else
                {
                    player1TurnUndo = false;
                    turnTxtBlock = "Player O";
                }



                UpdateTheBoard(positionsArray, savedPositions);
                return true;

            }
            else
            {
                MessageBox.Show("There are no more moves to 'redo'");
                return false;
            }
        }

        public void RetrieveTheReplayMovePositions()
        {

        }

        private void UpdateTheBoard(string [,]positionsArray, string []savedPositions)
        {
            positionsArray[0, 1] = savedPositions[1];
            positionsArray[0, 3] = savedPositions[3];
            positionsArray[0, 5] = savedPositions[5];
            positionsArray[0, 7] = savedPositions[7];

            positionsArray[1, 0] = savedPositions[8];
            positionsArray[1, 2] = savedPositions[10];
            positionsArray[1, 4] = savedPositions[12];
            positionsArray[1, 6] = savedPositions[14];

            positionsArray[2, 1] = savedPositions[17];
            positionsArray[2, 3] = savedPositions[19];
            positionsArray[2, 5] = savedPositions[21];
            positionsArray[2, 7] = savedPositions[23];

            positionsArray[3, 0] = savedPositions[24];
            positionsArray[3, 2] = savedPositions[26];
            positionsArray[3, 4] = savedPositions[28];
            positionsArray[3, 6] = savedPositions[30];

            positionsArray[4, 1] = savedPositions[33];
            positionsArray[4, 3] = savedPositions[35];
            positionsArray[4, 5] = savedPositions[37];
            positionsArray[4, 7] = savedPositions[39];

            positionsArray[5, 0] = savedPositions[40];
            positionsArray[5, 2] = savedPositions[42];
            positionsArray[5, 4] = savedPositions[44];
            positionsArray[5, 6] = savedPositions[46];

            positionsArray[6, 1] = savedPositions[49];
            positionsArray[6, 3] = savedPositions[51];
            positionsArray[6, 5] = savedPositions[53];
            positionsArray[6, 7] = savedPositions[55];

            positionsArray[7, 0] = savedPositions[56];
            positionsArray[7, 2] = savedPositions[58];
            positionsArray[7, 4] = savedPositions[60];
            positionsArray[7, 6] = savedPositions[62];
        }       
    }
}
