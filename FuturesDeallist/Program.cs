using FuturesDeallist;
using System;
using System.Collections.Generic;

namespace Futures
{

    class Program
    {
        static void Main()
        {
            IList <ContractInfoFromDB> contractInfos = new ContractInfoFromDB[] {
            new ContractInfoFromDB(1234.56, "EuroStoxx",50 ,"EF20230402"),
            new ContractInfoFromDB(7890.12, "SnP",150 ,"EF20230403"),
            new ContractInfoFromDB(3456.78, "EuroStoxx",100 ,"EF20230404"),
            new ContractInfoFromDB(9012.34, "SnP",50 ,"EF2023040"),
        };
            
            MarketData marketData = new MarketData();
            marketData.EuroStoxx = 5243.25;
            marketData.SnP = 4171.75;
            marketData.Kospi = 2255;

            Utils util = new Utils();

            FuturesDealList dealList = new FuturesDealList(contractInfos);
            dealList.CalculatePL(marketData, util);
            dealList.PrintDealList();
        }
    }

    class MarketData
    {
        public double EuroStoxx { get; set; }
        public double SnP { get; set; }
        public double Kospi { get; set; }
    }

    
}