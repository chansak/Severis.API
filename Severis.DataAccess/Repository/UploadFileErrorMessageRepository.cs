using Severis.DataAccess.Models.Context;
using Db = Severis.DataAccess.Models.DB;

namespace Severis.DataAccess.Repository
{
    public interface IUploadFileErrorMessageRepository
    {
        Db.UploadFileErrorMessage GetErrorMessagesByUploadFileJobId(Guid id);
    }
    public class UploadFileErrorMessageRepository : GenericRepository<Db.UploadFileErrorMessage>, IUploadFileErrorMessageRepository
    {
        public UploadFileErrorMessageRepository(BS_OE_BudgetContext context) : base(context)
        {

        }

        public Db.UploadFileErrorMessage GetErrorMessagesByUploadFileJobId(Guid id)
        {
            return this._context.UploadFileErrorMessages.FirstOrDefault(i => i.UploadFileJobId == id);
        }
    }
}
