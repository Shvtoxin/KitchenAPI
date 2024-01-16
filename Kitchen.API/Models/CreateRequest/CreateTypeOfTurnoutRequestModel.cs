namespace Kitchen.API.Models.CreateRequest
{
    /// <summary>
    /// Сущность добавления типа явки
    /// </summary>
    public class CreateTypeOfTurnoutRequestModel
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }
    }
}
