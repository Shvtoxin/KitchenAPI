using Kitchen.Services.Contracts.Models;

namespace Kitchen.Services.Contracts.ServicesContracts
{
    /// <summary>
    /// Сервис <see cref="StimulationModel"/>
    /// </summary>
    public interface IStimulationService
    {
        /// <summary>
        /// Получить список всех <see cref="StimulationModel"/>
        /// </summary>
        Task<IEnumerable<StimulationModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="StimulationModel"/> по идентификатору
        /// </summary>
        Task<StimulationModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новый <see cref="StimulationModel"/>
        /// </summary>
        Task<StimulationModel> AddAsync(StimulationModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующий <see cref="StimulationModel"/>
        /// </summary>
        Task<StimulationModel> EditAsync(StimulationModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующий <see cref="StimulationModel"/>
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

    }
}
