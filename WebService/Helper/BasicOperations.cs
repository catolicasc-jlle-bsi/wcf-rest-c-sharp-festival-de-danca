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
            try
            {
                _database.Store(x);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void Delete(object x)
        {
            try
            {
                _database.Delete(x);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public T Single<T>()
        {
            try
            {
                IQueryable<T> query = _database.AsQueryable<T>();
                return (from q in query
                        select q).SingleOrDefault<T>();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public IEnumerable<T> SelectAll<T>()
        {
            try
            {
                IQueryable<T> query = _database.AsQueryable<T>();
                return (from q in query
                        select q).AsEnumerable<T>();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public T First<T>()
        {
            try
            {
                IQueryable<T> query = _database.AsQueryable<T>();
                return (from q in query
                        select q).FirstOrDefault<T>();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public T Last<T>()
        {
            try
            {
                IQueryable<T> query = _database.AsQueryable<T>();
                return (from q in query
                        select q).LastOrDefault<T>();
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
