using Siteware.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Core.Services.Usuario
{
    public interface IUsuarioService
    {
        void InserirUsuario(UsuarioDTO user);
        void AlterarSenha(string email, string senha);
        UsuarioDTO Logar(string email, string senha);
    }
}
