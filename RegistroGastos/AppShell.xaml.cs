namespace RegistroGastos;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        // Rutas de navegación
        Routing.RegisterRoute("NuevaTransaccionPage", typeof(Views.NuevaTransaccionPage));
    }
}