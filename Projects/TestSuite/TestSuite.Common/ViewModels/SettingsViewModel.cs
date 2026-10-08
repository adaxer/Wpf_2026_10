using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TestSuite.Common.Interfaces;

namespace TestSuite.Common.ViewModels;

public partial class SettingsViewModel : ViewModelBase
{

    public SettingsViewModel(IViewModelFactory viewModelFactory)
    {
        Title = "Settings";
        this.viewModelFactory = viewModelFactory;
    }

    [ObservableProperty]
    private ICollection<MachineViewModel> machines = new ObservableCollection<MachineViewModel>();
    private readonly IViewModelFactory viewModelFactory;

    [RelayCommand]
    private async Task AddMachineAsync()
    {
        Machines.Add((viewModelFactory.CreateViewModel(typeof(MachineViewModel)) as MachineViewModel)!);
    }
}
