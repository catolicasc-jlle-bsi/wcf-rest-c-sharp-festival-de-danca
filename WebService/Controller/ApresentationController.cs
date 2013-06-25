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
        public Apresentation Current(DateTime current)
        {
            try
            {
                var query = _database.AsQueryable<Apresentation>();
                return (from q in query
                        where q.StartDate <= current &&
                        q.FinishDate >= current &&
                        q.FinishVote >= current
                        select q).LastOrDefault();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Apresentation> History(DateTime interval)
        {
            try
            {
                var query = _database.AsQueryable<Apresentation>();
                return (from q in query
                        where q.StartDate <= interval &&
                        q.FinishDate >= interval
                        select q).ToList<Apresentation>();
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
