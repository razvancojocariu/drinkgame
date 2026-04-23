using Microsoft.Maui.Controls.Internals;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace drinkgame.Models
{
    internal class GameModels
    {
    }

    [Preserve(AllMembers = true)]
    public class Player
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("challengesCompleted")]
        public int ChallengesCompleted { get; set; }

        [JsonPropertyName("challengesSkipped")]
        public int ChallengesSkipped { get; set; }
    }

    [Preserve(AllMembers = true)]
    public class Challenge
    {
        public string Text { get; set; }
        public int Difficulty { get; set; }
    }
}
