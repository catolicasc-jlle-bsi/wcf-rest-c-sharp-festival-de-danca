using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Helper;
using Db4objects.Db4o.Linq;
using BusinessObject.Voting;

namespace WebService.Controller
{
    public class ApresentationController : BasicOperations
    {
        public Apresentation Select(DateTime current)
        {
            var query = _database.AsQueryable<Apresentation>();
            var apresentation = (from q in query
                                 where q.StartDate <= current &&
                                 q.FinishDate >= current &&
                                 q.FinishVote >= current
                                 select q).LastOrDefault();

            // Implementar Exception específica
            if (apresentation == null) { throw new Exception(); };

            return apresentation;
        }

        public List<Apresentation> SelectAll(DateTime interval)
        {
            var query = _database.AsQueryable<Apresentation>();
            var presentations = (from q in query
                                 where q.StartDate <= interval &&
                                 q.FinishDate >= interval
                                 select q).ToList<Apresentation>();

            // Implementar Exception específica
            if (presentations == null) { throw new Exception(); };

            return presentations;
        }
    }
}