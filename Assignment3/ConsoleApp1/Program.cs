using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MIN_NUMBER_OF_PERIODS = 2;
            const int MAX_NUMBER_OF_PERIODS = 5;
            const int MIN_SALES_GROWTH = -10;
            const int MAX_SALES_GROWTH = 200;
            const int MIN_VARIABLE_COST = 5;
            const int MAX_VARIABLE_COST = 75;
            const int MIN_FIXED_COST = 500;
            const int MAX_FIXED_COST = 25000;

            decimal salesThisPeriods = 20000;
            decimal periodCost = 0;
            decimal periodProfit = 0;
            decimal totalCosts = 0;
            decimal totalsales = 0;
            decimal totalProfit = 0;




            int numberOfPeriods =
                 GetVaildNumber("Number of periods between 2 and 5: ",MIN_NUMBER_OF_PERIODS,MAX_NUMBER_OF_PERIODS);
            int SalesGrowth =
                GetVaildNumber("sales Growth Between -10 and 200: ", MIN_SALES_GROWTH,MAX_SALES_GROWTH);
            int variableCost =
                GetVaildNumber("Variable Cost Percentage Between 5 and 75: ",MIN_VARIABLE_COST,MAX_VARIABLE_COST );
            int FixedCosts =
                GetVaildNumber("Fixed Cost between 500 and 25,000 DollarsCOST: ", MIN_FIXED_COST, MAX_FIXED_COST);
            Console.WriteLine("\n{0,6}{1,12}{2,14}{3,19}",
                "Period","Sales","Cost","Profit");
            for (int i = 1; i <= numberOfPeriods; i++)
            {
                salesThisPeriods *= (SalesGrowth / 100m) + 1m;
                periodCost = (salesThisPeriods * variableCost /100m ) + FixedCosts;
                periodProfit = salesThisPeriods - periodCost;
                totalsales += salesThisPeriods;
                totalCosts += periodCost;
                totalProfit += periodProfit;
                Console.WriteLine("{0,6}{1,14:C}{2,15:C}{3,19:C}",i,salesThisPeriods, periodCost, periodProfit);
            }
            Console.WriteLine("{0,6}{1,14:C}{2,15:C}{3,19:C}", "Total" ,totalsales, totalCosts, totalProfit);
            Console.ReadLine();
        }
        static int GetVaildNumber(string Prompt, int Min, int Max)
        {
            bool isVailNumber;
            int vailNumber;

            do
            {
                Console.Write(Prompt);
                isVailNumber = int.TryParse(Console.ReadLine(), out vailNumber)
                    && vailNumber >= Min && vailNumber <= Max; 
            } while (!isVailNumber);
            return vailNumber;
        }
    }
}
