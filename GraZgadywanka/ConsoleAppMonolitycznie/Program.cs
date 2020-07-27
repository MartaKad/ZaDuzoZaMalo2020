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

            Console.Write("Podaj swoją propozycję: ");
            // 2. Człowiek proponuje wartość
            int propozycja = int.Parse(Console.ReadLine());

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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Trafiłeś");
                Console.ResetColor();
            }
            #endregion
        }
    }
}
