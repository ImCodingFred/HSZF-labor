using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSZF_labor
{
    internal class FuncActionPredicate
    {
        public delegate int DiscoutnCalculator(int price);
        int StudentDiscount(int price) => (int)(price * 0.8);
        int SeniorDiscount(int price) => (int)(price * 0.5);
        public FuncActionPredicate()
        {
            int OriginalPrice = 1000;
            DiscoutnCalculator sale;
            Func<int, int> sale2;
            sale = StudentDiscount;
            sale += SeniorDiscount;
            sale2 = StudentDiscount;
            sale2 += SeniorDiscount;
            foreach (Func<int,int> item in sale2.GetInvocationList())
            {
                Console.WriteLine($"{OriginalPrice} => {item?.Invoke(OriginalPrice)}");
            }
            PricePrinter(OriginalPrice, StudentDiscount);
        }
        void PricePrinter(int price, Func<int, int> dc)
        {
            Console.WriteLine($"Price {dc(price)}");
        }
    }
}
