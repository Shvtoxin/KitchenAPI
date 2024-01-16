namespace Kitchen.Services.Contracts.Exceptions
{
    public class KitchenEntityNotFoundException<TEntity> : KitchenNotFoundException
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="KitchenEntityNotFoundException{TEntity}"/>
        /// </summary>
        public KitchenEntityNotFoundException(Guid id)
            : base($"Сущность {typeof(TEntity)} c id = {id} не найдена.")
        {
        }
    }
}
