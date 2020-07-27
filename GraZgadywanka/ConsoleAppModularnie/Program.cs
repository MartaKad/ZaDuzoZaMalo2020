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
            // człowiek podaje zakres losowania: min, max
            int wylosowana = Losuj();

            bool odgadnieto = false;
            do
            {
                // 2. zaproponuj
                //int propozycja = Wczytaj.Liczbe();

                // 3. oceń

            }
            while (!odgadnieto);
            
        }

        // ============================

        static int Losuj(int min=1, int max=101)
        {
            var los = new Random();
            int y = los.Next(min, max);
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
    }
}
