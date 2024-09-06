namespace TemplateEntity.Api.Domain.Pagination;

public class Pagination<T> : IPagination<T> where T : class
{
    public int TotalResults { get; private set; }
    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }
    public int PageSize { get; private set; }
    public bool HasPreviousPage
    {
        get
        {
            return PageIndex > 1;
        }
    }

    public bool HasNextPage
    {
        get
        {
            return PageIndex < TotalPages;
        }
    }

    public List<T> Result { get; private set; } = new List<T>();

    public Pagination(List<T> items, int count, int pageIndex = Constants.ApplicationDefaults.INITIAL_PAGE, int pageSize = Constants.ApplicationDefaults.MAX_RESULTS)
    {
        TotalResults = count;
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (decimal)pageSize);
        PageSize = pageSize;

        this.Result.AddRange(items);
    }
}
