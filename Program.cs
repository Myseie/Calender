using System;
using System.Collections.Generic;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    private static Dictionary<DateTime, List<string>> events = new Dictionary<DateTime, List<string>>();

    static void Main(string[] args )
    {
        while (true)
        {
            Console.WriteLine("\n Välj ett alternativ.:");
            Console.WriteLine("1. Lägg till händelse ");
            Console.WriteLine("2. Visa händelse");
            Console.WriteLine("3. Ta bort händelse");
            Console.WriteLine("4. Avsluta");
            string choice = Console.ReadLine();


            switch (choice) 
            {
                case "1":
                    AddEvent();
                    break;
                case "2":
                    ShowEvents();
                    break;
                case "3":
                    RemoveEvent();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Ogiltligt val, försök igen");
                    break;
            }

        }
    }
    static void AddEvent()
    {
        Console.WriteLine("Ange datum för händelsen (YYYY-MM-DD):");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            Console.WriteLine("Ange Händelsebeskrivning:");
            string eventDescription = Console.ReadLine();

            if (!events.ContainsKey(date) )
            {
                events[date] = new List<string>();
            }
            events[date].Add(eventDescription);
            Console.WriteLine("Händelse tillagd!");

        }
        else 
        {
            Console.WriteLine("Ogiltligt datumformat.");
        
        }


    }

    static void ShowEvents()
    {
        Console.WriteLine("Ange datum för att visa händelser (YYYY-MM-DD): ");
        if(DateTime.TryParse(Console.ReadLine(),out DateTime date))
        {
            if (events.ContainsKey(date))
            {
                Console.WriteLine($"Händelser för {date.ToShortDateString()}:");
                foreach (var evt in events[date])
                {
                    Console.WriteLine($"- {evt}");

                }
            }else
            {
                Console.WriteLine("Inga händelser för detta datum.");
            }
        }else
        {
            Console.WriteLine("Ogiltligt datumformat");
        }
    }

    static void RemoveEvent()
    {
        Console.WriteLine("Ange datum för händelsen som ska tas bort (YYYY-MM-DD): ");
        if( DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            if (events.ContainsKey(date))
            {
                Console.WriteLine($"Händelser för {date.ToShortDateString()}:");
                for (int i = 0; i < events[date].Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {events[date][i]}");
                }

                Console.WriteLine("Ange nummer på den händelse som ska tas bort: ");
                if (int.TryParse(Console.ReadLine(), out int eventNumber) && eventNumber > 0 && eventNumber <= events[date].Count)
                {
                    events[date].RemoveAt(eventNumber - 1);
                    Console.WriteLine("Händelse borttagen!");
                }
                else
                {
                    Console.WriteLine("Ogiltligt händelsenummer");
                }
            }
            else
            {
                Console.WriteLine("Inga händelser för detta datum.");
            }
        }else
        {
            Console.WriteLine("Ogiltligt datumformat.");
        }
        
       
    }
}