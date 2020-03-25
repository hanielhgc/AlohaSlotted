using Accord.Statistics.Distributions.Univariate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _20201403_PPE1
{
    public class Program
    {
        public static void Main(string[] args)
        {

            List<double> transmissoesSucesso = new List<double>();
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
                Estacao estacao = new Estacao(i, ExponentialDistribution.Random(0.05), 0, 0);
                slot.estacoes.Add(estacao);

            }


            //iterando os slots

            for (int k = 0; k < 10000; k++)
            {



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


                //para a questão 2
                if (estacoesProntas.Count == 1)
                {
                    transmissoesSucesso.Add(Math.Abs(slot.tContador-estacoesProntas[0].tProximaChegada));
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
                            estacoesProntas[i].tProximaTransmissao = estacoesProntas[i].tProximaTransmissao + GeometricDistribution.Random(0.05);
                        }

                        //extra

                        for (int i = 0; i < slot.estacoes.Count; i++)
                        {
                            if (estacoesProntas.Where(x => x.id == slot.estacoes[i].id).FirstOrDefault() != null)
                            {

                                slot.estacoes[i] = estacoesProntas.Where(x => x.id == slot.estacoes[i].id).FirstOrDefault();

                            }
                        }


                        break;
                }



                slot.tContador += 1;
            }


            Console.WriteLine("Transmitidos: " + nSlotsTransmitidos + " Ociosos: " + nSlotsOciosos + " Colisões: " + nSlotsComColisao);
            int total = (nSlotsTransmitidos + nSlotsOciosos + nSlotsComColisao);
            double percentual = double.Parse(nSlotsTransmitidos.ToString()) / double.Parse(total.ToString());
            Console.WriteLine("\n Taxa de sucesso: " + percentual + " \n");
            Console.WriteLine("\n Média de espera: " + transmissoesSucesso.Average() + " \n");
            Console.WriteLine("\n Variância: " + Math.Pow(StandardDeviation(transmissoesSucesso),2)  + " \n");

            //Iterações



            //for (int i = 0; i < slot.nEstacoes; i++)
            //{
            //    Console.WriteLine(slot.estacoes[i].tProximaChegada);
            //}



        }

        public static double StandardDeviation(IEnumerable<double> values)
        {
            double standardDeviation = 0;

            if (values.Any())
            {
                // Compute the average.     
                double avg = values.Average();

                // Perform the Sum of (value-avg)_2_2.      
                double sum = values.Sum(d => Math.Pow(d - avg, 2));

                // Put it all together.      
                standardDeviation = Math.Sqrt((sum) / (values.Count() - 1));
            }

            return standardDeviation;
        }


    }


}
