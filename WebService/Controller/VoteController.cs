using BusinessObject.Voting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Helper;
using Db4objects.Db4o.Linq;

namespace WebService.Controller
{
    public class VoteController : BasicOperations
    {

        private bool IsValid(Vote vote)
        {
            /*
            var query = _database.AsQueryable<Vote>();
            var valid = (from q in query
                         where q.Apresentation.Equals(vote.Apresentation)
                         select q);
            */
            return true;
        }

        public void Save(Vote vote)
        {
            if (IsValid(vote))
                base.Save(vote);
        }
    }
}