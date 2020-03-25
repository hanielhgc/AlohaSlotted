using Accord.Statistics.Distributions.Univariate;
using System;
using System.Collections.Generic;

namespace _20201403_PPE1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            int nEstacoesProntas = 0;

            //Inicialização:
            Slot slot = new Slot();
            slot.estacoes = new List<Estacao>();
            slot.tContador = 1;//alterar

            slot.nEstacoes = 5; //??


            int nSlotsOciosos = 0;
            int nSlotsTransmitidos = 0;
            int nSlotsComColisao = 0;

            for (int i = 0; i < slot.nEstacoes; i++)
            {
                //?? 
                Estacao estacao = new Estacao(ExponentialDistribution.Random(0.9), 0, 0);
                slot.estacoes.Add(estacao);

            }


            //iterando as estações
            for (int i = 0; i < slot.nEstacoes; i++)
            {
                if (slot.estacoes[i].tProximaChegada <= slot.tContador)
                {
                    if (slot.estacoes[i].nNaFila == 0)
                    {
                        slot.estacoes[i].tProximaTransmissao = slot.tContador + 1;
                    }

                    slot.estacoes[i].nNaFila += 1;

                }

            }

            nEstacoesProntas = 0;
            List<Estacao> estacoesProntas = new List<Estacao>();

            for (int i = 0; i < slot.nEstacoes; i++)
            {
                if (slot.estacoes[i].tProximaTransmissao <= slot.tContador)
                {
                    nEstacoesProntas += 1; //armazenar aqui as estações prontas
                    estacoesProntas.Add(slot.estacoes[i]);
                }

            }


            switch (nEstacoesProntas)
            {
                case 0:
                    nSlotsOciosos += 1;
                    break;
                case 1:
                    nSlotsTransmitidos += 1;

                    for (int i = 0; i < estacoesProntas.Count; i++)
                    {
                        estacoesProntas[i].nNaFila += 1;
                        estacoesProntas[i].tProximaTransmissao = slot.tContador + 1;
                    }
                    break;
                default:
                    nSlotsComColisao += 1;

                    for (int i = 0; i < estacoesProntas.Count; i++)
                    {
                        estacoesProntas[i].tProximaTransmissao = GeometricDistribution.Random(0.5);
                    }

                    break;
            }


            //Iterações



            //for (int i = 0; i < slot.nEstacoes; i++)
            //{
            //    Console.WriteLine(slot.estacoes[i].tProximaChegada);
            //}



        }
    }
}
