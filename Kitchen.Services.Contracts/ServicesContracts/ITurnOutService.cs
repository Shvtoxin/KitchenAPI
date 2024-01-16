using Kitchen.Services.Contracts.Models;
using Kitchen.Services.Contracts.ModelsRequest;

namespace Kitchen.Services.Contracts.ServicesContracts
{
    /// <summary>
    /// Сервис <see cref="TurnOutModel"/>
    /// </summary>
    public interface ITurnOutService
    {
        /// <summary>
        /// Получить список всех <see cref="TurnOutModel"/>
        /// </summary>
        Task<IEnumerable<TurnOutModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="TurnOutModel"/> по идентификатору
        /// </summary>
        Task<TurnOutModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новый <see cref="TurnOurRequestModel"/>
        /// </summary>
        Task<TurnOutModel> AddAsync(TurnOurRequestModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующий <see cref="TurnOurRequestModel"/>
        /// </summary>
        Task<TurnOutModel> EditAsync(TurnOurRequestModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующий<see cref="TurnOutModel"/>
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
