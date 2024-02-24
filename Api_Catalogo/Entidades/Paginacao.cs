using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paginacao
    {

        const int tamanhoMaximoPg = 10;
        public int numeroPg { get; set; }
        private int _tamanhoPg;
        public int tamanhoPg
        {
            get
            {
                return _tamanhoPg;
            }
            set
            {
                _tamanhoPg = (value > tamanhoMaximoPg) ? tamanhoMaximoPg : value;
            }
        }
    }
}
