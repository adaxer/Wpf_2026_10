using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Automation.Peers;
using TestSuite.Common;
using TestSuite.Common.Interfaces;
using TestSuite.Common.ViewModels;

namespace TestSuite.Wpf;

public partial class MainViewModel : ViewModelBase
{
    public MainViewModel(IViewModelFactory viewModelFactory, StatusViewModel statusViewModel)
    {
        Title = "Test Suite";
        Commands.Add(new CommandViewModel("Load Setup", LoadSetupCommand, "🔧"));
        Commands.Add(new CommandViewModel("Measurements", ShowMeasurementsCommand, "📐"));
        Commands.Add(new CommandViewModel("Settings", ShowSettingsCommand, "⚙"));
        this.viewModelFactory = viewModelFactory;
        Status = statusViewModel;
    }

    [ObservableProperty]
    private ICollection<CommandViewModel> commands = new ObservableCollection<CommandViewModel>();

    [ObservableProperty]
    private StatusViewModel status;

    [ObservableProperty]
    private bool isMenuExpanded = false;


    [ObservableProperty]
    private ViewModelBase currentElement = new WelcomeViewModel();

    private readonly IViewModelFactory viewModelFactory;

    [RelayCommand(CanExecute = nameof(CanLoadSetup))]
    private async Task LoadSetupAsync(object? parameter)
    {
        ShowElement(typeof(SetupViewModel));
    }

    private void ShowElement(Type elementType)
    {
        IsBusy = true;
        CurrentElement = viewModelFactory.CreateViewModel(elementType);
        IsBusy = false;
        IsMenuExpanded = false;
    }

    [RelayCommand]
    private async Task ShowMeasurementsAsync(object? parameter)
    {
        IsBusy = true;
        await Task.Delay(1000); // Simulate a long-running operation
        IsBusy = false;
    }

    [RelayCommand]
    private async Task ShowSettingsAsync(object? parameter)
    {
        ShowElement(typeof(SettingsViewModel));
    }

    private bool CanLoadSetup()
    {
        return !IsBusy;
    }
    // Implement the logic for loading the setup here
}

