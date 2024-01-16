using Kitchen.Common.Entity.InterfaceDB;
using Kitchen.Context.Contracts.Models;
using Kitchen.Repositories.Anchors;
using Kitchen.Repositories.Contracts.WriteRepositoriesContracts;

namespace Kitchen.Repositories.WriteRepositoriеs
{
    /// <summary>
    /// Реализация <see cref="ITurnOutWriteRepository"/>
    /// </summary>
    public class TurnOutWriteRepository : BaseWriteRepository<TurnOut>, ITurnOutWriteRepository, IRepositoryAnchor
    {
        public TurnOutWriteRepository(IDbWriterContext writerContext) 
            : base(writerContext)
        {
            
        }
    }
}
