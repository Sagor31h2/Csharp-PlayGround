public class BackgroundWorkerService : BackgroundService
{ //BackgroundService : IHostedService, IDisposable
    private readonly ILogger<BackgroundWorkerService> _logger;

    public BackgroundWorkerService(ILogger<BackgroundWorkerService> logger)
    {
        _logger = logger;
    }
    //public async Task StartAsync(CancellationToken cancellationToken)
    //{
    //    while (!cancellationToken.IsCancellationRequested)
    //    {
    //        _logger.LogInformation("service is running {time}", DateTimeOffset.Now);
    //        await Task.Delay(1000, cancellationToken);
    //    }
    //}

    //public Task StopAsync(CancellationToken cancellationToken)
    //{
    //    _logger.LogInformation("service is finished");
    //    return Task.CompletedTask;
    //}

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("service is running {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}