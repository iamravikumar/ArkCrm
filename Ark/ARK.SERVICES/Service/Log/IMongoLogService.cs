using ARK.MODEL.V1.Domain.Log;
using MongoDB.Driver;

namespace ARK.SERVICES.Service.Log
{
    public interface IMongoLogService : IService
    {
        void InsertWebLog(LogEntity entity);
        void InsertMobilLog(LogEntity entity);
        void InsertServiceLog(LogEntity entity);
    }
}
