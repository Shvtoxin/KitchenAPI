using Kitchen.Services.Contracts.Models;

namespace Kitchen.Services.Contracts.ServicesContracts
{
    /// <summary>
    /// Сервис <see cref="CuisineModel"/>
    /// </summary>
    public interface ICuisineService
    {
        /// <summary>
        /// Получить список всех <see cref="CuisineModel"/>
        /// </summary>
        Task<IEnumerable<CuisineModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="CuisineModel"/> по идентификатору
        /// </summary>
        Task<CuisineModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новый <see cref="CuisineModel"/>
        /// </summary>
        Task<CuisineModel> AddAsync(CuisineModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующий <see cref="CuisineModel"/>
        /// </summary>
        Task<CuisineModel> EditAsync(CuisineModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующий <see cref="CuisineModel"/>
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
