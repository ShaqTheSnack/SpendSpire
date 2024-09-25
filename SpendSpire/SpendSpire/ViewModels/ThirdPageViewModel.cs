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
    internal class ThirdPageViewModel : ViewModelBase
    {
        MainViewModel? _mainViewModel;
        BudgetInfoModel? _budgetInfoModel;
        ObservableCollection<BudgetInfoAccount> seeBudgetData = new();
        public ObservableCollection<BudgetInfoAccount> SeeBudgetData { get => seeBudgetData; set => this.RaiseAndSetIfChanged(ref seeBudgetData, value, nameof(SeeBudgetData)); }
        public ThirdPageViewModel(MainViewModel mainViewModel, BudgetInfoModel budgetInfoModel)
        {
            _mainViewModel = mainViewModel;
            _budgetInfoModel = budgetInfoModel;
            NewAllCategory = new ObservableCollection<string>(budgetInfoModel.AllCategory);
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



        private ObservableCollection<string> _newAllCategory;
        public ObservableCollection<string> NewAllCategory
        {
            get { return _newAllCategory; }
            set { this.RaiseAndSetIfChanged(ref _newAllCategory, value); }
        }


        //Selected In ComboBox
        private string _SelectedCategory;
        public string SelectedCategory
        {
            get => _SelectedCategory;
            set
            {
                this.RaiseAndSetIfChanged(ref _SelectedCategory, value, nameof(SelectedCategory));
            }
        }

        //Money Input
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
        private int _SelectedCategoryForDelete;
        public int SelectedCategoryForDelete
        {
            get => _SelectedCategoryForDelete;
            set
            {
                this.RaiseAndSetIfChanged(ref _SelectedCategoryForDelete, value, nameof(SelectedCategoryForDelete));
            }
        }

        public void DeleteBtn()
        {
            DatabaseService.DeleteItemFromDatabase(SelectedCategoryForDelete);
        }

        public void AddBtn()
        {
            DatabaseService.UpdateDatabase(SelectedCategory, MoneyInput);
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
