﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace MTD.SDVTwitch.Models
{
    public class FollowerResponse
    {
        [JsonProperty("_total")]
        public int Total { get; set; }

        [JsonProperty("follows")]
        public List<Follow> Follows { get; set; }
    }
}