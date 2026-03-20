using ETLWorker.Services;
using System.Linq;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var csvService = new CsvService();
        var dbService = new DatabaseService();
        var apiService = new ApiService(); 
        var staging = new StagingService();

        try
        {
            _logger.LogInformation("Iniciando ETL...");

            var csv = csvService.LeerCsv(@"C:\Users\emils\Downloads\ETLWorker\ETLWorker\ETLWorker\opiniones.csv");
            var db = dbService.ObtenerComentarios();
            var api = await apiService.ObtenerComentariosAsync();
            var todos = csv
                .Concat(db.Select(x => x.Texto))
                .Concat(api)
                .ToList();

            staging.Guardar(todos);

            _logger.LogInformation("Proceso completado");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en ETL");
        }
    }
}