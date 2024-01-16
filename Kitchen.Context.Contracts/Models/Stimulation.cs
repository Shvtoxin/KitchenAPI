namespace Kitchen.Context.Contracts.Models
{
    /// <summary>
    /// Сущность стимуляции для сотрудников
    /// </summary>
    public class Stimulation : BaseAuditEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Описание бонуса
        /// </summary>
        public string Description { get; set; } = string.Empty;

        public ICollection<TurnOut>? TurnOuts { get; set;}
    }
}
