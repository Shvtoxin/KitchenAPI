using Kitchen.Context.Contracts.Models;

namespace Kitchen.Repositories.Contracts.ReadRepositoriesContracts
{
    /// <summary>
    /// Репозиторий чтения <see cref="TurnOut"/>
    /// </summary>
    public interface ITurnOutReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="TurnOut"/>
        /// </summary>
        Task<IReadOnlyCollection<TurnOut>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="TurnOut"/> по идентификатору
        /// </summary>
        Task<TurnOut?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
