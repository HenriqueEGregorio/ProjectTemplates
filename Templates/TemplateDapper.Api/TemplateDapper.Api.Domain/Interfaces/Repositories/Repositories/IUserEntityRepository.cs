using TemplateDapper.Api.Domain.Interfaces.Entities;
using TemplateDapper.Api.Domain.Interfaces.Repositories.Generics;

namespace TemplateDapper.Api.Domain.Interfaces.Repositories.Repositories;

public interface IUserEntityRepository<T> : IGenericRepository<T> where T : class, IDefaultEntity
{

}
