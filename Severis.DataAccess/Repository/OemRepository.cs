using Severis.DataAccess.Models.Context;
using Db = Severis.DataAccess.Models.DB;

namespace Severis.DataAccess.Repository
{
    public interface IOemRepository : IRepository<Db.Oem>
    {
    }
    public class OemRepository : GenericRepository<Db.Oem>, IOemRepository
    {
        public OemRepository(BS_OE_BudgetContext context) : base(context)
        {

        }
        public override Db.Oem GetById(Guid id)
        {
            return base._context.Oems.SingleOrDefault(s => s.OemId == id);
        }
    }
}
