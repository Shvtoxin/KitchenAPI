using Kitchen.Common.Entity.InterfaceDB;
using Kitchen.Context.Contracts.Models;
using Kitchen.Repositories.Anchors;
using Kitchen.Repositories.Contracts.WriteRepositoriesContracts;

namespace Kitchen.Repositories.WriteRepositoriеs
{
    /// <summary>
    /// Реализация <see cref="ITypeOfTurnoutWriteRepository"/>
    /// </summary>
    public class TypeOfTurnoutWriteRepository : BaseWriteRepository<TypeOfTurnout>, ITypeOfTurnoutWriteRepository, IRepositoryAnchor
    {
        public TypeOfTurnoutWriteRepository(IDbWriterContext writerContext) 
            : base(writerContext)
        {

        }
    }
}
