namespace NewsLott.Constantes
{
    public static class ElementosHtml
    {
        //Cada elemento tendra su ubicacion para un acceso preciso: ( div.Clase1 Div.Clase2 <a )

        //RUTA DE ELEMENTOS ?HTML

        public const string cssBotonVincularPorNumero = "div._2rQUO > span";
        public const string xPathInputNumeroVincular = "/html/body/div[1]/div/div/div[3]/div[1]/div/div[3]/div[2]/div/div/div/form/input";
        public const string classBntVincular = "_3QJHf";
        public const string cssCodigoConfirmacion = "div.ovutvysd > span";


        public const string cssCajaDeTextoChat = "div._3Uu1_ div.g0rxnol2 div.to2l77zo";
        public const string cssCajaDeTextoBuscar = "div._2vDPL div.g0rxnol2 div.to2l77zo";
        public const string classBtnEnviarMensaje = "epia9gcq";


        public const string classBtnCerrar = "_1MZM5";
        public const string classBtnConfirmarCerrar = "szmswy5k";

        // botones del menu _1MZM5   //El ultimo es de cerrar session
        // Confirmar cerrar class  = szmswy5k


        const string classListaChat = "_3YS_f";
        public const string classContadorNuevoMensaje = "_2H6nH";
        public const string xPathMensajeRecibido = "//div[@class='message-in focusable-list-item _1AOLJ _2UtSC _1jHIY']//span[@class=\"_11JPr selectable-text copyable-text\"]/span";
        public const string xPathMensajeEnviado = "//div[@class='message-out focusable-list-item _1AOLJ _2UtSC _1jHIY']//span[@class=\"_11JPr selectable-text copyable-text\"]/span";
        const string mensaje = "f";


        const string numeroCliente = "s";
        const string notaDeVoz = "s";
        const string emoji = "s";

        const string numerosQuiniela = "div.data div.c";
        public const string fechaResultado = "span.tag";



        public static Dictionary<string, string> elementosDeWebConectate = new Dictionary<string, string>() 
        {
            { "clave", "valor" },


        };


    }
}
