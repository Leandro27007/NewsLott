namespace NewsLott.DTOs
{
    public class CodigoEstadoDTO
    {
        public int StatusCode { get; set; }
        public string Mensaje { get; set; } = "Mensaje: ";
        public object? ObjRespuesta { get; set; }  = null;

    }
}
