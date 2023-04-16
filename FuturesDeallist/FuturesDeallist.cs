using FuturesDeallist;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Futures
{
    class FuturesDealList:IEnumerable<FuturesDeal>
    {
        public readonly IList<FuturesDeal> deals; //private보다 좋은건가?

        public FuturesDealList(IList<ContractInfoFromDB> contractInfos)
        {
            deals = new List<FuturesDeal>();

            foreach (ContractInfoFromDB info in contractInfos)
            {
                FuturesDeal deal = new FuturesDeal(info.InitialPrice, info.ProductType, info.NumOfContract, info.DealCode);
                deals.Add(deal);//IList라서 선언이 가능
            }
        }

        public IEnumerator<FuturesDeal> GetEnumerator()
        {
            return deals.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return deals.GetEnumerator();
        }

        public void PrintDealList()
        {
            Console.WriteLine("Futures Deal List:");
            Console.WriteLine("------------------");

            foreach (FuturesDeal deal in deals)
            {
                Console.WriteLine("Deal Code: {0}", deal.DealCode);
                Console.WriteLine("Product Type: {0}", deal.ProductType);
                Console.WriteLine("ExternalValue: {0:C}", deal.CalulatedPL);
                Console.WriteLine();
            }
        }

        public void CalculatePL(MarketData market, Utils util)
        {   

            foreach(FuturesDeal deal in deals)
            {   
                var marketDataProperty = typeof(MarketData).GetProperty(deal.ProductType, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);//리플렉션 사용
                var marketDataValue = marketDataProperty.GetValue(market);//object 형식으로 반환
                double marketData=Convert.ToDouble(marketDataValue);

                var multiples=util.MyReadOnlyDictionary[deal.ProductType];
                deal.CalulatedPL = (marketData - deal.InitialPrice) * (deal.NumOfContract)*(multiples);
            }
        }
    }

    class FuturesDeal//contract 정보 들고있는 클래스 -> 나중에 futuresDeals에서 list로 들고있음
    {
        public double InitialPrice { get;}
        public string ProductType { get;}
        public double NumOfContract { get; }
        public string DealCode { get; }
        public double CalulatedPL { get; set; }

        public FuturesDeal(double initialPrice, string productType, double numOfContract, string dealCode)
        {
            InitialPrice = initialPrice;
            ProductType = productType;
            NumOfContract = numOfContract;
            DealCode = dealCode;
        }
    }

    class ContractInfoFromDB
    {
        public double InitialPrice { get; }
        public string ProductType { get; }
        public double NumOfContract { get; }
        public string DealCode { get; }

        public ContractInfoFromDB(double initialPrice, string productType, double numOfContract, string dealCode)
        {
            InitialPrice = initialPrice;
            ProductType = productType;
            NumOfContract = numOfContract;
            DealCode = dealCode;
        }
    }

    
}

    //필요한 deallist 정보

