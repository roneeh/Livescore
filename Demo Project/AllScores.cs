using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Demo_Project
{
    public class AllScores
    {
        [JsonProperty("home_name")]
        public string HomeName { get; set; }

        [JsonProperty("away_name")]
        public string AwayName { get; set; }

        public int Id { get; set; }
        public string Score { get; set; }
        public string Time { get; set; }
    }
}
