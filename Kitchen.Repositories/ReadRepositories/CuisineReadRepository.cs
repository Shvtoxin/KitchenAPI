using Kitchen.Common.Entity.InterfaceDB;
using Kitchen.Common.Entity.Repositories;
using Kitchen.Context.Contracts.Models;
using Kitchen.Repositories.Anchors;
using Kitchen.Repositories.Contracts.ReadRepositoriesContracts;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Repositories.ReadRepositories
{
    /// <summary>
    /// Реализация <see cref="ICuisineReadRepository"/>
    /// </summary>
    public class CuisineReadRepository : ICuisineReadRepository, IRepositoryAnchor
    {
        /// <summary>
        /// Контекст для связи с бд
        /// </summary>
        private IDbRead reader;

        public CuisineReadRepository(IDbRead reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<Cuisine>> ICuisineReadRepository.GetAllAsync(CancellationToken cancellationToken) 
            => reader.Read<Cuisine>()
                .NotDeletedAt()
                .OrderBy(x => x.Title)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<Cuisine?> ICuisineReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken) 
            => reader.Read<Cuisine>()
                .ById(id)
                .NotDeletedAt()
                .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, Cuisine>> ICuisineReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken) 
            => reader.Read<Cuisine>()
                .NotDeletedAt()
                .ByIds(ids)
                .OrderBy(x => x.Title)
                .ToDictionaryAsync(x => x.Id, cancellationToken);
    }
}
