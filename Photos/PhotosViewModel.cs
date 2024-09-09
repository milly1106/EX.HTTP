using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploHttp.Photos
{
    internal class PhotosViewModel
    {
        public partial class PostViewModel : ObservableObject
        {
            [ObservableProperty]
            ObservableCollection<Post> posts;

            public ICommand getPostsCommand { get; }

            public PostViewModel()
            {
                getPhotosCommand = new Command(getPhotos);
            }

            public async void getPhotos()
            {
                RestService postService = new RestService();
                Posts = await postService.getPostAsync();
            }
        }
    }

    public class ObservableObject
    {
    }
}
