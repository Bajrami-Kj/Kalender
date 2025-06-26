using System;

namespace Kalender
{
    public class Kalender
    {
        public static void PrintKalender(int currentDay)
        {
            string[,] kalender = new string[3, 7];
            int[] days = new int[7];
            for (int i = 0; i < days.Length; i++)
            {
                days[i] = currentDay + i;

            }
            for(int i = 0; i  < kalender.GetLength(0); i++)
            {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                
                if(i == 0)
                {
                    Console.Write($"|    Montag    |    Dienstag    |    Mittwoch  |    Donnerstag    |     Freitag     |     Samstag      |     Sonntag  |");
                }
                if(i == 1)
                {
                    Console.Write($"|      {days[0],-3}     |        {days[1],-3}     |       {days[2],-3}    |         {days[3],-3}      |         {days[4],-3}     |         {days[5],-3}      |      {days[6],-3}     |");
                }
                if (i==2)
                {
                                        
                }
                Console.WriteLine();
            }
  
        }

      
        public static void Main()
        {
            Console.WriteLine("Sommerferien - Kalender");
            Console.WriteLine("=======================");
            string input = "";
            int currentDay = 5;

            PrintKalender(currentDay);
            Save(input);


        }

       
    }
}