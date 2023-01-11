using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BudgetCalc.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection connection;
        public Database(string dbPath)
        {
            connection = new SQLiteAsyncConnection(dbPath);
            connection.CreateTableAsync<Expense>().Wait();
        }

        public bool DeleteData(Expense selected)
        {
            return connection.DeleteAsync(selected).Result == 1 ? true : false;
        }
        public ObservableCollection<Expense> GetAllData()
        {
            ObservableCollection<Expense> obs = new ObservableCollection<Expense>();
            List<Expense> list = connection.Table<Expense>().ToListAsync().Result;
            list.ForEach(x => obs.Add(x));
            return obs;
        }

        public Task<int> SaveExpenseData(Expense expense)
        {
            return connection.InsertAsync(expense);

        }

    }
}
