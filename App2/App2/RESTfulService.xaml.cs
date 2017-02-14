using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App2
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public partial class RESTfulService : ContentPage
    {

        private const string Url = "https://jsonplaceholder.typicode.com/posts";        
        private HttpClient _client = new HttpClient();

        private ObservableCollection<Post> _posts;


        public RESTfulService()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);

            var posts = JsonConvert.DeserializeObject<List<Post>>(content);

            _posts = new ObservableCollection<Post>(posts);

            postsListView.ItemsSource = _posts;

            base.OnAppearing();
        }

        void OnAdd(object sender, System.EventArgs e)
        {
        }

        void OnUpdate(object sender, System.EventArgs e)
        {
        }

        void OnDelete(object sender, System.EventArgs e)
        {
        }
    }
    
}
