using System;
using System.Collections.Generic;

namespace _20201403_PPE1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");


            //Inicialização:
            Slot slot = new Slot();
            slot.estacoes = new List<Estacao>();
            slot.tContador = 0;

            slot.nEstacoes = 5; //??

            for (int i = 0; i < slot.nEstacoes; i++)
            {
                Random rnd = new Random();
                Estacao estacao = new Estacao(rnd.Next(), 0, 0);
                slot.estacoes.Add(estacao);

            }

            //for (int i = 0; i < slot.nEstacoes; i++)
            //{
            //    Console.WriteLine(slot.estacoes[i].tProximaChegada);
            //}



        }
    }
}
