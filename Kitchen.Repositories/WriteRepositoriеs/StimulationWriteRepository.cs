using Kitchen.Common.Entity.InterfaceDB;
using Kitchen.Context.Contracts.Models;
using Kitchen.Repositories.Anchors;
using Kitchen.Repositories.Contracts.WriteRepositoriesContracts;

namespace Kitchen.Repositories.WriteRepositoriеs
{
    /// <summary>
    /// Реализация <see cref="IStimulationWriteRepository"/>
    /// </summary>
    public class StimulationWriteRepository : BaseWriteRepository<Stimulation>, IStimulationWriteRepository, IRepositoryAnchor
    {
        public StimulationWriteRepository(IDbWriterContext writerContext) 
            : base(writerContext)
        {
            
        }
    }
}
