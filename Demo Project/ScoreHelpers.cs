using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

/*
 * Create an API client that uses livescore-api.com services. Your client must be able to do the following things
 * 1.   Show all the livescores
 * 2.   Show all the livescores for a particular country. The country of choice doesn't matter.
 * 3.   Show fixtures for tomorrow.
 *
 * You can use the following API key and secret:
 *
 * Key: 6r94GgdPiJ5ciqdx
 * Secret: 70Qx0KjZN2uD6jfdLohrFuhXem9wNm4U
 *
 */


namespace Demo_Project
{
    public class ScoreHelpers
    {
        static string demo_key = "6r94GgdPiJ5ciqdx";
        static string demo_secret = "70Qx0KjZN2uD6jfdLohrFuhXem9wNm4U";

        public static List<T> ShowResultsList<T>(string dir, string dotJson, string dataName, string longerUrl)
        {
            var json = new WebClient().DownloadString(
                longerUrl ??
                $"http://livescore-api.com/api-client/{dir}/{dotJson}.json?key={demo_key}&secret={demo_secret}");

            JObject obj = JObject.Parse(json);

            IList<JToken> results = obj["data"][dataName].Children().ToList();
            List<T> myList = new List<T>();

            foreach (JToken result in results)
            {
                T myObject = result.ToObject<T>();
                myList.Add(myObject);
            }

            return myList;
        }

        public static void ShowResults(List<AllScores> allScoresList)
        {
            int count = 0;
            foreach (var item in allScoresList)
            {
                Console.WriteLine($"ID: {item.Id}");
                Console.WriteLine($"{item.HomeName} vs. {item.AwayName}");
                Console.WriteLine($"Score: {item.Score}");
                Console.WriteLine($"Time played: {item.Time}");
                if (count != allScoresList.Count - 1)
                {
                    Console.WriteLine();
                }
                count++;
            }
        }

        public static void Country()
        {
            Console.WriteLine("Please write the name of the country you want listed.");
            string countryName = Console.ReadLine();
            ShowResults(ShowResultsList<CountryScores>("countries", "list", "country", null), countryName);
        }

        public static void ShowResults(List<CountryScores> countryScoresList, string countryName)
        {
            if (countryScoresList.Count(s => s.Name == countryName) == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Error: Country doesn't exist! Please try again.");
                Console.WriteLine();
                Country();
            }

            foreach (var item in countryScoresList.Where(s => s.Name == countryName))
            {
                Console.WriteLine($"ID: {item.Id}");
                Console.WriteLine($"Country: {item.Name}");
                Console.WriteLine("-------------------------------");
                ShowResults(ShowResultsList<AllScores>("scores", "live", "match",
                    $"http://livescore-api.com/api-client/scores/live.json?key={demo_key}&secret={demo_secret}&country={item.Id}"));
                Console.WriteLine("-------------------------------");
            }
        }

        public static void ShowResults(List<FixtureScores> fixtureScoresList)
        {
            foreach (var item in fixtureScoresList)
            {
                Console.WriteLine($"Date: {item.Date:dd/MM/yyyy} {item.Time:t}");
                Console.WriteLine($"{item.HomeName} vs. {item.AwayName}");
                Console.WriteLine($"Played at: {item.Location}");
                Console.WriteLine();
            }
        }
    }
}