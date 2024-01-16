namespace Kitchen.Context.Contracts.Models
{
    /// <summary>
    /// Сущность должности работника
    /// </summary>
    public class Post : BaseAuditEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Оплата в час
        /// </summary>
        public decimal PayPerHour { get; set; }

        public ICollection<Staff> Staffs { get; set; }
    }
}
