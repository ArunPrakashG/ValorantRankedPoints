using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static GetRankedPoints.Config;

namespace GetRankedPoints {
	public class Account {
		[JsonProperty]
		public string UserName { get; set; }

		[JsonProperty]
		public string Password { get; set; }

		[JsonProperty]
		public RegionalCode Code { get; set; }
	}

	public class Config {
		private const string CONFIG_FILE_NAME = "config.json";
		private static readonly string CONFIG_PATH;

		[JsonProperty]
		public List<Account> Accounts { get; set; }

		public Config() {

		}

		static Config() {
			CONFIG_PATH = Path.Combine(Assembly.GetEntryAssembly().Location, CONFIG_FILE_NAME);
		}

		public async Task<bool> LoadAsync() {
			if (!File.Exists(CONFIG_PATH)) {
				return false;
			}

			try {
				string json = await File.ReadAllTextAsync(CONFIG_PATH).ConfigureAwait(false);

				if (string.IsNullOrEmpty(json)) {
					return false;
				}

				Accounts = JsonConvert.DeserializeObject<List<Account>>(json) ?? new List<Account>();
				return Accounts.Count > 0;
			}
			catch(Exception e) {
				Console.WriteLine(e);
				return false;
			}			
		}

		public enum RegionalCode {
			NA,
			EU,
			AP,
			KO,
			BR
		}
	}
}
