using System;
using System.Collections.Generic;
using System.Text;

namespace Calendario
{
    public class Pascoa
    {
        public Pascoa(int ano)
        {
            int numeroAureo = NumeroAureo(ano);
            int seculo = Seculo(ano);
            int x = QuocienteX(seculo);
            int z = QuocienteY(seculo);
            int epacta = Epacta(numeroAureo, z, x);
            int luaCheia = LuaCheia(epacta);
            int domingo = Domingo(x, ano);
            DiaPascoa = CalculoMes(luaCheia, domingo);
        }

        public int DiaPascoa { get; set; }

        private int NumeroAureo(int y)
        {
            return (y % 19) + 1;
        }

        private int Seculo(int y)
        {
            return (y / 100) + 1;
        }

        private int QuocienteX(int c)
        {
            return ((3 * c) / 4) - 12;
        }

        private int QuocienteY(int c)
        {
            return (((8 * c) + 5) / 25) - 5;
        }

        private int Epacta(int g, int z, int x)
        {
            int epacta = ((11 * g) + 20 + z - x) % 30;
            if ((epacta == 25 && g > 11) || epacta == 24)
            {
                epacta++;
            }
            return epacta;
        }

        private int LuaCheia(int e)
        {
            int n = 44 - e;
            if (n < 21)
            {
                return n + 30;
            }
            else
            {
                return n;
            }
        }

        private int Domingo(int x, int y)
        {
            return ((5 * y) / 4) - (x + 10);
        }

        private int CalculoMes(int luaCheia, int domingo)
        {
            return (luaCheia + 7) - ((domingo + luaCheia) % 7);
        }

        public void ImprimirPascoa(int calculoMes, int ano)
        {

            if (calculoMes > 31)
            {
                Console.WriteLine("Pascoa: {0} de abril de {1}", calculoMes -= 31, ano);
            }
            else
            {
                Console.WriteLine("Pascoa: {0} de marco de {1}", calculoMes, ano);
            }
        }

    }
}
