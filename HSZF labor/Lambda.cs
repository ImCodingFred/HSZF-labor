using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSZF_labor
{
    internal class Lambda
    {
        //int _ (int x) 
        //{
        //    return (int)(x * 0.8);
        //}
        public Lambda()
        {
            PricePrinter(1000, x => (int)(x * 0.8));
            MassPricePrinter(100, 80, 150, (x, y, z) => (int)(x * 0.8 +y*0.5+z*0.3));
        }
        void PricePrinter(int price, Func<int, int> dc)
        {
            Console.WriteLine($"Price {dc?.Invoke(price)}");
        }
        void MassPricePrinter(int price1, int price2,int price3, Func<int, int,int,int> dc)
        {
            Console.WriteLine($"Price {dc?.Invoke(price1,price2,price3)}");
        }

    }
}
