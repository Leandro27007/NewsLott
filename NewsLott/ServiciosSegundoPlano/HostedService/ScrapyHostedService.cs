using NewsLott.ServiciosSegundoPlano.Interfaces;

namespace NewsLott.ServiciosSegundoPlano.HostedService
{
    public class ScrapyHostedService : BackgroundService, IDisposable
    {
        private IServiceProvider _serviceProvider;
        public ScrapyHostedService(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var resultadoWebScrapy = scope.ServiceProvider.GetRequiredService<IScraper>();

                    await resultadoWebScrapy.RasparWeb();
                }
                await Task.Delay(new TimeSpan(0, 3, 0));
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Se paro el servicio en segundo plano, Queloque?");

            return base.StopAsync(cancellationToken);
        }


    }
}
