
namespace NewsLott.Servicios.Interfaces
{
    public interface IWebDriverWsppService
    {

        string VincularWsppPorQr();
        string VincularWsppPorNumero(string numeroCelular);
        string CerrarSesionWspp();

        
    }
}
