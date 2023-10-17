using DataAccess.DTO;
using DataAccess.Entities;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IUsuariosRepository : IGenericRepository<Usuarios>
    {
        IEnumerable<MostrarUsuariosDTO> MostrarUsuariosDTO();
        Usuarios IniciarSesion (string usuario, string contrseña);
        int ValidarUsuarios(string usuario,string contraseña);
        int ObtenerIdUsuario(string login);
    }
}
