using System;
using System.Collections.Generic;

#nullable disable

namespace Siteware.Core.Model
{
    public partial class Pedido
    {
        public Pedido()
        {
            ItensPedidos = new HashSet<ItensPedido>();
        }

        public int PkPedidoId { get; set; }
        public DateTime DataEntrada { get; set; }
        public int FkUsuarioId { get; set; }

        public virtual Usuario FkUsuario { get; set; }
        public virtual ICollection<ItensPedido> ItensPedidos { get; set; }
    }
}
