using Kitchen.API.Models.CreateRequest;

namespace Kitchen.API.Models.Request
{
    /// <summary>
    /// Модель добавления стимуляции для сотрудников
    /// </summary>
    public class StimulationRequest : CreateStimulationRequestModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
