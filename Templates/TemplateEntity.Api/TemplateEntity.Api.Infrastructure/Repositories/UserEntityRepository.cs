using TemplateEntity.Api.Domain.Entities;
using TemplateEntity.Api.Domain.Interfaces.Repositories;
using TemplateEntity.Api.Infrastructure.Data;
using TemplateEntity.Api.Infrastructure.Repositories.Generics;

namespace TemplateEntity.Api.Infrastructure.Repositories;

public class UserEntityRepository : CrudGenericRepository<Domain.Entities.UserEntity> , IUserEntityRepository
{
    public UserEntityRepository(Context context) : base(context)
    {
    }
}
