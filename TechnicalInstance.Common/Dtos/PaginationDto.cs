namespace TechnicalInstance.Common.Dtos
{
    public class PaginationDto<TModel>
    {
        public PaginationDto()
        {
            Items = new List<TModel>();
        }

        const int MaxPageSize = 500;
        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public IList<TModel> Items { get; set; }        

    }
}
