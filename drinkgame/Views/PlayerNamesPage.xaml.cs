using drinkgame.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace drinkgame.Views;

public partial class PlayerNamesPage : ContentPage
{
    public PlayerNamesPage(PlayerNamesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = LoadBackgroundAsync();
    }

    private async Task LoadBackgroundAsync()
    {
        try
        {
            using var fileStream = await FileSystem.OpenAppPackageFileAsync("raccoon_party.png");
            var ms = new MemoryStream();
            await fileStream.CopyToAsync(ms);
            ms.Position = 0;
            BgImage.Source = ImageSource.FromStream(() => ms);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[BG] Failed to load raccoon_party.png: {ex.Message}");
        }
    }
}
