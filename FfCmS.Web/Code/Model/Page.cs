using System.Collections.Generic;

namespace FfCmS.Code.Model
{
    public class Page<TData> : List<TData>
    {
        public Page()
        {
        }
        public Page(int pageNumber, int pageSize, int totalResultSetSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Hits = totalResultSetSize;
        }

        public Page(int pageNumber, int pageSize, int totalResultSetSize, IEnumerable<TData> initialPayload)
            : this(pageNumber, pageSize, totalResultSetSize)
        {
            AddRange(initialPayload);
        }

        public int Hits { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int TotalPageCount
        {
            get
            {
                if (Hits == 0)
                    return 1;

                if (PageSize == 0)
                    return 1;

                if (Hits <= PageSize)
                    return 1;

                var totalPages = Hits / PageSize;
                if ((Hits % PageSize) > 0)
                {
                    totalPages += 1;
                }

                return totalPages;
            }
        }
    }
}