namespace Kitchen.API.Models.CreateRequest
{
    /// <summary>
    /// Модель добавления должности работника
    /// </summary>
    public class CreatePostRequestModel
    {
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
