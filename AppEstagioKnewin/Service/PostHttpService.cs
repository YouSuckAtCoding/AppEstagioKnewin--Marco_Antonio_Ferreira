using AppEstagioKnewin.Models;
using System.Text.Json;

namespace AppEstagioKnewin.Service
{
    public class PostHttpService : IPostHttpService
    {
        private readonly HttpClient httpClient;

        private static readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            IgnoreNullValues = true

        };

        public PostHttpService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7180");
        }
        /// <summary>
        /// Função para salvar postagem no banco de dados
        /// </summary>
        /// <param name="post">PostPresentationModel</param>
        /// <returns>PostPresentationModel</returns>
        public async Task<PostPresentationModel> Create(PostPresentationModel post)
        {
            var httpResponseMessage = await httpClient.PostAsJsonAsync("api/v1/PostApi", post);

            var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var created = await JsonSerializer.DeserializeAsync<PostPresentationModel>(contentStream, jsonSerializerOptions);

            return created;

        }
        /// <summary>
        /// Função para deletar a postagem desejada.
        /// </summary>
        /// <param name="id">Id do PostPresentationModel desejado</param>
        /// <returns>HTTP status code</returns>
        public async Task Delete(int id)
        {
            var httpResponseMessage = await httpClient.DeleteAsync($"api/v1/PostApi/{id}");
            httpResponseMessage.EnsureSuccessStatusCode();
            
        }
        /// <summary>
        /// Função para editar a postagem desejada
        /// </summary>
        /// <param name="post">PostPresentationModel</param>
        /// <returnsPostPresentationModel></returns>
        public async Task<PostPresentationModel> Edit(PostPresentationModel post)
        {
            var httpResponseMessage = await httpClient.PutAsJsonAsync($"api/v1/PostApi/{post.Id}", post);

            var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var edited = await JsonSerializer.DeserializeAsync<PostPresentationModel>(contentStream, jsonSerializerOptions);
            return edited;
        }
        /// <summary>
        /// Função para buscar todas as postagens
        /// </summary>
        /// <returns>IEnumerable de PostPresentationModel</returns>
        public async Task<IEnumerable<PostPresentationModel>> GetAll()
        {
            var Posts = await httpClient.GetFromJsonAsync<IEnumerable<PostPresentationModel>>($"api/v1/PostApi");
            return Posts;

        }
        /// <summary>
        /// Função para buscar a psotagem pelo id
        /// </summary>
        /// <param name="id">Id da postagem desejada</param>
        /// <returns>PostPresentationModel</returns>
        public async Task<PostPresentationModel> GetById(int id)
        {
            var Post = await httpClient.GetFromJsonAsync<PostPresentationModel>($"api/v1/PostApi/{id}");
            return Post;
        }


    }
}
