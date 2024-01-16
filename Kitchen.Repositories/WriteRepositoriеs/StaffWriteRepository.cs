using Kitchen.Common.Entity.InterfaceDB;
using Kitchen.Context.Contracts.Models;
using Kitchen.Repositories.Anchors;
using Kitchen.Repositories.Contracts.WriteRepositoriesContracts;

namespace Kitchen.Repositories.WriteRepositoriеs
{
    /// <summary>
    /// Реализация <see cref="IStaffWriteRepository"/>
    /// </summary>
    public class StaffWriteRepository : BaseWriteRepository<Staff>, IStaffWriteRepository, IRepositoryAnchor
    {
        public StaffWriteRepository(IDbWriterContext writerContext) 
            : base(writerContext)
        {
             
        }
    }
}
