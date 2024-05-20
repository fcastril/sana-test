using Sana.Backend.Domain.Common.Enums;

namespace Sana.Backend.Domain.Common
{
    public class Paginate<T> where T : class, new()
    {
        public int Count { get; set; }

        public int Page { get; set; }

        public List<FilterPaginate>? Filters { get; set; }

        public List<OrderPaginate>? Orders { get; set; }

        public int RowsTotal { get; set; }

        public int PagesTotal { get; set; }

        public List<T> Data { get; set; }
    }
    public class FilterPaginate
    {
        public string Property { get; set; } =string.Empty;

        public object Value { get; set; }  =string.Empty ;

        public Operations Operator { get; set; }

        public LogicalOperators Conditional { get; set; }
    }
    public class OrderPaginate
    {
        public string Name { get; set; } = string.Empty;


        public string Direction { get; set; }   = string.Empty;
    }
}
