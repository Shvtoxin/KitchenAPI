using Kitchen.Context.Contracts.Models;

namespace Kitchen.Repositories.Contracts.ReadRepositoriesContracts
{
    /// <summary>
    /// Репозиторий чтения <see cref="Post"/>
    /// </summary>
    public interface IPostReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Post"/>
        /// </summary>
        Task<IReadOnlyCollection<Post>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Post"/> по идентификатору
        /// </summary>
        Task<Post?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Post"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, Post>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);
    }
}
