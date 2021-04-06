using Siteware.Core.Model;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

namespace Siteware.Core.Data
{
    public class PrecoData
    {
        public void InserirPreco(Preco preco)
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    context.Precos.Add(preco);
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
