namespace Kitchen.API.Models.Reqsponse
{
    /// <summary>
    /// Модель ответа стимуляции для сотрудников
    /// </summary>
    public class StimulationResponse
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
        /// Описание бонуса
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
