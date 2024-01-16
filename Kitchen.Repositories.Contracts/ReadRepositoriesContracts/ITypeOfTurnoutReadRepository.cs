using Kitchen.Context.Contracts.Models;

namespace Kitchen.Repositories.Contracts.ReadRepositoriesContracts
{
    /// <summary>
    /// Репозиторий чтения <see cref="TypeOfTurnout"/>
    /// </summary>
    public interface ITypeOfTurnoutReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="TypeOfTurnout"/>
        /// </summary>
        Task<IReadOnlyCollection<TypeOfTurnout>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="TypeOfTurnout"/> по идентификатору
        /// </summary>
        Task<TypeOfTurnout?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="TypeOfTurnout"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, TypeOfTurnout>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);

    }
}
