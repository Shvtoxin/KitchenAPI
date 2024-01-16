using Kitchen.Common.Entity.InterfaceDB;
using Kitchen.Context.Contracts.Models;
using Kitchen.Repositories.Anchors;
using Kitchen.Repositories.Contracts.WriteRepositoriesContracts;

namespace Kitchen.Repositories.WriteRepositoriеs
{
    /// <summary>
    /// Реализация <see cref="ICuisineWriteRepository"/>
    /// </summary>
    public class CuisineWriteRepository : BaseWriteRepository<Cuisine>, ICuisineWriteRepository, IRepositoryAnchor
    {
        public CuisineWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {

        }
    }
}
