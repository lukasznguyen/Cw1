using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //int tmp1 = 1;
            //int? tmp11 = null; //moze byc nullem
            //double tmp2 = 2.0;

            //string tmp3 = "aaa";
            //string tmp33 = "bbb";
            //bool tmp4 = true;

            //var tmp5 = 1;
            //var tmp7 = 2;

            //var path = $@"C:\Users\s18964\Desktop\Cw1";
            //Console.WriteLine($"{tmp3} {tmp33} {tmp5 + tmp7}");

            //var newPerson = new Person { FirstName = "Lukasz"};

            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            //var httpClient = new HttpClient();

            //httpClient.Dispose();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    //2xx

                    if (response.IsSuccessStatusCode)
                    {
                        var htmlContent = await response.Content.ReadAsStringAsync();

                        var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                        var matches = regex.Matches(htmlContent);

                        foreach (var match in matches)
                        {
                            Console.WriteLine(match.ToString());
                        }
                    }
                }
                
            }

           

        }
    }
}
