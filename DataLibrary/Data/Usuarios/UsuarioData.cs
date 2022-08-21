using Data.Library.DataAccess;
using Models.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Library.Data.Usuarios
{
    public class UsuarioData : IUsuarioData
    {
        private readonly ISqlDataAccess database;

        public UsuarioData(ISqlDataAccess _database)
        {
            database = _database;
        }

        public Task<IEnumerable<Usuario>> GetUsuarios() => database.LoadData<Usuario, dynamic>("dbo.spUsuarios_GetAll", new { });

        public async Task<Usuario?> GetUsuario(int id)
        {
            var result = await database.LoadData<Usuario, dynamic>("dbo.spUsuarios_Get", new { Id = id });

            return result.FirstOrDefault();
        }

        public Task InsertUsuario(Usuario usuario) =>
            database.SaveData("dbo.spUsuarios_Insert", new { usuario.Name, usuario.EmailAddress });

        public Task UpdateUsuario(Usuario usuario) => database.SaveData("dbo.spUsuarios_Update", usuario);

        public Task DeleteUsuario(int id) => database.SaveData("dbo.spUsuarios_Delete", new { Id = id });


    }
}
