
using Amazon.IdentityManagement;
using Calculator.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Calculator;

public partial class HistoryPage : ContentPage
{
    public string sum;
    Data.OrderDataBase dataBase = new Data.OrderDataBase();
    Data.BillDataBase billDataBase = new Data.BillDataBase();   
    public HistoryPage()
    {
        InitializeComponent();
        BindingContext = new {history = App.vm.Items};
        
       
    }    
    

    private async void Clear_Clicked(object sender, EventArgs e)
    {
        await dataBase.DeleteAllAsync();
        App.vm.Items.Clear();
        await billDataBase.DeleteAllAsync();
        total.Text = "Total : 0";
    }

    public async void Button_Clicked(object sender, EventArgs e)
    {
        var res = await dataBase.GetItemsAsync();
        App.vm.Items.Clear();
        res.ForEach(App.vm.Items.Add);
        var res1 = await billDataBase.GetItemsAsync();
        var res2 = res1[0].Bill;
        total.Text = res2;

    }

}