using System;

namespace Calendario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ano? ");
            int ano = Convert.ToInt32(Console.ReadLine());

            Pascoa pascoa = new Pascoa(ano);
            pascoa.ImprimirPascoa(pascoa.DiaPascoa, ano);

            Calendario calendario = new Calendario(ano);
            calendario.Imprimir();
            
            Console.ReadLine();
        }

    }
}
