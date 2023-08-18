using NewsLott.ServiciosSegundoPlano.Interfaces;

namespace NewsLott.ServiciosSegundoPlano.HostedService
{
    public class WsppChatHostedService : BackgroundService, IDisposable
    {


        private static bool interruptor = false;

        IServiceProvider _serviceProvider;
        public WsppChatHostedService(IServiceProvider provider)
        {
            this._serviceProvider = provider;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int contador = 0;
            while(!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(10));

                if (interruptor)
                {
                    contador++;
                    Console.WriteLine($"iteracion numero {contador} de servicio segundo plano WsspChat");
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var WsppChat = scope.ServiceProvider.GetRequiredService<IWsppChat>();

                        await WsppChat.ObtenerMsgNoLeido();
                    }
                }
                Console.WriteLine($"Interuptor en WsppChat en {interruptor}");
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {

            return base.StopAsync(cancellationToken);
        }

        /// <summary>
        /// Cambia el estado de la bandera condicional que permite crear el Scope para utilizar WsppChat en el BackgroundService.
        /// </summary>
        public static bool InterruptorWsppChatService()
        {
            interruptor = !interruptor;

            return interruptor;
        }

    }
}
