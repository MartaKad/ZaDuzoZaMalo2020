using System;

namespace ConsoleAppModularnie
{
    class Program
    {
        const string ZA_DUZO = "Za dużo";
        const string ZA_MALO = "Za mało";
        const string TRAFIONO = "Trafiono";

        static void Main()
        {
            Console.WriteLine("Za dużo za mało - proceduralnie");
            // 1. losuj
            int zakresOd = WczytajLiczbe("Podaj dolny zakres losowania: ");
            int zakresDo = WczytajLiczbe("Podaj górny zkres losowania: ");
            int wylosowana = Losuj(zakresOd, zakresDo);
            Console.WriteLine($"Wylosowano wartość w zakresie od {zakresOd} do {zakresDo}.");
#if DEBUG
             Console.WriteLine(wylosowana);
#endif
            
            do
            {
                // 2. zaproponuj
                int propozycja = WczytajLiczbe("Podaj swoją propozyjcę: ");

                // 3. oceń
                string odpowiedz = Ocena(propozycja, wylosowana);
                Console.WriteLine(odpowiedz);
                if (odpowiedz == TRAFIONO)
                {
                    //return; //wychodzimy z Main
                    break; //wychodzimy z petli
                }
            }
            while (true);
            Console.WriteLine("Koniec gry");
        }

        // ============================

        /// <summary>
        /// Losuje liczbę całkowitą z podanego zakresu włącznie z granicami
        /// </summary>
        /// <remarks>
        /// Dłuższy tekst z wyjaśnieniami
        /// </remarks>
        /// <param name="min">dolna granica losowania</param>
        /// <param name="max">górna granica losowania, nie mniejsza niż granica dolna</param>
        /// <returns>liczba losowa z zakresu min..max włącznie</returns>
        static int Losuj(int min=1, int max=100)
        {
            var los = new Random();
            int y = los.Next(min, max + 1);
            return y;
        }

        int Losuj1(int min = 1, int max = 101)
        {
            var los = new Random();
            return los.Next(min, max);  
        }

        int Losuj2(int min = 1, int max = 101)
        {
            return (new Random()).Next(min, max);
        }

        static string Ocena(int propozycja, int wylosowana)
        {
            if(propozycja < wylosowana )
            {
                return ZA_DUZO;
            }
            else if (propozycja > wylosowana)
            {
                return ZA_MALO;
            }
            else
            {
                return TRAFIONO;
            }

            // operator ternarny
        }

        static int WczytajLiczbe(string tekst = "Podaj liczbę: ")
        {
            int wynik = 0;
            do
            {
                Console.Write(tekst + " (X aby zakończyć): ");
                string napis = Console.ReadLine();
                //if(napis == "X" || napis == "x")
                if(napis.ToUpper() == "X")
                {
                    Console.WriteLine("Poddałeś się! Koniec programu.");
                    Environment.Exit(0);
                }

                try
                {
                    wynik = int.Parse(napis);
                    return wynik;
                }
                catch (FieldAccessException)
                {
                    Console.WriteLine("Niepoprawny format. Spróbuj jeszcze raz!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Przekroczony zakres. Spróbuj jeszcze raz!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Nieznany błąd. Spróbuj jeszcze raz!");
                }
            }
            while (true);
                
            return wynik;
        }
    }
}
