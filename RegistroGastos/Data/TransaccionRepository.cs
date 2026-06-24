using SQLite;
using RegistroGastos.Models;

namespace RegistroGastos.Data;

public class TransaccionRepository : ITransaccionRepository 
{
    private readonly SQLiteAsyncConnection _connection; 

    public TransaccionRepository(string databaseName = "gastos.db3")
    {
        string folderPath = FileSystem.Current.AppDataDirectory;
        string dbPath = Path.Combine(folderPath, databaseName);

        if (!Directory.Exists(folderPath)) 
        {
            Directory.CreateDirectory(folderPath);
        }

        _connection = new SQLiteAsyncConnection(dbPath);
        _connection.CreateTableAsync<Transaccion>().Wait();
    }

    public async Task<List<Transaccion>> ObtenerTransaccionesAsync()
    {
        return await _connection.Table<Transaccion>().OrderByDescending(t => t.Fecha).ToListAsync();
    }

    public async Task<int> GuardarTransaccionAsync(Transaccion transaccion)
    {
        return await _connection.InsertAsync(transaccion);
    }
}