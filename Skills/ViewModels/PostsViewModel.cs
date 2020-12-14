using Newtonsoft.Json;
using Skills.DataBase;
using Skills.Models;
using Skills.ThirdParty;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Skills.ViewModels
{
    public class PostsViewModel : ViewModelBase 
    {
        public async Task<Response> GetList<T>(string urlBase)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = client.BaseAddress; 
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(result);

                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list as List<Post> , 
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public PostsViewModel()
        {
            LoadPosts();

        }
        private ObservableCollection<Post> posts;

        public ObservableCollection<Post> Posts { get => posts; set => posts = value; }

        private async void LoadPosts()
        {
            var response = await GetList<Post>(Constants.BaseURL);

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            var list = (List<Post>)response.Result;
            Posts = new ObservableCollection<Post>(list);
        }
    }
}
