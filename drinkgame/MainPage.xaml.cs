using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace drinkgame.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Load background image directly from the app package, bypassing
        // Android's Resizetizer/drawable pipeline which silently fails on
        // certain PNG formats (AI-generated images, embedded ICC profiles, etc.).
        // FileSystem.OpenAppPackageFileAsync works identically on Android and Windows.
        _ = LoadBackgroundAsync();

        LogoLabel.Scale = 0.5;
        LogoLabel.Opacity = 0;

        await Task.WhenAll(
            LogoLabel.FadeTo(1, 800),
            LogoLabel.ScaleTo(1, 800, Easing.CubicOut)
        );
    }

    private async Task LoadBackgroundAsync()
    {
        try
        {
            using var fileStream = await FileSystem.OpenAppPackageFileAsync("bereaa.png");
            var ms = new MemoryStream();
            await fileStream.CopyToAsync(ms);
            ms.Position = 0;
            BgImage.Source = ImageSource.FromStream(() => ms);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[BG] Failed to load bereaa.png: {ex.Message}");
        }
    }

    private async void OnStartClicked(object sender, EventArgs e)
    {
        int count = 2;
        try
        {
            await Shell.Current.GoToAsync($"///PlayerNamesPage?playerCount={count}");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Navigation Error", ex.ToString(), "OK");
        }
    }
}
