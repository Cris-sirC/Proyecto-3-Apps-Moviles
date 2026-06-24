using RegistroGastos.ViewModels;

namespace RegistroGastos.Views;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel _viewModel;

    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.CargarDatosAsync();
    }
}