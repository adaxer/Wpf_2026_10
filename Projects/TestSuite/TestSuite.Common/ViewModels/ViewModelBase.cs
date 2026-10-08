
namespace TestSuite.Common.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    public ViewModelBase()
    {
        Title = GetType().Name;
    }

    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private bool isBusy;
}
