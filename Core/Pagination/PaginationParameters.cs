namespace Core.Pagination
{
    public class PaginationParameters
    {
        private const int MaxPageSize = 25;
        public int PageNumber { get; set; }
        private int _pageSize;
        public int PageSize 
        { 
          get => _pageSize; 
          set => _pageSize = value > MaxPageSize ? MaxPageSize : value; 
        }
    }
}
