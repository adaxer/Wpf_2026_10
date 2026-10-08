using CommunityToolkit.Mvvm.ComponentModel;

namespace TestSuite.Common.ViewModels;

public partial class WelcomeViewModel : ViewModelBase
{

    public WelcomeViewModel()
    {
        Title = Strings.Welcome;
    }
}
