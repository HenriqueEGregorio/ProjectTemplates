using TemplateEntity.Api.Domain.Entities;
using TemplateEntity.Api.Domain.Interfaces.Repositories.Generics;

namespace TemplateEntity.Api.Domain.Interfaces.Repositories;

public interface IUserEntityRepository : IDefaultRepository<Domain.Entities.UserEntity>
{
}
