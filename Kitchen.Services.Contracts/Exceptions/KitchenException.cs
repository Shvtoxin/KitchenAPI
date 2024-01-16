namespace Kitchen.Services.Contracts.Exceptions
{
    public abstract class KitchenException : Exception
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="KitchenException"/> без параметров
        /// </summary>
        protected KitchenException() { }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="KitchenException"/> с указанием
        /// сообщения об ошибке
        /// </summary>
        protected KitchenException(string message)
            : base(message) { }
    }
}
