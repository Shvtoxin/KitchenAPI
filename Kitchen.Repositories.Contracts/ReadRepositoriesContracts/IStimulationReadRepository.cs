using Kitchen.Context.Contracts.Models;

namespace Kitchen.Repositories.Contracts.ReadRepositoriesContracts
{
    /// <summary>
    /// Репозиторий чтения <see cref="Stimulation"/>
    /// </summary>
    public interface IStimulationReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Stimulation"/>
        /// </summary>
        Task<IReadOnlyCollection<Stimulation>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Stimulation"/> по идентификатору
        /// </summary>
        Task<Stimulation?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Stimulation"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, Stimulation>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);
    }
}
