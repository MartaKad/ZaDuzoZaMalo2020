using System;

namespace ConsoleAppMonolitycznie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gra \"Za dużo za mało\"");

            //1. Komputer losuje liczbę do odgadnięcia
            #region komputer losuje
            var los = new Random(); // tworzymy generator liczb losowych
            int wylosowana = los.Next(1, 101); // lsoujemy liczbę z podanego zakresu

#if DEBUG
            Console.WriteLine(wylosowana);
#endif

            Console.WriteLine("Wylosowałem liczbę od 1 do 100.\nOdgadnij ją!");
            #endregion

            bool odgadniete = false;
            do // powtarzaj
            {
                // 2. Człowiek proponuje wartość
                Console.Write("Podaj swoją propozycję: ");
                int propozycja;
                try
                {
                     propozycja = int.Parse(Console.ReadLine());
                }
                catch(FormatException)
                {
                    Console.WriteLine("Nie podano poprawnej liczby. Koniec programu");
                    return;
                }
                catch(OverflowException)
                {
                    Console.WriteLine("Podano za dużą liczbę. Koniec programu");
                    return;
                }
                catch(Exception)
                {
                    Console.WriteLine("Niezidentyfikowana awaria. Koniec programu");
                    return;
                }

                // 3. Komputer ocenia propozycję człowieka
                #region komputer ocenia
                if (propozycja < wylosowana)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Za mało");
                    Console.ResetColor();
                }
                else if (propozycja > wylosowana)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Za dużo");
                    Console.ResetColor();
                }
                else // propozycja == wylosowana
                {
                    odgadniete = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Trafiłeś");
                    Console.ResetColor();
                }
                #endregion
            }
            while (!odgadniete); // dopoki nie odgadnieto
            Console.WriteLine("Koniec gry");
        }
    }
}
