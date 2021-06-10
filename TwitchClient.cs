using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using MTD.SDVTwitch.Models;
using Newtonsoft.Json;

namespace MTD.SDVTwitch
{
    public class TwitchClient
    {
        internal static Config Config;

        public TwitchClient(Config config) => Config = config;

        public List<User> GetUsersByName(string name)
        {
            return GetFollowersByName(name).Follows.Select(follow => follow.User).ToList();
        }

        public FollowerResponse GetFollowersByName(string name)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.twitch.tv/kraken/channels/" + name + "/follows");
            httpWebRequest.Headers["Client-Id"] = Config.ClientId;

            var response = httpWebRequest.GetResponse();
            string str;

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                str = streamReader.ReadToEnd();
            }
            
            return JsonConvert.DeserializeObject<FollowerResponse>(str);
        }
    }
}