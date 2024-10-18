namespace TemplateDapper.Api.Domain.Filters;

public interface IDefaultFilter
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}
