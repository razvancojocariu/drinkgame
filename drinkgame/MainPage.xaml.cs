using System;
using Microsoft.Maui.Controls;

namespace drinkgame.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Animation disabled for debugging black screen
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
