using Amazon.EC2.Model;
using Calculator.Models;
using System.Collections.Immutable;

namespace Calculator;

public partial class MainPage : ContentPage
{
    int sum = 0;
    IDictionary<string, int> prices = new Dictionary<string, int>();
    public MainPage()
    {
        InitializeComponent();
        OnClear(this, null);
        
        prices.Add("Burger", 10);
        prices.Add("Pizza", 12);
        prices.Add("Sandwich", 8);
        prices.Add("Chicken", 9);
        prices.Add("Milk", 3);
        prices.Add("Wine", 25);
        prices.Add("Beef", 5);
        prices.Add("Bacon", 4);
        prices.Add("Cheese Burger", 20);
        prices.Add("Buffalo Sauce", 1); prices.Add("Tangy Sauce", 1);
        prices.Add("Ranch", 1);
        prices.Add("Crispy Corn", 5);
        prices.Add("Cajun Potato", 7);
        prices.Add("French Fries", 2);
        prices.Add("Pepsi", 2);
        prices.Add("Coke", 2);
        prices.Add("Mountain Dew", 2);
        prices.Add("Salad", 1);
        prices.Add("8 Piece", 18);

    }
    
    
    
    
    

    void OnSelectNumber(object sender, EventArgs e)
    {
        
        Button button = (Button)sender;
        string pressed = button.Text;
        this.resultText.Text = pressed + " : " + "$" + prices[pressed];
        string res = pressed + " : " + "$" + prices[pressed];
        
        sum = sum + prices[pressed];
        string res1 = "Total" + " : " + sum;
        App.vm.Add(res,res1);
        
        
    }

   
    void OnClear(object sender, EventArgs e)
    {
       
        this.resultText.Text = "0";
        
    }   
    


   
}
