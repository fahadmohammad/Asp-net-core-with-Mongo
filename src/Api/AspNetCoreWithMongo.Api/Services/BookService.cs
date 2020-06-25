using AspNetCoreWithMongo.Api.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithMongo.Api.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;
        public BookService(IDbSettings dbSettings)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);

            _books = database.GetCollection<Book>(dbSettings.CollectionName);
        }

        public List<Book> Get() =>
            _books.Find(book => true).ToList();
        public Book Get(string id) =>
            _books.Find(book => book.Id == id).FirstOrDefault();
        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }
        public void Update(string id, Book bookToUpdate) =>
            _books.ReplaceOne(book => book.Id == id, bookToUpdate);
        public void Remove(Book bookToRemove) =>
            _books.DeleteOne(book => book.Id == bookToRemove.Id);
        public void Remove(string id) =>
            _books.DeleteOne(book => book.Id == id);

    }
}
