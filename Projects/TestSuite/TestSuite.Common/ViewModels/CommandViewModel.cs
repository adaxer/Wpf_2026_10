
namespace TestSuite.Common.ViewModels;

public partial class CommandViewModel : ViewModelBase
{
    public CommandViewModel(string title, ICommand command, string iconType = "")
    {
        Title = title;
        Command = command;
        IconType = iconType;
    }

    [ObservableProperty]
    private ICommand command;

    [ObservableProperty]
    private string iconType;

  }
