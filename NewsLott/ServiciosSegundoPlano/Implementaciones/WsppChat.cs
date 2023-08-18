using Microsoft.EntityFrameworkCore;
using NewsLott.Constantes;
using NewsLott.DAL.Repositorio.Interfaces;
using NewsLott.Entidades;
using NewsLott.ServiciosSegundoPlano.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Linq.Expressions;
using utilidades;

namespace NewsLott.ServiciosSegundoPlano.Implementaciones
{
    public class WsppChat : IWsppChat
    {
        private WebDriver _navegador;
        private WebDriverWait wait1Minute;
        private WebDriverWait wait1Second;
        private Func<By, Func<IWebDriver, IWebElement>> ExisteElemento;


        private readonly IResultadoLoteriaRepositorio _resultadoLoteriaRepositorio;

        public WsppChat(INavegador navegador, IResultadoLoteriaRepositorio resultadoLoteriaRepositorio)
        {

            this._resultadoLoteriaRepositorio = resultadoLoteriaRepositorio;

            this._navegador = navegador.ObtenerDriver();
            ExisteElemento = SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists;
            wait1Minute = new WebDriverWait(_navegador, TimeSpan.FromMinutes(1));
            wait1Second = new WebDriverWait(_navegador, TimeSpan.FromSeconds(1));
        }
        public Task ObtenerMsgNoLeido()
        {

            Task tarea = Task.Run(async () =>
            {


                try
                {
                    //Buscara el elemento durante 1 Minuto hasta encontrarlo. Si encuentra el elemento antes del minuto seguira el flujo. Si el elemento es encontrado/existe lo amacenara en la varible de lo contrario lo dejara null.
                    var contadorNuevoMensaje = wait1Minute.Until(ExisteElemento(By.ClassName(ElementosHtml.classContadorNuevoMensaje)));

                    if (contadorNuevoMensaje != null)
                    {

                        //Al hacer este click abrira el chat, ya que el contador de mensajes se coloca encima de los chats.
                        contadorNuevoMensaje.Click();
                        //Espero de 0 a 1 segundo buscando el elemento para seleccionarlo.
                        ////wait1Second.Until(ExisteElemento(By.XPath(ElementosHtml.xPathMensajeRecibido)));
                        string? mensajesRecibido = _navegador.FindElements(By.XPath(ElementosHtml.xPathMensajeRecibido)).Select(d => d.Text).LastOrDefault();


                        //Si encuentro el elemento y pasa de 50 caracteres, seleccione el minimo que son 50 caracteres y procedo a responder el mensaje..
                        if (mensajesRecibido != null)
                        {
                            mensajesRecibido = mensajesRecibido.Substring(0, Math.Min(50, mensajesRecibido.Length));
                            contadorNuevoMensaje = null;
                            await Responder(mensajesRecibido);
                        }
                        else
                        {
                            contadorNuevoMensaje.SendKeys(Keys.Escape);
                        }

                    }

                }
                catch (Exception ex)
                {

                    Actions accion = new Actions(_navegador);
                    accion.SendKeys(Keys.Escape);
                    Console.WriteLine("Error: " + ex.Message);
                }

            });

            tarea.Wait();

            return tarea;
        }


        private async Task<bool> Responder(string mensajeRecibido)
        {


            string ctrlEnter = Keys.Control + Keys.Enter + Keys.Control;

            string mensajesParaEnviar = "Este contacto es para obtener los numeros de las loterias dominicanas" + ctrlEnter +
                                        "```Si quieres ver cuales salieron en *La Real* Escribe:``` *9* o *real* \n" +

                                        "------Menu desde C#-----" + ctrlEnter +
                                        "═══════════════" + ctrlEnter +
                                        " *1* - ```Gana Mas```" + ctrlEnter +
                                        " *2* - ```La Primera```" + ctrlEnter +
                                        " *3* - ```La Primera-Noche```" + ctrlEnter +
                                        " *4* - ```Loteria Nacional```" + ctrlEnter +
                                        " *5* - ```New-York Tarde```" + ctrlEnter +
                                        " *6* - ```Pega 3 Mas```" + ctrlEnter +
                                        " *7* - ```Quiniela La Suerte```" + ctrlEnter +
                                        " *8* - ```Quiniela Loteka```" + ctrlEnter +
                                        " *9* - ```Quiniela Real```" + ctrlEnter +
                                        "═══════════════" + ctrlEnter +
                                        "*Escriba el numero de la opcion*";

            try
            {
                //declaro una variable para obtener una expresion lambda con la cual buscare data en la base de datos. ej: (d => d.id == "id")
                Expression<Func<ResultadoDeLoteria, bool>>? exprecionResultadoQuiniela;
                exprecionResultadoQuiniela = Constantes.Diccionario.ObtenerExprecionDesdeElDiccionario(mensajeRecibido);

                if (exprecionResultadoQuiniela != null)
                {
                    IQueryable<ResultadoDeLoteria> consulta = await _resultadoLoteriaRepositorio.Consultar(exprecionResultadoQuiniela);
                    var resultado = await consulta.OrderByDescending(r => r.FechaResultado).Include(l => l.Loteria).FirstOrDefaultAsync();

                    //Si tengo data en resultado entonces sobreescribo el mensaje que enviare al cliente de wspp.
                    if (resultado != null)
                    {
                        string listaNumerosPremiados = Utils.OrganizarNumeros(resultado.NumerosPremiados).Trim();

                        mensajesParaEnviar = "--------Mensaje desde C#--------" + ctrlEnter +
                                            $"Loteria: {resultado.Loteria.NombreLoteria}" + ctrlEnter +
                                            $"Numeros: *{listaNumerosPremiados}*" + ctrlEnter +
                                            //$"Segunda: *{stringProcesadoPrimera}*" + ctrlEnter +
                                            //$"Tercera: *{stringProcesadoTercera}*" + ctrlEnter +
                                            $"---------------------------------" + ctrlEnter +
                                            $"Fecha: {resultado.FechaResultado}" + ctrlEnter +
                                            "---------------------------------";
                    }
                }


                var cajaTextoMensaje = _navegador.FindElement(By.CssSelector(ElementosHtml.cssCajaDeTextoChat))/*.SendKeys(mensajeConstruido)*/;
                cajaTextoMensaje.SendKeys(mensajesParaEnviar);


                var btnEnviarMensaje = _navegador.FindElement(By.ClassName(ElementosHtml.classBtnEnviarMensaje));
                btnEnviarMensaje.Click();

                //envio un teclaso al boton Escape para salir del chat.

                while (wait1Second.Until(ExisteElemento(By.CssSelector(ElementosHtml.cssCajaDeTextoChat))) != null)
                {
                    Console.WriteLine("Precionando Scape para salir del chat");
                    cajaTextoMensaje.SendKeys(Keys.Escape);
                }


                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine("OCURRIO UN ERROR: " + ex.Message);

                Actions accion = new Actions(_navegador);
                accion.SendKeys(Keys.Escape);

                return false;
            }

        }



    }
}
