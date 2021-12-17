using System;

namespace WebSitesCheck
{
    class Program
    {
        private static bool valid = false;
        private static int sitesQuantity;
        
        static void Main(string[] args)
        {
            Console.WriteLine("Input sites quantity you would like to check: ");
            sitesQuantity = NumberInput();
            /*https://support.bunny.net/us
            https://google.com*/
            WebChecker webChecker = new WebChecker();
           
            webChecker.UrlCheck(webChecker.InputUrls(sitesQuantity));
            webChecker.ShowResults();

        }

        private static int NumberInput()
        {
            int quantity = 0;
            int number;
            int count = 0;
            while (!valid)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out number))
                {
                    valid = true;
                    quantity = number;
                }
                else
                {
                    count++;
                    if (count >= 4)
                    {
                       break;
                    }
                    Console.WriteLine("Please input a number: ");

                }
                
            }
            return quantity;
        }
    }
}
