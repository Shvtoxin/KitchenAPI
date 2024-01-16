using Kitchen.Common.Entity.InterfaceDB;
using Kitchen.Common.Entity.Repositories;
using Kitchen.Context.Contracts.Models;
using Kitchen.Repositories.Anchors;
using Kitchen.Repositories.Contracts.ReadRepositoriesContracts;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Repositories.ReadRepositories
{
    /// <summary>
    /// Реализация <see cref="ITypeOfTurnoutReadRepository"/>
    /// </summary>
    public class TypeOfTurnoutReadRepository : ITypeOfTurnoutReadRepository, IRepositoryAnchor
    {
        /// <summary>
        /// Контекст для связи с бд
        /// </summary>
        private IDbRead reader;

        public TypeOfTurnoutReadRepository(IDbRead reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<TypeOfTurnout>> ITypeOfTurnoutReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<TypeOfTurnout>()
                .NotDeletedAt()
                .OrderBy(x => x.Title)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<TypeOfTurnout?> ITypeOfTurnoutReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<TypeOfTurnout>()
                .ById(id)
                .NotDeletedAt()
                .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, TypeOfTurnout>> ITypeOfTurnoutReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
            => reader.Read<TypeOfTurnout>()
                .NotDeletedAt()
                .ByIds(ids)
                .OrderBy(x => x.Title).ToDictionaryAsync(x => x.Id, cancellationToken);
    }
}