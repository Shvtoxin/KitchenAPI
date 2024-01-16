using Kitchen.Common.Entity.InterfaceDB;
using Kitchen.Common.Entity.Repositories;
using Kitchen.Context.Contracts.Models;
using Kitchen.Repositories.Anchors;
using Kitchen.Repositories.Contracts.ReadRepositoriesContracts;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Repositories.ReadRepositories
{
    /// <summary>
    /// Реализация <see cref="IPostReadRepository"/>
    /// </summary>
    public class CinemaReadRepository : IPostReadRepository, IRepositoryAnchor
    {
        /// <summary>
        /// Reader для связи с бд
        /// </summary>
        private IDbRead reader;

        public CinemaReadRepository(IDbRead reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<Post>> IPostReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Post>()
                .NotDeletedAt()
                .OrderBy(x=> x.Title)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<Post?> IPostReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Post>()
                .ById(id)
                .NotDeletedAt()
                .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, Post>> IPostReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
            => reader.Read<Post>()
                .ByIds(ids)
                .NotDeletedAt()
                .OrderBy(x => x.Title)
                .ToDictionaryAsync(x => x.Id, cancellationToken);
    }
}
