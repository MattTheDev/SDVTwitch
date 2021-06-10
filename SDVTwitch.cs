using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MTD.SDVTwitch.Models;
using StardewModdingAPI;
using StardewValley;

namespace MTD.SDVTwitch
{
    public class SDVTwitch : Mod
    {
        internal static Config Config;
        private List<User> _followersAtStart = new List<User>();
        private TwitchClient _client;

        public override void Entry(IModHelper helper)
        {
            Config = (Config)helper.ReadJsonFile<Config>("config.json");
            _client = new TwitchClient(Config);
            _followersAtStart = _client.GetUsersByName(Config.TwitchName);
            new Thread(TwitchLoop).Start();
        }

        private void TwitchLoop()
        {
            while (true)
            {
                if (Context.IsWorldReady)
                {
                    foreach (var user1 in _client.GetUsersByName(Config.TwitchName))
                    {
                        var user = user1;
                        
                        if (_followersAtStart.FirstOrDefault(u => u.DisplayName == user.DisplayName) != null)
                        {
                            continue;
                        }

                        _followersAtStart.Add(user);

                        Game1.addHUDMessage(new HUDMessage($"New Follower: {user.DisplayName}!", 2));
                    }
                }
                Thread.Sleep(15000);
            }
        }
    }
}
