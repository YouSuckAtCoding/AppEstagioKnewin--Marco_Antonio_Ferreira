using AppEstagioKnewin.Models;

namespace AppEstagioKnewin.Service
{
    public interface IUsuarioHttpService
    {
        Task<UsuarioPresentationModel> Create(UsuarioPresentationModel usuario);
        Task Delete(int id);
        Task<UsuarioPresentationModel> Edit(UsuarioPresentationModel usuario);
        Task<IEnumerable<UsuarioPresentationModel>> GetAll();
        Task<UsuarioPresentationModel> GetById(int id);
    }
}