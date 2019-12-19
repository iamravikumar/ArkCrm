using System.Collections.Generic;

namespace ARK.CORE.Response
{
    /// <summary>
    /// Paged list interface
    /// </summary>
    public interface IPagedList<T> : IList<T>
    {
        /// <summary>
        /// Page index
        /// </summary>
        int PageNumber { get; }
        /// <summary>
        /// Page size
        /// </summary>
        int PageSize { get; }
        /// <summary>
        /// Total count
        /// </summary>
        int TotalCount { get; }
        /// <summary>
        /// Total pages
        /// </summary>
        int TotalPages { get; }
        /// <summary>
        /// Has previous page
        /// </summary>
        bool HasPreviousPage { get; }
        /// <summary>
        /// Has next age
        /// </summary>
        bool HasNextPage { get; }

    }
}
