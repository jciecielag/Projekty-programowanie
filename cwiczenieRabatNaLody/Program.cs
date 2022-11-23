using System;

namespace cwiczenieRabatNaLody
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rabat=0;
            DateTime data_urodzenia,data_wylotu;
            string rodzaj_lotu,staly_klient;

            Console.WriteLine("Witaj");
            
            Console.WriteLine("Podaj datę urodzenia(W formacie DD.MM.YYYY)"); 
            data_urodzenia = DateTime.Parse(Console.ReadLine()); // Oblicza na podstawie daty wiek
            var today = DateTime.Today;
            var age = today.Year - data_urodzenia.Year;

            if (data_urodzenia.Date > today.AddYears(-age)) age--;

            Console.WriteLine("Podaj datę wylotu(W formacie DD.MM.YYYY)");
            data_wylotu = DateTime.Parse(Console.ReadLine());

             bool isSeasonal;
            if (
                (data_wylotu.Month == 7 || data_wylotu.Month == 8) || //miesiąc Lipiec lub Sierpień
                (data_wylotu >= new DateTime(data_wylotu.Year, 12, 20) || data_wylotu <= new DateTime(data_wylotu.Year, 1, 10)) || //Okres wakacyjny 20.12.XXXX – 10.01.XXX(X+1)
                (data_wylotu >= new DateTime(data_wylotu.Year, 3, 20) && data_wylotu <= new DateTime(data_wylotu.Year, 4, 10)) // Okres wakacyjny 20.03.XXXX – 10.04.XXXX
                )
                isSeasonal = true;
            else
                isSeasonal = false;

            Console.WriteLine("Jest to lot krajowy czy międzynarodowy? (krajowy|międzynarodowy)");
            rodzaj_lotu = Console.ReadLine();
            
            Console.WriteLine("Czy jesteś stałym klientem? (tak|nie)");
            staly_klient = Console.ReadLine();
            
            if (age < 2 && rodzaj_lotu == "krajowy" )
            {
                rabat = 80;
            }
            else if (age < 2 && rodzaj_lotu == "międzynarodowy")
            {
                rabat = 70;
            }

            if (age <= 16 && age >= 2)
                {
                rabat += 10;
                }
            
            if  (data_wylotu.AddMonths(-5) >= today   )
                {
                    rabat += 10;
                }
             if  (isSeasonal )
                {
                    rabat += 10;
                }   
                
            if  (staly_klient == "tak")
                {
                    rabat += 10;
                }
                
                if (age < 2 && rabat > 80)
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
