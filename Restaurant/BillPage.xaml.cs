using Calculator.Data;

namespace Calculator;

public partial class BillPage : ContentPage
{
    Data.BillDataBase billDataBase = new Data.BillDataBase();

    public BillPage()
	{
        
        InitializeComponent();
        
    }

    private async void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        var res1 = await billDataBase.GetItemsAsync();
        if (res1 != null)
        {
            var res2 = res1[0].Bill;
            Bill.Text = res2;
        }
        else
            Bill.Text = "";
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Bill.Text = "";
    }
}