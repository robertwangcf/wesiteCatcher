using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace websiteCatcher
{
    class Program
    {

        static void Main(string[] args)
        {

            
            GetActivityIdFromPrime();
            Console.ReadKey();
        }

        private static string GetActivityIdFromPrime()
        {
            WebRequest request = WebRequest.Create("http://www.msn.com/");
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
           // Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            string sPattern = "activityId=\\w{32}";
            var match = Regex.Match(responseFromServer, sPattern);

            if (match.Success)
            {
                Console.WriteLine(match.Value);
                return match.Value;
            }

            //Console.WriteLine(responseFromServer);
            Console.WriteLine("The length is {0}", responseFromServer.Length);
            Console.WriteLine("Nothing found!");
            reader.Close();
            response.Close();
            
            return "";
        }
    }
}
