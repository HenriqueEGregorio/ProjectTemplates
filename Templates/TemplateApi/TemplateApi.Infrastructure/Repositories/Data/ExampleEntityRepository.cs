using TemplateApi.Domain.Entities;
using TemplateApi.Domain.Interfaces.Repository.Repositories;
using TemplateApi.Infrastructure.Data;
using TemplateApi.Infrastructure.Repositories.Generics;

namespace TemplateApi.Infrastructure.Repositories.Data
{
    public class ExampleEntityRepository : EntityGenericRepository<ExampleEntity>, IExampleEntityRepository
    {
        public ExampleEntityRepository(Context context) : base(context)
        {
        }
    }
}
