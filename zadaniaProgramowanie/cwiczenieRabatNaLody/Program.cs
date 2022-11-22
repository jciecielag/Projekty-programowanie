using System;
using System.Data;
using System.Security.Cryptography;

namespace cwiczenieRabatNaLody
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rabat=0,rabatmax=0;
            DateTime data_urodzenia,data_wylotu;
            string rodzaj_lotu,staly_klient;

            Console.WriteLine("Witaj");
            
            Console.WriteLine("Podaj datę urodzenia(W formacie DD.MM.YYYY)"); 
            data_urodzenia = DateTime.Parse(Console.ReadLine());
            var today = DateTime.Today;
            var age = today.Year - data_urodzenia.Year;

            if (data_urodzenia.Date > today.AddYears(-age)) age--;

            Console.WriteLine("Podaj datę wylotu(W formacie DD.MM.YYYY)");
            data_wylotu = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Jest to lot krajowy czy międzynarodowy? (krajowy|międzynarodowy)");
            rodzaj_lotu = Console.ReadLine();
            
            Console.WriteLine("Czy jesteś stałym klientem? (tak|nie)");
            staly_klient = Console.ReadLine();
            
            if (age <= 2 && rodzaj_lotu == "krajowy" )
            {
                rabat = 80;
            }
            else if (age <= 2 && rodzaj_lotu == "międzynarodowy")
            {
                rabat = 70;
            }

            if (age <= 16 && age >= 2 && rodzaj_lotu == "krajowy" || rodzaj_lotu == "międzynarodowy" )
                {
                rabat = 10;
                }
            
            if  (data_wylotu.AddMonths(-5) >= today)
                {
                    rabat += 10;
                }
                
            if  (staly_klient == "tak")
                {
                    rabat += 10;
                }
                
                if (age <= 2 && rabat > 80)
                {
                    rabat = 80;
                    Console.WriteLine($"Twój rabat wynosi {rabat}%,jest to maksymalny rabat dla niemowląt");
                }
                else
                {
                    Console.WriteLine($"Twój rabat wynosi {rabat}%");
                }
        }
    }
}
