namespace TemplateApi.Domain.Pagination;

public interface IPagination<T> where T : class
{
    public int TotalResults { get; }
    public int PageIndex { get; }
    public int TotalPages { get; }
    public int PageSize { get; }
    public bool HasPreviousPage { get; }
    public bool HasNextPage { get; }
    public List<T> Result { get; }
}
