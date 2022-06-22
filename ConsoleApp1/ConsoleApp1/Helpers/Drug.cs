using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Helpers
{
    class Drug
    {
        public int Id { get; }
        public static int _id;
        public string Name { get; set; }
        public int Count { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public DrugType DrugType { get; set; }
        public Drug()
        {

        }
        public Drug(string name,int count,double purchaseprice,double saleprice,DrugType drugtype):this()
        {
            Id = ++_id;
            Name = name;
            Count = count;
            PurchasePrice = purchaseprice;
            SalePrice = saleprice;
            DrugType = drugtype;
        }
    }
    enum DrugType
    {
        SYROB,
        POWDER,
        TABLET
    }
}
