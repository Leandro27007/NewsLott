namespace NewsLott.DTOs
{
    public class ChatDTO
    {
        public string IdMensaje { get; set; } //los 10 primeros caracteres del mensaje + la hora y fecha de envio.
        public string Mensaje { get; set; }
        public int Respondido { get; set; }
    }
}
