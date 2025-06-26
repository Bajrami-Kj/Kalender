using System;
using System.Security;

namespace Kalender
{
    public class Kalender
    {
        public static void PrintKalender(int currentDay, string[] isTheretermin,string month)
        {
            string[,] kalender = new string[3, 7];
            int[] days = new int[7];
            for (int i = 0; i < days.Length; i++)
            {
                days[i] = currentDay ++;
                if(days[i] >= 30)
                {
                    currentDay = 1;
                }
            }
            Console.WriteLine($"Monat: {month}");
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
                     Console.Write($"|     {isTheretermin[0],-3}     |      {isTheretermin[0],-3}      |      {isTheretermin[0],-3}    |      {isTheretermin[0],-3}        |       {isTheretermin[0],-3}      |       {isTheretermin[0],-3}       |     {isTheretermin[0],-3}     |");                  
                }



                Console.WriteLine();
            }
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
        }

      
        public static void Main()
        {
            Console.WriteLine("Sommerferien - Kalender");
            Console.WriteLine("=======================");
            int currentDay = 1;
            bool[] terminOrNot = new bool[7];
            string[] isThereTermin = new string[7];


            for (int i = 0; i < terminOrNot.Length; i++)
            {
                if(terminOrNot[i] == true)
                {
                    isThereTermin[i] = "JA";
                }
                else
                {
                    isThereTermin[i] = "NEIN";
                }
            }
            Console.WriteLine($"Eingabe \"x\" für termin hinzufügen, \"y\" für");
            PrintKalender(currentDay,isThereTermin,"Jänner");
            Save();


        }

        private static void Save()
        {
            
        }
    }
}