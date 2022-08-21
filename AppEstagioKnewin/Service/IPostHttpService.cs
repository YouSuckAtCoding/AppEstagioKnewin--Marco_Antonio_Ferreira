using AppEstagioKnewin.Models;

namespace AppEstagioKnewin.Service
{
    public interface IPostHttpService
    {
        Task<PostPresentationModel> Create(PostPresentationModel post);
        Task Delete(int id);
        Task<PostPresentationModel> Edit(PostPresentationModel post);
        Task<IEnumerable<PostPresentationModel>> GetAll();
        Task<PostPresentationModel> GetById(int id);
    }
}