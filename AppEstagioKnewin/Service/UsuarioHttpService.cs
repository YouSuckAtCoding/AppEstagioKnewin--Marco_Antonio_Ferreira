using AppEstagioKnewin.Models;
using System.Text.Json;

namespace AppEstagioKnewin.Service
{
    public class UsuarioHttpService : IUsuarioHttpService
    {
        private readonly HttpClient httpClient;

        private static readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            IgnoreNullValues = true

        };

        public UsuarioHttpService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7180");
        }
        /// <summary>
        /// Função para criar um usuário
        /// </summary>
        /// <param name="usuario">UsuarioPresentationModel</param>
        /// <returns>UsuarioPresentationModel</returns>
        public async Task<UsuarioPresentationModel> Create(UsuarioPresentationModel usuario)
        {
            var httpResponseMessage = await httpClient.PostAsJsonAsync($"api/v1/UsuarioApi", usuario);

            var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var created = await JsonSerializer.DeserializeAsync<UsuarioPresentationModel>(contentStream, jsonSerializerOptions);

            return created;

        }
        /// <summary>
        /// Função para deletar o usuário desejado
        /// </summary>
        /// <param name="id">Id do Usuário</param>
        /// <returns>HTTP Status Code</returns>
        public async Task Delete(int id)
        {
            var httpResponseMessage = await httpClient.DeleteAsync($"api/v1/UsuarioApi/{id}");
            httpResponseMessage.EnsureSuccessStatusCode();

        }
        /// <summary>
        /// Função para editar o usuário desejado
        /// </summary>
        /// <param name="usuario">UsuarioPresentationModel</param>
        /// <returns>UsuarioPresentationModel</returns>
        public async Task<UsuarioPresentationModel> Edit(UsuarioPresentationModel usuario)
        {
            var httpResponseMessage = await httpClient.PutAsJsonAsync($"api/v1/UsuarioApi/{usuario.Id}", usuario);

            var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var edited = await JsonSerializer.DeserializeAsync<UsuarioPresentationModel>(contentStream, jsonSerializerOptions);
            return edited;
        }
        /// <summary>
        /// Função para buscar todos os usuários
        /// </summary>
        /// <returns>IEnumerable de UsuarioPresentationModel</returns>
        public async Task<IEnumerable<UsuarioPresentationModel>> GetAll()
        {
            var Usuarios = await httpClient.GetFromJsonAsync<IEnumerable<UsuarioPresentationModel>>($"api/v1/UsuarioApi");
            return Usuarios;

        }
        /// <summary>
        /// Função para buscar o usuáro desejado
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <returns>UsuarioPresentationModel</returns>
        public async Task<UsuarioPresentationModel> GetById(int id)
        {
            var Usuario = await httpClient.GetFromJsonAsync<UsuarioPresentationModel>($"api/v1/UsuarioApi/{id}");
            return Usuario;
        }
    }
}
