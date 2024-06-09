using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BaseModels
{
    public interface IUsuariosModel : IGenericModel<UsuariosModel>
    {
        UsuariosModel IniciarSesion(string usuario,string contraseña);
        List<UsuariosModel> BuscarUsuario(string valor);
        int ObtenerIdUsuario(string login);
    }
}
