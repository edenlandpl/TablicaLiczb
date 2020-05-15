using System;
using System.Collections.Generic;

namespace Konsola2
{
    public class Konwerter
    {
        public List<int> parzyste = new List<int>();
        public List<int> nieparzyste = new List<int>();
        private List<int> testowaneCyfry = new List<int>();
        
        public void SegregujParzysteNieparzyste(List<int> doSortowaniaCyfry)
        {
            foreach (var cyfra in doSortowaniaCyfry)
            {
                if (cyfra % 2 != 0)
                    nieparzyste.Add(cyfra);
                else
                    parzyste.Add(cyfra);
            }
        }

        public void WyswietlCyfry(string komunikat, List<int> cyfry)
        {
            Console.Write(komunikat + " - ");
            foreach (int cyfra in cyfry)
            {
                Console.Write(cyfra + ", ");
            }
            Console.WriteLine();
        }

        public void resetujListy()
        {
            nieparzyste.Clear();
            parzyste.Clear();
            testowaneCyfry.Clear();
        }

        public bool TestujPoprawność(string pobranyCiagBezSpacji)
        {
            string tylkoCyfry = "";
            bool poprawnosc = false;

            foreach (char znak in pobranyCiagBezSpacji)
            {
                if (char.IsDigit(znak))
                {
                    tylkoCyfry += znak;
                }
                if (znak == ',' || !char.IsDigit(znak) || znak == '\0')
                {
                    try
                    {
                        testowaneCyfry.Add(Int32.Parse(tylkoCyfry));
                        tylkoCyfry = "";
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Błąd - wpisana litera zamiast liczby lub nie wprowadzono liczby ");
                        poprawnosc = true;
                    }
                }
                if (znak == '.')
                {
                    Console.WriteLine("Tylko liczby calkowite, wpisales liczbe z czescia ulamkowa");
                    poprawnosc = true;
                }
            }
            return poprawnosc;
        }
    }
}
