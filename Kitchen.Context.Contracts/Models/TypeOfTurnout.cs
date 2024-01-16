namespace Kitchen.Context.Contracts.Models
{
    /// <summary>
    /// Сущность типа явки
    /// </summary>
    public class TypeOfTurnout : BaseAuditEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }
        public ICollection<TurnOut> TurnOuts { get; set; }
    }
}
