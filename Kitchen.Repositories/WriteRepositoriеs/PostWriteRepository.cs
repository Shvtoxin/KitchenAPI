using Kitchen.Common.Entity.InterfaceDB;
using Kitchen.Context.Contracts.Models;
using Kitchen.Repositories.Anchors;
using Kitchen.Repositories.Contracts.WriteRepositoriesContracts;

namespace Kitchen.Repositories.WriteRepositoriеs
{
    /// <summary>
    /// Реализация <see cref="IPostWriteRepository"/>
    /// </summary>
    public class PostWriteRepository : BaseWriteRepository<Post>, IPostWriteRepository, IRepositoryAnchor
    {
        public PostWriteRepository(IDbWriterContext writerContext) 
            : base(writerContext)
        {
            
        }
    }
}
