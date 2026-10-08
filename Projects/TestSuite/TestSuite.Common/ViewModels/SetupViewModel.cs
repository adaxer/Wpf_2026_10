using CommunityToolkit.Mvvm.ComponentModel;

namespace TestSuite.Common.ViewModels;

public partial class SetupViewModel : ViewModelBase
{
    private readonly IMessenger messenger;
    [ObservableProperty]
    private double currentVoltage = 0.0;

    [ObservableProperty]
    private ICollection<string> machines;

    public SetupViewModel(IMessenger messenger)
    {
        Machines = new List<string> { "Machine A", "Machine B", "Machine C" };
        SetVoltageAsync();
        this.messenger = messenger;
    }

    private async void SetVoltageAsync()
    {
        while(CurrentVoltage<220.0)
        {
            await Task.Delay(100);
            CurrentVoltage += 10;
            messenger.Send(new StatusMessage($"Current Voltage: {CurrentVoltage}V"));
        }
    }
}
