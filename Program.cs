using System;

namespace DIO_.NET
{
    class Program
    {
        static void Classe1() {
            Console.WriteLine("\nWhat is your name? ");
            var name = Console.ReadLine();
            var date = DateTime.Now;
            Console.WriteLine($"\nOlá, {name}, hoje é {date:d} e a hora atual é {date:t} !");
            Console.Write("\nPressione qualquer tecla para sair ...");
            Console.ReadKey(true);

        }
        static void Main(string[] args)
        {
            Classe1();
        }
    }
}
