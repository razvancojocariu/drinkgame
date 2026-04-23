using drinkgame.ViewModels;
using drinkgame.Models;
using Microsoft.Maui.Controls;
using Plugin.Maui.Audio;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace drinkgame.Views;

[QueryProperty(nameof(PlayersString), "players")]
public partial class GamePage : ContentPage
{
    private GameViewModel ViewModel => BindingContext as GameViewModel;
    private readonly IAudioManager _audioManager;
    private IAudioPlayer _wheelPlayer;
    private string _playersString;

    public string PlayersString
    {
        get => _playersString;
        set
        {
            _playersString = value;
            OnPlayersStringSet();
        }
    }

    public GamePage(GameViewModel viewModel, IAudioManager audioManager)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _audioManager = audioManager;

        viewModel.SinfulWheelSpinRequested += async (index) => await AnimateWheel(index);

        viewModel.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == nameof(GameViewModel.IsGameFinished) && viewModel.IsGameFinished)
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await Task.Delay(1000);
                    await NavigateToStatistics(viewModel);
                });
            }
        };
    }

    private async void OnPlayersStringSet()
    {
        try
        {
            if (ViewModel == null || string.IsNullOrEmpty(_playersString))
                return;

            await Task.Delay(100);

            var playerList = _playersString
                .Split(',')
                .Select(n => Uri.UnescapeDataString(n.Trim()))
                .Where(n => !string.IsNullOrEmpty(n))
                .Select(n => new Player { Name = n })
                .ToList();

            ViewModel.SetPlayers(playerList);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Eroare", $"Nu s-a putut initializa jocul: {ex.Message}", "OK");
        }
    }

    private async Task AnimateWheel(int categoryIndex)
    {
        try
        {
            if (ViewModel == null) return;

            ViewModel.IsWheelVisible = true;
            TheWheel.Rotation = 0;

            await PlayWheelSound();

            var random = new Random();
            int fullRotations = random.Next(5, 9);
            int finalRotation = (fullRotations * 360) + (categoryIndex * 90);

            await TheWheel.RotateTo(finalRotation, 4000, Easing.CubicOut);

            StopWheelSound();

            await Task.Delay(500);

            ViewModel.SetChallengeFromWheel(categoryIndex);
        }
        catch (Exception)
        {
            if (ViewModel != null)
                ViewModel.IsWheelVisible = false;
        }
    }

    private async Task PlayWheelSound()
    {
        try
        {
            StopWheelSound();

            using var assetStream = await FileSystem.OpenAppPackageFileAsync("wheel_spin.mp3");
            var memoryStream = new MemoryStream();
            await assetStream.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            _wheelPlayer = _audioManager.CreatePlayer(memoryStream);
            _wheelPlayer.Play();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Audio error: {ex.Message}");
        }
    }

    private void StopWheelSound()
    {
        try
        {
            _wheelPlayer?.Stop();
            _wheelPlayer?.Dispose();
            _wheelPlayer = null;
        }
        catch { }
    }

    private async Task NavigateToStatistics(GameViewModel viewModel)
    {
        try
        {
            var playersJson = System.Text.Json.JsonSerializer.Serialize(viewModel.Players.ToList());
            await Shell.Current.GoToAsync($"///StatisticsPage?players={Uri.EscapeDataString(playersJson)}");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Eroare", ex.Message, "OK");
        }
    }
}
