using BudgetCalc.ViewsModels;

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
        lstView.ItemsSource = model.expenses;
    }
}