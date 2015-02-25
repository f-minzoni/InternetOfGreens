using InternetOfGreens.Domain;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetOfGreens.Data
{
    public abstract class MongoRepository<TObject> where TObject : MongoEntity
    {
        private MongoCollection collection;

        public MongoRepository(string collectionName)
        {
            var client = new MongoClient("mongodb://localhost");
            var server = client.GetServer();
            var database = server.GetDatabase("iog");
            collection = database.GetCollection<TObject>(collectionName);
        }

        public IQueryable<TObject> All()
        {
            return collection.AsQueryable<TObject>();
        }

        public IQueryable<TObject> Filter(System.Linq.Expressions.Expression<Func<TObject, bool>> predicate)
        {
            return collection.AsQueryable<TObject>().Where(predicate);
        }

        public bool Contains(System.Linq.Expressions.Expression<Func<TObject, bool>> predicate)
        {
            return collection.AsQueryable<TObject>().Any(predicate);
        }

        public TObject Find(System.Linq.Expressions.Expression<Func<TObject, bool>> predicate)
        {
            return collection.AsQueryable<TObject>().FirstOrDefault(predicate);
        }

        public TObject Create(TObject t)
        {
            collection.Insert(t);
            return t;
        }

        public void Delete(TObject t)
        {
            var query = Query<TObject>.EQ(e => e.Id, t.Id);
            collection.Remove(query);
        }

        public void Update(TObject t)
        {
            collection.Save(t);
        }

        public int Count
        {
            get { return (int)collection.Count(); }
        }
    }
}
