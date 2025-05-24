using System.Net.Http;
using System.Text.Json;
using NewsPortal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsPortal.Services
{
    public class NewsService
    {
        private readonly HttpClient _httpClient;
        public NewsService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<List<Post>> GetPostsAsync()
        {
            var json = await _httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
            return JsonSerializer.Deserialize<List<Post>>(json) ?? new List<Post>();
        }

        public async Task<Post> GetPostAsync(int id)
        {
            var json = await _httpClient.GetStringAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
            return JsonSerializer.Deserialize<Post>(json) ?? new Post { Id = 0, UserId = 0, Title = string.Empty, Body = string.Empty };
        }

        public async Task<User> GetUserAsync(int userId)
        {
            var json = await _httpClient.GetStringAsync($"https://jsonplaceholder.typicode.com/users/{userId}");
            return JsonSerializer.Deserialize<User>(json) ?? new User { Id = 0, Name = string.Empty };
        }

        public async Task<List<Comment>> GetCommentsByPostIdAsync(int postId)
        {
            var json = await _httpClient.GetStringAsync($"https://jsonplaceholder.typicode.com/comments?postId={postId}");
            return JsonSerializer.Deserialize<List<Comment>>(json) ?? new List<Comment>();
        }
    }
}