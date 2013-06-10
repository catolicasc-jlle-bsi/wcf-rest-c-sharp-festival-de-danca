using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;

namespace WebService.Helper
{
    public class BasicOperations
    {
        public IObjectContainer _database = Session.Current.Database;

        public void Save(object x)
        {
            _database.Store(x);
        }

        public void Delete(object x)
        {
            _database.Delete(x);
        }

        public T Single<T>()
        {
            IQueryable<T> query = _database.AsQueryable<T>();
            return (from q in query
                    select q).SingleOrDefault<T>();
        }

        public IEnumerable<T> SelectAll<T>()
        {
            IQueryable<T> query = _database.AsQueryable<T>();
            return (from q in query
                    select q).AsEnumerable<T>();
        }

        public T First<T>()
        {
            IQueryable<T> query = _database.AsQueryable<T>();
            return (from q in query
                    select q).FirstOrDefault<T>();
        }

        public T Last<T>()
        {
            IQueryable<T> query = _database.AsQueryable<T>();
            return (from q in query
                    select q).LastOrDefault<T>();
        }
    }
}
