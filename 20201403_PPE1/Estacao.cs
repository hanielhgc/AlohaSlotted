using System;
using System.Collections.Generic;
using System.Text;

namespace _20201403_PPE1
{
    public class Estacao
    {
        public virtual int id { get; set; }
        public virtual double tProximaChegada { get; set; }
        public virtual int nNaFila { get; set; }
        public virtual double tProximaTransmissao { get; set; }

        public Estacao(int id, double tProximaChegada, int nNaFila, double tProximaTransmissao)
        {
            this.id = id;
            this.tProximaChegada = tProximaChegada;
            this.nNaFila = nNaFila;
            this.tProximaTransmissao = tProximaTransmissao;

        }

    }
}
