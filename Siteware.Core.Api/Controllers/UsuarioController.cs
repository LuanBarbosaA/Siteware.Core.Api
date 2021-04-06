using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Siteware.Core.DTO;
using Siteware.Core.Services.Usuario;

namespace Siteware.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuario)
        {
            this.usuarioService = usuario;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Logar([FromBody] UsuarioDTO usuario)
        {
            var user = usuarioService.Logar(usuario.Email, usuario.Senha);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Senha = "";
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpPost]
        public void CadastrarUsuario([FromBody] UsuarioDTO usuario)
        {
            usuarioService.InserirUsuario(usuario);
        }

        [HttpPut]
        public void AlteraSenhaUsuario([FromBody] string email, string senha)
        {
            usuarioService.AlterarSenha(email, senha);
        }
    }
}
