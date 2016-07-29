using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace LCBO_Scraper
{
    class Program
    {
        static int pageNum = 1;
        static int pageLimit = 999999;
        static List<Page> pages = new List<Page>();
        static List<Result> products = new List<Result>();

        static public double getMlPerDollar(Result r)
        {
            double ml = r.volume_in_milliliters/1000;
            double per = r.alcohol_content / 100;
            double price = r.price_in_cents / 100;

            return (ml * per) / price;
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to LCBO Scrapper!");

            var wc = new WebClient();
            try
            {
                while (pageNum < pageLimit)
                {
                    var url = ("https://lcboapi.com/products?page=" + pageNum + "&access_key=MDpmZDNhMGM5Yy0yOGZmLTExZTYtYTdmNS03Nzk2ZTY1MTg4Y2U6TVZtTzFFdUpPZFhUaDNJYnV0Q1E2NmlxdUtTVk5WUWFsUjlO");
                    string downloadedData = wc.DownloadString(url);

                    try
                    {
                        Page currentPage = Newtonsoft.Json.JsonConvert.DeserializeObject<Page>(downloadedData);
                        if (pageNum == 1)
                        {
                            pageLimit = currentPage.pager.total_pages;
                        }

                        for (int i = 0; i < currentPage.result.Length; i++)
                        {
                            Console.WriteLine("Name: " + currentPage.result[i].name + " - " + getMlPerDollar(currentPage.result[i]));
                            products.Add(currentPage.result[i]);
                        }
                    }
                    catch(Exception e) { }
                    pageNum++;
                }
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }

            Console.WriteLine("Number of products: " + products.Count);

            StreamWriter writer = new StreamWriter("file.csv");

            for(int i = 0; i < products.Count; i++)
            {
                writer.WriteLine(products[i].name + ";" + getMlPerDollar(products[i]) + "ml");
            }

            Result bestProduct = products[0];
            for(int i = 1; i < products.Count; i++)
            {
                Result curResult = products[i];

                if(getMlPerDollar(curResult) > getMlPerDollar(bestProduct))
                {
                    if (curResult.is_dead) continue;
                    if (curResult.is_discontinued) continue;
                    if (curResult.price_per_liter_of_alcohol_in_cents < 10) continue;
                    if (curResult.varietal == "Fortified Wine") continue;
                    if (curResult.varietal == "Aperitif Wine") continue;

                    bestProduct = curResult;
                }
            }

            Console.WriteLine("Name: " + bestProduct.name + " Percentage: " + bestProduct.alcohol_content / 100 + " Price: " + bestProduct.regular_price_in_cents / 100);

            Console.WriteLine("Press enter to close");
            Console.ReadLine();

        }
    }
}