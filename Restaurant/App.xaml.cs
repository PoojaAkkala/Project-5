namespace Calculator;

public partial class App : Application
{
    public static OrderViewModel vm;
	public static HistoryPage hp;
    public App()
	{
		InitializeComponent();

		//MainPage = new MainPage();
		vm =	new OrderViewModel();	
		hp = new HistoryPage();

	}
}
