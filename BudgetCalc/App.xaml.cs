﻿using BudgetCalc.Data;

namespace BudgetCalc;

public partial class App : Application
{

    static Database database;
    public static Database Database
    {
        get
        {
            if (database == null)
            {
                database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BudgetCalc.db3"));
            }
            return database;
        }
    }
    public App()
    {
        InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Dark;
        MainPage = new NavigationPage(new MainPage());
    }

}
