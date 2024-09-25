using Avalonia.Controls;
using SpendSpire.Views;
using ReactiveUI;
using SpendSpire.Models;

namespace SpendSpire.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public BudgetInfoModel BudgetInfoModel = new();
        public FrontPageView FrontPageView = new();
        public SecondView SecondView = new();
        public ThirdPageView ThirdPageView = new();
        public FourthPageView FourthPageView = new();
        Control _currentView;
        public Control CurrentView { 
            get => _currentView;
            private set => this.RaiseAndSetIfChanged(ref _currentView, value, nameof(CurrentView));
        }
        public MainViewModel()
        {
            FrontPageView.DataContext = new FrontPageViewModel(this);
            SecondView.DataContext = new SecondPageViewModel(this, BudgetInfoModel);
            ThirdPageView.DataContext = new ThirdPageViewModel(this, BudgetInfoModel);
            FourthPageView.DataContext = new FourthPageViewModel(this, BudgetInfoModel);
            ViewFrontPage();

        }

        public void ViewFrontPage()
        {
            CurrentView = FrontPageView;
        }
        public void ViewSecondPage()
        {
            CurrentView = SecondView;
        }
        public void ViewThirdPage()
        {
            CurrentView = ThirdPageView;
        }

        public void ViewFourthPage()
        {
            CurrentView = FourthPageView;
        }
    }
}
