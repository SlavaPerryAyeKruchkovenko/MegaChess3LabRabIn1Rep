using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MegaCheess
{
	class Printer
	{
        private static int coordinateX = Console.WindowWidth / 2 - 39;
		private static readonly int coordininateY = -1;
        private static readonly int delay = 100;
        private static readonly int SecondDelay = 10;

        public static void PrintMenu()
        {
            Console.Clear();
            coordinateX = Console.WindowWidth / 2 - 20;

            if (Console.WindowWidth <= 80)
                ErrorMesange();

            PrintNameSpace('E', '5', MenuDataBase.start_Y_ForNameSpace, 7, true, "name space", 7,MenuDataBase.NameSpaceColor);
            PrintNameSpace('C', '9', MenuDataBase.start_Y_ForNewGameSpace, 7, false, "new game space", 20,MenuDataBase.NewGameSpaceColor);
            PrintNameSpace('C', ':', MenuDataBase.start_Y_ForContinueSpace, 7, false, "continue space", 20,MenuDataBase.ContinueSpaceColor);
            PrintNameSpace('C', '7', MenuDataBase.start_Y_ForScoreSpace, 6, false, "score space", 8,MenuDataBase.ScoreSpaceColor);
            PrintNameSpace('C', '5', MenuDataBase.start_Y_ForExitSpace, 6, false, "exit space", 4,MenuDataBase.ExitSpaceColor);

            Thread.Sleep(delay);           
        }
        private static void PrintNameSpace(char firstRestriction, char secondRestriction,int displaceY, int displaceX,bool haveShortName,string nameSpace,int indent,ConsoleColor foregrount)
        {
            Console.ForegroundColor = foregrount;

            int x=coordinateX-indent, y=coordininateY+displaceY;
            for (char letter = 'A'; letter <= firstRestriction; letter++) 
            {
                y++;

                if(haveShortName)
                PrintShortNameSpace(displaceY);

                for (char num = '1'; num <= secondRestriction; num++) 
                {
                    x += displaceX;
                    Console.SetCursorPosition(x, y);
                   
                    if (nameSpace == "new game space"&&num=='5')
                        x += 7;
                    PrintElementOfDictionary(nameSpace, letter, num);
                }
                x = coordinateX - indent;
            }
            if(haveShortName)
            Console.Write("V 2.0");      
        }
        private static void PrintShortNameSpace(int displaceY)
		{
			for (int i = 0; i < 5; i++)
			{
                Console.SetCursorPosition(coordinateX-1, coordininateY +displaceY+1+i);
                Console.WriteLine(MenuDataBase.shortName[i]);
            }
            
        }
        private static void PrintElementOfDictionary(string nameSpace,char letter,char num)
		{
            switch(nameSpace)
			{
                case "name space": Console.Write(MenuDataBase.nameSpace[letter][num.ToString()]);break;
                case "new game space": Console.Write(MenuDataBase.newGameSpace[letter][num.ToString()]); break;
                case "continue space": Console.Write(MenuDataBase.continueSpace[letter][num.ToString()]); break;
                case "score space": Console.Write(MenuDataBase.scoreSpace[letter][num.ToString()]); break;
                case "exit space": Console.Write(MenuDataBase.exitSpace[letter][num.ToString()]); break;
            }   
        }
        private static void ErrorMesange()
		{  
            while(Console.WindowWidth<=80)
			{
                Console.Clear();
                Console.WriteLine(MenuDataBase.ErorrString);
                Thread.Sleep(delay);
			}
		}
        private static void EraseNameSpace(int startY,int startX,int height,int speed)
		{
			for (int i = 0; i <= startX; i++)
			{
				for (int j = startY; j < startY+height; j++)
				{
                    Console.SetCursorPosition(Console.WindowWidth / 2 - i, j);
                    Console.WriteLine(" ");
                    Console.SetCursorPosition(Console.WindowWidth / 2 + i, j);
                    Console.WriteLine(" ");
                    Thread.Sleep(SecondDelay-speed);
                }   
			}
		}
        public static void ConsoleClear()
		{
            EraseNameSpace(MenuDataBase.start_Y_ForNameSpace, 21, 5,0);
            Thread.Sleep(delay);
            EraseNameSpace(MenuDataBase.start_Y_ForNewGameSpace, 33, 3,2);
            Thread.Sleep(delay);
            EraseNameSpace(MenuDataBase.start_Y_ForContinueSpace, 33, 3,4);
            Thread.Sleep(delay);
            EraseNameSpace(MenuDataBase.start_Y_ForScoreSpace, 22, 3,6);
            Thread.Sleep(delay);
            EraseNameSpace(MenuDataBase.start_Y_ForExitSpace, 18, 3,8);
            Thread.Sleep(delay);
        }
        public static void PrintBoard(bool isNewGame)
		{
            Console.Clear();
            if (isNewGame)
                Console.WriteLine("Новая игра");
            else if (!isNewGame)
                Console.WriteLine("Продолжить");

        }
    }
}
