using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Demo_Project
{
    public class FixtureScores
    {
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        [JsonProperty("home_name")]
        public string HomeName { get; set; }
        [JsonProperty("away_name")]
        public string AwayName { get; set; }
        public string Location { get; set; }
    }
}
