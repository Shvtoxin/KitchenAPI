using Kitchen.Services.Contracts.Models;

namespace Kitchen.Services.Contracts.ServicesContracts
{
    /// <summary>
    /// Сервис <see cref="PostModel"/>
    /// </summary>
    public interface IPostService
    {
        /// <summary>
        /// Получить список всех <see cref="PostModel"/>
        /// </summary>
        Task<IEnumerable<PostModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="PostModel"/> по идентификатору
        /// </summary>
        Task<PostModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет нового <see cref="PostModel"/>
        /// </summary>
        Task<PostModel> AddAsync(PostModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующего <see cref="PostModel"/>
        /// </summary>
        Task<PostModel> EditAsync(PostModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующего <see cref="PostModel"/>
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
