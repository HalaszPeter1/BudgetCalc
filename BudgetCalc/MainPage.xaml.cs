using System.Text.RegularExpressions;

namespace BudgetCalc;

public partial class MainPage : ContentPage
{

    private Expense expenseData = new Expense(0,"",false);


	public MainPage()
	{
		InitializeComponent();
	}

    private async void NextButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BudgetPage());

    }

    private async void ExpenseButton_Clicked(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(AmountEntry.Text) && !String.IsNullOrEmpty(TypeEntry.Text))
        {
            expenseData.SetData(int.Parse(AmountEntry.Text), TypeEntry.Text, false);
            await App.Database.SaveExpenseData(expenseData);
        }
        else
        {
            DisplayAlert("HIBA!", "Az összeget és a típust megadni kötelező", "OK");
        }

    }

    private async void IncomeButton_Clicked(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(AmountEntry.Text) && !String.IsNullOrEmpty(TypeEntry.Text))
        {
            expenseData.SetData(int.Parse(AmountEntry.Text), TypeEntry.Text, true);
            await App.Database.SaveExpenseData(expenseData);
        }
        else
        {
            DisplayAlert("HIBA!", "Az összeget és a típust megadni kötelező", "OK");
        }
    }
}

