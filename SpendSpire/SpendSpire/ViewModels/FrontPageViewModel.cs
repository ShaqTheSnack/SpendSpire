using Avalonia.Controls;
using SpendSpire.Models;
using SpendSpire.Views;
using System;

namespace SpendSpire.ViewModels
{
    public class FrontPageViewModel : ViewModelBase
    {
        MainViewModel? _mainViewModel;
        public FrontPageViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

        }
        public void GetStartedBtn()
        {
            _mainViewModel?.ViewSecondPage();
        }

    }
}
