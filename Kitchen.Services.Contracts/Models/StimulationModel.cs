namespace Kitchen.Services.Contracts.Models
{
    /// <summary>
    /// Модель стимуляции для сотрудников
    /// </summary>
    public class StimulationModel
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
