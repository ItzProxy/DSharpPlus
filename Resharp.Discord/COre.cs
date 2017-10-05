using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;
using Newtonsoft.Json;

namespace Resharp.Discord
{
    public class Core
    {
        public DiscordClient Client { get; set; }

        public static void Main(string[] args)
            => new Core();


       /*
        * Run a console that runs the bot asyncronously
        * Reads configuration file to 
        */
        public async Task RunBotAsync()
        {
            //read the configuration settings
            var json = "";
            using(var fs = File.OpenRead("config.json"))
            {
                using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                {
                    json = await sr.ReadToEndAsync();
                }
            }

            var cfgjson = JsonConvert.DeserializeObject<ConfigJson>(json);

        }

        public struct ConfigJson
        {
            [JsonProperty("Token")]
            public string Token { get; private set; }
            
            [JsonProperty("prefix")]
            public string CommandPrefix { get; private set; }
        }
    }
}
