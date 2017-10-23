using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseWork
{
    class Program
    {     
        static void Main(string[] args)
        {
            #region Variables / Objects / Collections

            TheBoard theBoard = new TheBoard();
            Player playerOb = new Player();            
            UndoRedoReplay undoRedoReplay = new UndoRedoReplay();



            // 2D array to map store the piece locations
            string[,] positionsArray = new string[8, 8];
            

            int yOne;
            int xOne;

            int yTwo;
            int xTwo;            

            bool player1Turn = true;           

            bool endGame = true;

            #endregion







            theBoard.NewGame(positionsArray);

            // Stores the current state of the board
            undoRedoReplay.StoreTheMovePositionsUndoRedo(positionsArray, player1Turn);

            theBoard.ConsoleSettings();

            void NewGamePrep()
            {
                // Clears the stacks and queues, so they are ready to record another game
                undoRedoReplay.undoStack.Clear();
                undoRedoReplay.redoStack.Clear();
                undoRedoReplay.replayQueue.Clear();

                // Stores the current state of the board
                undoRedoReplay.StoreTheMovePositionsUndoRedo(positionsArray, player1Turn);
                yOne = 0;
                xOne = 0;
                yTwo = 0;
                xTwo = 0;
            }

            while (endGame)
            {
                Console.Clear();

                // Displays the current board
                theBoard.DisplayTheBoard(positionsArray, player1Turn);

                // Displays the menu
                Console.WriteLine("Menu\n" +                    
                    "\nPress [1] to take a turn." +
                    "\t\t\tPress [4] to reset a turn." +
                    "\nPress [2] to undo a move." +
                    "\t\t\tPress [5] to end a turn." +
                    "\nPress [3] to redo a move." +
                    "\t\t\tPress [6] to restart the game." +
                    "\nPress [7] to replay the game." +
                    "\t\t\tPress [0] to exit the application.\n\n");
               

                

                int caseSwitch;
                Int32.TryParse(Console.ReadLine(), out caseSwitch);

                switch (caseSwitch)
                {
                    // Take a turn
                    case 1: 
                        {
                            

                            Console.Clear();
                            theBoard.DisplayTheBoard(positionsArray, player1Turn);

                            Console.WriteLine("Please enter the Y Co-Ordinate of the piece you want to move:");
                            Int32.TryParse(Console.ReadLine(), out yOne);

                            Console.WriteLine("Please enter the X Co-Ordinate of the piece you want to move:");
                            Int32.TryParse(Console.ReadLine(), out xOne);

                            if (playerOb.PlayerCheck(yOne, xOne, positionsArray, player1Turn).Equals(false))
                            {
                                Console.Clear();
                                theBoard.DisplayTheBoard(positionsArray, player1Turn);
                                Console.WriteLine("You must select a piece that belongs to you.");
                                Console.ReadKey();
                                break;
                            }

                            Console.Clear();
                            theBoard.DisplayTheBoard(positionsArray, player1Turn);

                            Console.WriteLine("Please enter the Y Co-Ordinate of the tile you want to move your piece to:");
                            Int32.TryParse(Console.ReadLine(), out yTwo);

                            Console.WriteLine("Please enter the X Co-Ordinate of the tile you want to move your piece to:");
                            Int32.TryParse(Console.ReadLine(), out xTwo);

                            playerOb.ForcedCaptureCheck(ref player1Turn, positionsArray, yOne, xOne, yTwo, xTwo);

                            // If a piece has just been converted into a king, this method ends the turn for that player.
                            playerOb.IsItAKing(yTwo, xTwo, positionsArray, ref player1Turn);
                            

                            // Stores the current state of the board
                            undoRedoReplay.StoreTheMovePositionsUndoRedo(positionsArray, player1Turn);

                            // Displays the current board
                            theBoard.DisplayTheBoard(positionsArray, player1Turn);

                            // Checks if there is a winner
                            endGame = theBoard.IsThereAWinner();



                            break;
                        }

                    // Undo a move
                    case 2: 
                        {
                            // Stops the program from trying to pop the top value off the stack 'undoStack'
                            // When there is nothing stored on the stack
                            if (undoRedoReplay.undoStack.Count > 1)
                            {
                                string[] savedPositions = undoRedoReplay.DisplayTheUndoMovePositions(positionsArray);

                                if (savedPositions[64].Equals(" X "))
                                {
                                    player1Turn = true;                                    
                                }
                                else
                                {
                                    player1Turn = false;                                    
                                }


                                theBoard.UpdateTheBoard(positionsArray, savedPositions);
                                theBoard.DisplayTheBoard(positionsArray, player1Turn);



                            }
                            else
                            {
                                Console.Clear();
                                theBoard.DisplayTheBoard(positionsArray, player1Turn);
                                Console.WriteLine("There are no more moves to 'Undo'");
                                Console.ReadKey();                                
                            }
                            break;
                        }

                    // Redo a move
                    case 3:
                        {
                            // Stops the program from trying to pop the top value off the stack 'redoStack'
                            // When there is nothing stored on the stack
                            if (undoRedoReplay.redoStack.Count > 0)
                            {
                                string[] savedPositions = undoRedoReplay.DisplayTheRedoMovePositions(positionsArray);

                                if (savedPositions[64].Equals(" X "))
                                {
                                    player1Turn = true;                                    
                                }
                                else
                                {
                                    player1Turn = false;                                    
                                }

                                theBoard.UpdateTheBoard(positionsArray, savedPositions);
                                theBoard.DisplayTheBoard(positionsArray, player1Turn);
                            }
                            else
                            {
                                Console.Clear();
                                theBoard.DisplayTheBoard(positionsArray, player1Turn);
                                Console.WriteLine("There are no more moves to 'Redo'");
                                Console.ReadKey();
                            }
                            break;                        
                        }

                    // Reset a turn
                    case 4:
                        {
                            yOne = 0;
                            xOne = 0;
                            yTwo = 0;
                            xTwo = 0;
                            theBoard.DisplayTheBoard(positionsArray, player1Turn);
                            break;
                        }
                    //End a turn
                    case 5:
                        {
                            if (player1Turn.Equals(true))
                            {
                                player1Turn = false;
                            }
                            else
                            {
                                player1Turn = true;
                            }

                            theBoard.DisplayTheBoard(positionsArray, player1Turn);
                            break;
                        }

                    // Restart game
                    case 6:
                        {
                            theBoard.NewGame(positionsArray);

                            NewGamePrep();
                            
                            break;
                        }

                    // Replay a game
                    case 7:
                        {
                            // Gets the number for how many times to loop
                            int numReplays = undoRedoReplay.replayQueue.Count;


                            for (int i = 0; i < numReplays; i++)
                            {
                                // Pauses the app, so you can follow the moves
                                int milliseconds = 2000;
                                Thread.Sleep(milliseconds);

                               

                                // Stops the program from trying to dequeue the first value off the queue 'replayQueue'
                                // When there is nothing stored on the stack
                                if (undoRedoReplay.replayQueue.Count > 0)
                                {
                                    string[] savedPositions = undoRedoReplay.DisplayTheReplayMovePositions(positionsArray);

                                    if (savedPositions[64].Equals(" X "))
                                    {
                                        player1Turn = true;
                                    }
                                    else
                                    {
                                        player1Turn = false;
                                    }
                                    Console.Clear();
                                    theBoard.UpdateTheBoard(positionsArray, savedPositions);
                                    theBoard.DisplayTheBoard(positionsArray, player1Turn);




                                }
                                else
                                {
                                    Console.Clear();
                                    theBoard.DisplayTheBoard(positionsArray, player1Turn);
                                    Console.WriteLine("There are no more moves to 'Replay'");
                                    Console.ReadKey();
                                }
                            }

                            Console.WriteLine("The replay has ended, a new game will begin.");
                            Console.ReadKey();

                            

                            theBoard.NewGame(positionsArray);
                            NewGamePrep();



                            break;
                        }

                    // Exit game
                    case 0:
                        {
                            endGame = false;
                            break;
                        }

                    

                    default:
                        {
                            Console.Beep();
                            Console.WriteLine("Please make sure the number you select is on the menu.");
                            Console.ReadKey();                            
                            break;
                        }                    
                }
            }                

            // Closes the application
            Environment.Exit(0);
        }        
    }
}


