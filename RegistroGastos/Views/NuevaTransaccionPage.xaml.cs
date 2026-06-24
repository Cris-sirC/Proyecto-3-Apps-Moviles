using RegistroGastos.ViewModels;

namespace RegistroGastos.Views;

public partial class NuevaTransaccionPage : ContentPage
{
    public NuevaTransaccionPage(NuevaTransaccionViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}