using Siteware.Core.Model;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Siteware.Core.Data
{
    public class UsuarioData
    {
        public Usuario ObterUsuario(string email)
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    return context.Usuarios.Where(x => x.Email == email).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Usuario Logar(string email, string senha)
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    return context.Usuarios.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AlterarSenha(string email, string senha)
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    Usuario usuario = context.Usuarios.Where(x => x.Email == email).FirstOrDefault();
                    usuario.Senha = senha;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void InserirUsuario(Usuario usuario)
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    context.Usuarios.Add(usuario);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
