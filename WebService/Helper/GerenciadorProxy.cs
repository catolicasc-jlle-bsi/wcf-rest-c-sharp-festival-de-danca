using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebService.Helper
{
    public class GerenciadorProxy
    {
        public string Endereco { get; set; }
        public string Porta { get; set; }

        public GerenciadorProxy(string endereco, string porta)
        {
            this.Endereco = endereco;
            this.Porta = porta;
        }
    }
}
