using Microsoft.Extensions.DependencyInjection;
using TestSuite.Common.Interfaces;

namespace TestSuite.Common.Services;

public class ViewModelFactory : IViewModelFactory
{
    private readonly IServiceProvider serviceProvider;

    public ViewModelFactory(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public ViewModelBase CreateViewModel(Type viewModelType)
    {
        return serviceProvider.GetRequiredService(viewModelType) as ViewModelBase ?? throw new ArgumentException($"{viewModelType} must derive from ViewModelBase.");
    }
}
