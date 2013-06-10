using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebService.Helper;
using Db4objects.Db4o;
using System.IO;
using BusinessObject.Voting;
using WebService.Model;
using Db4objects.Db4o.Linq;
using WebService.Controller;

namespace WebService.Helper
{
    public class Seeds : BasicOperations
    {
        /// <summary>
        /// Padrão da url
        /// </summary>
        private string _address = @"http://www.ifdj.com.br/2013/selecao/resultados/mostra-competitiva-{0}-2013.html";

        /// <summary>
        /// Gêneros disponíveis na url http://www.ifdj.com.br/2013/
        /// </summary>
        private static List<string> _genres = new List<string>()
        {
            "bale-classico",
            "bale-classico-de-repertorio",
            "danca-contemporanea",
            "dancas-populares",
            "dancas-urbanas",
            "jazz",
            "sapateado",
        };

        /// <summary>
        /// Classe responsável por popular dados prévios
        /// </summary>
        public Seeds()
        {
            //if (!File.Exists(ConnectionDBFactory.PATH)) { return; }

            // Garante que faça apenas na primeira sincronização
            var eventos = new BasicOperations().SelectAll<EventoFestivalDanca>();
            if (eventos.FirstOrDefault() == null)
            {
                Initialize();
                Converting();
            }

            //Debug();
        }

        private void Debug()
        {
            var apresentation = new ApresentationController().First<Apresentation>();
            apresentation.StartDate = DateTime.Now;

            DateTime finish = DateTime.Now;

            // A apresentação tem duração de 30 minutos
            finish = finish.AddMinutes(30);

            apresentation.FinishDate = finish;

            // Tem até 15 min após o término da votação para poder votar
            finish = finish.AddMinutes(15);

            apresentation.FinishVote = finish;

            Save(apresentation);
        }

        #region [ Coleta de dados puros da página http://www.ifdj.com.br/ do festival de dança ]

        private void Initialize()
        {
            IList<EventoFestivalDanca> eventos = new List<EventoFestivalDanca>();
            foreach (var genre in _genres)
            {
                try
                {
                    string pagina = Session.Current.Internet.Down(string.Format(_address, genre));
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(pagina);

                    var results = doc.DocumentNode
                        .Descendants("td")
                        .Select(s => s.InnerText);

                    var colector = new List<string>();

                    // A partir da 17ª linha, buscar os dados
                    var content = results.Skip(17);

                    int control = 0;
                    foreach (var data in content)
                    {
                        colector.Add(data);
                        if (control == 5)
                        {
                            eventos.Add(new EventoFestivalDanca(colector[0], colector[1], colector[2], colector[3], colector[4]));
                            colector.Clear();
                            control = 0;
                        }
                        else
                        {
                            control++;
                        }
                    }
                }
                catch (Exception) { }

                eventos.ToList().ForEach(e => _database.Store(e));
            }
        }

        #endregion

        #region [ Cast para o object Apresentation ]

        private void Converting()
        {
            var presentations = new List<Apresentation>();
            var eventos = new BasicOperations().SelectAll<EventoFestivalDanca>();

            eventos.ToList().ForEach(e => presentations.Add(
                new Apresentation
                {
                    Name = e.NomeGrupo,
                    Category = Cast(e.Categoria),
                }));

            presentations.ForEach(p => Save(p));
        }

        public Category Cast(string parameter)
        {
            return (parameter == null) ?
                new Category() :
                this.Valid(new Category() { Name = parameter, });
        }

        private Category Valid(Category parameter)
        {
            IQueryable<Category> query = _database.AsQueryable<Category>();
            var d = (from q in query
                     where q.Name == parameter.Name
                     select q).FirstOrDefault();

            return (d != null) ?
                d :
                parameter;
        }

        #endregion
    }
}
