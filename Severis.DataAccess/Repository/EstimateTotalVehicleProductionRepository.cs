using Severis.DataAccess.Models.Context;
using Severis.DataAccess.Models.DB;
using Db = Severis.DataAccess.Models.DB;

namespace Severis.DataAccess.Repository
{
    public interface IEstimateTotalVehicleProductionRepository : IRepository<Db.EstimateTotalVehicleProduction>
    {
        List<EstimateTotalVehicleProduction> SearchByUploadFileId(Guid UploadFileId);
    }
    public class EstimateTotalVehicleProductionRepository : GenericRepository<Db.EstimateTotalVehicleProduction>, IEstimateTotalVehicleProductionRepository
    {
        public EstimateTotalVehicleProductionRepository(BS_OE_BudgetContext context) : base(context)
        {
            
        }

        public List<EstimateTotalVehicleProduction> SearchByUploadFileId(Guid UploadFileId)
        {
            return this._context.EstimateTotalVehicleProductions.Where(i => i.UploadFileId == UploadFileId).ToList();
        }
    }
}
