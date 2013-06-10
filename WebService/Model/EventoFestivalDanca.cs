using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Model
{
    public class EventoFestivalDanca
    {
        public string CodigoGrupo { get; set; }
        public string NomeGrupo { get; set; }
        public string Coreografia { get; set; }
        public string Subgenero { get; set; }
        public string Categoria { get; set; }

        public EventoFestivalDanca(string codigoGrupo, string nomeGrupo, string coreografia, string subgenero, string categoria)
        {
            this.CodigoGrupo = codigoGrupo;
            this.NomeGrupo = nomeGrupo;
            this.Coreografia = coreografia;
            this.Subgenero = subgenero;
            this.Categoria = categoria;
        }
    }
}