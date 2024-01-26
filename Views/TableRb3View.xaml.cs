using SocialSciencesEF2024.ViewModels;

namespace SocialSciencesEF2024.Views;

public partial class TableRb3View : ContentPage
{
	public TableRb3View()
	{
		InitializeComponent();
		BindingContext = new TableRb3ViewModel();
	}
}
