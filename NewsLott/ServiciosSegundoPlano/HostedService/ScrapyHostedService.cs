using Microsoft.EntityFrameworkCore;
using NewsLott.Datos;
using NewsLott.ServiciosSegundoPlano.Interfaces;

namespace NewsLott.ServiciosSegundoPlano.HostedService
{
    public class ScrapyHostedService : BackgroundService, IDisposable
    {

        private Timer? _timer = null;


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
                    var resultadoWebScrapy = scope.ServiceProvider.GetRequiredService<IResultadoWebScrapy>();

                    await resultadoWebScrapy.CargarResultadosAsync();

                    await Task.Delay(new TimeSpan(0,1,0));
                }
            }
        }
    }
}
