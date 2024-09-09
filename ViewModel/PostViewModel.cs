using CommunityToolkit.Mvvm.ComponentModel;
using ExemploHttp.Models;
using ExemploHttp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ExemploHttp.ViewModel
{
    public partial class PostViewModel: ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Post> posts;

       public ICommand getPostsCommand { get; }

        public PostViewModel(){
            getPostsCommand = new Command(getPosts);
        }
        
        public async void getPosts()
        {
            RestService postService = new RestService();
            Posts = await postService.getPostAsync();
        }
    }
}
