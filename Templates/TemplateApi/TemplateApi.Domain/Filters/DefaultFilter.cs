using TemplateApi.Domain.Interfaces.Filters;

namespace TemplateApi.Domain.Filters;

public class DefaultFilter : IDefaultFilter
{
    public virtual int PageIndex { get; set; } = Constants.ApplicationDefaults.INITIAL_PAGE;
    public virtual int PageSize { get; set; } = Constants.ApplicationDefaults.MAX_RESULTS;
}
