using ARK.CORE.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ARK.CORE.Response
{
    public class ServiceResponse<R>
    {
        public short Code { get; set; }
        public int PageNumber;
        public int PageSize;
        public int TotalCount;
        public int TotalPages;
        public bool HasNextPage;
        public bool HasPreviousPage;
        public bool IsSuccessful { get; set; }
        public Exception Exception { get; set; }
        public ServiceError Error { get; }
        public string Message { get; set; }
        public List<R> ListData { get; set; }
        public R Data { get; set; }

        public ServiceResponse()
        {
            IsSuccessful = true;
            Message = "Başarılı";
            Code = 100;
        }

        public ServiceResponse(Exception ex)
        {
            IsSuccessful = false;
            Message = ex.Message;
            Code = -100;
        }
        public ServiceResponse(ServiceError error, bool isSuccessful, short code, string message)
        {
            Error = error;
            IsSuccessful = isSuccessful;
            Message = message;
            Code = code;
        }

        public ServiceResponse(bool isSuccessful, short code, string message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
            Code = code;
        }

        public ServiceResponse(R dataa, bool isSuccessful, short code, string message)
        {
            Data = dataa;
            IsSuccessful = isSuccessful;
            Code = code;
            Message = message;
        }

        public ServiceResponse(List<R> dataa, bool isSuccessful, short code, string message)
        {
            ListData = dataa;
            IsSuccessful = isSuccessful;
            Code = code;
            Message = message;
        }

        public ServiceResponse(R dataa,
            int pageNumber, int pageSize, int totalCount,
            int totalPages, bool hasNextPage, bool hasPreviousPage,
            bool isSuccessful, short code, string message)
        {
            Data = dataa;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = totalPages;
            HasNextPage = hasNextPage;
            HasPreviousPage = hasPreviousPage;
            IsSuccessful = isSuccessful;
            Message = message;
            Code = code;
        }

        public ServiceResponse(List<R> dataa,
            int pageNumber, int pageSize, int totalCount,
            int totalPages, bool hasNextPage, bool hasPreviousPage,
            bool isSuccessful, short code, string message)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = totalPages;
            HasNextPage = hasNextPage;
            HasPreviousPage = hasPreviousPage;
            ListData = dataa;
            IsSuccessful = isSuccessful;
            Message = message;
            Code = code;
        }

        public ServiceResponse(PagedList<R> dataa,
            int pageNumber, int pageSize, int totalCount,
            int totalPages, bool hasNextPage, bool hasPreviousPage,
            bool isSuccessful, short code, string message)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = totalPages;
            HasNextPage = hasNextPage;
            HasPreviousPage = hasPreviousPage;
            ListData = dataa;
            IsSuccessful = isSuccessful;
            Message = message;
            Code = code;
        }

        
    }

    public class ServiceError
    {
        public ServiceError(string code, string description)
        {
            Code = code;
            Description = description;
        }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}