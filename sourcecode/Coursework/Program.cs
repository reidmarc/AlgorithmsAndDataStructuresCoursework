using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Coursework
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Variables / Objects / Collections

            TheBoard theBoard = new TheBoard();
            Player playerOb = new Player();
            UndoRedoReplay undoRedoReplay = new UndoRedoReplay();
            AI aI = new AI();
            Stopwatch stopWatchGameTime = new Stopwatch();



            // 2D array to map store the piece locations
            string[,] positionsArray = new string[8, 8];


            int yOne = 0;
            int xOne = 0;

            int yTwo = 0;
            int xTwo = 0;

            int gameMode = 0;
            int gameModeSelection = 0;

            bool player1Turn = true;

            bool endGame = true;
            bool aiGame = true;
            bool notMadeChoice = true;

            #endregion

            #region Intro

            // Console settings
            theBoard.ConsoleSettings();


            //StartingMenu();
            Console.WriteLine("\n" +
                    "   ___  _                  _                          \n" +
                    "  / __\\| |__    ___   ___ | | __ ___  _ __  ___      \n" +
                    " / /   | '_ \\  / _ \\ / __|| |/ // _ \\| '__|/ __|   \n" +
                    "/ /___ | | | ||  __/| (__ |   <|  __/| |   \\__ \\    \n" +
                    "\\____/ |_| |_| \\___| \\___||_|\\_\\\\___||_|   |___/\n" +
                    "" +
                    "" +
                    "                                                         ___  _                  _                          \n" +
                    "                                                        / __\\| |__    ___   ___ | | __ ___  _ __  ___      \n" +
                    "                                                       / /   | '_ \\  / _ \\ / __|| |/ // _ \\| '__|/ __|   \n" +
                    "                                                      / /___ | | | ||  __/| (__ |   <|  __/| |   \\__ \\    \n" +
                    "                                                      \\____/ |_| |_| \\___| \\___||_|\\_\\\\___||_|   |___/\n" +
                    "");
            Console.ReadKey();

            Console.WriteLine("                                                                               By Marc Reid [03001588]");
            Console.ReadKey();

            #endregion

            #region Game Selection Menu

            while (notMadeChoice)
            {
                Console.Clear();
                Console.WriteLine("Game Modes Available:\n\n[1] - Human vs Human\n[2] - Human vs AI\n[3] - AI vs AI\n[4] - To quit the game\n\nPlease select a game mode.");


                Int32.TryParse(Console.ReadLine(), out gameMode);



                switch (gameMode)
                {
                    case 1:
                        {
                            gameModeSelection = 1;
                            notMadeChoice = false;
                            break;
                        }

                    case 2:
                        {
                            gameModeSelection = 2;
                            notMadeChoice = false;
                            break;
                        }

                    case 3:
                        {
                            gameModeSelection = 3;
                            notMadeChoice = false;
                            break;
                        }

                    case 4:
                        {
                            // Closes the application
                            Environment.Exit(0);
                            break;
                        }

                    default:
                        {
                            Console.Clear();
                            Console.Beep();
                            notMadeChoice = true;
                            Console.WriteLine("Please make sure the number you select is on the menu.");
                            Console.ReadKey();
                            break;
                        }

                }
            }

            #endregion

            // Loads the starting positions and the board
            theBoard.NewGame(positionsArray);

            // Stores the current state of the board
            undoRedoReplay.StoreTheMovePositionsUndoRedo(positionsArray, player1Turn);





            while (endGame)
            {
                Console.Clear();

                // Displays the current board
                theBoard.DisplayTheBoard(positionsArray, player1Turn);

                if (gameModeSelection.Equals(1) || gameModeSelection.Equals(2))
                {

                    // Displays the menu
                    Console.WriteLine("Menu\n" +
                        "\nPress [1] to take a turn." +
                        "\t\t\tPress [5] to reset a turn." +
                        "\nPress [2] to undo a move." +
                        "\t\t\tPress [6] to end a turn." +
                        "\nPress [3] to redo a move." +
                        "\t\t\tPress [7] to restart the game." +
                        "\nPress [4] to replay the game." +
                        "\t\t\tPress [0] to exit the application.\n\n");
                }

                if (gameModeSelection.Equals(3))
                {
                    // Displays the menu
                    Console.WriteLine("Menu\n" +
                        "\nPress [1] to start a new game." +
                        "\nPress [4] to replay the game." +
                        "\nPress [0] to exit the application.\n\n");
                }



                        int caseSwitch;
                        Int32.TryParse(Console.ReadLine(), out caseSwitch);

                        switch (caseSwitch)
                        {
                            // Take a turn
                            case 1:
                                {
                                    try
                                    {
                                       

                                        if (gameModeSelection.Equals(3))
                                        {

                                            stopWatchGameTime.Start();

                                            int testSize = 2500;

                                            for (int k = 0; k < testSize; k++)
                                            {
                                                aiGame = true;

                                                while (aiGame)
                                                {

                                                    undoRedoReplay.undoStack.Clear();
                                                    undoRedoReplay.redoStack.Clear();
                                                    undoRedoReplay.redoStack.Clear();



                                                    //// Pauses the app, so you can follow the moves
                                                    //int milliseconds = 1000;
                                                    //Thread.Sleep(milliseconds);


                                                    // Checks if the current player has any available moves
                                                    // If the method returns false, the player will lose.
                                                    if (playerOb.AreThereAnyValidMoves(positionsArray, player1Turn).Equals(false))
                                                    {
                                                        // Stores the current state of the board
                                                        undoRedoReplay.StoreTheMovePositionsUndoRedo(positionsArray, player1Turn);

                                                        // A different winning message is displayed depending on who won
                                                        if (player1Turn.Equals(false))
                                                        {
                                                            theBoard.PlayerXWinningMessage();
                                                        }
                                                        else
                                                        {
                                                            theBoard.PlayerOWinningMessage();
                                                        }

                                                        Console.Clear();
                                                        theBoard.DisplayTheBoard(positionsArray, player1Turn);
                                                        Console.WriteLine("Press enter to return to the menu");
                                                        //Console.ReadKey();

                                                        theBoard.NewGame(positionsArray);
                                                        theBoard.DisplayTheBoard(positionsArray, player1Turn);
                                                        aiGame = false;
                                                        player1Turn = true;                                                        
                                                        //break;
                                                    }




                                                    Console.Clear();
                                                    theBoard.DisplayTheBoard(positionsArray, player1Turn);

                                                    if (gameModeSelection.Equals(3))
                                                    {
                                                        aI.GetMove(ref yOne, ref xOne, ref yTwo, ref xTwo, positionsArray, ref player1Turn);

                                                    }

                                                    // Stops any out of range exceptions
                                                    if ((yTwo < 0 || yTwo > 7) || (xTwo < 0 || xTwo > 7))
                                                    {
                                                        theBoard.DisplayTheBoard(positionsArray, player1Turn);
                                                        Console.WriteLine("You have entered an incorrect co-ordinate for the destination tile.\nPlease enter your co-ordinates again.");
                                                        Console.ReadKey();
                                                        break;
                                                    }

                                                    playerOb.ForcedCaptureCheck(ref player1Turn, positionsArray, yOne, xOne, yTwo, xTwo);

                                                    // If a piece has just been converted into a king, this method ends the turn for that player.
                                                    playerOb.IsItAKing(yTwo, xTwo, positionsArray, ref player1Turn);


                                                    // Stores the current state of the board
                                                    undoRedoReplay.StoreTheMovePositionsUndoRedo(positionsArray, player1Turn);

                                                    // Displays the current board
                                                    theBoard.DisplayTheBoard(positionsArray, player1Turn);

                                                    // Checks if there is a winner   
                                                    if (theBoard.IsThereAWinner().Equals(true))
                                                    {
                                                        Console.Clear();
                                                        theBoard.DisplayTheBoard(positionsArray, player1Turn);
                                                        Console.WriteLine("Press enter to return to the menu");
                                                        //Console.ReadKey();

                                                        theBoard.NewGame(positionsArray);
                                                        theBoard.DisplayTheBoard(positionsArray, player1Turn);
                                                        aiGame = false;
                                                        player1Turn = true;                                                        
                                                        //break;
                                                    }

                                                    yOne = 0;
                                                    xOne = 0;
                                                    yTwo = 0;
                                                    xTwo = 0;


                                                    if (aI.IsItADraw().Equals(true))
                                                    {
                                                        theBoard.IsItADraw(1);

                                                        Console.Clear();
                                                        theBoard.DisplayTheBoard(positionsArray, player1Turn);
                                                        Console.WriteLine("Press enter to return to the menu");
                                                        //Console.ReadKey();
                                                        //Console.ReadKey();

                                                        theBoard.NewGame(positionsArray);
                                                        theBoard.DisplayTheBoard(positionsArray, player1Turn);
                                                        aiGame = false;
                                                        player1Turn = true;                                                        
                                                        //break;
                                                    }
                                                }
                                            }

                                            stopWatchGameTime.Stop();



                                    long totalTimeLong = stopWatchGameTime.ElapsedMilliseconds;

                                    long totalTimeInt = totalTimeLong / 1000;

                                    long averageTimeLong = totalTimeInt / testSize;
                                    long aveargeTimeMod = totalTimeInt % testSize;



                                    Console.WriteLine("Total Time {0} seconds for {1} games.", totalTimeInt, testSize);

                                    //string totalTime = (stopWatchGameTime.Elapsed).ToString();

                                    //Int32.TryParse(totalTime, out int _totalTime);


                                    //int averageTime = (_totalTime / testSize);


                                    Console.WriteLine("Average time per game: {0}.{1} seconds",averageTimeLong, aveargeTimeMod );

                                            Console.ReadKey();
                                            Console.ReadKey();
                                        }







                                        // Checks if the current player has any available moves
                                        // If the method returns false, the player will lose.
                                        if (playerOb.AreThereAnyValidMoves(positionsArray, player1Turn).Equals(false))
                                        {
                                            // Stores the current state of the board
                                            undoRedoReplay.StoreTheMovePositionsUndoRedo(positionsArray, player1Turn);

                                            // A different winning message is displayed depending on who won
                                            if (player1Turn.Equals(false))
                                            {
                                                theBoard.PlayerXWinningMessage();   
                                            }
                                            else
                                            {
                                                theBoard.PlayerOWinningMessage();
                                            }
                                        
                                            Console.Clear();
                                            theBoard.DisplayTheBoard(positionsArray, player1Turn);
                                            Console.WriteLine("Press enter to return to the menu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    



                                        Console.Clear();
                                        theBoard.DisplayTheBoard(positionsArray, player1Turn);

                                        

                                        if (gameModeSelection.Equals(2) && player1Turn.Equals(false))
                                        {

                                            aI.GetMove(ref yOne, ref xOne, ref yTwo, ref xTwo, positionsArray, ref player1Turn);


                                        }

                                        if (gameModeSelection.Equals(1) || (player1Turn.Equals(true) && gameModeSelection.Equals(2)))
                                        {
                                            Console.WriteLine("Please enter the Y Co-Ordinate of the piece you want to move:");
                                            Int32.TryParse(Console.ReadLine(), out yOne);

                                            Console.WriteLine("Please enter the X Co-Ordinate of the piece you want to move:");
                                            Int32.TryParse(Console.ReadLine(), out xOne);

                                            // Stops any out of range exceptions
                                            if ((yOne < 0 || yOne > 7) || (xOne < 0 || xOne > 7))
                                            {
                                                theBoard.DisplayTheBoard(positionsArray, player1Turn);
                                                Console.WriteLine("You have entered an incorrect co-ordinate.\nPlease enter your co-ordinates again.");
                                                Console.ReadKey();
                                                break;
                                            }

                                            if (playerOb.PlayerCheck(yOne, xOne, positionsArray, player1Turn).Equals(false))
                                            {
                                                Console.Clear();
                                                theBoard.DisplayTheBoard(positionsArray, player1Turn);
                                                Console.WriteLine("You must select a piece that belongs to you.");
                                                Console.ReadKey();
                                                break;
                                            }

                                            // Refreshes the board
                                            Console.Clear();
                                            theBoard.DisplayTheBoard(positionsArray, player1Turn);

                                            Console.WriteLine("Please enter the Y Co-Ordinate of the tile you want to move your piece to:");
                                            Int32.TryParse(Console.ReadLine(), out yTwo);

                                            Console.WriteLine("Please enter the X Co-Ordinate of the tile you want to move your piece to:");
                                            Int32.TryParse(Console.ReadLine(), out xTwo);

                                        } 

                                        // Stops any out of range exceptions
                                        if ((yTwo < 0 || yTwo > 7) || (xTwo < 0 || xTwo > 7))
                                        {
                                            theBoard.DisplayTheBoard(positionsArray, player1Turn);
                                            Console.WriteLine("You have entered an incorrect co-ordinate for the destination tile.\nPlease enter your co-ordinates again.");
                                            Console.ReadKey();
                                            break;
                                        }

                                        playerOb.ForcedCaptureCheck(ref player1Turn, positionsArray, yOne, xOne, yTwo, xTwo);

                                        // If a piece has just been converted into a king, this method ends the turn for that player.
                                        playerOb.IsItAKing(yTwo, xTwo, positionsArray, ref player1Turn);


                                        // Stores the current state of the board
                                        undoRedoReplay.StoreTheMovePositionsUndoRedo(positionsArray, player1Turn);

                                        // Displays the current board
                                        theBoard.DisplayTheBoard(positionsArray, player1Turn);     

                                        // Checks if there is a winner   
                                        if (theBoard.IsThereAWinner().Equals(true))
                                        {
                                            Console.Clear();
                                            theBoard.DisplayTheBoard(positionsArray, player1Turn);
                                            Console.WriteLine("Press enter to return to the menu");
                                            Console.ReadKey();

                                            theBoard.NewGame(positionsArray);                                                                                                            
                                        }

                                        yOne = 0;
                                        xOne = 0;
                                        yTwo = 0;
                                        xTwo = 0;

                                    

                                    }
                                    catch (Exception ex)
                                    {
                                        Console.Clear();
                                        Console.WriteLine(ex);
                                        Console.ReadKey();
                                    }

                                    break;
                                }

                            // Undo a move
                            case 2:
                                {
                                    try
                                    {
                                        if (gameModeSelection.Equals(1) || gameModeSelection.Equals(2))
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

                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.Clear();
                                        Console.WriteLine(ex);
                                        Console.ReadKey();
                                    }
                            

                                            break;
                                }

                            // Redo a move
                            case 3:
                                {
                                    try
                                    {
                                        if (gameModeSelection.Equals(1) || gameModeSelection.Equals(2))
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
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.Clear();
                                        Console.WriteLine(ex);
                                        Console.ReadKey();
                                    }
                        

                                    break;
                                }

                            // Replay a game
                            case 4:
                                {
                                    try
                                    {
                                        // Gets the number for how many times to loop
                                        int numReplays = undoRedoReplay.replayQueue.Count;



                                        if (undoRedoReplay.replayQueue.Count.Equals(1))
                                        {
                                            Console.WriteLine("You must play some moves first, before being able to replay.");
                                            Console.ReadKey();
                                            break;
                                        }



                                        for (int i = 0; i < numReplays; i++)
                                        {
                                            // Pauses the app, so you can follow the moves
                                            int milliseconds = 2000;
                                            Thread.Sleep(milliseconds);



                                            // Stops the program from trying to dequeue the first value off the queue 'replayQueue'
                                            // When there is nothing stored on the stack
                                            if (undoRedoReplay.replayQueue.Count > 1)
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

                                        //Clears the stacks and queues, so they are ready to record another game
                                        undoRedoReplay.undoStack.Clear();
                                        undoRedoReplay.redoStack.Clear();
                                        undoRedoReplay.replayQueue.Clear();

                                        yOne = 0;
                                        xOne = 0;
                                        yTwo = 0;
                                        xTwo = 0;                                    
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.Clear();
                                        Console.WriteLine(ex);
                                        Console.ReadKey();
                                    }

                                    break;
                                }


                            // Reset a turn
                            case 5:
                                {
                                    try
                                    {
                                        if (gameModeSelection.Equals(1) || gameModeSelection.Equals(2))
                                        {
                                            yOne = 0;
                                            xOne = 0;
                                            yTwo = 0;
                                            xTwo = 0;
                                            theBoard.DisplayTheBoard(positionsArray, player1Turn);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.Clear();
                                        Console.WriteLine(ex);
                                        Console.ReadKey();
                                    }

                                    break;
                                }
                            //End a turn
                            case 6:
                                {
                                    try
                                    {
                                        if (gameModeSelection.Equals(1) || gameModeSelection.Equals(2))
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
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.Clear();
                                        Console.WriteLine(ex);
                                        Console.ReadKey();
                                    }

                                            break;
                                }

                            // Restart game
                            case 7:
                                {
                                    try
                                    {
                                        if (gameModeSelection.Equals(1) || gameModeSelection.Equals(2))
                                        {
                                            theBoard.NewGame(positionsArray);

                                            //Clears the stacks and queues, so they are ready to record another game
                                            undoRedoReplay.undoStack.Clear();
                                            undoRedoReplay.redoStack.Clear();
                                            undoRedoReplay.replayQueue.Clear();

                                            // Stores the current state of the board
                                            undoRedoReplay.StoreTheMovePositionsUndoRedo(positionsArray, player1Turn);
                                            yOne = 0;
                                            xOne = 0;
                                            yTwo = 0;
                                            xTwo = 0;

                                            player1Turn = true;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.Clear();
                                        Console.WriteLine(ex);
                                        Console.ReadKey();
                                    }

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

            #region Starting Menu   

            //void StartingMenu()
            //{

            //    Console.WriteLine("\n" +
            //        "   ___  _                  _                          \n" +
            //        "  / __\\| |__    ___   ___ | | __ ___  _ __  ___      \n" +
            //        " / /   | '_ \\  / _ \\ / __|| |/ // _ \\| '__|/ __|   \n" +
            //        "/ /___ | | | ||  __/| (__ |   <|  __/| |   \\__ \\    \n" +
            //        "\\____/ |_| |_| \\___| \\___||_|\\_\\\\___||_|   |___/\n" +
            //        "" +
            //        "" +
            //        "                                                         ___  _                  _                          \n" +
            //        "                                                        / __\\| |__    ___   ___ | | __ ___  _ __  ___      \n" +
            //        "                                                       / /   | '_ \\  / _ \\ / __|| |/ // _ \\| '__|/ __|   \n" +
            //        "                                                      / /___ | | | ||  __/| (__ |   <|  __/| |   \\__ \\    \n" +
            //        "                                                      \\____/ |_| |_| \\___| \\___||_|\\_\\\\___||_|   |___/\n" +
            //        "");
            //    Console.ReadKey();

            //    Console.WriteLine("                                                                               By Marc Reid [03001588]");
            //    Console.ReadKey();




            //    while (notMadeChoice)
            //    {
            //        Console.Clear();
            //        Console.WriteLine("Game Modes Available:\n\n[1] - Human vs Human\n[2] - Human vs AI\n[3] - AI vs AI\n[4] - To quit the game\n\nPlease select a game mode.");


            //        Int32.TryParse(Console.ReadLine(), out gameMode);



            //        switch (gameMode)
            //        {
            //            case 1:
            //                {
            //                    gameModeSelection = 1;
            //                    notMadeChoice = false; ;
            //                    break;
            //                }

            //            case 2:
            //                {
            //                    gameModeSelection = 2;
            //                    notMadeChoice = false;
            //                    break;
            //                }

            //            case 3:
            //                {
            //                    gameModeSelection = 3;
            //                    notMadeChoice = false;
            //                    break;
            //                }

            //            case 4:
            //                {
            //                    // Closes the application
            //                    Environment.Exit(0);
            //                    break;
            //                }

            //            default:
            //                {
            //                    Console.Clear();
            //                    Console.Beep();
            //                    notMadeChoice = true;
            //                    Console.WriteLine("Please make sure the number you select is on the menu.");
            //                    Console.ReadKey();
            //                    break;
            //                }

            //        }
            //    }
            //}

            #endregion
        }
    }
}



