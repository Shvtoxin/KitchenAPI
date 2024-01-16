using Kitchen.Context.Contracts.Models;

namespace Kitchen.Repositories.Contracts.ReadRepositoriesContracts
{
    /// <summary>
    /// Репозиторий чтения <see cref="Cuisine"/>
    /// </summary>
    public interface ICuisineReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Cuisine"/>
        /// </summary>
        Task<IReadOnlyCollection<Cuisine>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Cuisine"/> по идентификатору
        /// </summary>
        Task<Cuisine?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Cuisine"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, Cuisine>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);
    }
}
