
namespace TestSuite.Common.ViewModels;

public partial class StatusViewModel : ViewModelBase, IRecipient<StatusMessage>
{

    public StatusViewModel(IMessenger messenger)
    {
        messenger.Register(this);
    }

    [ObservableProperty]
    private string statusMessage=string.Empty;

    public void Receive(StatusMessage message)
    {
        StatusMessage = message.Message;
    }
}
