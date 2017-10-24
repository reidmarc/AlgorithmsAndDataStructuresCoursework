using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    class UndoRedoReplay
    {
        #region variables   

        TheBoard theBoard = new TheBoard();

        public Stack<string> undoStack = new Stack<string>();
        public Stack<string> redoStack = new Stack<string>();
        public Queue<string> replayQueue = new Queue<string>();
       

        string positions;
        string positionsTemp;

        #endregion        

        #region Storing Moves As Strings   

        public void StoreTheMovePositionsUndoRedo(string[,] positionsArray, bool player1Turn)
        { 
            // Loops through the 2D array and outputs the strings to a varible then concatenates them with a comma inbetween each value.
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    positionsTemp = positionsArray[i, j];

                    //// Replaces the tiles that have no content with a symbol
                    //if (positionsTemp.Equals("   "))
                    //{
                    //    positionsTemp = "-";
                    //}

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
                positions = string.Concat(string.Concat(positions, ","), " X ");
            }
            else
            {
                positions = string.Concat(string.Concat(positions, ","), " O ");
            }


            // Pushes the string 'positions' on to the stack 'undoStack'
            undoStack.Push(positions);

            // Enqueues the string 'positions' in the queue 'replayQueue'
            replayQueue.Enqueue(positions);
        }

        #endregion

        #region Displaying Moves From The Undo Stack

        public string[] DisplayTheUndoMovePositions(string[,] positionsArray)
        {            
            string positionsOfPieces = undoStack.Pop();

            redoStack.Push(positionsOfPieces);

            string positionsOfPiecesNow = undoStack.Peek();

            string[] savedPositions = positionsOfPiecesNow.Split(',');

            //// Replaces the '-' with string.empty like it was before being saved
            //for (int i = 0; i < savedPositions.Length; i++)
            //{
            //    if (savedPositions[i].Equals("-"))
            //    {
            //        savedPositions[i] = "   ";
            //    }
            //}

            

            return savedPositions;           
            
        }

        #endregion

        #region Displaying Moves From The Redo Stack

        public string[] DisplayTheRedoMovePositions(string[,] positionsArray)
        {
            string positionsOfPieces = redoStack.Pop();

            undoStack.Push(positionsOfPieces);


            string[] savedPositions = positionsOfPieces.Split(',');

            //// Replaces the '-' with string.empty like it was before being saved
            //for (int i = 0; i < savedPositions.Length; i++)
            //{
            //    if (savedPositions[i].Equals("-"))
            //    {
            //        savedPositions[i] = "   ";
            //    }
            //}         

            return savedPositions; 
        }

        #endregion

        #region Displaying Moves From The Replay Queue

        public string[] DisplayTheReplayMovePositions(string[,] positionsArray)
        {            
                string positionsOfPieces = replayQueue.Dequeue();

                string[] savedPositions = positionsOfPieces.Split(',');

                //// Replaces the '-' with string.empty like it was before being saved
                //for (int i = 0; i < savedPositions.Length; i++)
                //{
                //    if (savedPositions[i].Equals("-"))
                //    {
                //        savedPositions[i] = "   ";
                //    }
                //}               
                
                return savedPositions;   
        }

        #endregion  
    }
}
