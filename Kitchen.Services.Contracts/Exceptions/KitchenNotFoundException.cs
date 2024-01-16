namespace Kitchen.Services.Contracts.Exceptions
{
    public class KitchenNotFoundException : KitchenException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="KitchenNotFoundException"/> с указанием
        /// сообщения об ошибке
        /// </summary>
        public KitchenNotFoundException(string message)
            : base(message)
        { }
    }
}
