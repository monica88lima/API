using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class Conversao
    {
        public static float CorrigirPreco(float preco)
        {
            string preco2 = Convert.ToString(preco);
            preco2.Replace(',', '.');
            return  preco = Convert.ToSingle(preco2);
        }
    }
}
