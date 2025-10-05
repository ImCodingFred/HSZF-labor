using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSZF_labor
{
    internal class Basic
    {
        public delegate int DiscoutnCalculator(int price);
        int StudentDiscount(int price) => (int)(price * 0.8);
        int SeniorDiscount(int price) => (int)(price * 0.5);
        public Basic()
        {
            int OriginalPrice = 1000;
            DiscoutnCalculator sale;
            sale = StudentDiscount;
            sale += SeniorDiscount;
            //sale -= StudentDiscount;

            // úgy viselkedik, mint egy lista
            //foreach (DiscoutnCalculator item in sale.GetInvocationList())
            //{
            //    Console.WriteLine($"{OriginalPrice} => {item?.Invoke(OriginalPrice)}");
            //}
            PricePrinter(OriginalPrice, StudentDiscount);
        }
        void PricePrinter(int price, DiscoutnCalculator dc) 
        {
            Console.WriteLine($"Price {dc(price)}");
        }
    }
}
