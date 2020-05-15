using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Konsola2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool programAktywny = true;
            Konwerter konwerter = new Konwerter();
            List<int> wpisaneCyfry = new List<int>();
            do
            {
                Console.WriteLine();
                Console.WriteLine("Wciśnij y, aby wpisać liczby");
                Console.WriteLine("Wciśnij n, abu zakończyć");
                char menu = Console.ReadKey().KeyChar;

                switch (menu)
                {
                    case 'n':
                        {
                            Console.WriteLine("Wybrałeś n");
                            programAktywny = false;
                        }
                        break;

                    case 'y':
                        {
                            Console.Clear();
                            konwerter.resetujListy();
                            Console.WriteLine("Wybrałeś y");
                            Console.WriteLine("Wpisz liczby calkowite po przecinku, zatwierdz Enter");
                            // testowy ciąg liczb
                            //string pobranyCiag = "1,2,1  1 ,9,77";   
                            string pobranyCiag = Console.ReadLine();

                            var pobranyCiagBezSpacji = pobranyCiag.Replace(" ", String.Empty);

                            if (konwerter.TestujPoprawność(pobranyCiagBezSpacji))
                            {
                                Console.WriteLine("Wpisałeś - " + pobranyCiagBezSpacji);
                                break;
                            }
                            
                            var numbers = Regex.Split(pobranyCiagBezSpacji, @"[^(0-9)]+").ToList();
                            numbers = numbers.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

                            try
                            {
                                wpisaneCyfry = numbers.Select(s => int.Parse(s)).ToList();
                            }
                            catch (Exception e)
                            {

                                Console.WriteLine("Liczba wykracza poza zakres, wpisz mniejsza"); 
                                break;
                            }

                            konwerter.SegregujParzysteNieparzyste(wpisaneCyfry);
                            konwerter.WyswietlCyfry("Nieparzyste", konwerter.nieparzyste);
                            konwerter.WyswietlCyfry("Parzyste   ", konwerter.parzyste);
                            Console.WriteLine("Suma - " + wpisaneCyfry.Sum());
                        }
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Nie rozpoznano znaku, wcisnij y lub n");
                        break;
                }
            } while (programAktywny);
        }
    }
}
