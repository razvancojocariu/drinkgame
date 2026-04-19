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
        int count = 2; // This is just an example, you should get the actual player count
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