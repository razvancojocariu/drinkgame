using Microsoft.Maui.Controls.Internals;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace drinkgame.ViewModels;

[Preserve(AllMembers = true)]
public partial class PlayerNameInput : ObservableObject
{
    [ObservableProperty]
    private string name = string.Empty;
}

public partial class PlayerNamesViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<PlayerNameInput> playerNames;

    public PlayerNamesViewModel()
    {
        // Initialize the collection
        playerNames = new ObservableCollection<PlayerNameInput>();
        
        // Start with 2 default player name slots
        PlayerNames.Add(new PlayerNameInput());
        PlayerNames.Add(new PlayerNameInput());
    }

    [RelayCommand]
    public void AddPlayer()
    {
        PlayerNames.Add(new PlayerNameInput());
    }

    [RelayCommand]
    public void RemovePlayer(PlayerNameInput playerInput)
    {
        if (playerInput != null && PlayerNames.Contains(playerInput))
        {
            PlayerNames.Remove(playerInput);
        }
    }

    [RelayCommand]
    public async Task StartGame()
    {
        // Filter out empty names
        var validPlayers = PlayerNames
            .Where(p => !string.IsNullOrWhiteSpace(p.Name))
            .Select(p => p.Name)
            .ToList();

        if (validPlayers.Count < 2)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Validare", 
                "Te rog introdu cel puțin 2 nume de jucători", 
                "OK");
            return;
        }

        try
        {
            // Navigate to GamePage with player names using absolute routing
            string playerNamesString = string.Join(",", validPlayers);
            await Shell.Current.GoToAsync($"///GamePage?players={playerNamesString}");
        }
        catch (Exception ex)
        {
            // Display an error message if navigation fails
            await Application.Current.MainPage.DisplayAlert("Navigation Error", ex.ToString(), "OK");
        }
    }
}
