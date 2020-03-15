using System;
using System.Collections.Generic;
using System.Text;

namespace _20201403_PPE1
{
    public class Slot
    {
        public virtual List<Estacao> estacoes { get; set; }
        public virtual int tContador { get; set; }
        public virtual int nEstacoes { get; set; }

    }
}
