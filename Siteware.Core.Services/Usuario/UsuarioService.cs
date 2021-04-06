using AutoMapper;
using Siteware.Core.Data;
using Siteware.Core.DTO;
using Siteware.Core.Utils;

namespace Siteware.Core.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioData usuarioData = new UsuarioData();
        private readonly IMapper mapper;
        public UsuarioService(IMaps mapper)
        {
            this.mapper = mapper.Configurar().CreateMapper();
        }
        public void InserirUsuario(UsuarioDTO user)
        {
            var map = mapper.Map<Model.Usuario>(user);
            usuarioData.InserirUsuario(map);
        }

        public void AlterarSenha(string email, string senha)
        {
            usuarioData.AlterarSenha(email, senha);
        }

        public UsuarioDTO Logar(string email, string senha)
        {
            return mapper.Map<UsuarioDTO>(usuarioData.Logar(email, senha));
        }
    }
}
