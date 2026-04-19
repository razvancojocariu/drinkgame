using drinkgame.ViewModels;
using Microsoft.Maui.Controls;

namespace drinkgame.Views;

public partial class PlayerNamesPage : ContentPage
{
    public PlayerNamesPage(PlayerNamesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
