using ExemploHttp.ViewModel;

namespace ExemploHttp.Views;

public partial class PostsView : ContentPage
{
	public PostsView()
	{
		InitializeComponent();
		BindingContext = new PostViewModel();
	}
}