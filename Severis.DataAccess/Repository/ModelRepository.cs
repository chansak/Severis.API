using Severis.DataAccess.Models.Context;
using Db = Severis.DataAccess.Models.DB;

namespace Severis.DataAccess.Repository
{
    public interface IModelRepository : IRepository<Db.Model>
    {
    }
    public class ModelRepository : GenericRepository<Db.Model>, IModelRepository
    {
        public ModelRepository(BS_OE_BudgetContext context) : base(context)
        {

        }
    }
}
