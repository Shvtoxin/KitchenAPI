namespace Kitchen.API.Models.Reqsponse
{
    /// <summary>
    /// Модель ответа должности работника
    /// </summary>
    public class PostResponse
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
