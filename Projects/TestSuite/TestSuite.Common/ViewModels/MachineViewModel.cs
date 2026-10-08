using CommunityToolkit.Mvvm.ComponentModel;

namespace TestSuite.Common.ViewModels;

public partial class MachineViewModel : ViewModelBase
{
    [ObservableProperty]
    private string name="";

    [ObservableProperty]
    private string iPAddress="";

}
