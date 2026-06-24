using SQLite;
using Microsoft.Maui.Graphics;

namespace RegistroGastos.Models;

[Table("Transacciones")] 
public class Transaccion
{
    [PrimaryKey, AutoIncrement] 
    public int Id { get; set; }
    
    public string Glosa { get; set; } = string.Empty;
    
    public decimal Cantidad { get; set; }
    
    public DateTime Fecha { get; set; } = DateTime.Now;
    
    public bool EsIngreso { get; set; }

    [Ignore]
    public string MontoFormateado => EsIngreso ? $"+ ${Cantidad:N2}" : $"- ${Cantidad:N2}";

    [Ignore]
    public Color ColorMonto => EsIngreso ? Colors.Green : Colors.Red;
}