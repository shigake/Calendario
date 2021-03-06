﻿using System;

namespace Calendario
{
    public class Calendario : Pascoa
    {
        public Calendario(int ano) : base(ano)
        {
            Ano = ano;
        }
        public bool Bissexto
        {
            get { return VerificaBissexto(Ano); }
        }
        
        public void Imprimir()
        {
            int diaSemana = DiaSemanaUm(base.DiaPascoa, Bissexto);
            for (int mes = 1; mes <= 12; mes++)
            {
                int totalDiaMes = TotalDiaMes(mes, Bissexto);
                ImprimeCabecalho(mes, diaSemana);
                for (int dia = 1; dia <= totalDiaMes; dia++, diaSemana++)
                {
                    if (diaSemana == 7)
                    {
                        diaSemana = 0;
                        if (dia != 1)
                        {
                            Console.WriteLine(" |");
                            Console.Write("|");
                        }
                    }
                    ImprimeDias(diaSemana, dia);
                }
                ImprimeFinalMes(diaSemana + 1);
            }
        }

        private bool VerificaBissexto(int ano)
        {
            int bi = ano % 100 == 0 ? ano / 100 : ano;

            if (bi % 4 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int DiaSemanaUm(int dia, bool bissexto)
        {
            int diaSemana = 7;
            if (dia > 31)
            {
                dia -= 31;
                for (int mes = 3; mes >= 0; mes--)
                {
                    while (dia > 0)
                    {
                        if (diaSemana == 1)
                        {
                            diaSemana = 8;
                        }
                        dia--;
                        diaSemana--;
                    }
                    if (mes > 0)
                    {
                        dia = bissexto ? mes == 2 ? 29 : 31 : mes == 2 ? 28 : 31;
                    }
                }
            }
            else
            {
                for (int mes = 2; mes >= 0; mes--)
                {
                    while (dia > 0)
                    {
                        if (diaSemana == 1)
                        {
                            diaSemana = 8;
                        }
                        dia--;
                        diaSemana--;
                    }
                    if (mes > 0)
                    {
                        dia = bissexto ? mes == 2 ? 29 : 31 : mes == 2 ? 28 : 31;
                    }
                }
            }
            diaSemana = diaSemana + 1 == 8 ? 1 : diaSemana + 1;
            return diaSemana;
        }

        private int TotalDiaMes(int mes, bool bissexto)
        {
            switch (mes)
            {
                case 1: return 31;
                case 2: return bissexto ? 29 : 28;
                case 3: return 31;
                case 4: return 30;
                case 5: return 31;
                case 6: return 30;
                case 7: return 31;
                case 8: return 31;
                case 9: return 30;
                case 10: return 31;
                case 11: return 30;
                case 12: return 31;
                default: throw new Exception();
            }
        }

        private void ImprimeDias(int diaSemana, int dia)
        {
            if (dia < 10)
            {
                Console.Write(" 0{0} ", dia);
            }
            else
            {
                Console.Write(" {0} ", dia);
            }

        }

        private void ImprimeCabecalho(int mes, int diaSemanaUm)
        {
            switch (mes)
            {
                case 1:
                    Console.WriteLine("Janeiro");
                    break;
                case 2:
                    Console.WriteLine("Fevereiro");
                    break;
                case 3:
                    Console.WriteLine("Marco");
                    break;
                case 4:
                    Console.WriteLine("Abril");
                    break;
                case 5:
                    Console.WriteLine("Maio");
                    break;
                case 6:
                    Console.WriteLine("Junho");
                    break;
                case 7:
                    Console.WriteLine("Julho");
                    break;
                case 8:
                    Console.WriteLine("Agosto");
                    break;
                case 9:
                    Console.WriteLine("Setembro");
                    break;
                case 10:
                    Console.WriteLine("Outubro");
                    break;
                case 11:
                    Console.WriteLine("Novembro");
                    break;
                case 12:
                    Console.WriteLine("Dezembro");
                    break;
            }

            Console.WriteLine("|-----------------------------|");
            Console.WriteLine("| dom seg ter qua qui sex sab |");
            Console.Write("|");
            switch (diaSemanaUm)
            {
                case 0:

                case 1:
                    Console.Write(" -- ");
                    break;
                case 2:
                    Console.Write(" --  -- ");
                    break;
                case 3:
                    Console.Write(" --  --  -- ");
                    break;
                case 4:
                    Console.Write(" --  --  --  -- ");
                    break;
                case 5:
                    Console.Write(" --  --  --  --  -- ");
                    break;
                case 6:
                    Console.Write(" --  --  --  --  --  -- ");
                    break;
            }
        }

        private void ImprimeFinalMes(int diaSemana)
        {
            switch (diaSemana)
            {
                case 2:
                    Console.WriteLine(" --  --  --  --  --  --  |");
                    break;
                case 3:
                    Console.WriteLine(" --  --  --  --  --  |");
                    break;
                case 4:
                    Console.WriteLine(" --  --  --  --  |");
                    break;
                case 5:
                    Console.WriteLine(" --  --  --  |");
                    break;
                case 6:
                    Console.WriteLine(" --  --  |");
                    break;
                case 7:
                    Console.WriteLine(" --  |");
                    break;
                case 8:
                    Console.WriteLine(" |");
                    break;
            }
            Console.WriteLine("|-----------------------------|");

        }
    }
}
