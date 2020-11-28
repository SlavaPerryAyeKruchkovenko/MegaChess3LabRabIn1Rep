using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MegaCheess
{

    class Menu
    {
        public static void WorkWithMenu()
		{            
            MoveArrow();
		}
        private static void MoveArrow()
		{
            bool haveChoice=false;
            do
            {
                Printer.PrintMenu();
                ConsoleKeyInfo key = Console.ReadKey();

                haveChoice=CountConsoleKey(key);

            } while (!haveChoice);
		}
        private static bool CountConsoleKey(ConsoleKeyInfo key)
		{
            bool haveChoice = false;
            if (key.Key == ConsoleKey.UpArrow)
                ChangeColorUp();

            else if (key.Key == ConsoleKey.DownArrow)
                ChangeColorDown();

            else if (key.Key == ConsoleKey.Enter)
                haveChoice = ChangeGameSpace();
            return haveChoice;
        }
        private static void ChangeColorUp()
		{
            if(MenuDataBase.ContinueSpaceColor==MenuDataBase.HighlightColor)
			{
                MenuDataBase.NewGameSpaceColor = MenuDataBase.HighlightColor;
                MenuDataBase.ContinueSpaceColor = MenuDataBase.StandartColor;
            }
            else if (MenuDataBase.ScoreSpaceColor == MenuDataBase.HighlightColor)
            {
                MenuDataBase.ContinueSpaceColor = MenuDataBase.HighlightColor;
                MenuDataBase.ScoreSpaceColor = MenuDataBase.StandartColor;
            }
            else if (MenuDataBase.ExitSpaceColor == MenuDataBase.HighlightColor)
            {
                MenuDataBase.ScoreSpaceColor = MenuDataBase.HighlightColor;
                MenuDataBase.ExitSpaceColor = MenuDataBase.StandartColor;
            }
        }
        private static void ChangeColorDown()
		{
            if (MenuDataBase.NewGameSpaceColor == MenuDataBase.ContinueSpaceColor && MenuDataBase.ScoreSpaceColor == MenuDataBase.ExitSpaceColor)
                MenuDataBase.NewGameSpaceColor = MenuDataBase.HighlightColor;

            else if (MenuDataBase.NewGameSpaceColor == MenuDataBase.HighlightColor)
            {
                MenuDataBase.NewGameSpaceColor = MenuDataBase.StandartColor;
                MenuDataBase.ContinueSpaceColor = MenuDataBase.HighlightColor;
            }
            else if (MenuDataBase.ContinueSpaceColor == MenuDataBase.HighlightColor)
            {
                MenuDataBase.ContinueSpaceColor = MenuDataBase.StandartColor;
                MenuDataBase.ScoreSpaceColor = MenuDataBase.HighlightColor;
            }
            else if (MenuDataBase.ScoreSpaceColor == MenuDataBase.HighlightColor)
            {
                MenuDataBase.ScoreSpaceColor = MenuDataBase.StandartColor;
                MenuDataBase.ExitSpaceColor = MenuDataBase.HighlightColor;
            }
        }
        private static bool ChangeGameSpace()
		{
            if (MenuDataBase.NewGameSpaceColor == MenuDataBase.HighlightColor)
			{
                Printer.ConsoleClear();
                ChessGameSpace.CheesLogic(true);
                return true;
            }                
            if (MenuDataBase.ContinueSpaceColor == MenuDataBase.HighlightColor)
			{
                Printer.ConsoleClear();
                ChessGameSpace.CheesLogic(false);
                return true;
            }             
            if (MenuDataBase.ScoreSpaceColor == MenuDataBase.HighlightColor)
			{
                Printer.ConsoleClear();
                GameSetting.WorkWithSetting();
                return true;
            }
            if (MenuDataBase.ExitSpaceColor == MenuDataBase.HighlightColor)
			{
                Printer.ConsoleClear();
                Environment.Exit(0);
            }             
            return false;    
        }
    }
}
