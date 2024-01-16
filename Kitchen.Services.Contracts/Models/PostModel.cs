namespace Kitchen.Services.Contracts.Models
{
    /// <summary>
    /// Модель должности работника
    /// </summary>
    public class PostModel
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
        /// Оплата в час
        /// </summary>
        public decimal PayPerHour { get; set; }
    }
}
