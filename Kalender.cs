using Spectre.Console;
using System;

namespace CalendarApp
{
    class Program
    {
        static void ShowCalendar(int week, string[] weekdays, string[,] allAppointments)
        {
            int startDay = (week - 1) * 7 + 1;

            Table table = new Table();

            for (int i = 0; i < 7; i++)
            {
                table.AddColumn(new TableColumn(weekdays[i]).Centered());
            }

            string[] days = new string[7];
            for (int i = 0; i < 7; i++)
            {
                int dayNumber = startDay + i;
                if (dayNumber > 30)
                {
                    dayNumber = dayNumber - 30;
                }
                days[i] = dayNumber.ToString();
            }
            table.AddRow(days);

            string[] appointments = new string[7];
            for (int i = 0; i < 7; i++)
            {
                if (string.IsNullOrEmpty(allAppointments[week - 1, i]) || allAppointments[week - 1, i] == "NO")
                {
                    appointments[i] = "NO";
                }
                else
                {
                    appointments[i] = allAppointments[week - 1, i];
                }
            }
            table.AddRow(appointments);

            AnsiConsole.Clear();
            Console.WriteLine("Calendar - Week " + week);
            AnsiConsole.Write(table);
        }

        static int ChooseWeekday(string[] weekdays)
        {
            string choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose the weekday:")
                    .AddChoices(weekdays)
            );

            for (int i = 0; i < weekdays.Length; i++)
            {
                if (weekdays[i] == choice)
                {
                    return i;
                }
            }

            return 0;
        }

        static int ChooseWeek()
        {
            string[] weeks = { "1", "2", "3", "4", "5" };
            string choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose the week (1-5):")
                    .AddChoices(weeks)
            );

            return int.Parse(choice);
        }

        static void Main(string[] args)
        {
            string[] weekdays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            string[,] allAppointments = new string[5, 7];

            for (int week = 0; week < 5; week++)
            {
                for (int day = 0; day < 7; day++)
                {
                    allAppointments[week, day] = "NO";
                }
            }

            int currentWeek = 1;
            bool running = true;

            do
            {
                ShowCalendar(currentWeek, weekdays, allAppointments);

                string action = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("What do you want to do?")
                        .AddChoices("Add appointment", "Delete appointment", "Change appointment", "Change week", "Exit")
                );

                if (action == "Add appointment")
                {
                    int day = ChooseWeekday(weekdays);

                    if (allAppointments[currentWeek - 1, day] != "NO")
                    {
                        Console.WriteLine("There is already an appointment on this day.");
                    }
                    else
                    {
                        Console.Write("Enter appointment: ");
                        string appointment = Console.ReadLine();
                        allAppointments[currentWeek - 1, day] = appointment;
                        Console.WriteLine("Appointment added.");
                    }
                }
                else if (action == "Delete appointment")
                {
                    int day = ChooseWeekday(weekdays);

                    if (allAppointments[currentWeek - 1, day] == "NO")
                    {
                        Console.WriteLine("No appointment on this day.");
                    }
                    else
                    {
                        allAppointments[currentWeek - 1, day] = "NO";
                        Console.WriteLine("Appointment deleted.");
                    }
                }
                else if (action == "Change appointment")
                {
                    int day = ChooseWeekday(weekdays);

                    if (allAppointments[currentWeek - 1, day] == "NO")
                    {
                        Console.WriteLine("No appointment on this day.");
                    }
                    else
                    {
                        Console.WriteLine("Current appointment: " + allAppointments[currentWeek - 1, day]);
                        Console.Write("Enter new appointment: ");
                        string newAppointment = Console.ReadLine();
                        allAppointments[currentWeek - 1, day] = newAppointment;
                        Console.WriteLine("Appointment changed.");
                    }
                }
                else if (action == "Change week")
                {
                    currentWeek = ChooseWeek();
                }
                else if (action == "Exit")
                {
                    running = false;
                    Console.WriteLine("Program ended.");
                }
            } while (running);
        }
    }
}
