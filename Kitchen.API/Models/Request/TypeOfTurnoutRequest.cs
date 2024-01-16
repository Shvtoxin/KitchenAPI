using Kitchen.API.Models.CreateRequest;

namespace Kitchen.API.Models.Request
{
    /// <summary>
    /// Сущность добавления типа явки
    /// </summary>
    public class TypeOfTurnoutRequest : CreateTypeOfTurnoutRequestModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
