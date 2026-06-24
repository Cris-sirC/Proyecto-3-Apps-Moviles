using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RegistroGastos.Models;
using RegistroGastos.Data;

namespace RegistroGastos.ViewModels;

public partial class NuevaTransaccionViewModel : ObservableObject
{
    private readonly ITransaccionRepository _repo;

    [ObservableProperty]
    private string _glosa = string.Empty;

    [ObservableProperty]
    private decimal _cantidad;

    [ObservableProperty]
    private DateTime _fecha = DateTime.Now;

    [ObservableProperty]
    private bool _esIngreso;

    public NuevaTransaccionViewModel(ITransaccionRepository repo)
    {
        _repo = repo;
    }

    [RelayCommand]
    private async Task Guardar()
    {
        if (string.IsNullOrWhiteSpace(Glosa) || Cantidad <= 0)
            return;

        var nuevaTransaccion = new Transaccion
        {
            Glosa = Glosa,
            Cantidad = Cantidad,
            Fecha = Fecha,
            EsIngreso = EsIngreso
        };

        await _repo.GuardarTransaccionAsync(nuevaTransaccion);
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task Cancelar()
    {
        await Shell.Current.GoToAsync("..");
    }
}