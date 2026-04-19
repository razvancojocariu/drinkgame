using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using drinkgame.Models;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Linq;
using System;

namespace drinkgame.ViewModels;

public partial class StatisticsViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<PlayerStatistic> rankedPlayers = new();

    [RelayCommand]
    public async Task PlayAgain()
    {
        await Shell.Current.GoToAsync("///MainPage");
    }

    [RelayCommand]
    public async Task Back()
    {
        await Shell.Current.GoToAsync("///MainPage");
    }

    public void LoadPlayers(string playersJson)
    {
        try
        {

            // Deserialize the JSON
            var players = JsonSerializer.Deserialize<List<Player>>(playersJson);

            if (players == null || players.Count == 0)
            {
                return;
            }


            // Create ranked list with badges
            var ranked = players
                .OrderByDescending(p => p.ChallengesCompleted)
                .ThenBy(p => p.ChallengesSkipped)
                .ToList();

            RankedPlayers.Clear();

            // Find the player with most completed challenges (Betivul)
            int maxCompleted = ranked.FirstOrDefault()?.ChallengesCompleted ?? 0;
            // Find the player with most skipped challenges (Fatălăul)
            int maxSkipped = players.Max(p => p.ChallengesSkipped);

            for (int i = 0; i < ranked.Count; i++)
            {
                var player = ranked[i];
                var stat = new PlayerStatistic
                {
                    Rank = i + 1,
                    Name = player.Name,
                    ChallengesCompleted = player.ChallengesCompleted,
                    ChallengesSkipped = player.ChallengesSkipped,
                    HasBadge = false,
                    Badge = "",
                    BadgeColor = "White"
                };

                // Assign badges
                if (player.ChallengesCompleted == maxCompleted && maxCompleted > 0)
                {
                    stat.HasBadge = true;
                    stat.Badge = "🍺 Betivul Serii, cumetre!";
                    stat.BadgeColor = "Gold";
                }
                else if (player.ChallengesSkipped == maxSkipped && maxSkipped > 0)
                {
                    stat.HasBadge = true;
                    stat.Badge = "😴 Fatălăul Serii!";
                    stat.BadgeColor = "#FF6B6B";
                }

                RankedPlayers.Add(stat);

            }

        }
        catch (Exception ex)
        {
        }
    }
}

public class PlayerStatistic
{
    public int Rank { get; set; }
    public string Name { get; set; }
    public int ChallengesCompleted { get; set; }
    public int ChallengesSkipped { get; set; }
    public bool HasBadge { get; set; }
    public string Badge { get; set; }
    public string BadgeColor { get; set; }
}
