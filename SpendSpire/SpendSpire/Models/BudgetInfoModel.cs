using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace SpendSpire.Models
{
    public class BudgetInfoAccount
    {
        public string Name { get; set; }
        public int Amount { get; set; }
    }
    public class BudgetInfoModel
    {
        public Dictionary<string, int> Budget = new()
        {
            { "Income", 0 },
            { "Expenses", 0 },
            { "Remaining", 0 },
            { "RentOrMortgage", 0 },
            { "Groceries", 0 },
            { "Utilities", 0 },
            { "Transportation", 0 },
            { "LoanPayments", 0 },
            { "Savings", 0 },
            { "Health", 0 },
            { "Entertainment", 0 },
            { "PersonalCare", 0 },
            { "Insurance", 0 },
            { "Education", 0 },
            { "Childcare", 0 },
            { "DiningOut", 0 },
            { "Subscriptions", 0 },
            { "HomeMaintenance", 0 },
            { "Pets", 0 },
            { "Others", 0 }
        };

        public ObservableCollection<string> AllCategory { get; set; }
        public BudgetInfoModel() 
        {
            AllCategory = new ObservableCollection<string>
            {
                "Income",
                "Expenses",
                "Remaining",
                "RentOrMortgage",
                "Groceries",
                "Utilities",
                "Transportation",
                "LoanPayments",
                "Savings",
                "Health",
                "Entertainment",
                "PersonalCare",
                "Insurance",
                "Education",
                "Childcare",
                "DiningOut",
                "Subscriptions",
                "HomeMaintenance",
                "Pets",
                "Others"
            };
        }
    }
}
