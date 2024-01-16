using Kitchen.Common.Entity.InterfaceDB;
using Kitchen.Common.Entity.Repositories;
using Kitchen.Context.Contracts.Models;
using Kitchen.Repositories.Anchors;
using Kitchen.Repositories.Contracts.ReadRepositoriesContracts;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Repositories.ReadRepositories
{
    /// <summary>
    /// Реализация <see cref="IStaffReadRepository"/>
    /// </summary>
    public class StaffReadRepository : IStaffReadRepository, IRepositoryAnchor
    {
        /// <summary>
        /// Контекст для связи с бд
        /// </summary>
        private IDbRead reader;

        public StaffReadRepository(IDbRead reader)
        {
            this.reader = reader;
        }
        Task<IReadOnlyCollection<Staff>> IStaffReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Staff>()
                .NotDeletedAt()
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ThenBy(x => x.Patronymic)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<Staff?> IStaffReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken) 
            => reader.Read<Staff>()
                .ById(id)
                .NotDeletedAt()
                .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, Staff>> IStaffReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken) 
            => reader.Read<Staff>()
                .NotDeletedAt()
                .ByIds(ids)
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ThenBy(x => x.Patronymic)
                .ToDictionaryAsync(x => x.Id, cancellationToken);
    }
}
