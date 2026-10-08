using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Windows;
using TestSuite.Common.Interfaces;
using TestSuite.Common.Services;

namespace TestSuite.Wpf;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IServiceProvider? _serviceProvider;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Determine environment (DOTNET_ENVIRONMENT or ASPNETCORE_ENVIRONMENT)
        var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
                          ?? Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                          ?? "Development";

        // Build configuration from appsettings.json, environment-specific file, env vars and command line args
        var configBuilder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .AddCommandLine(e.Args ?? Array.Empty<string>());

        IConfiguration configuration = configBuilder.Build();

        // Sprache könnte aus Configuration kommen, hier wird sie auf Englisch gesetzt
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

        // Setup DI
        var services = new ServiceCollection();

        // Logging configured from configuration
        services.AddLogging(lb =>
        {
            lb.AddConfiguration(configuration.GetSection("Logging"));
            lb.AddConsole();
            lb.AddDebug();
        });

        services.AddSingleton(configuration);

        // Register application services / viewmodels / windows
        services.AddSingleton<IMessenger>(sp => WeakReferenceMessenger.Default);
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<MainWindow>(sp =>
        {
            var mw = new MainWindow();
            mw.DataContext = sp.GetRequiredService(typeof(MainViewModel));
            return mw;
        });
        services.AddCommonServices();

        _serviceProvider = services.BuildServiceProvider();

        // Log startup
        var logger = _serviceProvider.GetRequiredService<ILogger<App>>();
        logger.LogInformation("Starting application. Environment: {env}", environment);

        // Resolve and show main window
        MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        MainWindow.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        if (_serviceProvider is IDisposable d)
        {
            try { d.Dispose(); } catch { }
        }

        base.OnExit(e);
    }
}

