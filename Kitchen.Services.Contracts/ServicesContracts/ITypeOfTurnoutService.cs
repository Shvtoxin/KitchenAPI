using Kitchen.Services.Contracts.Models;

namespace Kitchen.Services.Contracts.ServicesContracts
{
    /// <summary>
    /// Сервис <see cref="TypeOfTurnoutModel"/>
    /// </summary>
    public interface ITypeOfTurnoutService
    {
        /// <summary>
        /// Получить список всех <see cref="TypeOfTurnoutModel"/>
        /// </summary>
        Task<IEnumerable<TypeOfTurnoutModel>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="TypeOfTurnoutModel"/> по идентификатору
        /// </summary>
        Task<TypeOfTurnoutModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новый <see cref="TypeOfTurnoutModel"/>
        /// </summary>
        Task<TypeOfTurnoutModel> AddAsync(TypeOfTurnoutModel model, CancellationToken cancellationToken);

        /// <summary>
        /// Редактирует существующий <see cref="TypeOfTurnoutModel"/>
        /// </summary>
        Task<TypeOfTurnoutModel> EditAsync(TypeOfTurnoutModel source, CancellationToken cancellationToken);

        /// <summary>
        /// Удаляет существующий <see cref="TypeOfTurnoutModel"/>
        /// </summary>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

    }
}
