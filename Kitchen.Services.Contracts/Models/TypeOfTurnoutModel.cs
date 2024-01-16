namespace Kitchen.Services.Contracts.Models
{
    /// <summary>
    /// Сущность типа явки
    /// </summary>
    public class TypeOfTurnoutModel
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
