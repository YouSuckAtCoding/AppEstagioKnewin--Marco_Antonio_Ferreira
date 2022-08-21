using Models.Library;

namespace Data.Library.Data.Usuarios
{
    public interface IUsuarioData
    {
        Task DeleteUsuario(int id);
        Task<Usuario?> GetUsuario(int id);
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task InsertUsuario(Usuario Usuario);
        Task UpdateUsuario(Usuario Usuario);
    }
}