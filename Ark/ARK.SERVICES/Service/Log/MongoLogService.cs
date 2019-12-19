using ARK.MODEL.V1.Configuration;
using ARK.MODEL.V1.Domain.Log;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace ARK.SERVICES.Service.Log
{
    public class MongoLogService : IMongoLogService
    {
        private WeblogConfiguration Config { get; }

        public MongoLogService(IOptions<WeblogConfiguration> options)
        {
            Config = options.Value;
        }

        public void InsertWebLog(LogEntity entity)
        {
            try
            {
                var asd = GetMongoDbDatabase("Web_Log");
                asd.InsertOne(entity);
            }
            catch (Exception ex)
            {
                entity.Exception = ex.Message;
                //_log.InsertOne(entity);
            }
        }

        public void InsertMobilLog(LogEntity entity)
        {
            try
            {
                var asd = GetMongoDbDatabase("Mobil_Log");
                asd.InsertOne(entity);
            }
            catch (Exception ex)
            {
                entity.Exception = ex.Message;
                //_log.InsertOne(entity);
            }
        }

        public void InsertServiceLog(LogEntity entity)
        {
            try
            {
                var asd = GetMongoDbDatabase("Service_Log");
                asd.InsertOne(entity);
            }
            catch (Exception ex)
            {
                entity.Exception = ex.Message;
                //_log.InsertOne(entity);
            }
        }

        private IMongoCollection<LogEntity> GetMongoDbDatabase(string collectionName)
        {
            try
            {
                string dbPath = Config.MongoDbConnection;
                var client = new MongoClient(dbPath);
                var database = client.GetDatabase("ark_log");
                return database.GetCollection<LogEntity>(collectionName);
            }
            catch (Exception ex)
            {
                throw;
            }            
        }
    }
}
