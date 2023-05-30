namespace OnlineStore.Application.Products.Queries.FilterSortPaginOfProducts.DTO
{
    public class Page
    {
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }

        public Page(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public bool HasPreviousPage => (PageNumber > 1);

        public bool HasNextPage => (PageNumber < TotalPages);
    }
}
