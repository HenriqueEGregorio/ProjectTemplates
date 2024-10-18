using TemplateDapper.Api.Domain.Entities;
using TemplateDapper.Api.Domain.Interfaces;
using TemplateDapper.Api.Infrastucture.Repositories.Generics;

namespace TemplateDapper.Api.Infrastucture.Repositories;

public class UserEntityRepository : CrudGenericRepository<UserEntity>, IUserEntityRepository
{
    public UserEntityRepository(
        IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    protected override string InsertQuery => throw new NotImplementedException();

    protected override string InsertQueryReturnInserted => throw new NotImplementedException();

    protected override string UpdateByIdQuery => throw new NotImplementedException();

    protected override string DeleteByIdQuery => throw new NotImplementedException();

    protected override string SelectByIdQuery => throw new NotImplementedException();

    protected override string SelectAllQuery => throw new NotImplementedException();
}
