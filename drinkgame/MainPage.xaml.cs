using System;
using Microsoft.Maui.Controls;

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

        LogoLabel.Scale = 0.5;
        LogoLabel.Opacity = 0;

        await Task.WhenAll(
            LogoLabel.FadeTo(1, 800),
            LogoLabel.ScaleTo(1, 800, Easing.CubicOut)
        );
    }

    private async void OnStartClicked(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync("///PlayerNamesPage");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Eroare navigare", ex.ToString(), "OK");
        }
    }
}
