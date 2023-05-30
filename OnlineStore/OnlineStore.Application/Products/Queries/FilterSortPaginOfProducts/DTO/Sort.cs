namespace OnlineStore.Application.Products.Queries.FilterSortPaginOfProducts.DTO
{
    public class Sort
    {
        public SortState NameSort { get; set; }
        public SortState PriceSort { get; set; }
        public SortState Current { get; set; }

        public Sort(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            PriceSort = sortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            Current = sortOrder;
        }
    }
}
