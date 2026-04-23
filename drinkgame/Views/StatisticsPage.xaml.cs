using drinkgame.ViewModels;
using drinkgame.Models;
using System.Collections.ObjectModel;
using System.Text.Json;
using Microsoft.Maui.Controls;

namespace drinkgame.Views;

[QueryProperty(nameof(PlayersJson), "players")]
public partial class StatisticsPage : ContentPage
{
    private string _playersJson;

    public string PlayersJson
    {
        get => _playersJson;
        set
        {
            _playersJson = value;
            OnPlayersJsonSet();
        }
    }

    public StatisticsPage(StatisticsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnPlayersJsonSet()
    {
        if (BindingContext is StatisticsViewModel viewModel && !string.IsNullOrEmpty(_playersJson))
        {
            try
            {
                viewModel.LoadPlayers(Uri.UnescapeDataString(_playersJson));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"StatisticsPage.OnPlayersJsonSet error: {ex.Message}");
            }
        }
    }
}
