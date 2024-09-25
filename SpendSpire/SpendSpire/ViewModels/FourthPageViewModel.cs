using ReactiveUI;
using SpendSpire.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendSpire.ViewModels
{
    public class FourthPageViewModel : ViewModelBase
    {
        MainViewModel? _mainViewModel;
        BudgetInfoModel? _budgetInfoModel;
        FourthPageViewModel? _fourthPageViewModel;
        ObservableCollection<BudgetInfoAccount> seeBudgetData = new();
        public ObservableCollection<BudgetInfoAccount> SeeBudgetData { get => seeBudgetData; set => this.RaiseAndSetIfChanged(ref seeBudgetData, value, nameof(SeeBudgetData)); }

        public FourthPageViewModel(MainViewModel mainViewModel, BudgetInfoModel budgetInfoModel)
        {
            _mainViewModel = mainViewModel;
            _budgetInfoModel = budgetInfoModel;
            BudgetInfoModel model = DatabaseService.SeeAllData();

            foreach (KeyValuePair<string, int> kv in model.Budget)
            {
                SeeBudgetData.Add(new BudgetInfoAccount()
                {
                    Name = kv.Key,
                    Amount = kv.Value,
                });
            }
        }


        private int _MoneyInput;
        public int MoneyInput
        {
            get => _MoneyInput;
            set
            {
                this.RaiseAndSetIfChanged(ref _MoneyInput, value, nameof(MoneyInput));
            }
        }

        //SelectedCategoryForDelete
        private int _SelectedCategoryForEdit;
        public int SelectedCategoryForEdit
        {
            get => _SelectedCategoryForEdit;
            set
            {
                this.RaiseAndSetIfChanged(ref _SelectedCategoryForEdit, value, nameof(SelectedCategoryForEdit));
            }
        }

        public void ConfirmBtn()
        {
            DatabaseService.EditItemFromDatabase(SelectedCategoryForEdit, MoneyInput);
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
