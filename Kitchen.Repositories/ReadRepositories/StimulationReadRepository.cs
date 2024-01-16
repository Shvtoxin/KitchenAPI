using Kitchen.Common.Entity.InterfaceDB;
using Kitchen.Common.Entity.Repositories;
using Kitchen.Context.Contracts.Models;
using Kitchen.Repositories.Anchors;
using Kitchen.Repositories.Contracts.ReadRepositoriesContracts;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Repositories.ReadRepositories
{
    /// <summary>
    /// Реализация <see cref="IStimulationReadRepository"/>
    /// </summary>
    public class StimulationReadRepository : IStimulationReadRepository, IRepositoryAnchor
    {
        /// <summary>
        /// Контекст для связи с бд
        /// </summary>
        private IDbRead reader;

        public StimulationReadRepository(IDbRead reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<Stimulation>> IStimulationReadRepository.GetAllAsync(CancellationToken cancellationToken) 
            => reader.Read<Stimulation>()
                .NotDeletedAt()
                .OrderBy(x => x.Title)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<Stimulation?> IStimulationReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken) 
            => reader.Read<Stimulation>()
                .ById(id)
                .NotDeletedAt()
                .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, Stimulation>> IStimulationReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken) 
            => reader.Read<Stimulation>()
                .ByIds(ids)
                .NotDeletedAt()
                .OrderBy(x => x.Title)
                .ToDictionaryAsync(x => x.Id, cancellationToken);
    }
}
