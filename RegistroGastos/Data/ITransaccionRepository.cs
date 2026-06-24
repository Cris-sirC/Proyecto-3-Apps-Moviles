using RegistroGastos.Models;

namespace RegistroGastos.Data;

public interface ITransaccionRepository
{
    Task<List<Transaccion>> ObtenerTransaccionesAsync();
    Task<int> GuardarTransaccionAsync(Transaccion transaccion);
}