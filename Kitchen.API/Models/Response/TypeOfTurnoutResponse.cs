namespace Kitchen.API.Models.Reqsponse
{
    /// <summary>
    /// Модель ответа типа явки
    /// </summary>
    public class TypeOfTurnoutResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

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
