using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BudgetCalc.ViewsModels
{
    public class ListModelView
    {
        public ObservableCollection<Expense> expenses { get; set; }
        public ListModelView()
        {
            expenses = new ObservableCollection<Expense>();
        }

        public void init()
        {
            expenses = App.Database.GetAllData();
        }

    }

}
