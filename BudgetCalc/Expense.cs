using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetCalc
{
    public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Amount { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string IsIncome { get; set; }

        
        public Expense()
        {

        }
        public Expense(int amount, string type, string isIncome)
        {
            Amount = 0;
            Type = "";
            Date = DateTime.Now;
            IsIncome = "";
        }

        public void SetData(int amount, string type, string isIncome)
        {
            Amount= amount;
            Type = type;
            Date = DateTime.Now;
            IsIncome= isIncome;
        }


    }
}
