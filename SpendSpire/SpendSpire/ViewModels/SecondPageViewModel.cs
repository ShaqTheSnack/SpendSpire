using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using SpendSpire.Models;

namespace SpendSpire.ViewModels
{
    public class SecondPageViewModel : ViewModelBase
    {
        BudgetInfoModel? _budgetInfoModel;
        MainViewModel? _mainViewModel;
        ObservableCollection<BudgetInfoAccount> budgetData = new();
        ObservableCollection<BudgetInfoAccount> threeBudgetData = new();
        public ObservableCollection<BudgetInfoAccount> BudgetData { get => budgetData; set => this.RaiseAndSetIfChanged(ref budgetData, value, nameof(BudgetData)); }
        public ObservableCollection<BudgetInfoAccount> ThreeBudgetData { get => threeBudgetData; set => this.RaiseAndSetIfChanged(ref threeBudgetData, value, nameof(ThreeBudgetData)); }

        public SecondPageViewModel(MainViewModel mainViewModel, BudgetInfoModel budgetInfoModel)
        {
            _mainViewModel = mainViewModel;
            _budgetInfoModel = budgetInfoModel;
            BudgetInfoModel model = DatabaseService.GetAllData();

            foreach (KeyValuePair<string, int> kv in model.Budget)
            {
                BudgetData.Add( new BudgetInfoAccount()
                {
                    Name = kv.Key,
                    Amount = kv.Value
                });
            }

            BudgetInfoModel threeModel = DatabaseService.GetThreeData();

            foreach (KeyValuePair<string, int> kv in threeModel.Budget)
            {
                ThreeBudgetData.Add(new BudgetInfoAccount()
                {
                    Name = kv.Key,
                    Amount = kv.Value
                });
            }

            double[] dataX = { 1, 2, 3, 4, 5 };
            double[] dataY = { 1, 4, 9, 16, 25 };
        }





        public void HomeBtn()
        {
            _mainViewModel?.ViewSecondPage();
        }
        public void CreateBtn()
        {
            _mainViewModel?.ViewThirdPage(); 
        }

        public void EditBtn()
        {
           _mainViewModel?.ViewFourthPage();
        }

    }
}
