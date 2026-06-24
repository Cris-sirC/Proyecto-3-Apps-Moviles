using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RegistroGastos.Models;
using RegistroGastos.Data;

namespace RegistroGastos.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly ITransaccionRepository _repo;

    [ObservableProperty]
    private decimal _balanceTotal;

    [ObservableProperty]
    private decimal _totalIngresos;

    [ObservableProperty]
    private decimal _totalGastos;

    public ObservableCollection<Transaccion> Transacciones { get; set; } = new();

    public MainViewModel(ITransaccionRepository repo)
    {
        _repo = repo;
    }

    public async Task CargarDatosAsync()
    {
        var lista = await _repo.ObtenerTransaccionesAsync();
        
        Transacciones.Clear();
        decimal ingresos = 0;
        decimal gastos = 0;

        foreach (var t in lista)
        {
            Transacciones.Add(t);
            if (t.EsIngreso) ingresos += t.Cantidad;
            else gastos += t.Cantidad;
        }

        TotalIngresos = ingresos;
        TotalGastos = gastos;
        BalanceTotal = ingresos - gastos;
    }

    [RelayCommand]
    private async Task IrANuevaTransaccion()
    {
        await Shell.Current.GoToAsync("NuevaTransaccionPage");
    }
}