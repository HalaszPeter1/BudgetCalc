using BudgetCalc.ViewsModels;
using System.Collections.ObjectModel;

namespace BudgetCalc;

public partial class BudgetPage : ContentPage
{

	ListModelView model;
    public BudgetPage()
	{
		InitializeComponent();
		model= new ListModelView();
        
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        this.BindingContext = model;
        model.init();
        model.expenses = new ObservableCollection<Expense>(model.expenses.OrderByDescending(x => x.Date).ToList());
        lstView.ItemsSource = model.expenses;
        lblBalance.Text = CalculateBalance().ToString();
        
        
    }
    public int CalculateBalance()
    {
        int Income = model.expenses.Where(x => x.IsIncome == "Bev�tel").Sum(y=>y.Amount);
        int Expense = model.expenses.Where(x => x.IsIncome == "Kiad�s").Sum(y=>y.Amount);
        return Income - Expense;

    } 

    private async void data_Selected(object sender, SelectedItemChangedEventArgs e)
    {
        Expense selected = (Expense)lstView.SelectedItem;
        if (await DisplayAlert("Meger�s�t�s", "Szeretn� t�r�lni a k�v�nt adatot?", "Igen", "Nem"))
        {
            if (App.Database.DeleteData(selected))
            {
                await DisplayAlert("Sikeres t�rl�s!", "A t�rl�s sikeres", "OK");
                App.Database.DeleteData(selected);
                model.expenses.Remove(selected);
                lstView.ItemsSource = model.expenses;
                lblBalance.Text = CalculateBalance().ToString();
            }
            else
            {
                await DisplayAlert("Hiba!", "A t�rl�s sikertelen, pr�b�lja �jra!", "OK");
            }
        }
    }
}