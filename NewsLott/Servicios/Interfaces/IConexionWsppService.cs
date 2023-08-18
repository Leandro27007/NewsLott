namespace NewsLott.Servicios.Interfaces
{
    public interface IConexionWsppService
    {
        Task<object> VincularDispositivo(); 
        Task<bool> EstaVinculado();
        Task<bool> Desvincular();

    }
}
