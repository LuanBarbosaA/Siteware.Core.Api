using System;
using System.Collections.Generic;

#nullable disable

namespace Siteware.Core.Model
{
    public partial class Usuario
    {
        public Usuario()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int PkUsuarioId { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
