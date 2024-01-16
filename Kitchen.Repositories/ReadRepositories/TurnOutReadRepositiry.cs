using Kitchen.Common.Entity.InterfaceDB;
using Kitchen.Common.Entity.Repositories;
using Kitchen.Context.Contracts.Models;
using Kitchen.Repositories.Anchors;
using Kitchen.Repositories.Contracts.ReadRepositoriesContracts;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Repositories.ReadRepositories
{
    /// <summary>
    /// Реализация <see cref="ITurnOutReadRepository"/>
    /// </summary>
    public class TurnOutReadRepositiry : ITurnOutReadRepository, IRepositoryAnchor
    {
        /// <summary>
        /// Контекст для связи с бд
        /// </summary>
        private IDbRead reader;

        public TurnOutReadRepositiry(IDbRead reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<TurnOut>> ITurnOutReadRepository.GetAllAsync(CancellationToken cancellationToken)     
            =>reader.Read<TurnOut>()
                .NotDeletedAt()
                .OrderBy(x => x.OpeningTime)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<TurnOut?> ITurnOutReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken) 
            => reader.Read<TurnOut>()
                .ById(id)
                .NotDeletedAt()
                .FirstOrDefaultAsync(cancellationToken);
    }
}
