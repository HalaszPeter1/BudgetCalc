using System.Text.RegularExpressions;

namespace BudgetCalc;

public partial class MainPage : ContentPage
{

    private Expense expenseData = new Expense(0,"","");


	public MainPage()
	{
		InitializeComponent();
	}

    private async void NextButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BudgetPage());

    }

    private void ExpenseButton_Clicked(object sender, EventArgs e)
    {
        SaveData("kiadásod","Kiadás");
    }

    private void IncomeButton_Clicked(object sender, EventArgs e)
    {
        SaveData("bevételed","Bevétel");
    }

    private async void SaveData(string Text, string isIncome)
    {
        if (!String.IsNullOrEmpty(AmountEntry.Text) && !String.IsNullOrEmpty(TypeEntry.Text))
        {
            expenseData.SetData(int.Parse(AmountEntry.Text), TypeEntry.Text, isIncome);
            await App.Database.SaveExpenseData(expenseData);
            await DisplayAlert("Mentve!", $"A {Text} sikeresen rögzítve!", "OK");
        }
        else
        {
            DisplayAlert("HIBA!", "Az összeget és a típust megadni kötelező", "OK");
        }
        AmountEntry.Text = "";
        TypeEntry.Text = "";
    }
}

