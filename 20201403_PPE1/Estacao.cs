using System;
using System.Collections.Generic;
using System.Text;

namespace _20201403_PPE1
{
    public class Estacao
    {
        public virtual int tProximaChegada { get; set; }
        public virtual int nNaFila { get; set; }
        public virtual int tProximaTransmissao { get; set; }

        public Estacao(int tProximaChegada, int nNaFila, int tProximaTransmissao)
        {
            this.tProximaChegada = tProximaChegada;
            this.nNaFila = nNaFila;
            this.tProximaTransmissao = tProximaTransmissao;

        }

    }
}
