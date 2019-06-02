using ILeilao.CrossCutting;
using ILeilao.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using System;
using System.Security.Authentication;

namespace ILeilao.Repository
{
    public class ILeilaoContext
    {
        public IMongoClient Client { get; set; }
        public IMongoDatabase MongoDatabase { get; set; }

        public ILeilaoContext(IOptions<DatabaseOptions> settings)
        {
            MongoClientSettings mongoSettings = MongoClientSettings.FromUrl(
                new MongoUrl(settings.Value.ConnectionString)
            );

            mongoSettings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            Client = new MongoClient(mongoSettings);
            MongoDatabase = Client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<T> Collection<T>(string collectionName)
        {
            return MongoDatabase.GetCollection<T>(collectionName);
        }

    }
}
