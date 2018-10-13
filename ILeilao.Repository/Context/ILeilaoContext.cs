﻿using ILeilao.CrossCutting;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace ILeilao.Repository
{
    public class ILeilaoContext
    {
        public IMongoClient Client { get; set; }
        public IMongoDatabase MongoDatabase { get; set; }

        public ILeilaoContext(IOptions<DatabaseOptions> settings)
        {
            Client = new MongoClient(settings.Value.ConnectionString);
            MongoDatabase = Client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<T> Collection<T>(string collectionName)
        {
            return MongoDatabase.GetCollection<T>(collectionName);
        }
    }
}