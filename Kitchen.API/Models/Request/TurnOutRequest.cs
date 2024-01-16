using Kitchen.API.Models.CreateRequest;

namespace Kitchen.API.Models.Request
{
    /// <summary>
    /// Сущность добавления явки
    /// </summary>
    public class TurnOutRequest : CreateTurnOutRequestModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
