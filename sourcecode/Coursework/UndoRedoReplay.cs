// Class UndoRedoReplay
// This class provides the features Undo, Redo and Replay
// There are method included which deal with the storing of the state of the board after every turn
// And retrieving those stored states and displaying them again, depending on which feature the user uses.
// Written By: Marc Reid [03001588]

#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Coursework
{
    public class UndoRedoReplay
    {
        #region Variables / Objects / Data Structures   

        // Instantiates a new object of the TheBoard Class.
        TheBoard theBoard = new TheBoard();

        // Creates 2 stacks which holds string values.
        public Stack<string> undoStack = new Stack<string>();
        public Stack<string> redoStack = new Stack<string>();

        // Creates a Queue which holds string values.
        public Queue<string> replayQueue = new Queue<string>();

        string positions;
        string positionsTemp;

        #endregion        

        #region Storing Moves As Strings 

        /// <summary>
        /// Retrieves all the values storing in the array, then concatenates them together in a 
        /// Single string, then pushes the string on to the undoStack and Enqueue's the same string on to
        /// the replayQueue.
        /// </summary>
        /// <param name="positionsArray">Used to retrieve the current playing piece positions</param>
        /// <param name="player1Turn">Used to store which player has just complete a move</param>
        public void StoreTheMovePositionsUndoRedo(string[,] positionsArray, bool player1Turn)
        {
            // Loops through the 2D array and outputs the strings to a varible then concatenates them with a comma inbetween each value.
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    positionsTemp = positionsArray[i, j];                   

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

        /// <summary>
        /// Method that pops a string off the undoStack, then pushes that string on to the redoStack
        /// Then peeks at the string on the undoStack and makes positionsOfPiecesNow equal to that string
        /// The method splits positionsOfPiecesNow removing the commas and adding the values into a 1d array        
        /// </summary>
        /// <returns> A 1D array called savedPositions that stores the playing piece positions retrieved from the stack</returns>
        public string[] DisplayTheUndoMovePositions()
        {
            string positionsOfPieces = undoStack.Pop();

            redoStack.Push(positionsOfPieces);

            string positionsOfPiecesNow = undoStack.Peek();

            string[] savedPositions = positionsOfPiecesNow.Split(',');        

            return savedPositions;

        }

        #endregion

        #region Displaying Moves From The Redo Stack

        /// <summary>
        /// Method that pops a string off the redoStack, then pushes that string on to the undoStack        
        /// The method splits positionsOfPieces removing the commas and adding the values into a 1d array        
        /// </summary>
        /// <returns> A 1D array called savedPositions that stores the playing piece positions retrieved from the stack</returns>
        public string[] DisplayTheRedoMovePositions(string[,] positionsArray)
        {
            string positionsOfPieces = redoStack.Pop();

            undoStack.Push(positionsOfPieces);

            string[] savedPositions = positionsOfPieces.Split(',');            

            return savedPositions;
        }

        #endregion

        #region Displaying Moves From The Replay Queue

        /// <summary>
        /// Method dequeues the string stored in the queue, then removes the commas adding the vlaues into a 1d array
        /// </summary>       
        /// <returns>  A 1D array called savedPositions that stores the playing piece positions retrieved from the queue</returns>
        public string[] DisplayTheReplayMovePositions()
        {
            string positionsOfPieces = replayQueue.Dequeue();

            string[] savedPositions = positionsOfPieces.Split(',');
            
            return savedPositions;
        }

        #endregion  
    }
}
