using TestSuite.Common.Interfaces;
using TestSuite.Common.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceRegistration
{
    public static void AddCommonServices(this IServiceCollection services)
    {
        services.AddSingleton<IViewModelFactory, ViewModelFactory>();
        services.AddSingleton<SetupViewModel>();
        services.AddSingleton<WelcomeViewModel>();
        services.AddSingleton<StatusViewModel>();
        services.AddSingleton<SettingsViewModel>();
        services.AddTransient<MachineViewModel>();
    }
}
