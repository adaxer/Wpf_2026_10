namespace TestSuite.Common.Interfaces;

public interface IViewModelFactory
{
    ViewModelBase CreateViewModel(Type viewModelType);
}
