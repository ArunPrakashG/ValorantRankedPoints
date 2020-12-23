using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetRankedPoints.Models {
	public class MatchResponse {
		[JsonProperty]
		public int Version { get; set; }

		[JsonProperty]
		public string Subject { get; set; }

		[JsonProperty]
		public Match[] Matches { get; set; }
	}

	public class Match {
		[JsonProperty]
		public string MatchID { get; set; }

		[JsonProperty]
		public string MapID { get; set; }

		[JsonProperty]
		public long MatchStartTime { get; set; }

		[JsonProperty]
		public int TierAfterUpdate { get; set; }

		[JsonProperty]
		public int TierBeforeUpdate { get; set; }

		[JsonProperty]
		public int TierProgressAfterUpdate { get; set; }

		[JsonProperty]
		public int TierProgressBeforeUpdate { get; set; }

		[JsonProperty]
		public int RankedRatingEarned { get; set; }

		[JsonProperty]
		public string CompetitiveMovement { get; set; }
	}
}
